
using System;
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
	/// Description of RefreshColorHelper.
	/// </summary>
	public class RefreshColorHelper
	{
		public RefreshColorHelper()
		{
		}
		
		private ArgbColorControl m_control;
		private bool m_changeColorCode = false;
		private bool m_changeAlpha = false;
		
		public void Step1_SetArgbColorControl(ArgbColorControl control)
		{
			m_control = control;
		}
		
		public void Step2_ChangeColorCode(bool yes)
		{
			m_changeColorCode = yes;
		}
		
		public void Step2_ChangeAlpha(bool yes)
		{
			m_changeAlpha = yes;
		}
		
		public void Step3_Refresh()
		{
			if (m_changeColorCode)
			{
				// Prevent sending event in loop.
				bool send = m_control.SendColorCodeChanged;
				m_control.SendColorCodeChanged = false;
				m_control.code.Text = Utils.HexStringFromArgbColor(m_control.Color);
				m_control.SendColorCodeChanged = send;
			}
			
			if (m_changeAlpha)
			{
				// Prevents sending event in loop.
				bool send = m_control.SendAlphaChanged;
				m_control.SendAlphaChanged = false;
				m_control.alphaTextBox.Text = m_control.Color.A.ToString();
				m_control.SendAlphaChanged = send;
			}
			
			m_control.hsvBox.Refresh();
			m_control.brightness.Refresh();
			m_control.alpha.Refresh();
			m_control.ProcessSelectedColorChanged();
		}
	}
}
