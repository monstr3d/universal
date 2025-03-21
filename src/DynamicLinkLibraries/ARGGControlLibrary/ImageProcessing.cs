﻿
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
	/// Description of ImageProcessing.
	/// </summary>
	public class ImageProcessing
	{
		public static void Invert(RectangleF rect, Bitmap image)
		{
			int w = image.Width;
			int h = image.Height;
			int rectX = (int)rect.X;
			int rectY = (int)rect.Y;
			int rectMaxX = (int)(rect.X + rect.Width);
			int rectMaxY = (int)(rect.Y + rect.Height);
			System.Drawing.Imaging.BitmapData data = image.LockBits(new Rectangle(0, 0, w, h), 
				System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			unsafe
			{
				byte* start = (byte*)data.Scan0.ToPointer();
				int stride = data.Stride;
				byte* cur;
				for (int x = rectX; x < rectMaxX; x++)
				{
					for (int y = rectY; y < rectMaxY; y++)
					{
						if (x >= 0 && x < w && y >= 0 && y < h)
						{
							cur = start + x * 4 + y * stride;
							*cur = (byte)(255 - *cur);
							cur++;
							*cur = (byte)(255 - *cur);
							cur++;
							*cur = (byte)(255 - *cur);
							cur++;
						}
					}
				}
			}

			image.UnlockBits(data);
		}
		
		public static void Hsv(Rectangle rect, Bitmap image)
		{
			int w = image.Width;
			int h = image.Height;
			int rectX = (int)rect.X;
			int rectY = (int)rect.Y;
			float invRectWidth = 1f/rect.Width;
			float halfInvRectHeight = 0.5f/rect.Height;
			int rectMaxX = (int)(rect.X + rect.Width);
			int rectMaxY = (int)(rect.Y + rect.Height);
			float fx, hue, saturation;
			byte v, p, q, t;
			int hi;
			float inv60 = 1f/60;
			float f;
			int x, y;
			
			// Boundary check.
			rectX = rectX < 0 ? 0 : rectX;
			rectY = rectY < 0 ? 0 : rectY;
			rectMaxX = rectMaxX >= w ? w : rectMaxX;
			rectMaxY = rectMaxY >= h ? h : rectMaxY;
			
			System.Drawing.Imaging.BitmapData data = image.LockBits(new Rectangle(0, 0, w, h), 
				System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
			unsafe
			{
				byte* start = (byte*)data.Scan0.ToPointer();
				int stride = data.Stride;
				byte* cur;
				
				for (x = rectX; x < rectMaxX; x++)
				{
					for (y = rectY; y < rectMaxY; y++)
					{
						fx = (x-rectX) * invRectWidth;
						hue = fx*360;
						
						// Calculate directly to save operations.
						// fy = (y-rectY) * invRectHeight;
						// saturation = fy*0.5f;
						saturation = (y-rectY) * halfInvRectHeight;
						
						hi = (int)(hue * inv60);
						f = hue * inv60 - hi;
						hi = hi % 6;
					
					    v = 255;
					    p = (byte)(255 * (1 - saturation));
					    q = (byte)(255 * (1 - f * saturation));
					    t = (byte)(255 * (1 - (1 - f) * saturation));
					
					    // red = hi == 0 ? v : hi == 1 ? q : hi == 2 ? p : hi == 3 ? p : hi == 4 ? t : v;
					    // green = hi == 0 ? t : hi == 1 ? v : hi == 2 ? v : hi == 3 ? q : hi == 4 ? p : p;
					    // blue = hi == 0 ? p : hi == 1 ? p : hi == 2 ? t : hi == 3 ? v : hi == 4 ? v : q;
						
						cur = start + x * 4 + y * stride;
						*cur = hi == 0 || hi == 1 ? p : hi == 2 ? t : hi == 3 || hi == 4 ? v : q;
						cur++;
						*cur = hi == 0 ? t : hi == 1 || hi == 2 ? v : hi == 3 ? q : p;
						cur++;
						*cur = hi == 1 ? q : hi == 2 || hi == 3 ? p : hi == 4 ? t : v;
						cur++;
						*cur = 255; // full opacity.
					}
				}
			}

			image.UnlockBits(data);
		}
	}
}
