using DataWarehouse.Interfaces;
using SQLServerWarehouse.DataSetWarehouseTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQLServerWarehouse
{
    internal static class StaticExtension
    {
        static internal byte[] GetData(this Guid id)
        {
            DataSetWarehouse.SelectBinaryDataTable selects = null;
            var adapter = new SelectBinaryTableAdapter();
            adapter.ConnectionAction(() => { selects = adapter.GetData(id); });
            return selects[0].Data;
        }
        static internal void SetData(this Guid id, byte[] data)
        {
            TableAdapter.ConnectionAction(() => { TableAdapter.UpdateBinaryData(id, data); });
        }


        static internal DataWarehouseContext Context
        { get; set; }
        static internal ILeaf ToLeaf(this string id)
        {
            Guid g = new Guid(id);
            return DataDictionary[g];
        }


        internal static string ConnectionString
        { get; set; }

        internal static QueriesTableAdapter TableAdapter
        { get; set; }


        static internal DataSetWarehouse.SelectBinaryTableDataTable DataTable
        { get; set; }

        static internal DataSetWarehouse.SelectBinaryTreeDataTable TreeTable
        { get; set; }

        static internal Dictionary<Guid, DataSetWarehouse.SelectBinaryTreeRow> TreeDictionary
        { get; } = new Dictionary<Guid, DataSetWarehouse.SelectBinaryTreeRow>();

        static internal Dictionary<Guid, DataSetWarehouse.SelectBinaryTableRow> DataDictionary
        { get; } = new Dictionary<Guid, DataSetWarehouse.SelectBinaryTableRow>();

        static internal List<IDirectory> Roots
        { 
            get; 
        } = new List<IDirectory>();


        static internal void ConnectionAction(this Component component, Action action)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var type = component.GetType();
                var method = type.GetMethod("SetConnection");
                if (method == null)
                {
                    type = null;
                }
                method.Invoke(component, new object[] { connection });
                connection.Open();
                action();
            }
        }

        static internal Dictionary<object, object> Get(string ext)
        {
            var result = new Dictionary<object, object>();
            var selection = new SelectBinaryContentsTableAdapter();
            DataSetWarehouse.SelectBinaryContentsDataTable table = null;
            selection.ConnectionAction(() => { table = selection.GetData(ext); });
            foreach (DataSetWarehouse.SelectBinaryContentsRow row in table.Rows)
            {
                result[row.Id] = row.Name;
            }
            return result;
        }
    }
}
