using System;
using System.Collections.Generic;
using System.Linq;

using DataWarehouse.Interfaces;
using ErrorHandler;
using NamedTree;
using SQLServerWarehouse.Models;

namespace SQLServerWarehouse
{
    public partial class DataWarehouseContext : IDatabaseInterface
    {

        #region Fields


        List<IDirectory> roots = new List<IDirectory>();

        Dictionary<Guid, ILeaf> data = 
            new Dictionary<Guid, ILeaf>();

        Dictionary<Guid, INode> dictionary = new Dictionary<Guid, INode>();

        Dictionary<object, object> Leaves
        {
            get;
            set;
        } = new Dictionary<object, object>();


        #endregion

        #region Interface implementation

        IDirectory[] IDatabaseInterface.GetRoots(params string[] extensions)
        {
            return roots.ToArray();
        }


        #endregion

        #region Members

        internal void Init()
        {
            var trees = BinaryTrees.Where(s => true);
            foreach (var tree in trees)
            {
                if (tree.Id == tree.ParentId)
                {
                    roots.Add(tree);
                }
                dictionary[tree.Id] = tree;
            }
            foreach (var tree in trees)
            {
                if (roots.Contains(tree))
                {
                    continue;
                }
                tree.Parent.Add(tree);
            //    var parent = dictionary[tree.ParentId] as BinaryTree;
            //    parent.Add(tree);
            }
            var tables = ViewBinaryTableInfos.Where(s => true);
            foreach (var table in tables)
            {
                var parent = dictionary[table.ParentId] as BinaryTree;
                table.Parent = parent;
                parent.Add(table);
                Leaves[table.Id] = table;
            }

        }


        #endregion
    }
}
