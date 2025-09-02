using System.Data;

using Npgsql;

using DataWarehouse;
using DataWarehouse.Interfaces;
using ErrorHandler;

namespace PostgreSQLWarehouse
{
    partial class PostgreSQLWarehouseInterface
    {
        object DropTree(NpgsqlCommand command)
        {
            command.CommandText = "DELETE FROM public.\"BinaryTree\" CASCADE;";
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            return null;

        }

        public void CreateRootsPublic()
        {
            CreateRoots();
        }

        void CreateRoots()
        {
            var t = Insert(null);
            var d = new Directory(t, this, false);
            roots = [d];
        }

        IDirectory[] GetCommandRoots(NpgsqlCommand command)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SelectRoots";
            command.CommandText = "SELECT \"Id\", \"ParentId\", \"Name\", \"Description\", \"ext\" \r \n FROM public.\"BinaryTree\"  WHERE \"Id\"=\"ParentId\";";
            var reader = command.ExecuteReader();
            var l = new List<IDirectory>();
            foreach (IDataRecord x in reader)
            {
                l.Add(new Directory(x, this, false));
            }
            return l.ToArray();
        }


        void Add(NpgsqlCommand command, string name, object value)
        {
            var p = command.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            command.Parameters.Add(p); ;
        }


        internal Tuple<Guid, Guid, string, string, string> Insert(NpgsqlCommand command, Tuple<Guid, Guid, string, string, string> t)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "public.\"InsertTree\"";
            Add(command, "id", t.Item1);
            Add(command, "parent", t.Item2);
            Add(command, "name", t.Item3);
            Add(command, "description", t.Item4);
            Add(command, "ext", t.Item5);
            var i = command.ExecuteNonQuery();
            return (i == -1) ? t : null;
        }



        internal Tuple<Guid, Guid, string, string, string> Insert(Tuple<Guid, IDirectory> dir)
        {
            var d = dir;
            var g = Guid.NewGuid();
            if (d == null)
            {
                d = new Tuple<Guid, IDirectory>(g, null);
            }
            var directory = d.Item2;
            Tuple<Guid, Guid, string, string, string> t = null;
            t = (directory == null) ?
                new Tuple<Guid, Guid, string, string, string>(g, g, "/", "Root", "") :
                new Tuple<Guid, Guid, string, string, string>(g, d.Item1, directory.Name, directory.Description, directory.Extension);

            t = Execute(Insert, t);
            return t;
        }


        internal ILeafData Get(IDirectory directory, ILeafData leaf)
        {
            return Execute(Get, directory, leaf);
        }

        internal List<IDirectory> GetChildren(IDirectory d)
        {
            return Execute(GetChildren, d);
        }

        internal byte[] GetData(ILeafData leaf)
        {
            return Execute(GetData, leaf);
        }

        internal object Remove(IDirectory directory)
        {
            return Execute(Remove, directory);
        }

        internal object Remove(ILeaf leaf)
        {
            return Execute(Remove, leaf);
        }


        object Remove(NpgsqlCommand command, IDirectory directory)
        {
            try
            {
                var q = $"DELETE FROM public.\"BinaryTree\" WHERE \"Id\" = @idd;";
                command.Parameters.AddWithValue("@idd", directory.Id);
                command.CommandText = q;
                var i = command.ExecuteNonQuery();
                return (i == 1) ? new object() : null;
            }
            catch (Exception e)
            {
                e.ShowError();
            }
            return null;
        }


        object Remove(NpgsqlCommand command, ILeaf leaf)
        {
            try
            {
                var q = $"DELETE FROM public.\"BinaryTable\" WHERE \"Id\" = @idd;";
                command.Parameters.AddWithValue("@idd", leaf.Id);
                command.CommandText = q;
                var i = command.ExecuteNonQuery();
                return (i == 1) ? new object() : null;
            }
            catch (Exception e)
            {
                e.ShowError();
            }
            return null;
        }

        internal object SetData(ILeafData leaf, byte[] data)
        {
            return Execute(SetData, leaf, data);
        }

        object SetData(NpgsqlCommand command, ILeafData leaf, byte[] data)
        {
            try
            {
                string sqlQuery = $"UPDATE public.\"BinaryTable\" SET  \"Data\"=@data WHERE \"Id\" = @idd;";
                // Double quotes for column name, @ for parameter
                command.Parameters.AddWithValue("@idd", leaf.Id);
                command.Parameters.AddWithValue("@data", data);
                command.CommandText = sqlQuery;
                var i = command.ExecuteNonQuery();
                return (i == 1) ? new object() : null;
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;
        }


        internal object SetDescription(IDirectory directory, string desription)
        {
            return Execute(SetDescription, directory, desription);
        }

        object SetDescription(NpgsqlCommand command, IDirectory directory, string desription)
        {
            try
            {
                string sqlQuery = $"UPDATE public.\"BinaryTree\" SET  \"Description\"=@desription  WHERE \"Id\" = @idd;";
                // Double quotes for column name, @ for parameter
                command.Parameters.AddWithValue("@idd", directory.Id);
                command.Parameters.AddWithValue("@desription", desription);
                command.CommandText = sqlQuery;
                var i = command.ExecuteNonQuery();
                return (i == 1) ? new object() : null;
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;
        }




        internal object SetDescription(ILeaf leaf, string desription)
        {
            return Execute(SetDescription, leaf, desription);
        }

        object SetDescription(NpgsqlCommand command, ILeaf leaf, string desription)
        {
            try
            {
                string sqlQuery = $"UPDATE public.\"BinaryTable\" SET  \"Description\"=@desription  WHERE \"Id\" = @idd;";
                command.Parameters.AddWithValue("@idd", leaf.Id);
                command.Parameters.AddWithValue("@desription", desription);
                command.CommandText = sqlQuery;
                var i = command.ExecuteNonQuery();
                return (i == 1) ? new object() : null;
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;
        }


        internal object SetName(ILeaf leaf, string name)
        {
            return Execute(SetName, leaf, name);
        }

        object SetName(NpgsqlCommand command, ILeaf leaf, string name)
        {
            try
            {
                string sqlQuery = $"UPDATE public.\"BinaryTable\" SET  \"Name\"=@name  WHERE \"Id\" = @idd;";
                // Double quotes for column name, @ for parameter
                command.Parameters.AddWithValue("@idd", leaf.Id);
                command.Parameters.AddWithValue("@name", name);
                command.CommandText = sqlQuery;
                var i = command.ExecuteNonQuery();
                return (i == 1) ? new object() : null;
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;
        }

        internal object SetName(IDirectory directory, string name)
        {
            return Execute(SetName, directory, name);
        }

        object SetName(NpgsqlCommand command, IDirectory directory, string name)
        {
            try
            {
                string sqlQuery = $"UPDATE public.\"BinaryTree\" SET  \"Name\"=@name  WHERE \"Id\" = @idd;";
                command.Parameters.AddWithValue("@idd", directory.Id);
                command.Parameters.AddWithValue("@name", name);
                command.CommandText = sqlQuery;
                var i = command.ExecuteNonQuery();
                return (i == 1) ? new object() : null;
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;
        }


        byte[] GetData(NpgsqlCommand command, ILeafData leaf)
        {
            try
            {
                string sqlQuery = $"SELECT \"Data\" FROM public.\"BinaryTable\" WHERE \"Id\" = @idd";
                command.Parameters.AddWithValue("@idd", leaf.Id);
                command.CommandText = sqlQuery;
                var i = command.ExecuteReader();
                if (i.Read())
                {
                    return (byte[])i["data"];
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        List<IDirectory> GetChildren(NpgsqlCommand command, IDirectory d)
        {
            var list = new List<IDirectory>();
            try
            {
                string sqlQuery = $"SELECT * FROM public.\"BinaryTree\" WHERE \"ParentId\" = @idd AND \"ParentId\" <> \"Id\"";
                // Double quotes for column name, @ for parameter
                command.Parameters.AddWithValue("@idd", d.Id);
                command.CommandText = sqlQuery;

                var i = command.ExecuteReader();
                foreach (IDataRecord x in i)
                {
                    var dr = new Directory(x, d, this, false);
                    list.Add(dr);
                }

            }
            catch (Exception ex)
            {

            }
            return list;
        }

        internal List<ILeaf> GetLeaves(IDirectory d)
        {
            return Execute(GetLeaves, d);
        }

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


        ILeafData Get(NpgsqlCommand command, IDirectory directory, ILeafData leaf)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "public.\"CreateTable\"";
            var g = Guid.NewGuid();
            Add(command, "id", g);
            Add(command, "parent", directory.Id);
            Add(command, "name", leaf.Name);
            Add(command, "description", leaf.Description);
            Add(command, "data", leaf.Data);
            Add(command, "extension", leaf.Extension);
            var i = command.ExecuteNonQuery();
            return (i == -1) ? new Leaf(leaf, directory, g, this) : null;

        }

    }
}
