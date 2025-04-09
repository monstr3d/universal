using ErrorHandler;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataSetService
{
    /// <summary>
    /// Abstract link between tables
    /// </summary>
    public class AbstractLink : ILink
    {
        #region Fields

        private AbstractColumn source;
        private AbstractColumn target;
        private AbstractDataSetDesktop desktop;

        /// <summary>
        /// Name of source table
        /// </summary>
        protected string sourceTable;

        /// <summary>
        /// Name of target table
        /// </summary>
        protected string targetTable;

        /// <summary>
        /// Name of source column
        /// </summary>
        protected string sourceColumn;

        /// <summary>
        /// Name of target column
        /// </summary>
        protected string targetColumn;

        /// <summary>
        /// The "ia marked" sign
        /// </summary>
        protected bool isMarked;

        #endregion


        #region ILink Members

        /// <summary>
        /// Source column
        /// </summary>
        public IColumn Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value as AbstractColumn;
            }
        }

        /// <summary>
        /// Target column
        /// </summary>
        public IColumn Target
        {
            get
            {
                return target;
            }
            set
            {
                Check(this, value);
                target = value as AbstractColumn;
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
        /// Name of source table
        /// </summary>
        public string SourceTable
        {
            get
            {
                return sourceTable;
            }
            set
            {
                sourceTable = value;
            }
        }

        /// <summary>
        /// Name of target table
        /// </summary>
        public string TargetTable
        {
            get
            {
                return targetTable;
            }
            set
            {
                targetTable = value;
            }
        }

        /// <summary>
        /// Name of source column
        /// </summary>
        public string SourceColumn
        {
            get
            {
                return sourceColumn;
            }
            set
            {
                sourceColumn = value;
            }
        }

        /// <summary>
        /// Name of target column
        /// </summary>
        public string TargetColumn
        {
            get
            {
                return targetColumn;
            }
            set
            {
                targetColumn = value;
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
        /// Removes itself
        /// </summary>
        public void Remove()
        {
            AbstractDataSetDesktop.RemoveLink(this);
        }



        #endregion

        #region Specific Members

        /// <summary>
        /// Checks target of link
        /// </summary>
        /// <param name="link">The link</param>
        /// <param name="target">The target</param>
        static public void Check(ILink link, IColumn target)
        {
            if (link.Source == target)
            {
                throw new OwnException("Cannot link to itself");
            }
            IDataSetDesktop d = link.Source.Table.Desktop;
            List<ILink> links = d.Links;
            foreach (ILink l in links)
            {
                if (l.Source == link.Source && target == l.Target)
                {
                    throw new OwnException("Link already exists");
                }
            }
            if (!link.Source.Type.Equals(target.Type))
            {
                throw new OwnException("Different types of columns");
            }
        }

        /// <summary>
        /// Sets parameters of link
        /// </summary>
        /// <param name="link">The link</param>
        /// <param name="sourceTable">Name of source table</param>
        /// <param name="targetTable">Name of target table</param>
        /// <param name="sourceColumn">Name of source column</param>
        /// <param name="targetColumn">Name of target column</param>
        static public void Set(ILink link, string sourceTable, string targetTable, 
            string sourceColumn, string targetColumn)
        {
            IDataSetDesktop d = link.Desktop;
            ITable tt = d.Tables[targetTable];
            IColumn tc = tt.Columns[targetColumn];
            link.Target = tc;
            ITable st = d.Tables[sourceTable];
            IColumn sc = st.Columns[sourceColumn];
            link.Source = sc;
        }

        /// <summary>
        /// Finds link in dictionary
        /// </summary>
        /// <param name="tableName">Name of table</param>
        /// <param name="columnName">Name of column</param>
        /// <param name="dictionary">Dictionary of links</param>
        /// <returns>Found link</returns>
        static public ILink Find(string tableName, string columnName, Dictionary<string, Dictionary<string, ILink>> dictionary)
        {
            return dictionary[tableName][columnName];
        }

        void Set()
        {
            Set(this, sourceTable, targetTable, sourceColumn, targetColumn);
        }


        #endregion
    }
}