using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.Data.SqlClient;


using DataWarehouse;
using DataWarehouse.Interfaces;


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
            //load(connectionString);
        }


        private SQLWarehouse()
        {
        }

        #endregion


        #region Specific members

        static private IDatabaseInterface GetInterface(string connectionString)
        {
            return new BinaryTree(connectionString);
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