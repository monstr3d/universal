using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;

using BaseTypes;
using BaseTypes.Utils;

using DataSetService;

using Regression.Portable;
using ErrorHandler;
using NamedTree;


namespace DataTableSelection
{
    /// <summary>
    /// Selection obtained from data set
    /// </summary>
    [Serializable()]
    public class DataSetSelection : ArraySelectionCollection, ISerializable, ICategoryObject, IDataSetConsumer
    {
        /// <summary>
        /// Data set
        /// </summary>
        protected DataSet dataSet;

        CategoryTheory.Performer performer = new();


        /// <summary>
        /// On Add action
        /// </summary>
        protected Action<DataSet> onAdd = (DataSet dataSet) => { };

        /// <summary>
        /// On Remoe action
        /// </summary>
        protected Action<DataSet> onRemove = (DataSet dataSet) => { };

        /// <summary>
        /// Associated object
        /// </summary>
        protected object obj;
        static readonly Double dt = 0;
        static readonly Decimal dc = 0;
        static readonly Int32 it = 0;
        static readonly Type td = dt.GetType();
        static readonly Type id = it.GetType();
        static readonly Type dct = dc.GetType();
        static readonly Type dtt = typeof(DateTime);

        /// <summary>
        /// Factory
        /// </summary>
        protected IDataSetFactory factory;
 
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataSetSelection()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private DataSetSelection(SerializationInfo info, StreamingContext context)
        {

        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            //info.AddValue("Table", table);
        }

        #endregion

        #region ICategoryObject Members


        /// <summary>
        /// The identical arrow of this object
        /// </summary>
        public ICategoryArrow Id
        {
            get
            {
                return null;
            }
        }

        #endregion

        #region IAssociatedObject Members

        /// <summary>
        /// The associated object
        /// </summary>
        public object Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        #endregion

        #region IDataSetConsumer Members

        /// <summary>
        /// Adds data set
        /// </summary>
        /// <param name="dataSet">Data set to add</param>
        public void Add(DataSet dataSet)
        {
            if (this.dataSet != null && dataSet != null)
            {
                throw new OwnException("Provider already exists");
            }
            this.dataSet = dataSet;
            if (dataSet != null)
            {
                Load();
            }
        }

        /// <summary>
        /// Removes data set
        /// </summary>
        /// <param name="dataSet">Data set to remove</param>
        public void Remove(DataSet dataSet)
        {
            this.dataSet = null;
        }

        /// <summary>
        /// Factory
        /// </summary>
        public IDataSetFactory Factory
        {
            get
            {
                return factory;
            }
            set
            {
                factory = value;
            }
        }

        string INamed.Name { get => performer.GetAssociatedName(this); set =>throw new  ErrorHandler.WriteProhibitedException(); }
       

        event Action<DataSet> IDataSetConsumer.OnAdd
        {
            add { onAdd += value; }
            remove { onAdd -= value; }
        }

