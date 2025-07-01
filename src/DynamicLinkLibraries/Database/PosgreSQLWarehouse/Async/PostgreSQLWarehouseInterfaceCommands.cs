using DataWarehouse;
using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using ErrorHandler;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PostgreSQLWarehouse.Async
{
    partial class PostgreSQLWarehouseInterface
    {
        async Task<IEnumerable<IDirectoryAsync>> GetCommandRootsAsync(NpgsqlCommand command)
        {
            Init();
            
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SelectRoots";
            command.CommandText = "SELECT \"Id\", \"ParentId\", \"Name\", \"Description\", \"ext\" \r \n FROM public.\"BinaryTree\"  WHERE \"Id\"=\"ParentId\";";
            var reader = command.ExecuteReaderAsync();
            await reader;
            var r = reader.Result;
            var l = new List<IDirectoryAsync>();
            foreach (IDataRecord x in r)
            {
                l.Add(new Directory(x, this));
            }
            return l;
        }

        

        async Task<List<IDirectoryAsync>> GetChildrenAsync(NpgsqlCommand command, IDirectory d)
        {
            Init();
            var list = new List<IDirectoryAsync>();
            try
            {
                //command.CommandType = CommandType.StoredProcedure;
                // command.CommandText = "public.\"TreeFunc";
                // Add(command, "idd", d.Id);
                //command.Parameters.AddWithValue("idd", d.Id);
                string sqlQuery = $"SELECT * FROM public.\"BinaryTree\" WHERE \"ParentId\" = @idd AND \"ParentId\" <> \"Id\"";
                // Double quotes for column name, @ for parameter
                command.Parameters.AddWithValue("@idd", d.Id);
                command.CommandText = sqlQuery;

                var i = command.ExecuteReaderAsync();
                await i;
                foreach (IDataRecord x in i.Result)
                {
                    var dr = new Directory(x, d, this);
                    list.Add(dr);
                }

            }
            catch (Exception ex)
            {

            }
            return list;
        }

        private void Add(NpgsqlCommand command, string s, object o)
        {
            command.Parameters.AddWithValue(s, o);
        }

        async Task<IDirectoryAsync> Add(NpgsqlCommand command, IDirectory parent, IDirectory directory)
        {
            try
            {
                var id = Guid.NewGuid();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "public.\"InsertTree\"";
                Add(command, "id", id);
                Add(command, "parent", parent.Id);
                Add(command, "name", directory.Name);
                Add(command, "description", directory.Description);
                Add(command, "ext", directory.Extension);
                var i = command.ExecuteNonQueryAsync();
                await i;
                if (i.Result == -1)
                {
                    return new Directory(directory, id, this);
                }

                return null;
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;
        }

        async Task<object> RemoveAsync(NpgsqlCommand command, IDirectory directory)
        {
            Init();
            try
            {
                var q = $"DELETE FROM public.\"BinaryTree\" WHERE \"Id\" = @idd;";
                command.Parameters.AddWithValue("@idd", directory.Id);
                command.CommandText = q;
                var i = command.ExecuteNonQueryAsync();
                await i;
                return (i.Result == 1) ? new object() : null;
            }
            catch (Exception e)
            {
                e.ShowError();
            }
            return false;
        }

        async Task<object> RemoveAsync(NpgsqlCommand command, ILeaf leaf)
        {
            Init();
            try
            {
                var q = $"DELETE FROM public.\"BinaryTable\" WHERE \"Id\" = @idd;";
                command.Parameters.AddWithValue("@idd", leaf.Id);
                command.CommandText = q;
                var i = command.ExecuteNonQueryAsync();
                await i;
                return (i.Result == 1) ? new object() : null;
            }
            catch (Exception e)
            {
                e.ShowError();
            }
            return false;
        }


        async Task<List<ILeafAsync>> GetLeavesAsync(NpgsqlCommand command, IDirectory d)
        {
            Init();
            var list = new List<ILeafAsync>();
            try
            {
                string sqlQuery = $"SELECT \"Id\", \"ParentId\", \"Name\", \"Description\", \"ext\" FROM public.\"BinaryTable\" WHERE \"ParentId\" = @idd"; // Double quotes for column name, @ for parameter
                command.Parameters.AddWithValue("@idd", d.Id);
                command.CommandText = sqlQuery;

                var i = command.ExecuteReaderAsync();
                await i;
                foreach (IDataRecord x in i.Result)
                {
                    var dr = new Leaf(x, d, this);
                    list.Add(dr);
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return list;
        }




    }
}
