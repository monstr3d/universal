using System.Data;

using Npgsql;

using DataWarehouse.Interfaces;
using ErrorHandler;

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
            }
            return roots;
        }


        #endregion

        #region Templates

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
            command.CommandText = "SELECT \"Id\", \"ParentId\", \"Name\", \"Description\", \"ext\"  FROM public.\"BinaryTree\" WHERE \"Id\"=\"ParentId\"";
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

        void Add(NpgsqlCommand command, object value)
        {
            var p = command.CreateParameter();
            p.Value = value;
            command.Parameters.Add(p);
        }

        internal IDirectory Insert(NpgsqlCommand command, IDirectory directory)
         {
            command.CommandType = CommandType.Text;
            var comm = "INSERT INTO public.\"BinaryTree\"(\"Id\", \"ParentId\", \"Name\", \"Description\", \"ext\")" +
                " VALUES(?, ?, ?, ?, ?);";
            command.CommandText = comm;
            var guid = Guid.NewGuid();
            Add(command, guid);
            Add(command, directory.Id);
            Add(command, directory.Name);
            Add(command, directory.Description);
            Add(command, directory.Extension);;
            var t = command.ExecuteNonQuery();
            return new Directory(directory, guid, this);
        }

        internal IDirectory Insert(IDirectory directory)
        {
           return Execute(Insert, directory);
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

