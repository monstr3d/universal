using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;


namespace DataSetService
{
    /// <summary>
    /// Abstract implementation of IColumn interface
    /// </summary>
    public class AbstractColumn : IColumn
    {

        #region Fields

        static readonly internal AbstractColumn Object = new AbstractColumn();

        /// <summary>
        /// Parent table
        /// </summary>
        protected ITable table;

        /// <summary>
        /// Data column
        /// </summary>
        protected DataColumn column;

        /// <summary>
        /// Column name
        /// </summary>
        protected string name;

        /// <summary>
        /// The "is marked" sign
        /// </summary>
        protected bool isMarked = false;

        /// <summary>
        /// Column type
        /// </summary>
        protected string type;


        /// <summary>
        /// The "is nullable" sign
        /// </summary>
        protected bool isNullable = false;

        /// <summary>
        /// The "is null" sign
        /// </summary>
        protected bool isNull = false;

        /// <summary>
        /// Modifier
        /// </summary>
        protected string modifier = "";

        /// <summary>
        /// Value
        /// </summary>
        protected string val = "";

        /// <summary>
        /// Length
        /// </summary>
        protected int length = 0;


        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        protected AbstractColumn()
        {
        }

        #region IColumn Members

        /// <summary>
        /// Partent table
        /// </summary>
        public ITable Table
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
        /// Column name
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
        /// Data column
        /// </summary>
        public DataColumn Column
        {
            get
            {
                return column;
            }
            set
            {
                column = value;
            }
        }

        /// <summary>
        /// The "is marked" sign
        /// </summary>
        public bool IsMarked
        {
            get
            {
                return isMarked;
            }
            set
            {
                isMarked = value;
            }
        }

        /// <summary>
        /// Column type
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        /// <summary>
        /// The "is nullable" sign
        /// </summary>
        public bool IsNullable
        {
            get { return isNullable; }
            set { isNullable = value; }
        }

        /// <summary>
        /// The "is null" sign
        /// </summary>
        public bool IsNull
        {
            get { return isNull; }
            set { isNull = value; }
        }

        /// <summary>
        /// Modifier
        /// </summary>
        public string Modifier
        {
            get { return modifier; }
            set { modifier = value; }
        }

        /// <summary>
        /// Value
        /// </summary>
        public string Value
        {
            get { return val; }
            set { val = value; }
        }

        /// <summary>
        /// Length
        /// </summary>
        public virtual int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }



        #endregion

        #region Specific Members

        /// <summary>
        /// Gets links from column
        /// </summary>
        /// <param name="column">The column</param>
        /// <returns>List of links</returns>
        static public List<ILink> GetLinks(IColumn column)
        {
            ITable t = column.Table;
            IDataSetDesktop d = t.Desktop;
            List<ILink> list = new List<ILink>();
            List<ILink> l = d.Links;
            foreach (ILink link in l)
            {
                if (link.Source == column | link.Target == column)
                {
                    list.Add(link);
                }
            }
            return list;
        }

        /// <summary>
        /// Gets links of table
        /// </summary>
        /// <param name="table">The table</param>
        /// <returns>List of links</returns>
        static public List<ILink> GetLinks(ITable table)
        {
            List<ILink> list = new List<ILink>();
            foreach (IColumn c in table.Columns.Values)
            {
                List<ILink> l = GetLinks(c);
                list.AddRange(l);
            }
            return list;

        }

        /// <summary>
        /// Sets table to itself
        /// </summary>
        /// <param name="table">The table to set</param>
        protected void SetTable(ITable table)
        {
            this.table = table;
        }

        #endregion
    }
}
