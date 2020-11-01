using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GeneralNode
{
    /// <summary>
    /// Factory of database node
    /// </summary>
    public class DatabaseNodeFactory : INodeFactory
    {
        #region

        string idRow = null;

        string parentIDRow = null;

        private string nameOfName = null;

        private string nameOfDescription = null;


        #endregion

        #region INodeFactory Members

        INode INodeFactory.CreateNode(object o)
        {
            DataRow row = o as DataRow;
            if (row.Table.Columns.Contains(nameOfName) & row.Table.Columns.Contains(nameOfDescription))
            {
                return new DataNodeNameDescription(idRow, parentIDRow, row, nameOfName, nameOfDescription);
            }
            return new DataRowNode(idRow, parentIDRow, row);
        }

        #endregion
    }
}
