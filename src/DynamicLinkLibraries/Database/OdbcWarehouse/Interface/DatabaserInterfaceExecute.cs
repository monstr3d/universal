using DataWarehouse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdbcWarehouse.Interface
{
    partial class DataBaseInterface
    {
        internal ILeafData Get(IDirectory directory, ILeafData leaf)
        {
            return Execute(Get, directory, leaf);
        }

        internal List<IDirectory> GetChildren(IDirectory d)
        {
            return Execute(GetChildren, d);
        }

        internal byte[] GetData(ILeafData leaf)
        {
            return Execute(GetData, leaf);
        }

        internal object Remove(IDirectory directory)
        {
            return Execute(Remove, directory);
        }

        internal object Remove(ILeaf leaf)
        {
            return Execute(Remove, leaf);
        }

        internal object SetData(ILeafData leaf, byte[] data)
        {
            return Execute(SetData, leaf, data);
        }



        IDirectory[] IDatabaseInterface.GetRoots(params string[] extensions)
        {
            if (roots == null)
            {
                roots = Execute(GetCommandRoots);
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


        internal List<ILeaf> GetLeaves(IDirectory d)
        {
            return Execute(GetLeaves, d);
        }

        internal object SetName(IDirectory directory, string name)
        {
            return Execute(SetName, directory, name);
        }

        internal object SetName(ILeaf leaf, string name)
        {
            return Execute(SetName, leaf, name);
        }
        internal object SetDescription(ILeaf leaf, string desription)
        {
            return Execute(SetDescription, leaf, desription);
        }


        internal object SetDescription(IDirectory directory, string desription)
        {
            return Execute(SetDescription, directory, desription);
        }



    }
}
