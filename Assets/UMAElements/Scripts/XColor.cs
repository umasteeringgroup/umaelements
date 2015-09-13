using UnityEngine;

namespace UMAElements
{
	public class XColor
	{
		public const int RGBA = 0;
		public const int HSLA = 1;
			
		public int R, G, B, H, S, L, A;			
		public float scalarR, scalarG, scalarB, scalarH, scalarS, scalarL, scalarA;
		public Color color;

		// constructor
		public XColor(int type, int x1, int x2, int x3, int x4)
		{
			if(type == RGBA)
			{
				this.R = x1;
				this.G = x2;
				this.B = x3;
				this.A = x4;
				this.scalarR = x1 * 0.003906f;
				this.scalarG = x2 * 0.003906f;
				this.scalarB = x3 * 0.003906f;
				this.scalarA = x4 * 0.003906f;
				SetHSL();
				this.H = (int)(this.scalarH * 255.0f);
				this.S = (int)(this.scalarS * 255.0f);
				this.L = (int)(this.scalarL * 255.0f);
				this.color = new Color(this.scalarR, this.scalarG, this.scalarB, this.scalarA);
			}
			if(type == HSLA)
			{
				this.H = x1;
				this.S = x2;
				this.L = x3;
				this.A = x4;
				this.scalarH = x1 * 0.003906f;
				this.scalarS = x2 * 0.003906f;
				this.scalarL = x3 * 0.003906f;
				this.scalarA = x4 * 0.003906f;
				SetRGB();	
				this.color = new Color(this.scalarR, this.scalarG, this.scalarB, this.scalarA);
			}
		}
			
		public XColor(int type, float x1, float x2, float x3, float x4)
		{
			if(type == RGBA)
			{
				this.scalarR = x1;
				this.scalarG = x2;
				this.scalarB = x3;
				this.scalarA = x4;
				this.R = (int)(x1 * 255.0f);
				this.G = (int)(x2 * 255.0f);
				this.B = (int)(x3 * 255.0f);
				this.A = (int)(x4 * 255.0f);
				SetHSL();
				this.color = new Color(this.scalarR, this.scalarG, this.scalarB, this.scalarA);
				this.H = (int)(this.scalarH * 255.0f);
				this.S = (int)(this.scalarS * 255.0f);
				this.L = (int)(this.scalarL * 255.0f);
			}
			if(type == HSLA)
			{
				this.scalarH = x1;
				this.scalarS = x2;
				this.scalarL = x3;
				this.scalarA = x4;
				this.H = (int)(x1 * 255.0f);
				this.S = (int)(x2 * 255.0f);
				this.L = (int)(x3 * 255.0f);
				this.A = (int)(x4 * 255.0f);
				SetRGB();
				this.color = new Color(this.scalarR, this.scalarG, this.scalarB, this.scalarA);
			}
		}

		private void SetHSL()
		{
			this.scalarH = 0;
			this.scalarS = 0;
			this.scalarL = 0;

			float v = Mathf.Max(this.scalarR, this.scalarG, this.scalarB);
			float m = Mathf.Min(this.scalarR, this.scalarG, this.scalarB);
			
			this.scalarL = (m + v) / 2.0f;
			if(this.scalarL <= 0.0f) return;
			
			float vm = v - m;
			this.scalarS = vm;
			if(this.scalarS > 0.0f)
			{
				this.scalarS /= (this.scalarL <= 0.5f) ? (v + m ) : (2.0f - v - m);
			} else {
				return;
			}

			float r2 = (v - this.scalarR) / vm;
			float g2 = (v - this.scalarG) / vm;
			float b2 = (v - this.scalarB) / vm;

			if(this.scalarR == v)
			{
				this.scalarH = (this.scalarG == m ? 5.0f + b2 : 1.0f - g2);
			} else if(this.scalarG == v) {
				this.scalarH = (this.scalarB == m ? 1.0f + r2 : 3.0f - b2);
			} else {
				this.scalarH = (this.scalarR == m ? 3.0f + g2 : 5.0f - r2);
			}
			
			this.scalarH /= 6.0f;
		}
		
		private void SetRGB()
		{
			this.scalarR = this.scalarL;
			this.scalarG = this.scalarL;
			this.scalarB = this.scalarL;

			float v = (this.scalarL <= 0.5) ? (this.scalarL * (1.0f + this.scalarS)) : (this.scalarL + this.scalarS - this.scalarL * this.scalarS);

			if(v > 0)
			{
				float m;
				float sv;
				int sextant;
				float fract, vsf, mid1, mid2;
	
				m = this.scalarL + this.scalarL - v;
				sv = (v - m ) / v;
				float h = this.scalarH * 6.0f;
				sextant = (int)h;
				fract = h - sextant;
				vsf = v * sv * fract;
				mid1 = m + vsf;
				mid2 = v - vsf;
				switch(sextant)
				{
					case 0:
						this.scalarR = v;
						this.scalarG = mid1;
						this.scalarB = m;
						break;
					case 1:
						this.scalarR = mid2;
						this.scalarG = v;
						this.scalarB = m;
						break;
					case 2:
						this.scalarR = m;
						this.scalarG = v;
						this.scalarB = mid1;
						break;
					case 3:
						this.scalarR = m;
						this.scalarG = mid2;
						this.scalarB = v;
						break;
					case 4:
						this.scalarR = mid1;
						this.scalarG = m;
						this.scalarB = v;
						break;
					case 5:
						this.scalarR = v;
						this.scalarG = m;
						this.scalarB = mid2;
						break;
				}
			}
			
			this.R = (int)(this.scalarR * 255.0f);
			this.G = (int)(this.scalarG * 255.0f);
			this.B = (int)(this.scalarB * 255.0f);
		}
	}
}