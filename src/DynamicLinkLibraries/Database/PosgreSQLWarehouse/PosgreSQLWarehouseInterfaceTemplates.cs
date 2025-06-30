using Npgsql;

using ErrorHandler;

namespace PosgreSQLWarehouse
{
    partial class PosgreSQLWarehouseInterface
    {

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



        public T Execute<T, S>(Func<NpgsqlCommand, S, T> func, S s) where T : class where S : class
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

    }
}
