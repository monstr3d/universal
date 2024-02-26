using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Symbols
{
    /// <summary>
    /// Proprty Symbol
    /// </summary>
    public class PropertySymbol : MathSymbol
    {
        string objName;

        string propertyName;

        internal PropertySymbol(string objName, string propertyName)
        {
            this.objName = objName;
            this.propertyName = propertyName;
        }

        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns></returns>
        public override object Clone()
        {
            return new PropertySymbol(objName, propertyName);
        }

        /// <summary>
        /// Name of the object
        /// </summary>
        public string ObjectName
        {
            get
            {
                return objName;
            }
        }

        /// <summary>
        /// Name of property
        /// </summary>
        public string PropertyName
        {
            get
            {
                return propertyName;
            }
        }
    }
}
