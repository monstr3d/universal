
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
	/// Description of Utils.
	/// </summary>
	public class Utils
	{
		public static Color ColorFromHSV(double hue, double saturation, double value)
		{
		    int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
		    double f = hue / 60 - Math.Floor(hue / 60);
		
		    value = value * 255;
		    int v = Convert.ToInt32(value);
		    int p = Convert.ToInt32(value * (1 - saturation));
		    int q = Convert.ToInt32(value * (1 - f * saturation));
		    int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));
		
		    if (hi == 0)
		        return Color.FromArgb(255, v, t, p);
		    else if (hi == 1)
		        return Color.FromArgb(255, q, v, p);
		    else if (hi == 2)
		        return Color.FromArgb(255, p, v, t);
		    else if (hi == 3)
		        return Color.FromArgb(255, p, q, v);
		    else if (hi == 4)
		        return Color.FromArgb(255, t, p, v);
		    else
		        return Color.FromArgb(255, v, p, q);
		}
		
		public static void ColorToHSV(Color color, out double hue, out double saturation, out double value)
		{
		    int max = Math.Max(color.R, Math.Max(color.G, color.B));
		    int min = Math.Min(color.R, Math.Min(color.G, color.B));
		
		    hue = color.GetHue();
		    saturation = (max == 0) ? 0 : 1d - (1d * min / max);
		    value = max / 255d;
		}
		
		private static string s_hex = "0123456789abcdef";
		public static bool ColorFromHexString(string code, ref Color result)
		{
			code = code.Replace(" ", "").Trim().ToLower();
			code = code.PadRight(6, '0');
			if (code.Length != 6) return false;
			
			long sum = 0, pow;
			int num;
			for (int i = 0; i < code.Length; i++)
			{
				num = s_hex.IndexOf(code[i]);
				if (num == -1) return false;
				
				pow = (long)Math.Pow(16, (code.Length - i - 1));
				sum += pow * num;
			}
			
			result = Color.FromArgb(255, Color.FromArgb((int)sum));
			return true;
		}
		
		// Converts a color from hex string with alpha channel.
		public static bool ArgbColorFromHexString(string code, ref Color result)
		{
			code = code.Replace(" ", "").Replace("0x", "").Trim().ToLower();
			
			// If alpha is not specified at end, use full value.
			if (code.Length > 6) code = code.PadRight(8, '0');
			else code = code.PadRight(6, '0').PadRight(8, 'f');
			
			if (code.Length != 8) return false;
			
			long sum = 0, pow;
			int num;
			for (int i = 0; i < code.Length; i++)
			{
				num = s_hex.IndexOf(code[i]);
				if (num == -1) return false;
				
				pow = (long)Math.Pow(16, (code.Length - i - 1));
				sum += pow * num;
			}
			
			// Flip format from RGBA to ARGB.
			long alpha = sum & 0xFF;
			long rgb = (sum >> 8) & 0xFFFFFF;
			long argb = (alpha << 24) + rgb;
			
			unchecked {
				result = Color.FromArgb((int)argb);
			}
			return true;
		}
		
		// Returns true if the hex code seems to contain alpha channel.
		public static bool IsHexStringWithAlpha(string code)
		{
			code = code.Replace(" ", "").Trim();
			
			if (code.Length <= 6) return false;
			
			return true;
		}
		
		public static string HexStringFromColor(Color color)
		{
			ulong argb;
			unchecked {argb = (ulong)color.ToArgb();}
			int bits;
			string hex = "";
			for (int i = 5; i >= 0; i--)
			{
				unchecked {bits = (int)((argb >> (i*4)) & 0xF);}
				hex += s_hex[bits];
			}
			return hex.ToUpper();
		}
		
		public static string HexStringFromArgbColor(Color color)
		{
			ulong argb;
			unchecked {argb = (ulong)color.ToArgb();}
			int bits;
			string hex = "";
			for (int i = 7; i >= 0; i--)
			{
				unchecked {bits = (int)((argb >> (i*4)) & 0xF);}
				hex += s_hex[bits];
			}
			
			if (hex.Length > 6)
			{
				// Flip alpha to the end.
				hex = hex.Substring(2, hex.Length-2) + hex.Substring(0, 2);
			}
			
			return hex.ToUpper();
		}
	}
}
