
using System;
using System.Drawing;
using System.Windows.Forms;
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
	/// Description of AlphaHelper.
	/// </summary>
	public class AlphaHelper
	{
		private ArgbColorControl m_control;
		private System.Globalization.CultureInfo c = System.Globalization.CultureInfo.InvariantCulture;
		
		public void Step1_SetArgbColorControl(ArgbColorControl control)
		{
			m_control = control;
		}
		
		private void MakeBufferSameSizeAsControl()
		{
			PictureBox alpha = m_control.alpha;
			Bitmap buffer = m_control.AlphaBuffer;
			if (buffer != null && buffer.Width == alpha.Width && buffer.Height == alpha.Height) return;
			
			if (buffer != null) buffer.Dispose();
			m_control.AlphaBuffer = new Bitmap(alpha.Width, alpha.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
		}
		
		public void Step2_Paint(Graphics eg)
		{
			MakeBufferSameSizeAsControl();
			
			PictureBox alpha = m_control.alpha;
			Bitmap alphaBuffer = m_control.AlphaBuffer;
			Color selectedColor = m_control.Color;
			ColorDialogSettings settings = m_control.Settings;
			
			Graphics g = Graphics.FromImage(alphaBuffer);
			g.Clear(Color.Transparent);
			
			// Draw grid.
			int w = alpha.Width;
			int h = alpha.Height;
			int size = 8;
			for (int x = 0; x < w; x += size)
			{
				for (int y = 0; y < h; y += size)
				{
					if ((x+y)%(size*2) == 0)
					{
						g.FillRectangle(Brushes.LightGray, x, y, size, size);
					}
				}
			}
			
			for (int x = 0; x < w; x++)
			{
				float f = (float)x/w;
				Color color = Color.FromArgb((int)(f*255), selectedColor);
				g.DrawLine(new Pen(color, 1), x, 0, x, h);
			}
			
			float alphaX = (int)(settings.AlphaValue*alpha.Width);
			ImageProcessing.Invert(new RectangleF(alphaX-6, 0, 6, h), alphaBuffer);
			
			eg.DrawImage(alphaBuffer, 0, 0);
		}
		
		public void Step2_AlphaTextChanged()
		{
			TextBox alphaTextBox = m_control.alphaTextBox;
			ColorDialogSettings settings = m_control.Settings;
			ToolTip tip = m_control.tip;
			PictureBox alpha = m_control.alpha;
			
			try
			{
				// Parse alue from alpha text box.
				int a = int.Parse(alphaTextBox.Text, c);
				if (a < 0 || a > 255)
					throw new Exception("Alpha must be in range 0 and 255");
				settings.AlphaValue = (float)a/255f;
				alphaTextBox.BackColor = SystemColors.Window;
				tip.SetToolTip(alphaTextBox, null);
				
				RefreshColorHelper helper = new RefreshColorHelper();
				helper.Step1_SetArgbColorControl(m_control);
				helper.Step2_ChangeColorCode(true);
				helper.Step3_Refresh();
			}
			catch (Exception ex)
			{
				alphaTextBox.BackColor = Color.Red;
				tip.SetToolTip(alphaTextBox, ex.Message);
			}
		}
	}
}
