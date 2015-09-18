using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace UMAElements
{
	public class AttachmentPoints : MonoBehaviour
	{
		private Transform bone_LeftHand;
		private Transform bone_LeftFinger03_01;
		private Transform bone_RightHand;
		private Transform bone_RightFinger03_01;
		private Transform bone_LeftShoulder;
		private Transform bone_LeftArm;
		private Transform bone_RightShoulder;
		private Transform bone_RightArm;
		private Transform bone_Spine1;
		private Transform bone_LeftUpLeg;
		private Transform bone_RightUpLeg;
	
		public Transform[] Points = new Transform[10];

		void Awake()
		{
			// find the bones we need
			bone_LeftHand = transform.FindChild("Root/Global/Position/Hips/LowerBack/Spine/Spine1/LeftShoulder/LeftArm/LeftForeArm/LeftHand");
			if(bone_LeftHand == null) 
				Debug.Log ("could not find left hand bone");
	
			bone_LeftFinger03_01 = transform.FindChild("Root/Global/Position/Hips/LowerBack/Spine/Spine1/LeftShoulder/LeftArm/LeftForeArm/LeftHand/LeftHandFinger03_01");
			if(bone_LeftFinger03_01 == null) 
				Debug.Log ("could not find left hand finger bone");
	
			bone_RightHand = transform.FindChild("Root/Global/Position/Hips/LowerBack/Spine/Spine1/RightShoulder/RightArm/RightForeArm/RightHand");
			if(bone_RightHand == null) 
				Debug.Log ("could not find right hand bone");
	
			bone_RightFinger03_01 = transform.FindChild("Root/Global/Position/Hips/LowerBack/Spine/Spine1/RightShoulder/RightArm/RightForeArm/RightHand/RightHandFinger03_01");
			if(bone_RightFinger03_01 == null) 
				Debug.Log ("could not find right hand finger bone");
			
			bone_LeftShoulder = transform.FindChild("Root/Global/Position/Hips/LowerBack/Spine/Spine1/LeftShoulder");
			if(bone_LeftShoulder == null) 
				Debug.Log ("could not find left shoudler bone");
			
			bone_LeftArm = transform.FindChild("Root/Global/Position/Hips/LowerBack/Spine/Spine1/LeftShoulder/LeftArm");
			if(bone_LeftArm == null) 
				Debug.Log ("could not find left arm bone");
			
			bone_RightShoulder = transform.FindChild("Root/Global/Position/Hips/LowerBack/Spine/Spine1/RightShoulder");
			if(bone_RightShoulder == null) 
				Debug.Log ("could not find right shoudler bone");
			
			bone_RightArm = transform.FindChild("Root/Global/Position/Hips/LowerBack/Spine/Spine1/RightShoulder/RightArm");
			if(bone_RightArm == null) 
				Debug.Log ("could not find right arm bone");
			
			bone_Spine1 = transform.FindChild("Root/Global/Position/Hips/LowerBack/Spine/Spine1");
			if(bone_RightArm == null) 
				Debug.Log ("could not find spine1 bone");
			
			bone_LeftUpLeg = transform.FindChild("Root/Global/Position/Hips/LeftUpLeg");
			if(bone_LeftUpLeg == null) 
				Debug.Log ("could not find left upper leg bone");
			
			bone_RightUpLeg = transform.FindChild("Root/Global/Position/Hips/RightUpLeg");
			if(bone_RightUpLeg == null) 
				Debug.Log ("could not find right upper leg bone");
			
			// build the attachment point game objects
			for(int i = 1; i < Points.Length; i++)
			{
				GameObject go = new GameObject("AttachmentPoint");
				go.transform.localScale = Vector3.one;
				Points[i] = go.transform;
			}

			// attach the spheres
			Points[(int)Positions.AttachmentSlots.LeftPalm].parent = bone_LeftHand;
			Points[(int)Positions.AttachmentSlots.RightPalm].parent = bone_RightHand;
			Points[(int)Positions.AttachmentSlots.LeftShoulder].parent = bone_LeftShoulder;
			Points[(int)Positions.AttachmentSlots.RightShoulder].parent = bone_RightShoulder;
			Points[(int)Positions.AttachmentSlots.LeftHip].parent = bone_LeftUpLeg;
			Points[(int)Positions.AttachmentSlots.RightHip].parent = bone_RightUpLeg;
			Points[(int)Positions.AttachmentSlots.Back].parent = bone_Spine1;
			Points[(int)Positions.AttachmentSlots.LeftShoulderBlade].parent = bone_LeftShoulder;
			Points[(int)Positions.AttachmentSlots.RightShoulderBlade].parent = bone_RightShoulder;

			// set the basic position for each attachment point
			Points[(int)Positions.AttachmentSlots.LeftPalm].localPosition = Vector3.zero;
			Points[(int)Positions.AttachmentSlots.RightPalm].localPosition = Vector3.zero;
			Points[(int)Positions.AttachmentSlots.LeftShoulder].localPosition = Vector3.zero;
			Points[(int)Positions.AttachmentSlots.RightShoulder].localPosition = Vector3.zero;
			Points[(int)Positions.AttachmentSlots.LeftHip].localPosition = Vector3.zero;
			Points[(int)Positions.AttachmentSlots.RightHip].localPosition = Vector3.zero;
			Points[(int)Positions.AttachmentSlots.Back].localPosition = Vector3.zero;
			Points[(int)Positions.AttachmentSlots.LeftShoulderBlade].localPosition = Vector3.zero;
			Points[(int)Positions.AttachmentSlots.RightShoulderBlade].localPosition = Vector3.zero;

			// set the basic rotation for each attachment point
			Points[(int)Positions.AttachmentSlots.LeftPalm].localRotation = Quaternion.identity;
			Points[(int)Positions.AttachmentSlots.RightPalm].localRotation = Quaternion.identity;
			Points[(int)Positions.AttachmentSlots.LeftShoulder].localRotation = Quaternion.identity;
			Points[(int)Positions.AttachmentSlots.RightShoulder].localRotation = Quaternion.identity;
			Points[(int)Positions.AttachmentSlots.LeftHip].localRotation = Quaternion.identity;
			Points[(int)Positions.AttachmentSlots.RightHip].localRotation = Quaternion.identity;
			Points[(int)Positions.AttachmentSlots.Back].localRotation = Quaternion.identity;
			Points[(int)Positions.AttachmentSlots.LeftShoulderBlade].localRotation = Quaternion.identity;
			Points[(int)Positions.AttachmentSlots.RightShoulderBlade].localRotation = Quaternion.identity;
		}
	}
}
