using DataWarehouse.Interfaces;
using ErrorHandler;
using System.Data.Odbc;

namespace OdbcWarehouse.Interface
{
    public partial class DataBaseInterface : IDatabaseCoordinator, IDatabaseInterface
    {
        void Init()
        {

        }

        public DataBaseInterface() 
        {
            Init();
        }

        IDirectory[] roots;

        public DataBaseInterface(string connencion)
        {
            Init();
            Connection = connencion;
        }


        public string Connection { get; init; }

        #region Interface Membres

        IDatabaseInterface IDatabaseCoordinator.this[string name] => Get(name);

        bool IDatabaseCoordinator.Create(string name)
        {
            throw new OwnNotImplemented("Odbc");
        }

 
        #endregion

        public IDatabaseInterface Get(string name)
        {
            try
            {
                using var c = new OdbcConnection(name);
            }
            catch
            {
                return null;
            }
            using (var conn = new OdbcConnection(name))
            {
                try
                {
                    conn.Open();
                    return new DataBaseInterface(name);
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