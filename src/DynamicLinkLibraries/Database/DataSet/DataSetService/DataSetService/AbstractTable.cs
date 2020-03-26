using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DataSetService
{
    /// <summary>
    /// Abstract base class for tables
    /// </summary>
    public class AbstractTable : ITable
    {
        #region Fields

        internal static readonly AbstractTable Object = new AbstractTable();

        /// <summary>
        /// Columns
        /// </summary>
        protected Dictionary<string, IColumn> columns = new Dictionary<string, IColumn>();

        /// <summary>
        /// X - coordinate
        /// </summary>
        protected int x;

        /// <summary>
        /// Y - coordinate
        /// </summary>
        protected int y;

        /// <summary>
        /// Table
        /// </summary>
        protected DataTable table;

        /// <summary>
        /// Table name
        /// </summary>
        protected string name;

        /// <summary>
        /// Desktop
        /// </summary>
        protected AbstractDataSetDesktop desktop;


        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        protected AbstractTable()
        {
        }

        #endregion

        #region ITable Members

        /// <summary>
        /// Columns' dictionary
        /// </summary>
        public Dictionary<string, IColumn> Columns
        {
            get
            {
                return columns;
            }
        }

        /// <summary>
        /// X - coordinate
        /// </summary>
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>
        /// Y - coordinate
        /// </summary>
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        /// <summary>
        /// Table
        /// </summary>
        public DataTable Table
        {
            get
            {
                return table;
            }
            set
            {
                table = value;
            }
        }

        /// <summary>
        /// Table name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Desktop
        /// </summary>
        public IDataSetDesktop Desktop
        {
            get
            {
                return desktop;
            }
            set
            {
                desktop = value as AbstractDataSetDesktop;
            }
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        public void Remove()
        {
            AbstractDataSetDesktop.RemoveTable(this);
        }


        #endregion

    }
}
