using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
