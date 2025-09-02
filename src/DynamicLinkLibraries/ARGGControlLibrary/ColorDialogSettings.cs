
using System;
using System.Drawing;
/*
csharp-ArgbColorDialog - C# Color Dialog With Alpha Channel
BSD license.
by Sven Nilsen, 2012
http://www.cutoutpro.com

Version: 0.000
Angular degrees version notation
http://isprogrammingeasy.blogspot.no/2012/08/angular-degrees-versioning-notation.html

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
1. Redistributions of source code must retain the above copyright notice, this
list of conditions and the following disclaimer.
2. Redistributions in binary form must reproduce the above copyright notice,
this list of conditions and the following disclaimer in the documentation
and/or other materials provided with the distribution.
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
The views and conclusions contained in the software and documentation are those
of the authors and should not be interpreted as representing official policies,
either expressed or implied, of the FreeBSD Project. 
*/


namespace CutoutPro.Winforms
{
	/// <summary>
	/// Contains color value in AHSV to prevent loosing information.
	/// </summary>
	public class ColorDialogSettings
	{
		private float m_alphaValue = 1;
		private float m_hue;
		private float m_saturation;
		private float m_brightness;
		
		public float AlphaValue
		{
			get
			{
				return m_alphaValue;
			}
			set 
			{
				m_alphaValue = value;
			}
		}
		
		public float Hue
		{
			get
			{
				return m_hue;
			}
			set
			{
				m_hue = value;
			}
		}
		
		public float Saturation
		{
			get
			{
				return m_saturation;
			}
			set
			{
				m_saturation = value;
			}
		}
		
		public float Brightness
		{
			get
			{
				return m_brightness;
			}
			set
			{
				m_brightness = value;
			}
		}
		
		public void SetColor(Color color)
		{
			double hue, saturation, brightness;
			Utils.ColorToHSV(color, out hue, out saturation, out brightness);
			this.m_hue = (float)hue;
			this.m_saturation = (float)saturation;
			this.m_brightness = (float)brightness;
			this.m_alphaValue = color.A/255f;
		}
	}
}
