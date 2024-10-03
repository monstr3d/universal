using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using DataWarehouse.Interfaces;


namespace DataWarehouse
{
    /// <summary>
    /// Converter that converts name by adding extensextensionsion
    /// </summary>
    public class ExtensionNameConverter : INameConverter
    {

        #region Fields

        private bool addDataExt;

        private bool addDirExt;

        #endregion


        #region Ctor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="addDataExt">The "add data exsention" flag</param>
        /// <param name="addDirExt">The "add directory extension" flag</param>
        public ExtensionNameConverter(bool addDataExt, bool addDirExt)
        {
            this.addDataExt = addDataExt;
            this.addDirExt = addDirExt;
        }

        #endregion

        #region INameConverter Members

        string INameConverter.CreateName(XmlElement e)
        {
            string tn = e.Name;
            if (tn.Equals("BinaryNode"))
            {
                string bnn = e.Attributes["BinaryNodeName"].Value;
                if (addDirExt)
                {
                    string ext = e.Attributes["BinaryNodeExtension"].Value;
                    bnn += '.' + ext;
                }
                return bnn;
            }
            string bdn = e.Attributes["BinaryName"].Value;
            if (addDataExt)
            {
                     string ext = e.Attributes["Ext"].Value;
                     bdn += '.' + ext;
            }
            return bdn;

        }

        #endregion
    }
}
