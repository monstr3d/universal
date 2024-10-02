using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
    /// <summary>
    /// Saver of formula to Xml document
    /// </summary>
    public class XmlFormulaSaver : IFormulaSaver
    {
        #region Fields

        IXmlSymbolCreator creator;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="creator">Creator of symbols</param>
        public XmlFormulaSaver(IXmlSymbolCreator creator)
        {
            this.creator = creator;
        }

        #endregion


        #region IFormulaSaver Members

        /// <summary>
        /// Loads formula
        /// </summary>
        /// <param name="str">String representation</param>
        /// <returns>The formula</returns>
        public virtual MathFormula Load(string str)
        {
            XElement doc = XElement.Parse(str);
            MathFormula f = MathFormula.CreateFormula(doc.GetFirst(), creator);
            f.SetLevel(0x0);
            return f;
        }

        string IFormulaSaver.Save(MathFormula formula)
        {
            XElement doc = XElement.Parse("<Root/>");
            XElement e = MathFormula.CreateElement(formula, creator);
            doc.Add(e);
            return doc + "";
          }

        #endregion
    }
}
