using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UMA;

namespace UMAElements
{
	public class HumanoidBuilder
	{
		// our objects
	    private static RaceLibrary _raceLibrary;
		private static UMAGenerator _generator;
		// atlas scale
		private static float _atlasScale = 0.5f;
		// has the builder been initialized or not
		private static bool	_initialized = false;

		private static HumanoidStructure _human;

		/// <summary>
		/// Initialize the HumanoidBuilder. This must be called first before trying to use the builder to create UMAs.
		/// </summary>
		/// <param name='scale'>
		/// The atlas reduction scale. 1 = no reduction. 0.5 = reduce by half.
		/// </param>
		public static void Initialize(float scale = 1)
		{
			// find our objects
			GameObject tmp = GameObject.Find("RaceLibrary");

			if(tmp == null) 
				Debug.LogError("UMAElements.HumanoidBuilder.Initialize: Could not find UMA RaceLibrary"); 
			else 
				_raceLibrary = tmp.GetComponentInChildren<RaceLibrary>();

			tmp = GameObject.Find("UMAGenerator");
			if(tmp == null) 
				Debug.LogError("UMAElements.HumanoidBuilder.Initialize: Could not find UMAGenerator"); 
			else 
				_generator = tmp.GetComponentInChildren<UMAGenerator>();

			// set the atlas resolution scale
			_atlasScale = scale;
			// we've been initialized
			_initialized = true;
		}

		/// <summary>
		/// Create a new UMA from a given HumanoidStructure.
		/// </summary>
		/// <returns>
		/// Returns a reference to the created GameObject containing the generated UMA.
		/// </returns>
		/// <param name='name'>
		/// The name given to the GameObject in the heirarchy.
		/// </param>
		/// <param name='position'>
		/// The Vector3 position to give the new UMA.
		/// </param>
		/// <param name='layer'>
		/// The layer to put the UMA in, or 0 for the default layer
		/// </param>
		/// <param name='human'>
		/// The UMAElements.HumanoidStructure to build from.
		/// </param>
		/// <param name='useRigidBody'>
		/// Whether to keep a RigidBody on the new UMA.
		/// </param>
		/// <param name='useCharController'>
		/// Whether to add a CharacterController to the new UMA.
		/// </param>
		/// <param name='animationController'>
		/// If null, will keep the original Locomotion script, or use the given RuntimeAnimationController.
		/// </param>
		public static GameObject Create(HumanoidStructure human, string name, RuntimeAnimatorController animationController, 
		                                Vector3 position = default(Vector3), int layer = 0, bool useRigidBody = true, bool useCharController = true)
		{
			// are we initialized?
			if(!_initialized) 
			{ 
				Debug.LogError("UMAElements.HumanoidBuilder.Create: Attempted use before initialization. Must call HumanoidBuilder.Initialize(scale) first."); 
				return null; 
			}

			_human = human;
			
			// create a new UMARecipe
			GameObject thisUMA = new GameObject(name);
			UMADynamicAvatar dynamicAvatar = thisUMA.AddComponent<UMADynamicAvatar>();
			dynamicAvatar.Initialize();
			UMAData thisUMAData = dynamicAvatar.umaData;
			dynamicAvatar.umaGenerator = _generator;
			thisUMAData.umaGenerator = _generator;

			var umaRecipe = dynamicAvatar.umaData.umaRecipe;
			thisUMAData.OnCharacterCreated += UMAFinished;

			// race and gender
			bool found = false;
			if(human.gender == 'M') 
			{ 
				umaRecipe.SetRace(_raceLibrary.GetRace("HumanMale")); 
				found = true; 
			}
			else if(human.gender == 'F') 
			{ 
				umaRecipe.SetRace(_raceLibrary.GetRace("HumanFemale")); 
				found = true; 
			}
			if(!found) 
			{ 
				Debug.LogError("UMAElements.HumanoidBuilder.Create: Incorrect gender given as '" + human.gender + "'. UMA could not be built."); 
				return null; 
			}

			// do the build (this is the same as update)
			thisUMAData.atlasResolutionScale = _atlasScale;
			BuildUMAShape(thisUMAData, human, true);
			BuildUMASlots(thisUMAData, human, true);

			// remove the rigidbody (if required)
			if(useRigidBody)
			{
				thisUMA.AddComponent<Rigidbody>();
			}
			
			// add a character controller (if required)
			if(useCharController)
			{
				CapsuleCollider chc = thisUMA.AddComponent<CapsuleCollider>();
				chc.radius = 0.0015f * human.height;
				chc.height = (human.height / 100.0f);
				chc.center = new Vector3(0, chc.height / 2.0f, 0);
			}

			// add the correct animator (if required)
			if(animationController != null)
			{
				dynamicAvatar.animationController = animationController;
			}

			// put the uma in the correct position
			thisUMA.transform.position = position;
			
			// ensure that all elements of the uma are set to the "Entities" layer
			thisUMA.layer = layer;
			foreach(Transform t in thisUMA.GetComponentsInChildren<Transform>()) 
				t.gameObject.layer = layer; 

			dynamicAvatar.UpdateNewRace();

			// finally return this UMA's game object
			return thisUMA;
		}

