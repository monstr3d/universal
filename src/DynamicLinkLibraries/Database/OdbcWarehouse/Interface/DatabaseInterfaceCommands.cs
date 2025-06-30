using DataWarehouse;
using DataWarehouse.Interfaces;
using ErrorHandler;
using NamedTree;
using System.Data;
using System.Data.Odbc;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace OdbcWarehouse.Interface
{
    partial class DataBaseInterface
    {
        object DropTree(OdbcCommand command)
        {
            Init();
            command.CommandText = "DELETE FROM binarytree CASCADE;";
            command.CommandType = CommandType.Text;
            command.ExecuteNonQuery();
            return null;

        }

        void CreateRoots()
        {
            var t = Insert(null);
            var d = new Directory(t, this);
            roots = [d];
        }




        IDirectory[] GetCommandRoots(OdbcCommand command)
        {
            Init();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SelectRoots";
            command.CommandText = "SELECT \"Id\", \"ParentId\", \"Name\", \"Description\", \"ext\" \r \n FROM binarytree  WHERE \"Id\"=\"ParentId\";";
            var reader = command.ExecuteReader();
            var l = new List<IDirectory>();
            foreach (IDataRecord x in reader)
            {
                l.Add(new Directory(x, this));
            }
            return l.ToArray();
        }


        void Add(OdbcCommand command, string name, object value)
        {
            Init();
            var p = command.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            command.Parameters.Add(p); ;
        }


        internal IDirectory Insert(OdbcCommand command, IDirectory directory)
        {
            Init();

            // CALL `mysqlwarehouse`.`insert_root`(<{id bigint}>, <{PareantId bigint}>, <{Name text}>,
            // <{description text}>, <{extension text}>);
            var conn = command.Connection;
            var stream = new MemoryStream();
            var cont = conn.Container;
            var p = conn.GetSchema();
             p.WriteXml(stream);
            stream.Position = 0;
            var reader = new StreamReader(stream);
            var s = reader.ReadToEnd();

            command.CommandType = CommandType.StoredProcedure;
            try
            {
                command.CommandText = "fiction";
                command.CommandText = $"`mysqlwarehouse`.`fiction`";
                var ll = command.ExecuteNonQuery();
           //     command.CommandType = CommandType.Text;
           //     command.CommandText = $"SELECT `binarytree`.`Id`, `binarytree`.`ParentId`,`binarytree`.`Name`,`binarytree`.`Description`,  `binarytree`.`Extension` FROM `mysqlwarehouse`.`binarytree`";
           //     var l = command.ExecuteReader();
                decimal parentId = 0;
                decimal id = 0;
                IDirectory dir = null;
                if (directory == null)
                {
                    decimal i = 0;
                    dir = new DataWarehouse.Classes.Directory(i, "/", "root", "");
                    var sql = $"`mysqlwarehouse`.`insert_root`";

                    command.Parameters.AddWithValue("Name", dir.Name);
                    command.Parameters.AddWithValue("description", dir.Description);
                    command.Parameters.AddWithValue("extension", dir.Extension);
                    command.CommandText = sql;
                    var lt = command.ExecuteNonQuery();
                    return dir;
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
                throw new OwnNotImplemented();
            }
            return null;
        }

        internal Tuple<decimal, decimal, string, string, string> Insert(OdbcCommand command, Tuple<decimal, decimal, string, string, string> t)
        {
            Init();
            var query = "";
            command.CommandType = CommandType.Text;

            if (t.Item1 == 0)
            {
                Add(command, "id", t.Item1);
                Add(command, "parent", t.Item2);
                query = "";
            }
            else
            {

            }
            Add(command, "name", t.Item3);
            Add(command, "description", t.Item4);
            Add(command, "ext", t.Item5);
            var i = command.ExecuteNonQuery();
            return (i == -1) ? t : null;
        }

        internal IDirectory Insert(IDirectory directory)
        {
            return Execute(Insert, directory);
        }




        object Remove(OdbcCommand command, IDirectory directory)
        {
            Init();
            try
            {
                var q = $"DELETE FROM binarytree WHERE \"Id\" = @idd;";
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


        object Remove(OdbcCommand command, ILeaf leaf)
        {
            Init();
            try
            {
                var q = $"DELETE FROM binarytable WHERE \"Id\" = @idd;";
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

        object SetData(OdbcCommand command, ILeafData leaf, byte[] data)
        {
            Init();
            try
            {
                string sqlQuery = $"UPDATE binarytable SET  \"Data\"=@data WHERE \"Id\" = @idd;";
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


        object SetDescription(OdbcCommand command, IDirectory directory, string desription)
        {
            Init();
            try
            {
                string sqlQuery = $"UPDATE binarytree SET  \"Description\"=@desription  WHERE \"Id\" = @idd;";
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





        object SetDescription(OdbcCommand command, ILeaf leaf, string desription)
        {
            Init();
            try
            {
                string sqlQuery = $"UPDATE binarytable SET  \"Description\"=@desription  WHERE \"Id\" = @idd;";
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



        object SetName(OdbcCommand command, ILeaf leaf, string name)
        {
            Init();
            try
            {
                string sqlQuery = $"UPDATE binarytable SET  \"Name\"=@name  WHERE \"Id\" = @idd;";
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


        object SetName(OdbcCommand command, IDirectory directory, string name)
        {
            Init();
            try
            {
                string sqlQuery = $"UPDATE binarytree SET  \"Name\"=@name  WHERE \"Id\" = @idd;";
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


        byte[] GetData(OdbcCommand command, ILeafData leaf)
        {
            Init();
            try
            {
                string sqlQuery = $"SELECT \"Data\" FROM binarytable WHERE \"Id\" = @idd";
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

        List<IDirectory> GetChildren(OdbcCommand command, IDirectory d)
        {
            Init();
            var list = new List<IDirectory>();
            try
            {
                //command.CommandType = CommandType.StoredProcedure;
                // command.CommandText = "public.\"TreeFunc";
                // Add(command, "idd", d.Id);
                //command.Parameters.AddWithValue("idd", d.Id);
                string sqlQuery = $"SELECT * FROM binarytree WHERE \"ParentId\" = @idd AND \"ParentId\" <> \"Id\"";
                // Double quotes for column name, @ for parameter
                command.Parameters.AddWithValue("@idd", d.Id);
                command.CommandText = sqlQuery;

                var i = command.ExecuteReader();
                foreach (IDataRecord x in i)
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
        List<ILeaf> GetLeaves(OdbcCommand command, IDirectory d)
        {
            Init();
            var list = new List<ILeaf>();
            try
            {
                //command.CommandType = CommandType.StoredProcedure;
                // command.CommandText = "public.\"TreeFunc";
                // Add(command, "idd", d.Id);
                //command.Parameters.AddWithValue("idd", d.Id);
                string sqlQuery = $"SELECT \"Id\", \"ParentId\", \"Name\", \"Description\", \"ext\" FROM binarytable WHERE \"ParentId\" = @idd"; // Double quotes for column name, @ for parameter
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


        ILeafData Get(OdbcCommand command, IDirectory directory, ILeafData leaf)
        {
            try
            {
                Init();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "public.\"CreateTable\"";
                //    var g = Guid.NewGuid();
                decimal g = 0;
                throw new OwnNotImplemented("decimal");
                Add(command, "id", g);
                Add(command, "parent", directory.Id);
                Add(command, "name", leaf.Name);
                Add(command, "description", leaf.Description);
                Add(command, "data", leaf.Data);
                Add(command, "extension", leaf.Extension);
                var i = command.ExecuteNonQuery();
                return (i == -1) ? new Leaf(leaf, directory, g, this) : null;

            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;
        }
    }
}