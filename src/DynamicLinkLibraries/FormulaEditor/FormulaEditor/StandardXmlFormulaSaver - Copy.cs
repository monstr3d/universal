using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace FormulaEditor
{
    /// <summary>
    /// Standard saver of formulas
    /// </summary>
    public class StandardXmlFormulaSaver : XmlFormulaSaver
    {

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly StandardXmlFormulaSaver Object = new StandardXmlFormulaSaver();


        /// <summary>
        /// Default constructor
        /// </summary>
        protected StandardXmlFormulaSaver()
            : base(new StandardXmlSymbolCreator())
        {
        }

        /// <summary>
        /// Overriden load method
        /// </summary>
        /// <param name="str">Source string</param>
        /// <returns>Loaded formula</returns>
        public override MathFormula Load(string str)
        {
            try
            {
                return base.Load(str);
            }
            catch (Exception)
            {
            }
            List<byte[]> list = new List<byte[]>();
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                byte[] b = new byte[] { (byte)c };
                list.Add(b);
            }
            MathFormula fo = new MathFormula(0, MathSymbolFactory.Sizes, list, 0, str.Length);
            //new ObjectFormulaTree(fo.FullTransform);
            return fo;

        }
    }
}
