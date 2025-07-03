using Npgsql;
using System.Data;

using DataWarehouse;
using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;
using ErrorHandler;

namespace PostgreSQLWarehouse.Async
{
    partial class PostgreSQLWarehouseInterface
    {
        async Task<byte[]> GetDataAsync(NpgsqlCommand command, ILeaf leaf)
        {
            Init();
            try
            {
                string sqlQuery = $"SELECT \"Data\" FROM public.\"BinaryTable\" WHERE \"Id\" = @idd";
                command.Parameters.AddWithValue("@idd", leaf.Id);
                command.CommandText = sqlQuery;
                var i = command.ExecuteReaderAsync();
                await i;
                var k = i.Result;
                if (k.Read())
                {
                    return (byte[])k["data"];
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;
        }


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
                l.Add(new Directory(x, this, false));
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
                    var dr = new Directory(x, d, this, false);
                    list.Add(dr);
                }

            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return list;
        }

        private void Add(NpgsqlCommand command, string s, object o)
        {
            command.Parameters.AddWithValue(s, o);
        }

        async Task<ILeafAsync> Add(NpgsqlCommand command, IDirectory parent, ILeafData leaf)
        {
            try
            {
                var directory = parent;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "public.\"CreateTable\"";
                var g = Guid.NewGuid();
                Add(command, "id", g);
                Add(command, "parent", directory.Id);
                Add(command, "name", leaf.Name);
                Add(command, "description", leaf.Description);
                Add(command, "data", leaf.Data);
                Add(command, "extension", leaf.Extension);
                var i = command.ExecuteNonQueryAsync();
                await i;
                return (i.Result == -1) ? new Leaf(leaf, directory, g, this) : null;

            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;
        }

        async Task<string> UpdateDirNameAsync(NpgsqlCommand command, string name, IDirectory parent)
        {
            string sqlQuery = $"UPDATE public.\"BinaryTree\" SET  \"Name\"=@name  WHERE \"Id\" = @idd;";
            // Double quotes for column name, @ for parameter
            command.Parameters.AddWithValue("@idd", parent.Id);
            command.Parameters.AddWithValue("@name", name);
            command.CommandText = sqlQuery;
            var i = command.ExecuteNonQueryAsync();
            await i;
            return (i.Result == 1) ? name : null;
        }
        async Task<string> UpdateDirDecriptionAsync(NpgsqlCommand command, string descrption, IDirectory parent)
        {
            string sqlQuery = $"UPDATE public.\"BinaryTree\" SET  \"Description\"=@descrption WHERE \"Id\" = @idd;";
            // Double quotes for column name, @ for parameter
            command.Parameters.AddWithValue("@idd", parent.Id);
            command.Parameters.AddWithValue("@descrption", descrption);
            command.CommandText = sqlQuery;
            var i = command.ExecuteNonQueryAsync();
            await i;
            return (i.Result == 1) ? descrption : null;
        }

        async Task<string> UpdateLeafNameAsync(NpgsqlCommand command, string name, ILeaf leaf)
        {
            string sqlQuery = $"UPDATE public.\"BinaryTablr\" SET  \"Name\"=@name  WHERE \"Id\" = @idd;";
            // Double quotes for column name, @ for parameter
            command.Parameters.AddWithValue("@idd", parent.Id);
            command.Parameters.AddWithValue("@name", name);
            command.CommandText = sqlQuery;
            var i = command.ExecuteNonQueryAsync();
            await i;
            return (i.Result == 1) ? name : null;
        }
        async Task<string> UpdateLeafrDecriptionAsync(NpgsqlCommand command, string descrption, ILeaf leaf)
        {
            string sqlQuery = $"UPDATE public.\"BinaryTable\" SET  \"Description\"=@descrption WHERE \"Id\" = @idd;";
            // Double quotes for column name, @ for parameter
            command.Parameters.AddWithValue("@idd", parent.Id);
            command.Parameters.AddWithValue("@descrption", descrption);
            command.CommandText = sqlQuery;
            var i = command.ExecuteNonQueryAsync();
            await i;
            return (i.Result == 1) ? descrption : null;
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
                    return new Directory(directory, id, this, true);
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

        async Task<byte[]> UpdateDataAcync(NpgsqlCommand command, byte[] data, ILeafData leaf)
        {
            Init();
            try
            {
                string sqlQuery = $"UPDATE public.\"BinaryTable\" SET  \"Data\"=@data WHERE \"Id\" = @idd;";
                // Double quotes for column name, @ for parameter
                command.Parameters.AddWithValue("@idd", leaf.Id);
                command.Parameters.AddWithValue("@data", data);
                command.CommandText = sqlQuery;
                var i = command.ExecuteNonQueryAsync();
                await i;
                return (i.Result == 1) ? data : null;
            }
            catch (Exception e)
            {
                e.ShowError();
            }
            return null;
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
