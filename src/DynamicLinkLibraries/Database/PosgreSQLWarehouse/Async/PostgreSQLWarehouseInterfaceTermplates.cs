using ErrorHandler;
using Npgsql;

namespace PostgreSQLWarehouse.Async
{
    partial class PostgreSQLWarehouseInterface
    {
        async Task<T> Execute<T>(Func<NpgsqlCommand, Task<T>> func) where T : class
        {
            try
            {
                using var conn = new NpgsqlConnection(Connection);
                var c =  conn.OpenAsync();
                await c;
                var cmd = conn.CreateCommand();
                var t =   func(cmd);
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
