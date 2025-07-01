using DataWarehouse.Interfaces;
using ErrorHandler;
using Npgsql;
using System.Threading.Tasks;

namespace PostgreSQLWarehouse
{
    public class PostgreSQLWarehouseCoordinator : IDatabaseCoordinator
    {

        public PostgreSQLWarehouseCoordinator()
        {

        }
        IDatabaseInterface IDatabaseCoordinator.this[string name] => Get(name);

        bool IDatabaseCoordinator.Create(string name)
        {
            throw new OwnNotImplemented("PosgreSQLWarehouseCoordinator");
        }

        public IDatabaseInterface Get(string name)
        {
            try
            {
                new NpgsqlConnection(name);
            }
            catch
            {
                return null;
            }
            using (var conn = new NpgsqlConnection(name))
            {
                try
                {
                    conn.Open(); ;
                    return new Async.PostgreSQLWarehouseInterface(name);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return null;
        }
    }
}