		private static void UMAFinished(UMAData thisUMAData)
		{
			AttachmentPoints points = thisUMAData.gameObject.AddComponent<AttachmentPoints>();
			BuildUMAAttachments(thisUMAData, _human, points);

			//To make sure its not used outside of this use
			_human = null;
		}

		/// <summary>
		/// Update the specified UMA.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if the UMA was successfully updated, false if it was unchanged.
		/// </returns>
		/// <param name='name'>
		/// The name of the GameObject containing the UMA.
		/// </param>
		/// <param name='human'>
		/// The UMAElements.HumanoidStructure to update the UMA.
		/// </param>
		/// <param name='meshDirty'>
		/// If set to <c>true</c> the mesh will be updated. This includes body parts, clothing, accessories, and attachments.
		/// </param>
		/// <param name='shapeDirty'>
		/// If set to <c>true</c> the shape of the UMA will be updated. This is usually only needed at character creation time, or at gametime to make an UMA fatter or thinner.
		/// </param>
		public static bool Update(string GOName, HumanoidStructure human, bool meshDirty, bool shapeDirty)
		{
			// are we initialized?
			if(!_initialized) 
			{ 
				Debug.Log("UMAElements.HumanoidBuilder.Update: Attempted use before initialization. Must call HumanoidBuilder.Initialize(scale) first."); 
				return false; 
			}

			// find the required UMA object
			GameObject thisUMA = GameObject.Find(GOName);
			if(thisUMA == null) return false;
			
			// get the umaData
			UMAData thisUMAData = thisUMA.GetComponentInChildren<UMAData>();
			if(thisUMAData == null) return false;
	
			// set all the DataSet settings
			if(shapeDirty) BuildUMAShape(thisUMAData, human, false);
			if(meshDirty) BuildUMASlots(thisUMAData, human, false);

			// make it dirty so that it updates
			if(shapeDirty) thisUMAData.isShapeDirty = true;
			if(meshDirty) thisUMAData.isMeshDirty = true;
			if(meshDirty) thisUMAData.isTextureDirty = true;
			if(shapeDirty || meshDirty) thisUMAData.Dirty();
				
			// rebuild the attachments if requied
			BuildUMAAttachments(thisUMAData, human, null);
			
			// all done
			return true;
		}

