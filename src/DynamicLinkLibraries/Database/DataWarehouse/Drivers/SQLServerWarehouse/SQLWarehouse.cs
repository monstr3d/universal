using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.Data.SqlClient;


using DataWarehouse;
using DataWarehouse.Interfaces;
using SQLServerWarehouse.DataSetWarehouseTableAdapters;
using System.Data.Common;
using static SQLServerWarehouse.DataSetWarehouse;

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
 Scaffold-DbContext "Server=IVANKOV\SQLExpress;Database=AstronomyExpress;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Verbose
            
            */
            //load(connectionString);
            // Z.EntityFramework.Extensions.EFCore 
        }


        private SQLWarehouse()
        {
            //dotnet ef dbcontext scaffold "Server=IVANKOV\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models 
        }

        #endregion


        #region Specific members

        static private IDatabaseInterface GetInterface(string connectionString)
        {
            var tableAdapter = new QueriesTableAdapter();
            StaticExtension.ConnectionString = connectionString;
            StaticExtension.TableAdapter = tableAdapter;
            tableAdapter.SetConnecion();
            var dataAdapter = new Adapter();
            dataAdapter.SetConnecion();
            var dataTable = dataAdapter.GetData();
            StaticExtension.DataTable = dataTable;
            var treeAdapter = new SelectBinaryTreeTableAdapter();
            treeAdapter.SetConnecion();
            var dataTree = treeAdapter.GetData();
            StaticExtension.TreeTable = dataTree;
            var dicTree = StaticExtension.TreeDictionary;
            dicTree.Clear();
            List<IDirectory> roots = StaticExtension.Roots;
            roots.Clear();
            foreach (SelectBinaryTreeRow row in dataTree.Rows)
            {
                if (row.Id == row.ParentId)
                {
                    roots.Add(row);
                }
                dicTree[row.Id] = row;
            }
            foreach (SelectBinaryTreeRow row in dicTree.Values)
            {
                if (!roots.Contains(row))
                {
                    var parent = dicTree[row.ParentId];
                    
                }
            }




            return tableAdapter;
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