using DataWarehouse.Interfaces;
using ErrorHandler;
using NamedTree;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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

        IDirectory[] IDatabaseInterface.GetRoots(params string[] extensions)
        {
            if (roots == null)
            {
                roots = Execute(GetCommandRoots);
            }
            return roots;
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

        public IDirectory[] GetCommandRoots(NpgsqlCommand command)
        {
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
            var l = new List<IDirectory>();
            foreach (IDataRecord x in reader)
            {
                l.Add(new Directory(x, this));
            }
            return l.ToArray();
        }

  
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
            }
        }
    }
}
