using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UMA;

namespace UMAElements
{
	[System.Serializable]
	public class ElementData : ScriptableObject
	{
		public int Index;
		
		public string Name;
		
		public Positions.BuildSlots buildPos;
		public Positions.AttachmentSlots attachmentDefaultPos;
		public Positions.AttachmentSlots attachmentActivePos;
		
		public SlotData slotItem;
		public OverlayData overlayItem;
		public Texture2D dyeSplat;
		public GameObject prefabItem;
		public List<Positions.BuildSlots> hides;
	
		public void OnEnable()
		{
			hideFlags = HideFlags.None;
		}
	}
}
