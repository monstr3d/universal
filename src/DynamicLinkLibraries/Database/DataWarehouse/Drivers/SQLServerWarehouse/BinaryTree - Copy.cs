using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataWarehouse.Interfaces;
using DataWarehouse;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SQLServerWarehouse
{
    partial class BinaryTree : IDirectory, IDatabaseInterface
    {
        #region Fields

        internal static DataWarehouseLinqDataContext Context;
        
        IDirectory[] dirs = null;

        #endregion

        #region Ctor

        internal BinaryTree(string conncectionString)
        {
            Context = new DataWarehouseLinqDataContext(conncectionString, new AttributeMappingSource());
        }

        #endregion

        #region IDirectory Members

        IDirectory IDirectory.Add(string name, string description, string ext)
        {
            ContainsDirectory(name);
            ISingleResult<InsertBinaryNodeResult> res =
                Context.InsertBinaryNode(_Id, name, description, ext);
            InsertBinaryNodeResult r = 
                res.ElementAt<InsertBinaryNodeResult>(0);
            BinaryTree bt = new BinaryTree();
            bt._Id = r.Id;
            bt._Name = name;
            bt._Description = description;
            bt._ext = ext;
            BinaryTrees.Add(bt);
            bt.BinaryTree1 = this;
            bt._ParentId = _Id;
            return bt;
        }

        ILeaf IDirectory.Add(string name, string description, byte[] data, string ext)
        {
            Contains(name);
            ISingleResult<InsertBinaryResult> r = 
                Context.InsertBinary(Id, name, description, data, 0, ext);
            Guid id = r.ElementAt<InsertBinaryResult>(0).Id;
            BinaryTable bt = new BinaryTable(id, this, name, description, ext);
            bt.BinaryTree = this;
            BinaryTables.Add(bt);
            return bt;
        }

        #endregion

        #region INode Members

        object INode.Id
        {
            get { return _Id; }
        }

 
        void INode.RemoveItself()
        {
            Context.DeleteBinaryTree(_Id);
            BinaryTree1._BinaryTrees.Remove(this);
        }

        string INode.Extension
        {
            get { return _ext; }
        }


        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable<ILeaf> Members

        IEnumerator<ILeaf> IEnumerable<ILeaf>.GetEnumerator()
        {
            return BinaryTables.Cast<ILeaf>().GetEnumerator();
        }

 
        #endregion


        #region INode Members


        string INode.Name
        {
            get
            {
                return _Name;
            }
            set
            {
                Name = value;
            }
        }

 
        #endregion

        #region IEnumerable<IDirectory> Members

        IEnumerator<IDirectory> IEnumerable<IDirectory>.GetEnumerator()
        {
            return BinaryTrees.Cast<IDirectory>().GetEnumerator();
        }

        #endregion

        #region IDatabaseInterface Members

        public void Login(string login, string password, object key)
        {
        }

        public IDirectory[] GetRoots(string login, string password, object key, string[] ext)
        {
            if (dirs == null)
            {
                Refresh(login, password, key, ext);
            }
            return dirs;
        }

        public void Refresh(string login, string password, object key, string[] ext)
        {
            List<IDirectory> lbt = new List<IDirectory>();
            DataWarehouseLinqDataContext dc = Context;
            //Dictionary<Guid, Guid> chp = new Dictionary<Guid, Guid>();
            Dictionary<Guid, BinaryTree> trees = new Dictionary<Guid, BinaryTree>();
            ISingleResult<SelectBinaryTreeResult> sbt = dc.SelectBinaryTree();
            foreach (SelectBinaryTreeResult sbr in sbt)
            {
                BinaryTree bt = new BinaryTree();
                bt._Id = sbr.Id;
                bt._ParentId = sbr.ParentId;
                if (bt._Id.Equals(bt._ParentId))
                {
                    lbt.Add(bt);
                }
                trees[bt.Id] = bt;
                bt._Name = sbr.Name;
                bt._Description = sbr.Description;
                bt._ext = sbr.ext;
            }

            foreach (BinaryTree tree in trees.Values)
            {
                BinaryTree parent = trees[tree._ParentId];
                if (!parent.Id.Equals(tree.Id))
                {
                    tree._BinaryTree1 = new EntityRef<BinaryTree>(parent);
                    parent._BinaryTrees.Add(tree);
                }
            }

            ISingleResult<SelectBinaryTableResult> btr = dc.SelectBinaryTable();

            foreach (SelectBinaryTableResult sbtr in btr)
            {
                BinaryTree parent = trees[sbtr.ParentId];
                BinaryTable bta = new BinaryTable(sbtr.Id, parent, sbtr.Name, sbtr.Description, sbtr.Ext);
            }
            dirs = lbt.ToArray();
        }

  

        byte[] IDatabaseInterface.GetData(string login, string password, object key, string id, ref string extension)
        {
            Guid g = new Guid(id);
            ISingleResult<SelectBinaryResult> sr = Context.SelectBinary(g);
            SelectBinaryResult r = sr.First<SelectBinaryResult>();
            ext = r.Ext;
            return r.Data.ToArray();
        }

        IDictionary<object, object> IDatabaseInterface.GetItems(string login, string password, object key, string extension)
        {
            ISingleResult<SelectBinaryContentsResult> sr = Context.SelectBinaryContents(extension);
            IDictionary<object, object> d = new Dictionary<object, object>();
            foreach (SelectBinaryContentsResult r in sr)
            {
                d[r.Id] = r.Name;
            }
            return d;
        }

        #endregion
 

        #region Partial Members


        partial void OnNameChanging(string value)
        {
            ContainsDirectory(value);
        }

        partial void OnNameChanged()
        {
            Context.UpdateBinaryTreeName(_Id, _Name);
        }

        partial void OnDescriptionChanged()
        {
            Context.UpdateBinaryTreeDescription(_Id, _Description);
        }


        #endregion


        #region  Own Members

        void ContainsDirectory(string name)
        {
            List<string> names = new List<string>();
            foreach (BinaryTree tr in BinaryTrees)
            {
                if (tr._Name.Equals(name))
                {
                    throw new Exception("Name \"" + name + "\" already exists");
                }
            }
        }

        internal void Contains(string name)
        {
            List<string> names = new List<string>();
            foreach (BinaryTable tr in BinaryTables)
            {
                if (tr.Name.Equals(name))
                {
                    throw new Exception("Name \"" + name + "\" already exists");
                }
            }
        }

        #endregion


    }
}