        event Action<DataSet> IDataSetConsumer.OnRemome
        {
            add { onRemove += value; }
            remove { onRemove -= value; }
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// The "is double" calculation
        /// </summary>
        /// <param name="c">Column</param>
        /// <returns>True if double and false otherwise</returns>
        public static bool IsDouble(DataColumn c)
        {
            Type t = c.DataType;
            return t.Equals(td) | t.Equals(dct) | t.Equals(dtt);

        }

        /// <summary>
        /// Selects column
        /// </summary>
        /// <param name="name">Column name</param>
        /// <param name="dataSet">Data set</param>
        /// <returns>Selected column</returns>
        static public DataColumn SelectColumn(string name, DataSet dataSet)
        {
            List<string> names = new List<string>();
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                DataTable table = dataSet.Tables[i];
                string pre = table.TableName + "_";
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    DataColumn col = table.Columns[j];
                    string nam = pre + col.ColumnName;
                    if (name.Equals(nam))
                    {
                        return col;
                    }
                    if (!names.Contains(nam))
                    {
                        names.Add(nam);
                    }
                    else
                    {
                        for (int k = 1; ; k++)
                        {
                            string s = name + k;
                            if (!names.Contains(s))
                            {
                                names.Add(s);
                                if (s.Equals(name))
                                {
                                    return col;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets names of double columns
        /// </summary>
        /// <param name="dataSet">Data set</param>
        /// <returns>List of names of double columns</returns>
        public static List<string> GetDoubleNames(DataSet dataSet)
        {
            List<string> names = new List<string>();
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                DataTable table = dataSet.Tables[i];
                List<DataColumn> dc = new List<DataColumn>();
                string pre = table.TableName + "_";
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    DataColumn col = table.Columns[j];
                    if (!IsDouble(col))
                    {
                        continue;
                    }
                    dc.Add(col);
                    string name = pre + col.ColumnName;
                    if (!names.Contains(name))
                    {
                        names.Add(name);
                    }
                    else
                    {
                        for (int k = 1; ; k++)
                        {
                            string s = name + k;
                            if (!names.Contains(s))
                            {
                                names.Add(s);
                                break;
                            }
                        }
                    }
                }
            }
            return names;
        }


        /// <summary>
        /// Loads itself
        /// </summary>
        protected void Load()
        {
            int n = 0;
            List<string> names = new List<string>();
            Dictionary<DataTable, List<DataColumn>> dic = new Dictionary<DataTable, List<DataColumn>>();
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                DataTable table = dataSet.Tables[i];
                List<DataColumn> dc = new List<DataColumn>();
                dic[table] = dc;
                string pre = table.TableName + "_";
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    DataColumn col = table.Columns[j];
                    if (!IsDouble(col))
                    {
                        continue;
                    }
                    dc.Add(col);
                    string name = pre + col.ColumnName;
                    if (!names.Contains(name))
                    {
                        names.Add(name);
                    }
                    else
                    {
                        for (int k = 1; ; k++)
                        {
                            string s = name + k;
                            if (!names.Contains(s))
                            {
                                names.Add(s);
                                break;
                            }
                        }
                    }
                }
            }
            string[] namesStr = new string[names.Count];
            for (int i = 0; i < namesStr.Length; i++)
            {
                namesStr[i] = names[i];
            }
            double[][] data = new double[namesStr.Length][];
            n = 0;
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                DataTable t = dataSet.Tables[i];
                int size = t.Rows.Count;
                List<DataColumn> l = dic[t];
                for (int j = 0; j < l.Count; j++)
                {
                    data[n] = new double[size];
                    ++n;
                }
            }
            n = 0;
            for (int i = 0; i < dataSet.Tables.Count; i++)
            {
                DataTable t = dataSet.Tables[i];
                DataRowCollection rows = t.Rows;
                List<DataColumn> l = dic[t];
                for (int k = 0; k < rows.Count; k++)
                {
                    DataRow row = rows[k];
                    for (int j = 0; j < l.Count; j++)
                    {
                        DataColumn dc = l[j];
                        double a = 0;
                        object o = row[dc.ColumnName];
                        try
                        {
                            if (o is DateTime)
                            {
                                DateTime dt = (DateTime)o;
                                a = dt.DateTimeToDay();
                            }
                            else
                            {
                                a = o.ToDouble();
                            }
                        }
                        catch (Exception ex)
                        {
                            ex.HandleException(10);
                            string s = o + "";
                            a = Double.Parse(s);
                        }
                        /*                     if (dc.DataType.Equals(it))
                                             {
                                                 int v = (int)o;
                                                 a = (double)v;
                                             }
                                             else
                                             {
                                                 a = (double)o;
                                             }*/
                        data[n + j][k] = a;
                    }
                }
                n += l.Count;
            }
            Set(namesStr, data);
        }
       #endregion

    }

}
