using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Aspose.ThreeD;

namespace WinFormsApp3DConversion
{
    public static class StaticExtension3D
    {
        /// <summary>
        /// Cob
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        static public void Convert(this string input,  string output)
        {
            var scene = Scene.FromFile(input);
            scene.Save(output);
        }

        static public void Process(this string input, string output)
        {
            var dirs = Directory.GetDirectories(input);
            foreach (var dir in dirs)
            {
                dir.Process(output);
            }
            var files = Directory.GetFiles(input, output);
            foreach (var file in files)
            {
                var s = Scene.FromFile(file);
                var f = Path.GetFileNameWithoutExtension(file);
                f = Path.Combine(input, f + ".dae");
                s.Save(f);
            }

        }
    }
}
