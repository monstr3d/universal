
using System;
using System.Windows.Forms;
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


namespace CutoutPro.Winforms.Helpers
{
	/// <summary>
	/// Make rendering and picking color from HSV area easier.
	/// </summary>
	public class HsvPickerHelper
	{
		private ArgbColorControl m_control;
		
		public HsvPickerHelper()
		{
		}
		
		public void Step1_SetArgbColorControl(ArgbColorControl control)
		{
			m_control = control;
		}
		
		public void Step2_SetHsv(float x, float y)
		{
			PictureBox hsvBox = m_control.hsvBox;
			ColorDialogSettings settings = m_control.Settings;
			TextBox brightnessTextBox = m_control.brightnessTextBox;
			PictureBox brightness = m_control.brightness;
			PictureBox alpha = m_control.alpha;
			
			x /= hsvBox.Width;
			y /= hsvBox.Height;
			x = x < 0 ? 0 : x > 1 ? 1 : x;
			y = y < 0 ? 0 : y > 1 ? 1 : y;
			settings.Hue = x*360;
			settings.Saturation = y;
			settings.Brightness = settings.Brightness == 0 ? 1 : settings.Brightness;
			brightnessTextBox.Text = ((int)(settings.Brightness*255)).ToString();
			
			RefreshColorHelper helper = new RefreshColorHelper();
			helper.Step1_SetArgbColorControl(m_control);
			helper.Step2_ChangeColorCode(true);
			helper.Step3_Refresh();
		}
	}
}
