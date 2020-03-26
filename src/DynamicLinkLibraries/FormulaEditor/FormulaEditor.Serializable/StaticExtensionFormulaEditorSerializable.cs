using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;

namespace FormulaEditor
{
    [InitAssembly]
    static public class StaticExtensionFormulaEditorSerializable
    {

        public static void Init()
        {

        }

        static StaticExtensionFormulaEditorSerializable()
        {
            InitFormEditor();
        }

        private static void InitFormEditor()
        {
            MathFormula.Saver = StandardSaver.Saver;
            string seb = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string sel = "abcdefghijklmnopqrstuvwxyz";
            string[] sym = new string[] { seb, sel };
            System.Globalization.CultureInfo c = System.Globalization.CultureInfo.CurrentCulture;
            if (c.TwoLetterISOLanguageName.ToLower().Equals("ru"))
            {
                string srb = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЬЫЪЭЮЯ";
                string srl = "абвгдеёжзийклмнопрстуфхцчшщьыъэюя";
                sym = new string[] { seb, sel, srb, srl };
            }
            //char ct = '\u0442';

        }
    }
}
