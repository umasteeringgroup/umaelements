using UnityEngine;
using System.Collections;

namespace UMAElements
{
	public class Positions
	{
		// you can edit this enum
		// these are the slots for building umas - slots and overlays on slots are all listed here.
		// it's wise to keep 0-13 just as they are, as these are the basic humanoid slots for UMA
		// 17-26 are our generic clothing slot positions suitable for most RPGs
		// 27-34 are our generic accessories slot positions suitable for most RPGs
		public enum BuildSlots {
			None = 0,
			Body_Eyes,
			Body_Head,
			Body_Torso,
			Body_Hands,
			Body_Mouth,
			Body_Legs,
			Body_Feet,
			Body_HeadEyes,
			Body_HeadEars,
			Body_HeadMouth,
			Body_HeadNose,
			Body_Eyelashes,
			Body_Hair,
			Body_Beard,
			Body_Horns,
			Body_Wings,
			Body_Tail,
			Garb_Helm,
			Garb_Mask,
			Garb_Shoulders,
			Garb_Arms,
			Garb_Chest,
			Garb_Legs,
			Garb_Hands,
			Garb_Feet,
			Garb_Belt,
			Garb_Cape,
			Acc_Ears,
			Acc_Neck,
			Acc_WristL,
			Acc_WristR,
			Acc_AnkleL,
			Acc_AnkleR,
			Acc_RingL,
			Acc_RingR,
			LastNoUse,
		}
		
		// you can edit this enum - but you will need to change the code in AttachmentsPoints.cs and HumanoidBuilder.cs
		// these are the ingame accessory positions
		public enum AttachmentSlots {
			None = 0,
			LeftPalm = 1,
			RightPalm = 2,
			LeftShoulder = 3,
			RightShoulder = 4,
			LeftHip = 5,
			RightHip = 6,
			Back = 7,
			LeftShoulderBlade = 8,
			RightShoulderBlade = 9,
		}
	}
}