using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace UMAElements
{
	public class ElementBlock
	{
		public ElementData element;
		public List<int> colors;
		public Texture2D dyedDiffuse;
		public bool attachmentIsActive;

		
		public ElementBlock(ElementData e)
		{
			this.element = e;
			this.colors = new List<int>();
			this.attachmentIsActive = false;
		}
		
		public ElementBlock(ElementData e, int c1)
		{
			this.element = e;
			this.colors = new List<int>();
			this.colors.Add(c1);
			this.attachmentIsActive = false;
		}
		
		public ElementBlock(ElementData e, int c1, int c2, int c3)
		{
			this.element = e;
			this.colors = new List<int>();
			this.colors.Add(c1);
			this.colors.Add(c2);
			this.colors.Add(c3);
			this.attachmentIsActive = false;
			
			// is everything correct?
			if(e.dyeSplat == null)
				Debug.LogError("UMAElements.ElementBlock: Attempted creation of a dyable element '" + e.Name + "' with no splat map.");
			if(e.dyeSplat.width != e.overlayItem.asset.textureList[0].width || e.dyeSplat.height != e.overlayItem.asset.textureList[0].height) 
				Debug.LogError("UMAElements.ElementBlock: Dyable Element '" + e.Name + 
					"' has a splat map of different size to the overlay '" + e.overlayItem.asset.name + "' it represents.");
			
			// make the new blank texture
			dyedDiffuse = new Texture2D(e.overlayItem.asset.textureList[0].width, e.overlayItem.asset.textureList[0].height, TextureFormat.ARGB32, false); 
			
			// call the thread or make the texture - this suffers because
			// after it's complete the UMA atlas needs rebuilding
			// NEEDS SORTING OUT
			//Thread t = new Thread(MakeDyedTexture);
			MakeDyedTexture();
		}
		
		public void MakeDyedTexture()
		{
			// the colors
			XColor col1 = GamePalette.DyeSwatch[colors[0]];
			XColor col2 = GamePalette.DyeSwatch[colors[1]];
			XColor col3 = GamePalette.DyeSwatch[colors[2]];
			
			// the arrays of colours
			Debug.LogWarning("FIX THIS!");
			Color[] difpixels = new Color[1];//element.overlayItem.textureList[0].GetPixels();
			Color[] splatpixels = element.dyeSplat.GetPixels();
			Color[] resultpixels = dyedDiffuse.GetPixels();
			
			// loop through the array and build a new merged texture
			for(int n = 0; n < difpixels.Length; n++)
			{
				resultpixels[n] = difpixels[n];
				if(splatpixels[n].r == 1) resultpixels[n] = (new XColor(XColor.HSLA, col1.scalarH, col1.scalarS, difpixels[n].r * col1.scalarL, difpixels[n].a).color);
				if(splatpixels[n].g == 1) resultpixels[n] = (new XColor(XColor.HSLA, col2.scalarH, col2.scalarS, difpixels[n].r * col2.scalarL, difpixels[n].a).color);
				if(splatpixels[n].b == 1) resultpixels[n] = (new XColor(XColor.HSLA, col3.scalarH, col3.scalarS, difpixels[n].r * col3.scalarL, difpixels[n].a).color);
			}
			
			dyedDiffuse.SetPixels(resultpixels);
			dyedDiffuse.Apply();
		}
	}
}
