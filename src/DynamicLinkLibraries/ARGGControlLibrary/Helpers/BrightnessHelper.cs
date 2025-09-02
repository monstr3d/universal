
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
	/// Description of BrightnessHelper.
	/// </summary>
	public class BrightnessHelper
	{
		private System.Globalization.CultureInfo c = System.Globalization.CultureInfo.InvariantCulture;
		
		private ArgbColorControl m_control;
		
		public delegate void Process();
		
		public BrightnessHelper()
		{
		}
		
		public void Step1_SetArgbControl(ArgbColorControl control)
		{
			m_control = control;
		}
		
		public void Step2_ChangedText()
		{
			TextBox brightnessTextBox = m_control.brightnessTextBox;
			ColorDialogSettings settings = m_control.Settings;
			ToolTip tip = m_control.tip;
			PictureBox brightness = m_control.brightness;
			
			// Set brightness by text.
			try
			{
				int val = int.Parse(brightnessTextBox.Text, c);
				if (val < 0 || val > 255)
					throw new Exception("Brightness must be in range 0 to 255");
				settings.Brightness = val/255f;
				
				RefreshColorHelper helper = new RefreshColorHelper();
				helper.Step1_SetArgbColorControl(m_control);
				helper.Step2_ChangeColorCode(true);
				helper.Step3_Refresh();
				
				brightnessTextBox.BackColor = SystemColors.Window;
				tip.SetToolTip(brightnessTextBox, null);
			}
			catch (Exception ex)
			{
				brightnessTextBox.BackColor = Color.Red;
				tip.SetToolTip(brightnessTextBox, ex.Message);
			}
		}
		
		public void Step2_ChangeByMousePos(float x)
		{
			PictureBox brightness = m_control.brightness;
			ColorDialogSettings settings = m_control.Settings;
			TextBox brightnessTextBox = m_control.brightnessTextBox;
			
			// Sets the brightness from user click or dragging.
			x /= brightness.Width;
			x = x < 0 ? 0 : x > 1 ? 1 : x;
			settings.Brightness = x;
			
			RefreshColorHelper helper = new RefreshColorHelper();
			helper.Step1_SetArgbColorControl(m_control);
			helper.Step2_ChangeColorCode(true);
			helper.Step3_Refresh();
			
			brightnessTextBox.Text = ((int)(x*255)).ToString();
		}
		
		private void MakeBufferSameSizeAsControl()
		{
			PictureBox brightness = m_control.brightness;
			Bitmap buffer = m_control.BrightnessBuffer;
			if (buffer != null && buffer.Width == brightness.Width && buffer.Height == brightness.Height) return;
			
			if (buffer != null) buffer.Dispose();
			m_control.BrightnessBuffer = new Bitmap(brightness.Width, brightness.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
		}
		
		public void Step2_PaintBrightness(Graphics eg)
		{
			MakeBufferSameSizeAsControl();
			
			Bitmap buffer = m_control.BrightnessBuffer;
			Graphics g = Graphics.FromImage(buffer);
			
			PictureBox brightness = m_control.brightness;
			ColorDialogSettings settings = m_control.Settings;
			
			Color brightColor = Utils.ColorFromHSV(settings.Hue, settings.Saturation, 1);
			
			int w = brightness.Width;
			int h = brightness.Height;
			float fx;
			int rx, gx, bx;
			int x;
			Color color;
			
			// Draw a scale of brightness.
			for (x = 0; x < w; x++)
			{
				fx = (float)x/w;
				rx = (int)(fx*brightColor.R);
				gx = (int)(fx*brightColor.G);
				bx = (int)(fx*brightColor.B);
				color = Color.FromArgb(rx, gx, bx);
				g.DrawLine(new Pen(color), x, 0, x, h);
			}
			
			// Draw inverted selection box.
			float br = settings.Brightness;
			float mx = br*w;
			ImageProcessing.Invert(new RectangleF(mx-6, 0, 6, h), buffer);
			
			eg.DrawImage(buffer, 0, 0);
		}
	}
}
