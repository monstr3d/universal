using System.Drawing;
using System.IO;
/*
This is free and unencumbered software released into the public domain.

Anyone is free to copy, modify, publish, use, compile, sell, or
distribute this software, either in source code form or as a compiled
binary, for any purpose, commercial or non-commercial, and by any
means.

In jurisdictions that recognize copyright laws, the author or authors
of this software dedicate any and all copyright interest in the
software to the public domain.We make this dedication for the benefit
of the public at large and to the detriment of our heirs and
successors. We intend this dedication to be an overt act of
relinquishment in perpetuity of all present and future rights to this
software under copyright law.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

For more information, please refer to <https://unlicense.org>
*/

namespace TGAConverter.TGA
{
    public class TGAReader
    {
        public static TGAImage ReadTGAFile(string _filePath)
        {
            // File read from filePath
            using FileStream fileStream = new FileStream(_filePath, FileMode.Open);
            using BinaryReader binaryReader = new BinaryReader(fileStream);

            TGAHeader header = new TGAHeader();
            /* Inside the first 18 Bytes of the TGA File is the Header
             * We dont need everything from the Header File so we start by skipping 
             * unnecessary data. Since we only need Width, Hight and pixelDepth
             */

            binaryReader.BaseStream.Seek(12, SeekOrigin.Begin); // Skips all Bytes till excluding 12
            header.Width = binaryReader.ReadInt16();
            header.Height = binaryReader.ReadInt16();
            header.PixelDepth = binaryReader.ReadByte();

            // Skips the last not needed byte of the file
            binaryReader.BaseStream.Seek(1, SeekOrigin.Current);

            TGAImage image = new TGAImage(header);

            // 32 Bit Targa files do contain an alphachannel
            if (image.Header.PixelDepth == 32) 
            {
                for (int y = image.PixelData.Height - 1; y >= 0; y--)
                {
                    for (int x = 0; x <= image.PixelData.Width - 1; x++)
                    {
                        
                        byte blue   = binaryReader.ReadByte();
                        byte green  = binaryReader.ReadByte();
                        byte red    = binaryReader.ReadByte();
                        byte alpha  = binaryReader.ReadByte();

                        Color cl = Color.FromArgb(alpha, red, green, blue);
                        image.PixelData.SetPixel(x, y, cl);
                    }
                }
            }
            else
            {
                for (int y = image.PixelData.Height - 1; y >= 0; y--)
                {
                    for (int x = 0; x <= image.PixelData.Width - 1; x++)
                    {
                        int blue    = binaryReader.ReadByte();
                        int green   = binaryReader.ReadByte();
                        int red     = binaryReader.ReadByte();

                        Color cl = Color.FromArgb(255, red, green, blue);
                        image.PixelData.SetPixel(x, y, cl);
                    }
                }
            }

            return image;
        }
    }
}