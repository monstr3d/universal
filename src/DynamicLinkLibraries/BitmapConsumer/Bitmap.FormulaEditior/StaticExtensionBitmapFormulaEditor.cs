using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using FormulaEditor;

using DataPerformer.Formula;

using Bitmap.FormulaEditior.UnaryDetectors;
using Bitmap.FormulaEditior.BinaryDetectors;
using AssemblyService.Attributes;

namespace Bitmap.FormulaEditior
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionBitmapFormulaEditor
    {


        internal static readonly string[] Operations = { "BinaryBitmap", "TernaryBitmap", "UnaryBitmap" };

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionBitmapFormulaEditor()
        {
            foreach (string s in Operations)
            {
                s.AddAdditionalFormula();
            }
            "Width".AddProperty();
            "x".AddProperty();
            "y".AddProperty();
            "z".AddProperty();
            try
            {
                BitmapDetector b = new BitmapDetector();
                b.Add();
                (new UnaryBitmapDetector()).Add();
              //  UnaryDetectors.BitmapDetector.Singleton.Add();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
