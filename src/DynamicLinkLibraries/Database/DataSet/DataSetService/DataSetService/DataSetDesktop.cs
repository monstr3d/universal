using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DataSetService
{
    /// <summary>
    /// Absract desktop
    /// </summary>
    public abstract class AbstractDataSetDesktop : IDataSetDesktop, IDataSetDesktopFactory
    {
        /// <summary>
        /// Desktop tables
        /// </summary>
        protected Dictionary<string, ITable> tables = new Dictionary<string, ITable>();
 
        /// <summary>
        /// Desktiop links
        /// </summary>
        protected List<ILink> links = new List<ILink>();
 
        #region IDataSetDesktop Members

        /// <summary>
        /// Dictionary of tables
        /// </summary>
        public Dictionary<string, ITable> Tables
        {
            get
            {
                return tables;
            }
        }

        /// <summary>
        /// Links
        /// </summary>
        public List<ILink> Links
        {
            get
            {
                return links;
            }
        }

        /// <summary>
        /// Removes table
        /// </summary>
        /// <param name="table">Table for removing</param>
        public void Remove(ITable table)
        {
            RemoveTable(table);
        }

        /// <summary>
        /// Removes linlk
        /// </summary>
        /// <param name="link">Link for removing</param>
        public void Remove(ILink link)
        {
            RemoveLink(link);
        }

        #endregion

        #region IDataSetDesktopFactory Members

        /// <summary>
        /// Creates default column
        /// </summary>
        public abstract IColumn Column
        {
            get;
        }

        /// <summary>
        /// Creates default table
        /// </summary>
        public abstract ITable Table
        {
            get;
        }

        /// <summary>
        /// Creates default link
        /// </summary>
        public abstract ILink Link
        {
            get;
        }


        /// <summary>
        /// Creates default desktop
        /// </summary>
        public abstract IDataSetDesktop Desktop
        {
            get;
        }

        /// <summary>
        /// Copies sesktop
        /// </summary>
        /// <param name="desktop">Prototype</param>
        /// <returns>A copy</returns>
        public IDataSetDesktop Copy(IDataSetDesktop desktop)
        {
            return DataSetFactoryPerformer.Copy(desktop, this);
        }

        /// <summary>
        /// Creates desktop from data set
        /// </summary>
        /// <param name="dataSet">The data set</param>
        /// <returns>The desktop</returns>
        public IDataSetDesktop Create(DataSet dataSet)
        {
            return DataSetFactoryPerformer.Create(dataSet, this);
        }

        /// <summary>
        /// Sets data set to desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="dataSet">The data set</param>
        public void Set(IDataSetDesktop desktop, DataSet dataSet)
        {
            DataSetFactoryPerformer.Set(dataSet, desktop);
        }

        /// <summary>
        /// Gets modifiers
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Modifiers</returns>
        public string[] GetModifiers(string type)
        {
            return DataSetFactoryPerformer.GetModifiers(type);
        }



        #endregion

        #region Specific Members

        /// <summary>
        /// Removes table
        /// </summary>
        /// <param name="table">Table for removing</param>
        static public void RemoveTable(ITable table)
        {
            IDataSetDesktop d = table.Desktop;
            List<ILink> l = new List<ILink>();
            List<ILink> lp = d.Links;
            foreach (ILink link in lp)
            {
                if (link.Source == table && link.Target == table)
                {
                    if (!l.Contains(link))
                    {
                        l.Add(link);
                    }
                }
            }
            foreach (ILink link in l)
            {
               d.Remove(link);
            }
            d.Remove(table);
        }

        /// <summary>
        /// Removes link
        /// </summary>
        /// <param name="link">Link for removing</param>
        static public void RemoveLink(ILink link)
        {
            IDataSetDesktop d = link.Desktop;
            d.Remove(link);
        }

        /// <summary>
        /// Gets selected columns from desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>List of selected columns</returns>
        static public List<IColumn> GetSelectedColumns(IDataSetDesktop desktop)
        {
            List<IColumn> list = new List<IColumn>();
            foreach (ITable t in desktop.Tables.Values)
            {
                foreach (IColumn c in t.Columns.Values)
                {
                    if (c.IsMarked)
                    {
                        list.Add(c);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// Gets selected links from desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>List of selected links</returns>
        static public List<ILink> GetSelectedLinks(IDataSetDesktop desktop)
        {
            List<ILink> list = new List<ILink>();
            foreach (ILink l in desktop.Links)
            {
                if (l.IsMarked)
                {
                    list.Add(l);
                }
            }
            return list;
        }

        /// <summary>
        /// Gets list of pairs of selected columns of desktop
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <returns>List of pairs of selected columns</returns>
        static public List<IColumn[]> GetLinkColumns(IDataSetDesktop desktop)
        {
            List<ILink> list = GetSelectedLinks(desktop);
            List<IColumn[]> l = new List<IColumn[]>();
            foreach (ILink link in list)
            {
                IColumn[] c = new IColumn[2];
                c[0] = link.Source;
                c[1] = link.Target;
                l.Add(c);
            }
            return l;

        }

        /// <summary>
        /// Generates standard statement of desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>The statement</returns>
        static public string GenerateStandardStatement(IDataSetDesktop desktop)
        {
            List<IColumn> cols = GetSelectedColumns(desktop);
            List<IColumn[]> links = GetLinkColumns(desktop);
            List<ITable> tables = new List<ITable>();
            foreach (IColumn c in cols)
            {
                ITable t = c.Table;
                if (!tables.Contains(t))
                {
                    tables.Add(t);
                }
            }
            List<IColumn[]> linksn = new List<IColumn[]>(links);
            foreach (IColumn[] c in linksn)
            {
                if (!tables.Contains(c[0].Table) | !tables.Contains(c[1].Table))
                {
                    if (links.Contains(c))
                    {
                        links.Remove(c);
                    }
                }
            }
            string s = "SELECT ";
            bool bg = false;
            foreach (IColumn c in cols)
            {
                if (bg)
                {
                    s += ", ";
                }
                bg = true;
                s += c.Table.Name + "." + c.Name;
            }
            s += " FROM ";
            bg = false;
            foreach (ITable t in tables)
            {
                if (bg)
                {
                    s += ", ";
                }
                bg = true;
                s += t.Name;
             }
             string wh = "";
            bg = false;
            foreach (IColumn[] c in links)
            {
                if (bg)
                {
                    wh += " AND ";
                }
                bg = true;
                wh += c[0].Table.Name + "." + c[0].Name + " = " + c[1].Table.Name + "."  + c[1].Name;
            }
            foreach (IColumn c in cols)
            {
                if (c.IsNullable)
                {
                    if (!c.IsNull)
                    {
                        if (bg)
                        {
                            wh += " AND ";
                        }
                        bg = true;
                        wh += c.Table.Name + "." + c.Name + " IS NOT NULL";
                    }
                }
            }
            foreach (ITable table in desktop.Tables.Values)
            {
                foreach (IColumn c in table.Columns.Values)
                {
                    string mod = c.Modifier;
                    string val = c.Value;
                    if (mod.Length > 0 & val.Length > 0)
                    {
                        if (bg)
                        {
                            wh += " AND ";
                        }
                        wh += c.Table.Name + "." + c.Name + " " + mod + " ";
                        if (c.Type.Equals("System.Char[]"))
                        {
                            wh += "\'";
                        }
                        wh += val;
                        if (c.Type.Equals("System.Char[]"))
                        {
                            wh += "\'";
                        }
                        bg = true;
                    }
                }
            }
            if (wh.Length > 0)
            {
                s += " WHERE " + wh;
            }
            return s;
        }


        #endregion
    }
}
