using DataWarehouse.Interfaces;
using ErrorHandler;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosgreSQLWarehouse
{
    public class PosgreSQLWarehouseCoordinator : IDatabaseCoordinator
    {

        public PosgreSQLWarehouseCoordinator()
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
                    conn.Open();
                    return new PosgreSQLWarehouseInterface(name);
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
