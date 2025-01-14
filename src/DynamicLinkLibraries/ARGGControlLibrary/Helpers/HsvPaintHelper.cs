
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
	/// Description of HsvPaintHelper.
	/// </summary>
	public class HsvPaintHelper
	{
		private ArgbColorControl m_control;
		
		public void Step1_SetArgbColorControl(ArgbColorControl control)
		{
			m_control = control;
		}
		
		private void MakeBufferSameSizeAsPictureBox(out bool changed)
		{
			PictureBox hsvBox = m_control.hsvBox;
			Bitmap buffer = m_control.HsvBuffer;
			if (buffer != null && buffer.Width == hsvBox.Width && buffer.Height == hsvBox.Height) 
			{
				changed = false;
				return;
			}
			
			changed = true;
			if (buffer != null) buffer.Dispose();
			m_control.HsvBuffer = new Bitmap(hsvBox.Width, hsvBox.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
		}
		
		private void PreprocessBuffer()
		{
			Bitmap buffer = m_control.HsvBuffer;
			ImageProcessing.Hsv(new Rectangle(0, 0, buffer.Width, buffer.Height), buffer);
		}
		
		public void Step2_Paint(Graphics eg)
		{
			bool bufferChanged = false;
			MakeBufferSameSizeAsPictureBox(out bufferChanged);
			if (bufferChanged) PreprocessBuffer();
			
			eg.DrawImage(m_control.HsvBuffer, 0, 0);
			
			// Draw cross at top of buffer.
			float mx = m_control.Settings.Hue / 360;
			float my = m_control.Settings.Saturation;
			mx *= m_control.hsvBox.Width;
			my *= m_control.hsvBox.Height;
			eg.DrawLine(Pens.Black, mx-5, my, mx-1, my);
			eg.DrawLine(Pens.Black, mx, my-5, mx, my-1);
			eg.DrawLine(Pens.Black, mx+1, my, mx+5, my);
			eg.DrawLine(Pens.Black, mx, my+1, mx, my+5);
		}
	}
}
