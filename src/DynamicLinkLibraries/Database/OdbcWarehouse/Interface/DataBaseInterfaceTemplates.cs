using System.Data.Odbc;

using DataWarehouse.Interfaces;

using ErrorHandler;


namespace OdbcWarehouse.Interface
{
    partial class DataBaseInterface
    {

        #region Templates

        public T Execute<T>(Func<OdbcCommand, T> func) where T : class
        {
            try
            {
                using var conn = new OdbcConnection(Connection);
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


        public T Execute<T, S>(Func<OdbcCommand, S, T> func, S s) where T : class where S : class
        {
            try
            {
                using var conn = new OdbcConnection(Connection);
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

        public T Execute<T, S, Q>(Func<OdbcCommand, Q, S, T> func, Q q, S s) where T : class where Q : class where S : class
        {
            try
            {
                using var conn = new OdbcConnection(Connection);
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


        public T Execute<T>(Func<OdbcConnection, T> func) where T : class
        {
            try
            {
                using (var conn = new OdbcConnection(Connection))
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