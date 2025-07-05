using DataWarehouse.Interfaces;
using ErrorHandler;
using Npgsql;
using System.Data;

namespace PostgreSQLWarehouse.Async
{
    partial class PostgreSQLWarehouseInterface
    {
 
        List<ILeaf> GetLeaves(NpgsqlCommand command, IDirectory d)
        {
            var list = new List<ILeaf>();
            try
            {
                //command.CommandType = CommandType.StoredProcedure;
                // command.CommandText = "public.\"TreeFunc";
                // Add(command, "idd", d.Id);
                //command.Parameters.AddWithValue("idd", d.Id);
                string sqlQuery = $"SELECT \"Id\", \"ParentId\", \"Name\", \"Description\", \"ext\" FROM public.\"BinaryTable\" WHERE \"ParentId\" = @idd"; // Double quotes for column name, @ for parameter
                command.Parameters.AddWithValue("@idd", d.Id);
                command.CommandText = sqlQuery;
                var i = command.ExecuteReader();
                foreach (IDataRecord x in i)
                {
                    var l = new Leaf(x, d, this);
                    list.Add(l);
                }

            }
            catch (Exception ex)
            {

            }
            return list;
        }


        async Task<T> Execute<T>(Func<NpgsqlCommand, Task<T>> func) where T : class
        {
            try
            {
                using var conn = new NpgsqlConnection(Connection);
                var c = conn.OpenAsync();
                await c;
                var cmd = conn.CreateCommand();
                var t = func(cmd);
                await t;
                return t.Result;
            }
            catch (Exception ex)
            {
                ex.HandleExceptionDouble();
            }
            return null;
        }

        async Task<T> Execute<R, S, T>(Func<NpgsqlCommand, R, S, Task<T>> func, R r, S s) where T : class where S : class where R : class
        {
            try
            {
                using var conn = new NpgsqlConnection(Connection);
                var c = conn.OpenAsync();
                await c;
                var cmd = conn.CreateCommand();
                var t = func(cmd, r, s);
                await t;
                return t.Result;
            }
            catch (Exception ex)
            {
                ex.HandleExceptionDouble();
            }
            return null;
        }


        async Task<T> Execute<S, T>(Func<NpgsqlCommand, S, Task<T>> func, S s) where T : class where S : class
        {
            try
            {
                using var conn = new NpgsqlConnection(Connection);
                var c = conn.OpenAsync();
                await c;
                var cmd = conn.CreateCommand();
                var t = func(cmd, s);
                await t;
                return t.Result;
            }
            catch (Exception ex)
            {
                ex.HandleExceptionDouble();
            }
            return null;
        }


    }
}
