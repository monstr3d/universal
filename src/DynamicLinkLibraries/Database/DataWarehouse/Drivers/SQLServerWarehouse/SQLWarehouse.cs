using System;
using System.Collections.Generic;


using DataWarehouse.Interfaces;
using SQLServerWarehouse.DataSetWarehouseTableAdapters;


namespace SQLServerWarehouse
{
    public class SQLWarehouse : IDatabaseCoordinator
    {

        #region Fields

        static public readonly SQLWarehouse Singleton = new SQLWarehouse();


        // static private IDatabaseInterface data;
        /*  private XmlDocument doc;
          private Dictionary<Guid, XmlElement> dic = new Dictionary<Guid, XmlElement>();
          QueriesTableAdapter ad;
          SelectBinaryTableAdapter bt;
          InsertBinaryTableAdapter idt;
          InsertBinaryNodeTableAdapter addn;
          */
        #endregion

        #region Ctor

        internal SQLWarehouse(string connectionString)
        {
            /*  
 Scaffold-DbContext "Server=IVANKOV\SQLExpress;Database=AstronomyExpress1;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models3 -Verbose
            
            */
            //load(connectionString);
            // Z.EntityFramework.Extensions.EFCore 
        }


        public SQLWarehouse()
        {
            //dotnet ef dbcontext scaffold "Server=IVANKOV\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models 
        }

        #endregion

        #region Specific members

        static internal void Refresh()
        {
              //tableAdapter.SetConnecion();
            var dataAdapter = new SelectBinaryTableTableAdapter();
            Action actData = () => { StaticExtension.DataTable = dataAdapter.GetData(); };
            dataAdapter.ConnectionAction(actData);
            var dataTable = StaticExtension.DataTable;
            var treeAdapter = new SelectBinaryTreeTableAdapter();
            Action actTree = () => { StaticExtension.TreeTable = treeAdapter.GetData(); };
            treeAdapter.ConnectionAction(actTree);
            var dataTree = StaticExtension.TreeTable;
            var dicTree = StaticExtension.TreeDictionary;
            dicTree.Clear();
            List<IDirectory> roots = StaticExtension.Roots;
            roots.Clear();
            foreach (DataSetWarehouse.SelectBinaryTreeRow row in dataTree.Rows)
            {
                if (row.Id == row.ParentId)
                {
                    roots.Add(row);
                }
                dicTree[row.Id] = row;
            }
            foreach (DataSetWarehouse.SelectBinaryTreeRow row in dicTree.Values)
            {
                if (!roots.Contains(row))
                {
                    var parent = dicTree[row.ParentId];
                    parent.Add(row);
                }
            }
            foreach (DataSetWarehouse.SelectBinaryTableRow row in dataTable.Rows)
            {
                var parent = dicTree[row.ParentId];
                parent.Add(row);
            }

        }

        protected virtual IDatabaseInterface GetInterface(string connectionString)
        {
            using (var conn = new System.Data.SqlClient.SqlConnection())
            {
                try
                {
                    conn.ConnectionString = connectionString;
                    conn.Open();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            var tableAdapter = new QueriesTableAdapter();
            StaticExtension.ConnectionString = connectionString;
            StaticExtension.TableAdapter = tableAdapter;
            //return QueriesTableAdapter;
            return DataWarehouseContext;
        }

        static private QueriesTableAdapter QueriesTableAdapter
        {
            get

            {
                Refresh();
                return StaticExtension.TableAdapter;
            }
        }

        static private DataWarehouseContext DataWarehouseContext
        {
            get
            {
                var ctx = new DataWarehouseContext();
                StaticExtension.Context = ctx;
                ctx.Init();
                return ctx;
            }
        }

        #endregion

        #region IDatabaseCoordinator Members

        IDatabaseInterface IDatabaseCoordinator.this[string name]
        {
            get
            {
                return GetInterface(name);
            }
        }

        public bool Create(string name)
        {
            return false;
        }


        #endregion

    }
}