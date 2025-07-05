using DataWarehouse.Interfaces;

namespace PostgreSQLWarehouse
{

    public partial class PostgreSQLWarehouseInterface : IDatabaseInterface
    {
        public string Connection { get; init; }

        protected IDirectory[] roots;
        
        protected void Init()
        {

        }

        public PostgreSQLWarehouseInterface(string connection)
        {
            this.Connection = connection;
        }

        #region Interface Implementstion

        protected virtual void GetRoots()
        {
            roots = Execute(GetCommandRoots);
        }

        
        

        IDirectory[] IDatabaseInterface.GetRoots(params string[] extensions)
        {
            if (roots == null)
            {
                GetRoots();
   //             roots = Execute(GetCommandRoots);
                if (roots.Length > 1)
                {
                    Execute(DropTree);
                    CreateRoots();
                }
                if (roots.Length == 0)
                {
                    CreateRoots();
                }
            }
            return roots;
        }

        #endregion

    }

}

