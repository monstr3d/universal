using DataWarehouse.Interfaces;
using ErrorHandler;
using Npgsql;
using System;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PosgreSQLWarehouse
{

    public class PosgreSQLWarehouseInterface : IDatabaseInterface
    {
        public string Connection {  get; init; }

        IDirectory[] roots;

        public PosgreSQLWarehouseInterface(string connection)
        {
            this.Connection = connection;
        }

        #region Interface Implementstion

        IDirectory[] IDatabaseInterface.GetRoots(params string[] extensions)
        {
            if (roots == null)
            {
                roots = Execute(GetCommandRoots);
                if (roots.Length > 1)
                {
                    DropTree(null);
                    throw new OwnException("Shuold drop");
                }
                if (roots.Length == 0)
                {
                    var t = Insert(null);
                    var d = new Directory(t, this);
                    roots = [d];
                }
            }
            return roots;
        }


        #endregion

        #region Templates

        object DropTree(NpgsqlCommand command)
        {
            return null;
        }

        public T Execute<T>(Func<NpgsqlCommand, T> func) where T : class
        {
            try
            {
                using var conn = new NpgsqlConnection(Connection);
                conn.Open();
                using var cmd = conn.CreateCommand();
                return func(cmd);
            }
            catch (Exception ex)
            {
                ex.HandleExceptionDouble();
            }
            return null;
        }



        public T Execute<T,S>(Func<NpgsqlCommand, S, T> func, S s) where T : class where S : class
        {
            try
            {
                using var conn = new NpgsqlConnection(Connection);
                conn.Open();
                using var cmd = conn.CreateCommand();
                return func(cmd, s);
            }
            catch (Exception ex)
            {
                ex.HandleExceptionDouble();
            }
            return null;

        }

        public T Execute<T, S, Q>(Func<NpgsqlCommand, Q, S, T> func, Q q, S s) where T : class where Q : class where S : class
        {
            try
            {
                using var conn = new NpgsqlConnection(Connection);
                conn.Open();
                using var cmd = conn.CreateCommand();
                return func(cmd, q, s);
            }
            catch (Exception ex)
            {
                ex.HandleExceptionDouble();
            }
            return null;

        }





        public T Execute<T>(Func<NpgsqlConnection, T> func) where T : class
        {
            try
            {
                using (var conn = new NpgsqlConnection(Connection))
                {
                    conn.Open();
                    return func(conn);
                }
            }
            catch (Exception ex)
            {
                ex.HandleExceptionDouble();
            }
            return null;
        }

        #endregion

        /*
         INSERT INTO public."BinaryTree"(
       "Id", "ParentId", "Name", "Description", ext)
       VALUES (?, ?, ?, ?, ?);
        */


        IDirectory[] GetCommandRoots(NpgsqlCommand command)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SelectRoots";
            command.CommandText = "SELECT \"Id\", \"ParentId\", \"Name\", \"Description\", \"ext\" \r \n FROM public.\"BinaryTree\"";
            //     command.CommandText = "SELECT \"Id\"  FROM \"BinaryTree\"";
            //            var reader = command.ExecuteReader();
          //  command.CommandText = "SELECT \"Id\", \"ParentId\", \"Name\", \"Description\", \"ext\"  FROM public.\"BinaryTree\" WHERE \"Id\"=\"ParentId\"";
            //         command.CommandText = "public.\"SelectRoots\"";
            //         command.CommandText = "public.\"SelectBinaryTree\"";
            //         command.CommandType = System.Data.CommandType.StoredProcedure;
            var reader = command.ExecuteReader();
            var l = new List<IDirectory>();
            foreach (IDataRecord x in reader)
            {
                l.Add(new Directory(x, this));
            }
            return l.ToArray();
        }

        void Add(NpgsqlCommand command, string name, object value)
        {
            var p = command.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            command.Parameters.Add(p);;
        }


        internal Tuple<Guid, Guid, string, string, string>  Insert(NpgsqlCommand command, Tuple<Guid, Guid, string, string, string> t)
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

  

        internal Tuple<Guid, Guid, string, string, string> Insert(Tuple<Guid,IDirectory> dir)
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
            Add(command, "ext", leaf.Extension);
            var i = command.ExecuteNonQuery();
            return (i == -1) ? new Leaf(leaf, directory, g, this) : null;

        }


        /*
              public IDirectory[] GetRoots(NpgsqlConnection connection)
              {
                  using (NpgsqlCommand command = new NpgsqlCommand())
                  {
                      command.Connection = connection;
                      command.CommandType = System.Data.CommandType.Text;
                      command.CommandText = "SelectRoots";
                      command.CommandText = "SELECT \"Id\", \"ParentId\", \"Name\", \"Description\", \"ext\"  FROM public.\"BinaryTree\"";
                      //     command.CommandText = "SELECT \"Id\"  FROM \"BinaryTree\"";
                      //            var reader = command.ExecuteReader();
                      command.CommandText = "SELECT \"Id\", \"ParentId\", \"Name\", \"Description\", \"ext\"  FROM public.\"BinaryTree\" WHERE \"Id\"=\"ParentId\"";
             //         command.CommandText = "public.\"SelectRoots\"";
             //         command.CommandText = "public.\"SelectBinaryTree\"";
             //         command.CommandType = System.Data.CommandType.StoredProcedure;
                      var reader = command.ExecuteReader();
                      foreach (IDataRecord x in reader)
                      {

                      }
                      return null;
                  }*/
    }
}

