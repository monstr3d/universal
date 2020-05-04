using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Standard saver of formulas
    /// </summary>
    public class StandardSaver : IFormulaSaver
    {

        private IFormulaSaver saver = new XmlFormulaSaver(new StandardXmlSymbolCreator());

        /// <summary>
        /// Saver
        /// </summary>
        public static StandardSaver Saver = new StandardSaver();

        private StandardSaver()
        {

        }
        

        #region IFormulaSaver Members

        MathFormula IFormulaSaver.Load(string str)
        {
           MathFormula f = null;
           try
            {
                return saver.Load(str);
            }
            catch (Exception ex)
            {
            }
            try
            {

                f = new MathFormula(0, MathSymbolFactory.Sizes, str, 0, str.Length,
                    ElementaryFormulaStringConverter.Object);
                ObjectFormulaTree.CreateTree(f.FullTransform(null));
                return f;
            }
            catch (Exception)
            {
                List<byte[]> list = new List<byte[]>();
                for (int i = 0; i < str.Length; i++)
                {
                    char c = str[i];
                    byte[] b = new byte[] { (byte)c };
                    list.Add(b);
                }
                try
                {
                    MathFormula fo = new MathFormula(0, MathSymbolFactory.Sizes, list, 0, str.Length);
                    return fo;
                }
                catch (Exception ex)
                {
                }
            }
            return null;
        }

        string IFormulaSaver.Save(MathFormula formula)
        {
            return saver.Save(formula);
       }

        #endregion

    }
}
