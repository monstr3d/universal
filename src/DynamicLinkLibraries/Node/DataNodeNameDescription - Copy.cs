using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GeneralNode
{
    /// <summary>
    /// Node with description
    /// </summary>
    public class DataNodeNameDescription : DataRowNode, INameDescription
    {
        #region Fields

        private string nameOfName;

        private string nameOfDescription;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="idRow">Name of row</param>
        /// <param name="parentIDRow">Name of parent row</param>
        /// <param name="row">Associated row</param>
        /// <param name="nameOfName">Name of name</param>
        /// <param name="nameOfDescription">Name of description</param>
        public DataNodeNameDescription(string idRow, string parentIDRow, DataRow row,
           string nameOfName, string nameOfDescription)
            : base(idRow, parentIDRow, row)
        {
            this.nameOfName = nameOfName;
            this.nameOfDescription = nameOfDescription;
        }

        #endregion


        #region INameDescription Members

        string INameDescription.Name
        {
            get 
            {
                return row[nameOfName] + "";
            }
        }

        string INameDescription.Description
        {
            get { return row[nameOfDescription] + ""; }
        }

        #endregion
    }
}