		// private method to build the UMA shape	
		private static void BuildUMAShape(UMAData thisUMAData, HumanoidStructure human, bool isNewUMA)
		{
			UMADnaHumanoid thisUMAdna;
	
			// if it already exists - clear out the old data
			if(!isNewUMA) thisUMAData.umaRecipe.ClearDna();
			
			// create a new set of data
			thisUMAdna = new UMADnaHumanoid();
			thisUMAData.umaRecipe.AddDna(thisUMAdna);
//			thisUMAData.umaRecipe.umaDna.Add(thisUMAdna.GetType(), thisUMAdna);
	
			// set the height to 0.5f (using scale is better than changing this, but that's for you the game dev to decide)
			thisUMAdna.height = 0.5f;
	
			// muscle v weight
			thisUMAdna.upperMuscle = human.upperMuscle;
			thisUMAdna.upperWeight = human.upperWeight + human.upperMuscle;
			if(thisUMAdna.upperWeight > 1.0){ thisUMAdna.upperWeight = 1.0f;}
			if(thisUMAdna.upperWeight < 0.0){ thisUMAdna.upperWeight = 0.0f;}
			
			thisUMAdna.lowerMuscle = human.lowerMuscle + thisUMAdna.upperMuscle;
			if(thisUMAdna.lowerMuscle > 1.0){ thisUMAdna.lowerMuscle = 1.0f;}
			if(thisUMAdna.lowerMuscle < 0.0){ thisUMAdna.lowerMuscle = 0.0f;}
			
			thisUMAdna.lowerWeight = human.lowerWeight + thisUMAdna.upperWeight;
			if(thisUMAdna.lowerWeight > 1.0){ thisUMAdna.lowerWeight = 1.0f;}
			if(thisUMAdna.lowerWeight < 0.0){ thisUMAdna.lowerWeight = 0.0f;}
	
			// set the body shape
			thisUMAdna.armLength = human.armLength;
			thisUMAdna.forearmLength = human.forearmLength;
			thisUMAdna.legSeparation = human.legSeparation;
			thisUMAdna.handsSize = human.handSize;
			thisUMAdna.feetSize = human.feetSize;
			thisUMAdna.legsSize = human.legsSize;
			thisUMAdna.armWidth = human.armWidth;
			thisUMAdna.forearmWidth = human.forearmWidth;
			thisUMAdna.breastSize = human.breastSize;
			thisUMAdna.belly = human.belly;
			thisUMAdna.waist = human.waist;
			thisUMAdna.gluteusSize = human.gluteusSize;
	
			// set the head shape
			thisUMAdna.headSize = human.headSize;
			thisUMAdna.headWidth = human.headWidth;
			thisUMAdna.neckThickness = human.neckThickness;
				
			// set the facial morphs - ears
			thisUMAdna.earsSize = human.earsSize;
			thisUMAdna.earsPosition = human.earsPosition;
			thisUMAdna.earsRotation = human.earsRotation;
			
			// set the facial morphs - nose
			thisUMAdna.noseSize = human.noseSize;
			thisUMAdna.noseCurve = human.noseCurve;
			thisUMAdna.noseWidth = human.noseWidth;
			thisUMAdna.noseInclination = human.noseInclination;
			thisUMAdna.nosePosition = human.nosePosition;
			thisUMAdna.nosePronounced = human.nosePronounced;
			thisUMAdna.noseFlatten = human.noseFlatten;
				
			// set the facial morphs - chin
			thisUMAdna.chinSize = human.chinSize;
			thisUMAdna.chinPronounced = human.chinPronounced;
			thisUMAdna.chinPosition = human.chinPosition;
				
			// set the facial morphs - jaw
			thisUMAdna.mandibleSize = human.mandibleSize;
			thisUMAdna.jawsSize = human.jawsSize;
			thisUMAdna.jawsPosition = human.jawsPosition;
			
			// set the facial morphs - cheeks
			thisUMAdna.cheekSize = human.cheekSize;
			thisUMAdna.cheekPosition = human.cheekPosition;
			thisUMAdna.lowCheekPronounced = human.lowCheekPronounced;
			thisUMAdna.lowCheekPosition = human.lowCheekPosition;
				
			// set the facial morphs - forehead
			thisUMAdna.foreheadSize = human.foreheadSize;
			thisUMAdna.foreheadPosition = human.foreheadPosition;
				
			// set the facial morphs - mouth
			thisUMAdna.lipsSize = human.lipsSize;
			thisUMAdna.mouthSize = human.mouthSize;
	
			// eye size and rotation
			thisUMAdna.eyeSize = human.eyeSize;
			thisUMAdna.eyeRotation = human.eyeRotation;
		}

