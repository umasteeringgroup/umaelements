using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UMAElements
{
	public class HumanoidStructure
	{
		// UMA race and gender
		// expecting "H" for Human, but you may have other humanoid races (see UMAElementsHumanoidBuilder.Create)
		// expecting "M" or "F" for gender, but you may have other genders (see UMAElementsHumanoidBuilder.Create)
		/*  0 */	public char race;
		/*  1 */	public char gender;
		
		// UMA height
		// the height is in centimeters cm. UMAs are scaled to the correct height to ensure that attached objects scale to match.
		/*  2 */	public int height;
			
		// UMA muscle & weight
		// Scalar values from sliders - or don't use as they default to 0.5f anyway (see UMAElementsHumanoidBuilder.CreateShape)
		/*  3 */	public float upperMuscle;
		/*  4 */	public float upperWeight;
		/*  5 */	public float lowerMuscle;
		/*  6 */	public float lowerWeight;
			
		// UMA body morphs
		// Scalar values from sliders - or don't user as they defaul to 0.5f anyway (see UMAElementsHumanoidBuilder.CreateShape)
		/*  7 */	public float armLength;
		/*  8 */	public float forearmLength;
		/*  9 */	public float legSeparation;
		/* 10 */	public float handSize;
		/* 11 */	public float feetSize;
		/* 12 */	public float legsSize;
		/* 13 */	public float armWidth;
		/* 14 */	public float forearmWidth;
		/* 15 */	public float breastSize;
		/* 16 */	public float waist;
		/* 17 */	public float belly;
		/* 18 */	public float gluteusSize;
			
		// UMA neck and head morphs
		// Scalar values from sliders - or don't user as they defaul to 0.5f anyway (see UMAElementsHumanoidBuilder.CreateShape)
		/* 19 */	public float headSize;
		/* 20 */	public float headWidth;
		/* 21 */	public float neckThickness;
		
		// UMA facial morphs - ears
		// Scalar values from sliders - or don't user as they defaul to 0.5f anyway (see UMAElementsHumanoidBuilder.CreateShape)
		/* 22 */	public float earsSize;
		/* 23 */	public float earsPosition;
		/* 24 */	public float earsRotation;
		
		// UMA facial morphs - nose
		// Scalar values from sliders - or don't user as they defaul to 0.5f anyway (see UMAElementsHumanoidBuilder.CreateShape)
		/* 25 */	public float noseSize;
		/* 26 */	public float noseCurve;
		/* 27 */	public float noseWidth;
		/* 28 */	public float noseInclination;
		/* 29 */	public float nosePosition;
		/* 30 */	public float nosePronounced;
		/* 31 */	public float noseFlatten;
		
		// UMA facial morphs - chin
		// Scalar values from sliders - or don't user as they defaul to 0.5f anyway (see UMAElementsHumanoidBuilder.CreateShape)
		/* 32 */	public float chinSize;
		/* 33 */	public float chinPronounced;
		/* 34 */	public float chinPosition;
		
		// UMA facial morphs - jaw
		// Scalar values from sliders - or don't user as they defaul to 0.5f anyway (see UMAElementsHumanoidBuilder.CreateShape)
		/* 35 */	public float mandibleSize;
		/* 36 */	public float jawsSize;
		/* 37 */	public float jawsPosition;
		
		// UMA facial morphs - cheeks
		// Scalar values from sliders - or don't user as they defaul to 0.5f anyway (see UMAElementsHumanoidBuilder.CreateShape)
		/* 38 */	public float cheekSize;
		/* 39 */	public float cheekPosition;
		/* 40 */	public float lowCheekPronounced;
		/* 41 */	public float lowCheekPosition;
		
		// UMA facial morphs - forehead
		// Scalar values from sliders - or don't user as they defaul to 0.5f anyway (see UMAElementsHumanoidBuilder.CreateShape)
		/* 42 */	public float foreheadSize;
		/* 43 */	public float foreheadPosition;
		
		// UMA facial morphs - mouth
		// Scalar values from sliders - or don't user as they defaul to 0.5f anyway (see UMAElementsHumanoidBuilder.CreateShape)
		/* 44 */	public float lipsSize;
		/* 45 */	public float mouthSize;
		
		// UMA facial morphs - eyes
		// Scalar values from sliders - or don't user as they defaul to 0.5f anyway (see UMAElementsHumanoidBuilder.CreateShape)
		/* 46 */	public float eyeSize;
		/* 47 */	public float eyeRotation;
		
		// UMA Slots & Overlays
		// these are used by UMABuilder.CreateSlots - and must be slot and overlays from your libraries
		// you can extend this structure with any extra elements for UMABuilder.CreateSlots)
	
		// body slots - these go to make up the actual body of the avatar
		/* 48 */	public List<ElementBlock> Body;
			
		// the in-game worn wardrobe and positions
		/* 49 */	public List<ElementBlock> Wardrobe;
		
		// the in-game worn attachments and positions
		/* 50 */	public List<ElementBlock> Attachments;

// -------------------------------------------------------------------------------------------------------------		
// constructors
		
		/// <summary>
		/// Initializes a new instance of the <see cref="UMAElements.HumanoidStructure"/> class.
		/// </summary>
		public HumanoidStructure()
		{
			this.Body = new List<ElementBlock>();
			this.Wardrobe = new List <ElementBlock>();
			this.Attachments = new List<ElementBlock>();
		}
					
		/// <summary>
		/// Initializes a new instance of the <see cref="UMAElements.HumanoidStructure"/> class.
		/// </summary>
		/// <param name='gender'>
		/// gender of the humanoid M or F
		/// </param>
		public HumanoidStructure(char gender)
		{
			/*  0 */	this.race = 'H';
			/*  1 */	this.gender = gender;
			/*  2 */	this.height = 200;
			/*  3 */	this.upperMuscle = 0.5f;
			/*  4 */	this.upperWeight = 0.5f;
			/*  5 */	this.lowerMuscle = 0.5f;
			/*  6 */	this.lowerWeight = 0.5f;
			/*  7 */	this.armLength = 0.5f;
			/*  8 */	this.forearmLength = 0.5f;
			/*  9 */	this.legSeparation = 0.5f;
			/* 10 */	this.handSize = 0.5f;
			/* 11 */	this.feetSize = 0.5f;
			/* 12 */	this.legsSize = 0.5f;
			/* 13 */	this.armWidth = 0.5f;
			/* 14 */	this.forearmWidth = 0.5f;
			/* 15 */	this.breastSize = 0.5f;
			/* 16 */	this.waist = 0.5f;
			/* 17 */	this.belly = 0.5f;
			/* 18 */	this.gluteusSize = 0.5f;
			/* 19 */	this.headSize = 0.5f;
			/* 20 */	this.headWidth = 0.5f;
			/* 21 */	this.neckThickness = 0.5f;
			/* 22 */	this.earsSize = 0.5f;
			/* 23 */	this.earsPosition = 0.5f;
			/* 24 */	this.earsRotation = 0.5f;
			/* 25 */	this.noseSize = 0.5f;
			/* 26 */	this.noseCurve = 0.5f;
			/* 27 */	this.noseWidth = 0.5f;
			/* 28 */	this.noseInclination = 0.5f;
			/* 29 */	this.nosePosition = 0.5f;
			/* 30 */	this.nosePronounced = 0.5f;
			/* 31 */	this.noseFlatten = 0.5f;
			/* 32 */	this.chinSize = 0.5f;
			/* 33 */	this.chinPronounced = 0.5f;
			/* 34 */	this.chinPosition = 0.5f;
			/* 35 */	this.mandibleSize = 0.5f;
			/* 36 */	this.jawsSize = 0.5f;
			/* 37 */	this.jawsPosition = 0.5f;
			/* 38 */	this.cheekSize = 0.5f;
			/* 39 */	this.cheekPosition = 0.5f;
			/* 40 */	this.lowCheekPronounced = 0.5f;
			/* 41 */	this.lowCheekPosition = 0.5f;
			/* 42 */	this.foreheadSize = 0.5f;
			/* 43 */	this.foreheadPosition = 0.5f;
			/* 44 */	this.lipsSize = 0.5f;
			/* 45 */	this.mouthSize = 0.5f;
			/* 46 */	this.eyeSize = 0.5f;
			/* 47 */	this.eyeRotation = 0.5f;
			
			this.Body = new List<ElementBlock>();
			this.Wardrobe = new List <ElementBlock>();
			this.Attachments = new List<ElementBlock>();
		}

// -------------------------------------------------------------------------------------------------------------		
// Body block methods
		
		
		/// <summary>
		/// Adds a body element to the humanoid-structure build, given it's element-name
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the element to add.
		/// </param>
		public static bool BodyAdd(HumanoidStructure human, string name)
		{
			// does this named element exist in our dictionaries
			foreach(ElementData ed in ElementsLibrary.Elements.Values)
			{
				if(ed.Name == name)
				{
					// build a new element block and add it to the body
					ElementBlock eb = new ElementBlock(ed);
					human.Body.Add(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Adds a body element to the humanoid-structure build, given it's element-name, and a single multiplier color.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the element to add.
		/// </param>
		/// <param name='color'>
		/// the color to use.
		/// </param>
		public static bool BodyAdd(HumanoidStructure human, string name, Color32 color)
		{
			// does this named element exist in our dictionaries
			foreach(ElementData ed in ElementsLibrary.Elements.Values)
			{
				if(ed.Name == name)
				{
					// build a new element block and add it to the body
					ElementBlock eb = new ElementBlock(ed, color);
					human.Body.Add(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Adds a body element to the humanoid-structure build, given it's element-name, and a single multiplier color.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the element to add.
		/// </param>
		/// <param name='color'>
		/// the index of the muliplier color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class.
		/// </param>
		public static bool BodyAdd(HumanoidStructure human, string name, int color)
		{
			// does this named element exist in our dictionaries
			foreach(ElementData ed in ElementsLibrary.Elements.Values)
			{
				if(ed.Name == name)
				{
					// build a new element block and add it to the body
					ElementBlock eb = new ElementBlock(ed, color);
					human.Body.Add(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Adds a body element to the humanoid-structure build, given it's element-name, and three element-splatmap colors.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the element to add.
		/// </param>
		/// <param name='color1'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Red splatmap component.
		/// </param>
		/// <param name='color2'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Green splatmap component
		/// </param>
		/// <param name='color3'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Blue splatmap component
		/// </param>
		public static bool BodyAdd(HumanoidStructure human, string name, int color1, int color2, int color3)
		{
			// does this named element exist in our dictionaries
			foreach(ElementData ed in ElementsLibrary.Elements.Values)
			{
				if(ed.Name == name)
				{
					// build a new element block and add it to the body
					ElementBlock eb = new ElementBlock(ed, color1, color2, color3);
					human.Body.Add(eb);
					return true;
				}
			}
			return false;
		}
				
		/// <summary>
		/// Adds a body element to the humanoid-structure build, given it's element-index.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to add.
		/// </param>
		public static bool BodyAdd(HumanoidStructure human, int index)
		{
			// does this index exist?
			if(!ElementsLibrary.Elements.ContainsKey(index)) return false;
			
			// build a new element block and add it to the body
			ElementBlock eb = new ElementBlock(ElementsLibrary.Elements[index]);
			human.Body.Add(eb);
			return true;
		}

		/// <summary>
		/// Adds a body element to the humanoid-structure build, given it's element-index, and a single multiplier color.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to add.
		/// </param>
		/// <param name='color'>
		/// the color to add.
		/// </param>
		public static bool BodyAdd(HumanoidStructure human, int index, Color32 color)
		{
			// does this index exist?
			if(!ElementsLibrary.Elements.ContainsKey(index)) return false;
			
			// build a new element block and add it to the body
			ElementBlock eb = new ElementBlock(ElementsLibrary.Elements[index], color);
			human.Body.Add(eb);
			return true;
		}

		/// <summary>
		/// Adds a body element to the humanoid-structure build, given it's element-index, and a single multiplier color.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to add.
		/// </param>
		/// <param name='color'>
		/// the index of the muliplier color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class.
		/// </param>
		public static bool BodyAdd(HumanoidStructure human, int index, int color)
		{
			// does this index exist?
			if(!ElementsLibrary.Elements.ContainsKey(index)) return false;
			
			// build a new element block and add it to the body
			ElementBlock eb = new ElementBlock(ElementsLibrary.Elements[index], color);
			human.Body.Add(eb);
			return true;
		}
		
		/// <summary>
		/// Adds a body element to the humanoid-structure build, given it's element-index, and three element-splatmap colors.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to add.
		/// </param>
		/// <param name='color1'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Red splatmap component.
		/// </param>
		/// <param name='color2'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Green splatmap component
		/// </param>
		/// <param name='color3'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Blue splatmap component
		/// </param>
		public static bool BodyAdd(HumanoidStructure human, int index, int color1, int color2, int color3)
		{
			// does this index exist?
			if(!ElementsLibrary.Elements.ContainsKey(index)) return false;
			
			// build a new element block and add it to the body
			ElementBlock eb = new ElementBlock(ElementsLibrary.Elements[index], color1, color2, color3);
			human.Body.Add(eb);
			return true;
		}

		/// <summary>
		/// Removes a body element of the humanoid-structure build, from it's element-name
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was removed, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the element to remove.
		/// </param>
		public static bool BodyRemove(HumanoidStructure human, string name)
		{
			// does this named element exist
			foreach(ElementBlock eb in human.Body)
			{
				if(eb.element.Name == name)
				{
					human.Body.Remove(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Removes a body element of the humanoid-structure build, from it's element-index
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was removed, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to remove.
		/// </param>
		public static bool BodyRemove(HumanoidStructure human, int index)
		{
			// does this named element exist
			foreach(ElementBlock eb in human.Body)
			{
				if(eb.element.Index == index)
				{
					human.Body.Remove(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Remove all body elements from the build.
		/// </summary>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		public static void BodyRemoveAll(HumanoidStructure human)
		{
			human.Body.Clear();
		}
		
		/// <summary>
		/// Removes a body element of the humanoid-structure build, from the build-slot position. See <see cref="UMAElements.Positions"/> class.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was removed, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='position'>
		/// the build-slot position to clear.
		/// </param>
		public static bool BodyRemoveAtPosition(HumanoidStructure human, int position)
		{
			// find any elements at this position
			foreach(ElementBlock eb in human.Body)
			{
				if((int)eb.element.buildPos == position)
				{
					human.Body.Remove(eb);
					return true;
				}
			}
			return false;
		}
		
// -------------------------------------------------------------------------------------------------------------		
// Wardrobe block methods

		
		/// <summary>
		/// Adds a wardrobe element to the humanoid-structure build, given it's element-name
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the element to add.
		/// </param>
		public static bool WardrobeAdd(HumanoidStructure human, string name)
		{
			// does this named element exist in our dictionaries
			foreach(ElementData ed in ElementsLibrary.Elements.Values)
			{
				if(ed.Name == name)
				{
					// build a new element block and add it to the body
					ElementBlock eb = new ElementBlock(ed);
					human.Wardrobe.Add(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Adds a wardrobe element to the humanoid-structure build, given it's element-name, and a single multiplier color.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the element to add.
		/// </param>
		/// <param name='color'>
		/// the color to add.
		/// </param>
		public static bool WardrobeAdd(HumanoidStructure human, string name, Color32 color)
		{
			// does this named element exist in our dictionaries
			foreach(ElementData ed in ElementsLibrary.Elements.Values)
			{
				if(ed.Name == name)
				{
					// build a new element block and add it to the body
					ElementBlock eb = new ElementBlock(ed, color);
					human.Wardrobe.Add(eb);
					return true;
				}
			}
			return false;
		}


		/// <summary>
		/// Adds a wardrobe element to the humanoid-structure build, given it's element-name, and a single multiplier color.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the element to add.
		/// </param>
		/// <param name='color'>
		/// the index of the muliplier color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class.
		/// </param>
		public static bool WardrobeAdd(HumanoidStructure human, string name, int color)
		{
			// does this named element exist in our dictionaries
			foreach(ElementData ed in ElementsLibrary.Elements.Values)
			{
				if(ed.Name == name)
				{
					// build a new element block and add it to the body
					ElementBlock eb = new ElementBlock(ed, color);
					human.Wardrobe.Add(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Adds a wardrobe element to the humanoid-structure build, given it's element-name, and three element-splatmap colors.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the element to add.
		/// </param>
		/// <param name='color1'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Red splatmap component.
		/// </param>
		/// <param name='color2'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Green splatmap component
		/// </param>
		/// <param name='color3'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Blue splatmap component
		/// </param>
		public static bool WardrobeAdd(HumanoidStructure human, string name, int color1, int color2, int color3)
		{
			// does this named element exist in our dictionaries
			foreach(ElementData ed in ElementsLibrary.Elements.Values)
			{
				if(ed.Name == name)
				{
					// build a new element block and add it to the body
					ElementBlock eb = new ElementBlock(ed, color1, color2, color3);
					human.Wardrobe.Add(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Adds a wardrobe element to the humanoid-structure build, given it's element-index.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to add.
		/// </param>
		public static bool WardrobeAdd(HumanoidStructure human, int index)
		{
			// does this index exist?
			if(!ElementsLibrary.Elements.ContainsKey(index)) return false;
			
			// build a new element block and add it to the body
			ElementBlock eb = new ElementBlock(ElementsLibrary.Elements[index]);
			human.Wardrobe.Add(eb);
			return true;
		}

		/// <summary>
		/// Adds a wardrobe element to the humanoid-structure build, given it's element-index, and a single multiplier color.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to add.
		/// </param>
		/// <param name='color'>
		/// the color to add.
		/// </param>
		public static bool WardrobeAdd(HumanoidStructure human, int index, Color32 color)
		{
			// does this index exist?
			if(!ElementsLibrary.Elements.ContainsKey(index)) return false;
			
			// build a new element block and add it to the body
			ElementBlock eb = new ElementBlock(ElementsLibrary.Elements[index], color);
			human.Wardrobe.Add(eb);
			return true;
		}

		/// <summary>
		/// Adds a wardrobe element to the humanoid-structure build, given it's element-index, and a single multiplier color.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to add.
		/// </param>
		/// <param name='color'>
		/// the index of the muliplier color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class.
		/// </param>
		public static bool WardrobeAdd(HumanoidStructure human, int index, int color)
		{
			// does this index exist?
			if(!ElementsLibrary.Elements.ContainsKey(index)) return false;
			
			// build a new element block and add it to the body
			ElementBlock eb = new ElementBlock(ElementsLibrary.Elements[index], color);
			human.Wardrobe.Add(eb);
			return true;
		}

		/// <summary>
		/// Adds a wardrobe element to the humanoid-structure build, given it's element-index, and three element-splatmap colors.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to add.
		/// </param>
		/// <param name='color1'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Red splatmap component.
		/// </param>
		/// <param name='color2'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Green splatmap component
		/// </param>
		/// <param name='color3'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Blue splatmap component
		/// </param>
		public static bool WardrobeAdd(HumanoidStructure human, int index, int color1, int color2, int color3)
		{
			// does this index exist?
			if(!ElementsLibrary.Elements.ContainsKey(index)) return false;
			
			// build a new element block and add it to the body
			ElementBlock eb = new ElementBlock(ElementsLibrary.Elements[index], color1, color2, color3);
			human.Wardrobe.Add(eb);
			return true;
		}

		/// <summary>
		/// Removes a wardrobe element of the humanoid-structure build, from it's element-name
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was removed, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the element to remove.
		/// </param>
		public static bool WardrobeRemove(HumanoidStructure human, string name)
		{
			// does this named element exist
			foreach(ElementBlock eb in human.Wardrobe)
			{
				if(eb.element.Name == name)
				{
					human.Wardrobe.Remove(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Removes a wardrobe element of the humanoid-structure build, from it's element-index
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was removed, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to remove.
		/// </param>
		public static bool WardrobeRemove(HumanoidStructure human, int index)
		{
			// does this named element exist
			foreach(ElementBlock eb in human.Wardrobe)
			{
				if(eb.element.Index == index)
				{
					human.Wardrobe.Remove(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Remove all wardrobe elements from the build.
		/// </summary>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		public static void WardrobeRemoveAll(HumanoidStructure human)
		{
			human.Wardrobe.Clear();
		}
		
		/// <summary>
		/// Does the named wardrobe element exist in our list?
		/// </summary>
		/// <returns>
		/// true or false.
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the element to find.
		/// </param>
		public static bool WardrobeHasElement(HumanoidStructure human, string name)
		{
			// does this named element exist
			foreach(ElementBlock eb in human.Wardrobe)
			{
				if(eb.element.Name == name) return true;
			}
			return false;
		}

		/// <summary>
		/// Does the wardrobe element exist in our list?
		/// </summary>
		/// <returns>
		/// true or false.
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to find.
		/// </param>
		public static bool WardrobeHasElement(HumanoidStructure human, int index)
		{
			// does this named element exist
			foreach(ElementBlock eb in human.Wardrobe)
			{
				if(eb.element.Index == index) return true;
			}
			return false;
		}

// -------------------------------------------------------------------------------------------------------------		
// Attachments block methods

		/// <summary>
		/// Adds an attachment element to the humanoid-structure build, given it's element-name
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// <param name='name'>
		/// the element-name of the element to add.
		/// </param>
		public static bool AttachmentsAdd(HumanoidStructure human, string name)
		{
			// does this named element exist in our dictionaries
			foreach(ElementData ed in ElementsLibrary.Elements.Values)
			{
				if(ed.Name == name)
				{
					// build a new element block and add it to the body
					ElementBlock eb = new ElementBlock(ed);
					human.Attachments.Add(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Adds an attachment element to the humanoid-structure build, given it's element-name
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// <param name='name'>
		/// the element-name of the element to add.
		/// </param>
		/// <param name='color'>
		/// the index of the muliplier color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class.
		/// </param>
		public static bool AttachmentsAdd(HumanoidStructure human, string name, int color)
		{
			// does this named element exist in our dictionaries
			foreach(ElementData ed in ElementsLibrary.Elements.Values)
			{
				if(ed.Name == name)
				{
					// build a new element block and add it to the body
					ElementBlock eb = new ElementBlock(ed, color);
					human.Attachments.Add(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Adds an attachment element to the humanoid-structure build, given it's element-name
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// <param name='name'>
		/// the element-name of the element to add.
		/// </param>
		/// <param name='color1'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Red splatmap component.
		/// </param>
		/// <param name='color2'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Green splatmap component
		/// </param>
		/// <param name='color3'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Blue splatmap component
		/// </param>
		public static bool AttachmentsAdd(HumanoidStructure human, string name, int color1, int color2, int color3)
		{
			// does this named element exist in our dictionaries
			foreach(ElementData ed in ElementsLibrary.Elements.Values)
			{
				if(ed.Name == name)
				{
					// build a new element block and add it to the body
					ElementBlock eb = new ElementBlock(ed, color1, color2, color3);
					human.Attachments.Add(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Adds an attachment element to the humanoid-structure build, given it's element-index.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to add.
		/// </param>
		public static bool AttachmentsAdd(HumanoidStructure human, int index)
		{
			// does this index exist?
			if(!ElementsLibrary.Elements.ContainsKey(index)) return false;
			
			// build a new element block and add it to the body
			ElementBlock eb = new ElementBlock(ElementsLibrary.Elements[index]);
			human.Attachments.Add(eb);
			return true;
		}

		/// <summary>
		/// Adds an attachment element to the humanoid-structure build, given it's element-index.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to add.
		/// </param>
		/// <param name='color'>
		/// the index of the muliplier color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class.
		/// </param>
		public static bool AttachmentsAdd(HumanoidStructure human, int index, int color)
		{
			// does this index exist?
			if(!ElementsLibrary.Elements.ContainsKey(index)) return false;
			
			// build a new element block and add it to the body
			ElementBlock eb = new ElementBlock(ElementsLibrary.Elements[index], color);
			human.Attachments.Add(eb);
			return true;
		}
		
		/// <summary>
		/// Adds a wardrobe element to the humanoid-structure build, given it's element-index, and three element-splatmap colors.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was added, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to add.
		/// </param>
		/// <param name='color1'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Red splatmap component.
		/// </param>
		/// <param name='color2'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Green splatmap component
		/// </param>
		/// <param name='color3'>
		/// the index of the elemement-splatmap color to use, see DyeSwatch in the <see cref="UMAElements.GamePalette"/> class. This color replaces the Blue splatmap component
		/// </param>
		public static bool AttachmentsAdd(HumanoidStructure human, int index, int color1, int color2, int color3)
		{
			// does this index exist?
			if(!ElementsLibrary.Elements.ContainsKey(index)) return false;
			
			// build a new element block and add it to the body
			ElementBlock eb = new ElementBlock(ElementsLibrary.Elements[index], color1, color2, color3);
			human.Attachments.Add(eb);
			return true;
		}

		/// <summary>
		/// Removes an attachment element of the humanoid-structure build, from it's element-name
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was removed, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the attachment to remove.
		/// </param>
		public static bool AttachmentsRemove(HumanoidStructure human, string name)
		{
			// does this named element exist
			foreach(ElementBlock eb in human.Attachments)
			{
				if(eb.element.Name == name)
				{
					human.Attachments.Remove(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Removes an attachment element of the humanoid-structure build, from it's element-index
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was removed, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='index'>
		/// the element-index of the element to remove.
		/// </param>
		public static bool AttachmentsRemove(HumanoidStructure human, int index)
		{
			// does this named element exist
			foreach(ElementBlock eb in human.Attachments)
			{
				if(eb.element.Index == index)
				{
					human.Attachments.Remove(eb);
					return true;
				}
			}
			return false;
		}
		
		/// <summary>
		/// Remove all attachments elements from the build.
		/// </summary>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		public static void AttachmentsRemoveAll(HumanoidStructure human)
		{
			human.Attachments.Clear();
		}
		
		/// <summary>
		/// Removes an attachment element of the humanoid-structure build, from the attachment default position. See <see cref="UMAElements.Positions"/> class.
		/// </summary>
		/// <returns>
		/// Returns a bool, true if anything was removed, false if the body build list was unchanged
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='position'>
		/// the attachment default position to clear.
		/// </param>
		public static bool AttachmentsRemoveAtDefaultPosition(HumanoidStructure human, int position)
		{
			// find any elements at this position
			foreach(ElementBlock eb in human.Attachments)
			{
				if((int)eb.element.attachmentDefaultPos == position)
				{
					human.Attachments.Remove(eb);
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Set the named attachment to it's active position.
		/// </summary>
		/// <returns>
		/// Returns false if the element was not found.
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the element to set.
		/// </param>
		public static bool AttachmentSetActive(HumanoidStructure human, string name)
		{
			// iterate throught the list of attachments
			for(int i = 0; i < human.Attachments.Count; i++)
			{
				// is this our attachment?
				if(human.Attachments[i].element.Name == name)
				{
					human.Attachments[i].attachmentIsActive = true;
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Set the named attachment to it's default position.
		/// </summary>
		/// <returns>
		/// Returns false if the element was not found.
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the element to set.
		/// </param>
		public static bool AttachmentSetDefault(HumanoidStructure human, string name)
		{
			// iterate throught the list of attachments
			for(int i = 0; i < human.Attachments.Count; i++)
			{
				// is this our attachment?
				if(human.Attachments[i].element.Name == name)
				{
					human.Attachments[i].attachmentIsActive = false;
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Is the requested element-name attachment in the default position or the active position?
		/// </summary>
		/// <returns>
		/// true if in the active position, false if in the default position.
		/// </returns>
		/// <param name='human'>
		/// HumanoidStructure
		/// </param>
		/// <param name='name'>
		/// the element-name of the element to check.
		/// </param>
		public static bool AttachcmentIsActive(HumanoidStructure human, string name)
		{
			// iterate throught the list of attachments
			for(int i = 0; i < human.Attachments.Count; i++)
			{
				// is this our attachment?
				if(human.Attachments[i].element.Name == name)
				{
					return human.Attachments[i].attachmentIsActive;
				}
			}
			return false;
		}

// -------------------------------------------------------------------------------------------------------------		
// serialization	
	
		/// <summary>
		/// Unpack the specified HumanoidStructure packed string.
		/// </summary>
		/// <returns>
		/// Returns a HumanoidStructure.
		/// </returns>
		/// <param name='package'>
		/// The string to unpack. This must have been packed with the Pack() method.
		/// </param>
		public static HumanoidStructure Unpack(string package)
		{
			HumanoidStructure hs = new HumanoidStructure();
			
			string[] parts = package.Split('|');
			
			// the basic shape elements
			hs.race = String2Char(parts[0]);
			hs.gender = String2Char(parts[1]);
			hs.height = String2Int(parts[2]);
			hs.upperMuscle = String2Int2Scalar(parts[3]);
			hs.upperWeight = String2Int2Scalar(parts[4]);
			hs.lowerMuscle = String2Int2Scalar(parts[5]);
			hs.lowerWeight = String2Int2Scalar(parts[6]);
			hs.armLength = String2Int2Scalar(parts[7]);
			hs.forearmLength = String2Int2Scalar(parts[7]);
			hs.legSeparation = String2Int2Scalar(parts[8]);
			hs.handSize = String2Int2Scalar(parts[10]);
			hs.feetSize = String2Int2Scalar(parts[11]);
			hs.legsSize = String2Int2Scalar(parts[12]);
			hs.armWidth = String2Int2Scalar(parts[13]);
			hs.forearmWidth = String2Int2Scalar(parts[14]);
			hs.breastSize = String2Int2Scalar(parts[15]);
			hs.waist = String2Int2Scalar(parts[16]);
			hs.belly = String2Int2Scalar(parts[17]);
			hs.gluteusSize = String2Int2Scalar(parts[18]);
			hs.headSize = String2Int2Scalar(parts[19]);
			hs.headWidth = String2Int2Scalar(parts[20]);
			hs.neckThickness = String2Int2Scalar(parts[21]);
			hs.earsSize = String2Int2Scalar(parts[22]);
			hs.earsPosition = String2Int2Scalar(parts[23]);
			hs.earsRotation = String2Int2Scalar(parts[24]);
			hs.noseSize = String2Int2Scalar(parts[25]);
			hs.noseCurve = String2Int2Scalar(parts[26]);
			hs.noseWidth = String2Int2Scalar(parts[27]);
			hs.noseInclination = String2Int2Scalar(parts[28]);
			hs.nosePosition = String2Int2Scalar(parts[29]);
			hs.nosePronounced = String2Int2Scalar(parts[30]);
			hs.noseFlatten = String2Int2Scalar(parts[31]);
			hs.chinSize = String2Int2Scalar(parts[32]);
			hs.chinPronounced = String2Int2Scalar(parts[33]);
			hs.chinPosition = String2Int2Scalar(parts[34]);
			hs.mandibleSize = String2Int2Scalar(parts[35]);
			hs.jawsSize = String2Int2Scalar(parts[36]);
			hs.jawsPosition = String2Int2Scalar(parts[37]);
			hs.cheekSize = String2Int2Scalar(parts[38]);
			hs.cheekPosition = String2Int2Scalar(parts[39]);
			hs.lowCheekPronounced = String2Int2Scalar(parts[40]);
			hs.lowCheekPosition = String2Int2Scalar(parts[41]);
			hs.foreheadSize = String2Int2Scalar(parts[42]);
			hs.foreheadPosition = String2Int2Scalar(parts[43]);
			hs.lipsSize = String2Int2Scalar(parts[44]);
			hs.mouthSize = String2Int2Scalar(parts[45]);
			hs.eyeSize = String2Int2Scalar(parts[46]);
			hs.eyeRotation = String2Int2Scalar(parts[47]);
			
			// the body slots info
			string[] bodyparts = parts[48].Split('^');
			hs.Body = new List<ElementBlock>();
			for(int n = 0; n < bodyparts.Length; n++)
			{
				string[] bodypartsparams = bodyparts[n].Split(',');
				if(bodypartsparams.Length == 1)
					BodyAdd(hs, String2Int(bodypartsparams[0]));
				else if(bodypartsparams.Length == 2)
					BodyAdd(hs, String2Int(bodypartsparams[0]), String2Int(bodypartsparams[1]));
				else if(bodypartsparams.Length == 4)
					BodyAdd(hs, String2Int(bodypartsparams[0]), String2Int(bodypartsparams[1]), String2Int(bodypartsparams[2]), String2Int(bodypartsparams[3]));
				else if(bodypartsparams.Length == 5)
				{
					Color32 color = new Color32(byte.Parse(bodypartsparams[1]), byte.Parse(bodypartsparams[2]), byte.Parse(bodypartsparams[3]), byte.Parse(bodypartsparams[4]));
					BodyAdd(hs, String2Int(bodypartsparams[0]), color);
				}
			}
			
			// the wardrobe slots info
			string[] wardrobeparts = parts[49].Split('^');
			hs.Wardrobe = new List<ElementBlock>();
			for(int n = 0; n < wardrobeparts.Length; n++)
			{
				string[] wardrobepartsparams = wardrobeparts[n].Split(',');
				if(wardrobepartsparams.Length == 1)
					WardrobeAdd(hs, String2Int(wardrobepartsparams[0]));
				else if(wardrobepartsparams.Length == 2)
					WardrobeAdd(hs, String2Int(wardrobepartsparams[0]), String2Int(wardrobepartsparams[1]));
				else if(wardrobepartsparams.Length == 4)
					WardrobeAdd(hs, String2Int(wardrobepartsparams[0]), String2Int(wardrobepartsparams[1]), String2Int(wardrobepartsparams[2]), String2Int(wardrobepartsparams[3]));
				else if(wardrobepartsparams.Length == 5)
				{
					Color32 color = new Color32(byte.Parse(wardrobepartsparams[1]), byte.Parse(wardrobepartsparams[2]), byte.Parse(wardrobepartsparams[3]), byte.Parse(wardrobepartsparams[4]));
					WardrobeAdd(hs, String2Int(wardrobepartsparams[0]), color);
				}
			}
			
			// the attachments slots info
			string[] attachmentsparts = parts[50].Split('^');
			hs.Attachments = new List<ElementBlock>();
			for(int n = 0; n < attachmentsparts.Length; n++)
			{
				string[] attachmentspartsparams = attachmentsparts[n].Split(',');
				if(attachmentspartsparams.Length == 1)
					AttachmentsAdd(hs, String2Int(attachmentspartsparams[0]));
				//if(attachmentspartsparams.Length == 2) AttachmentsAdd(hs, String2Int(attachmentspartsparams[0]), String2Int(attachmentspartsparams[1]));
				//if(attachmentspartsparams.Length == 4) AttachmentsAdd(hs, String2Int(attachmentspartsparams[0]), String2Int(attachmentspartsparams[1]), String2Int(attachmentspartsparams[2]), String2Int(bodypartsparams[3]));
			}
			
			// return the result
			return hs;
		}

		/// <summary>
		/// Pack the specified HumanoidStructure into a string.
		/// </summary>
		/// <returns>
		/// Returns a packed string.
		/// </returns>
		/// <param name='humanoid'>
		/// The structure to pack.
		/// </param>
		public static string Pack(HumanoidStructure human)
		{
			string o = "";
			
			// the basic shape elements
			/*  0 */	o += human.race + "|";
			/*  1 */	o += human.gender + "|";
			/*  2 */	o += human.height + "|";
			/*  3 */	o += Scalar2Int2String(human.upperMuscle) + "|";
			/*  4 */	o += Scalar2Int2String(human.upperWeight) + "|";
			/*  5 */	o += Scalar2Int2String(human.lowerMuscle) + "|";
			/*  6 */	o += Scalar2Int2String(human.lowerWeight) + "|";
			/*  7 */	o += Scalar2Int2String(human.armLength) + "|";
			/*  8 */	o += Scalar2Int2String(human.forearmLength) + "|";
			/*  9 */	o += Scalar2Int2String(human.legSeparation) + "|";
			/* 10 */	o += Scalar2Int2String(human.handSize) + "|";
			/* 11 */	o += Scalar2Int2String(human.feetSize) + "|";
			/* 12 */	o += Scalar2Int2String(human.legsSize) + "|";
			/* 13 */	o += Scalar2Int2String(human.armWidth) + "|";
			/* 14 */	o += Scalar2Int2String(human.forearmWidth) + "|";
			/* 15 */	o += Scalar2Int2String(human.breastSize) + "|";
			/* 16 */	o += Scalar2Int2String(human.waist) + "|";
			/* 17 */	o += Scalar2Int2String(human.belly) + "|";
			/* 18 */	o += Scalar2Int2String(human.gluteusSize) + "|";
			/* 19 */	o += Scalar2Int2String(human.headSize) + "|";
			/* 20 */	o += Scalar2Int2String(human.headWidth) + "|";
			/* 21 */	o += Scalar2Int2String(human.neckThickness) + "|";
			/* 22 */	o += Scalar2Int2String(human.earsSize) + "|";
			/* 23 */	o += Scalar2Int2String(human.earsPosition) + "|";
			/* 24 */	o += Scalar2Int2String(human.earsRotation) + "|";
			/* 25 */	o += Scalar2Int2String(human.noseSize) + "|";
			/* 26 */	o += Scalar2Int2String(human.noseCurve) + "|";
			/* 27 */	o += Scalar2Int2String(human.noseWidth) + "|";
			/* 28 */	o += Scalar2Int2String(human.noseInclination) + "|";
			/* 29 */	o += Scalar2Int2String(human.nosePosition) + "|";
			/* 30 */	o += Scalar2Int2String(human.nosePronounced) + "|";
			/* 31 */	o += Scalar2Int2String(human.noseFlatten) + "|";
			/* 32 */	o += Scalar2Int2String(human.chinSize) + "|";
			/* 33 */	o += Scalar2Int2String(human.chinPronounced) + "|";
			/* 34 */	o += Scalar2Int2String(human.chinPosition) + "|";
			/* 35 */	o += Scalar2Int2String(human.mandibleSize) + "|";
			/* 36 */	o += Scalar2Int2String(human.jawsSize) + "|";
			/* 37 */	o += Scalar2Int2String(human.jawsPosition) + "|";
			/* 38 */	o += Scalar2Int2String(human.cheekSize) + "|";
			/* 39 */	o += Scalar2Int2String(human.cheekPosition) + "|";
			/* 40 */	o += Scalar2Int2String(human.lowCheekPronounced) + "|";
			/* 41 */	o += Scalar2Int2String(human.lowCheekPosition) + "|";
			/* 42 */	o += Scalar2Int2String(human.foreheadSize) + "|";
			/* 43 */	o += Scalar2Int2String(human.foreheadPosition) + "|";
			/* 44 */	o += Scalar2Int2String(human.lipsSize) + "|";
			/* 45 */	o += Scalar2Int2String(human.mouthSize) + "|";
			/* 46 */	o += Scalar2Int2String(human.eyeSize) + "|";
			/* 47 */	o += Scalar2Int2String(human.eyeRotation) + "|";
	
			// the body slots info
			string bodyparts = "";
			for(int n = 0; n < human.Body.Count; n++)
			{
				if(n != 0) 
					bodyparts += "^";
				bodyparts += human.Body[n].element.Index;
				if(human.Body[n].colors != null)
				{
					if(human.Body[n].colors.Count == 1) 
						bodyparts += "," + human.Body[n].colors[0];
					else if(human.Body[n].colors.Count == 3) 
						bodyparts += "," + human.Body[n].colors[0] + "," + human.Body[n].colors[1] + "," + human.Body[n].colors[2];
				}
				else
				{
					bodyparts += "," + human.Body[n].color.r + "," + human.Body[n].color.g + "," + human.Body[n].color.b + "," + human.Body[n].color.a;
				}
			}
			o += bodyparts + "|";
			
			// the wardrobe slots info
			string wardrobeparts = "";
			for(int n = 0; n < human.Wardrobe.Count; n++)
			{
				if(n != 0) wardrobeparts += "^";
				wardrobeparts += human.Wardrobe[n].element.Index;
				if(human.Body[n].colors != null)
				{
					if(human.Wardrobe[n].colors.Count == 1) 
						wardrobeparts += "," + human.Wardrobe[n].colors[0];
					if(human.Wardrobe[n].colors.Count == 3) 
						wardrobeparts += "," + human.Wardrobe[n].colors[0] + "," + human.Wardrobe[n].colors[1] + "," + human.Wardrobe[n].colors[2];
				}
				else
				{
					wardrobeparts += "," + human.Wardrobe[n].color.r + "," + human.Wardrobe[n].color.g + "," + human.Wardrobe[n].color.b + "," + human.Wardrobe[n].color.a;
				}
			}
			o += wardrobeparts + "|";
			
			// the attachments slots info
			string attachmentparts = "";
			for(int n = 0; n < human.Attachments.Count; n++)
			{
				if(n != 0) attachmentparts += "^";
				attachmentparts += human.Attachments[n].element.Index;
				if(human.Attachments[n].colors.Count == 1) 
					attachmentparts += "," + human.Attachments[n].colors[0];
				if(human.Attachments[n].colors.Count == 3) 
					attachmentparts += "," + human.Attachments[n].colors[0] + "," + human.Attachments[n].colors[1] + "," + human.Attachments[n].colors[2];
			}
			o += attachmentparts;
			
			// all done
			return o;
		}
		
		public void Serialize()
		{
				
		}
	
		public void Deserialize()
		{
				
		}
		
// -------------------------------------------------------------------------------------------------------------		
// helper functions		

		private static string Scalar2Int2String(float f)
		{
			int tmp = Mathf.RoundToInt(f * 256.0f);
			return ""+tmp;
		}
		
		private static float String2Int2Scalar(string s)
		{
			int tmp = 0;
			int.TryParse(s, out tmp);
			return (float)((float)tmp * 0.003906f);
		}
		
		private static char String2Char(string s)
		{
			return s[0];
		}
		
		private static int String2Int(string s)
		{
			int tmp = 0;
			int.TryParse(s, out tmp);
			return tmp;
		}
		
// -------------------------------------------------------------------------------------------------------------				
	}
}