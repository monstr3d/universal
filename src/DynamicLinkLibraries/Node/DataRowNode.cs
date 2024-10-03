using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GeneralNode
{
    /// <summary>
    /// Node of data row
    /// </summary>
    public class DataRowNode : ArbitraryNode
    {
        #region Fields

        /// <summary>
        /// Associated row
        /// </summary>
        protected DataRow row;

        string idRow;

        string parentIDRow;

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="idRow">Name of id</param>
        /// <param name="parentIDRow">Name of parent id</param>
        /// <param name="row">Wrapped row</param>
        public DataRowNode(string idRow, string parentIDRow, DataRow row)
            : base(row)
        {
            this.idRow = idRow;
            this.parentIDRow = parentIDRow;
            this.row = row;
        }

        #endregion

        /// <summary>
        /// Node Id
        /// </summary>
        public override object Id
        {
            get 
            { 
                return row[idRow]; 
            }
        }

        /// <summary>
        /// Parent Id
        /// </summary>
        public override object ParentId
        {
            get 
            {
                return row[parentIDRow]; 
            }
        }

        /// <summary>
        /// Associated object
        /// </summary>
        public override object Object
        {
            get
            {
                return row;
            }
            set
            {
                row = value as DataRow;
            }
        }
    }
}