		// private method to build the UMA slots
		private static void BuildUMASlots(UMA.UMAData thisUMAData, HumanoidStructure human, bool isNewUMA)
		{
			// the slot list one for each element in UMAElementsPositions.BuildSlots
			thisUMAData.umaRecipe.slotDataList = new SlotData[40];
			
			// now we add the items from the BODY elements list one at a time
			for(int i = 0; i < human.Body.Count; i++)
			{
				if(human.Body[i] == null)
					continue;

				// instantiate the body slot in this element at the correct position
				if(human.Body[i].element.slotItem)
					thisUMAData.umaRecipe.slotDataList[ (int)human.Body[i].element.buildPos ] = InstantiateSlot(human.Body[i].element.slotItem);
				
				// add the body overlay to this position
				if(human.Body[i].element.overlayItem)
				{
					if(human.Body[i].colors.Count == 0)
						thisUMAData.umaRecipe.slotDataList[ (int)human.Body[i].element.buildPos ].AddOverlay( InstantiateOverlay(human.Body[i].element.overlayItem, Color.white) );
					if(human.Body[i].colors.Count == 1)
						thisUMAData.umaRecipe.slotDataList[ (int)human.Body[i].element.buildPos ].AddOverlay( InstantiateOverlay(human.Body[i].element.overlayItem, GamePalette.BodySwatch[human.Body[i].colors[0]].color) );
					if(human.Body[i].colors.Count == 3)
					{
						thisUMAData.umaRecipe.slotDataList[ (int)human.Body[i].element.buildPos ].AddOverlay( InstantiateOverlay(human.Body[i].element.overlayItem, Color.white) );
						thisUMAData.umaRecipe.slotDataList[ (int)human.Body[i].element.buildPos ].GetOverlay(human.Body[i].element.overlayItem.asset.overlayName).asset.textureList[0] = human.Body[i].dyedDiffuse;
					}
				}
				
				// hide any slots that need it
				foreach(Positions.BuildSlots pos in human.Body[i].element.hides)
				{
					thisUMAData.umaRecipe.slotDataList[ (int)pos ] = null;
				}
			}
			
				// instantiate the wardrobe slot in this element at the correct position
			for(int i = 0; i < human.Wardrobe.Count; i++)
			{
				// instantiate all the slots in this element
				if(human.Wardrobe[i].element.slotItem)
					thisUMAData.umaRecipe.slotDataList[ (int)human.Wardrobe[i].element.buildPos ] = InstantiateSlot(human.Wardrobe[i].element.slotItem);
				
				// add the body overlay to this position
				if(human.Wardrobe[i].element.overlayItem)
				{
					if(human.Wardrobe[i].colors.Count == 0)
						thisUMAData.umaRecipe.slotDataList[ (int)human.Wardrobe[i].element.buildPos ].AddOverlay( InstantiateOverlay(human.Wardrobe[i].element.overlayItem, Color.white) );
					if(human.Wardrobe[i].colors.Count == 1)
						thisUMAData.umaRecipe.slotDataList[ (int)human.Wardrobe[i].element.buildPos ].AddOverlay( InstantiateOverlay(human.Wardrobe[i].element.overlayItem, GamePalette.DyeSwatch[human.Wardrobe[i].colors[0]].color) );
					if(human.Wardrobe[i].colors.Count == 3)
					{
						thisUMAData.umaRecipe.slotDataList[ (int)human.Wardrobe[i].element.buildPos ].AddOverlay( InstantiateOverlay(human.Wardrobe[i].element.overlayItem, Color.white) );
						thisUMAData.umaRecipe.slotDataList[ (int)human.Wardrobe[i].element.buildPos ].GetOverlay(human.Wardrobe[i].element.overlayItem.asset.overlayName).asset.textureList[0] = human.Wardrobe[i].dyedDiffuse;
					}
				}
				
				// hide any slots that need it
				foreach(Positions.BuildSlots pos in human.Wardrobe[i].element.hides)
				{
					thisUMAData.umaRecipe.slotDataList[ (int)pos ] = null;
				}
			}
		}

		//private static void AddAttachment
		public static void BuildUMAAttachments(UMAData thisUMAData, HumanoidStructure human, AttachmentPoints aPoints)
		{
			if(aPoints == null)
			{
				// get the attachment points component
				aPoints = thisUMAData.gameObject.GetComponent<AttachmentPoints>();
				if(aPoints == null) 
				{
					Debug.LogError("UMAElements.HumanoidBuilder.BuildUMAAttachments: Could not find AttachmentPoints script on UMA"); 
					return; 
				}
			}

			// remove all current attachments
			for(int i = 1; i < aPoints.Points.Length; i++)
			{
				int childcount = aPoints.Points[i].childCount;
				for(int c = childcount - 1; c >= 0; c--) 
				{
					GameObject.Destroy(aPoints.Points[i].GetChild(c).gameObject);
				}
			}
			
			// iterate through the list of attachments and see what we need to add
			for(int i = 0; i < human.Attachments.Count; i++)
			{
				// what position is this attachment in?
				int position = (int)human.Attachments[i].element.attachmentDefaultPos;
				if(human.Attachments[i].attachmentIsActive) 
					position = (int)human.Attachments[i].element.attachmentActivePos;
				
				// instantiate the prefab
				GameObject attachment = GameObject.Instantiate(human.Attachments[i].element.prefabItem) as GameObject;
				attachment.name = human.Attachments[i].element.prefabItem.name;
				attachment.transform.parent = aPoints.Points[position];
				attachment.transform.localPosition = Vector3.zero;
				attachment.transform.localRotation = Quaternion.Euler(Vector3.zero);
			}
		}

		// this instantiator saves us from having to use the slot library 
		// it just returns a duplicate of the SlotData
		private static SlotData InstantiateSlot(SlotData sd)
		{
			return sd.Copy();
		}

		// this instantiator saves us from having to use the overlay library 
		// it just returns a duplicate of the OverlayData
		private static OverlayData InstantiateOverlay(OverlayData od, Color col)
		{
			OverlayData newod = od.Duplicate();
			newod.color = col;
			return newod;
		}
	}
}