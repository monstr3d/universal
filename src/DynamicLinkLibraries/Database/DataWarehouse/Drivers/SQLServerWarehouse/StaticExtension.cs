using DataWarehouse.Interfaces;
using SQLServerWarehouse.DataSetWarehouseTableAdapters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLServerWarehouse.DataSetWarehouse;

namespace SQLServerWarehouse
{
    internal static class StaticExtension
    {

        internal static string ConnectionString
        { get; set; }

        internal static QueriesTableAdapter TableAdapter
        { get; set; }

        internal static SqlConnection Connection { get => new SqlConnection(ConnectionString); }

        internal static void SetConnecion(this global::System.ComponentModel.Component component)
        {
            var type = component.GetType();
            var connection = type.GetProperty("Connection");
            connection.SetValue(component, Connection);
        }


        static internal DataSetWarehouse.SelectBinaryTableDataTable DataTable
        { get; set; }

        static internal DataSetWarehouse.SelectBinaryTreeDataTable TreeTable
        { get; set; }

        static internal Dictionary<Guid, SelectBinaryTreeRow> TreeDictionary
        { get; } = new Dictionary<Guid, SelectBinaryTreeRow>();

        static internal Dictionary<Guid, SelectBinaryTableRow> DataDictionary
        { get; } = new Dictionary<Guid, SelectBinaryTableRow>();

        static internal List<IDirectory> Roots
        { get; } = new List<IDirectory>();


    }
}
