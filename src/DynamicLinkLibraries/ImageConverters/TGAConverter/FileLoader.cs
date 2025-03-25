using System.Drawing;

using TGAConverter.TGA;
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

namespace TGAConverter
{
    internal class FileLoader
    {
        public String m_selectedInputPath { get; set; }
        public String m_selectedOutputPath { get; set; }
        public Dictionary<String, Image> LoadedImages { get; set; }

        // Expression-Bodied Constructor -> eine verkürzte Version für die Lesbarkeit
        public FileLoader() => LoadedImages = new Dictionary<String, Image>();


        // Lädt Dateien ins Programm
        public void LoadTGAFiles(out int fileCount)
        {
            fileCount = 0;
            IEnumerable<string> folderContent = Directory.EnumerateFiles(m_selectedInputPath, "*.TGA");
            if (folderContent.Count() <= 0) return;

            foreach (string file in folderContent) // file = ganzer Pfad der Datei (C:\\xyz\\zzz\\test.tga)
            {
                Bitmap bitmap = TGAReader.ReadTGAFile(file).PixelData;
                Image image = (Image)bitmap;
                LoadedImages.Add(file.Remove(0, m_selectedInputPath.Length + 1), image);
                fileCount++;
            }
        }

        // Speichert die geladenen BitMaps als PNG Datei an den Benutzerdefinierten Ort
        public void ExportImageAsPNG()
        {
            // Einfacher Weg um über nen Dictionary zu iterieren
            foreach (KeyValuePair<string, Image> entry in LoadedImages)
            {
                entry.Value.Save($"{m_selectedOutputPath}\\{entry.Key.Replace(".tga", "")}.PNG");
            }

    //        DialogResult res = MessageBox.Show($"All files exported as PNG to {m_selectedOutputPath}", "Confirmation",
     //           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}