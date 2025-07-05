using DataWarehouse.Interfaces;
using ErrorHandler;
using NamedTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PostgreSQLWarehouse.Models
{
    public partial class BinaryTree : IDirectory
    {
        public BinaryTree()
        {
            Directory = this;
        }

        #region Fields

        IDirectory Directory { get; set; }

        internal HashSet<ILeaf> leaves =
            new HashSet<ILeaf>();

        internal HashSet<IDirectory> directories = new HashSet<IDirectory>();

        internal List<string> Names
        {
            get;
            set;
        }
            = new List<string>();


        #endregion


        #region IDirectory events

        /// <summary>
        /// Add child event
        /// </summary>
        protected event Action<IDirectory> OnAddDirectory;

        /// <summary>
        /// Delete itself event
        /// </summary>
        protected event Action<object> OnDeleteItself;

        /// <summary>
        /// Change itself event
        /// </summary>
        protected event Action<IDirectory> OnChangeItself;

        /// <summary>
        /// Add leaf event
        /// </summary>
        protected event Action<ILeaf> OnAddLeaf;

        event Action<object> IDirectory.OnDeleteItself
        {
            add
            {
                OnDeleteItself += value;
            }

            remove
            {
                OnDeleteItself -= value;
            }
        }

        event Action<object> IDirectory.OnChangeItself
        {
            add
            {
                OnChangeItself += value;
            }

            remove
            {
                OnChangeItself -= value;
            }
        }

        event Action<object> IDirectory.OnAddLeaf
        {
            add
            {
                OnAddLeaf += value;
            }

            remove
            {
                OnAddLeaf -= value;
            }
        }

        event Action<object> IDirectory.OnAddDirectory
        {
            add
            {
                OnAddDirectory += value;
            }

            remove
            {
                OnAddDirectory -= value;
            }
        }


        #endregion



        #region Interface implementation

        object INode.Id => Id;

        string IDescription.Description { get => Description; set => UpdateDescription(value); }

        string INode.Extension => Ext;

        INode<INode> INode<INode>.Parent { get => Parent; set => throw new OwnNotImplemented("DataWarehouse"); }
        IEnumerable<INode<INode>> INode<INode>.Nodes { get => throw new OwnNotImplemented("DataWarehouse"); set => throw new OwnNotImplemented("DataWarehouse"); }

        INode INode<INode>.Value => this;

        IEnumerable<IDirectory> IChildren<IDirectory>.Children => directories;

        IEnumerable<ILeaf> IChildren<ILeaf>.Children => leaves;

        string INamed.Name
        {
            get => Name;
            set => UpdateName(value);
        }
       

        event Action<INode> INode<INode>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<INode> INode<INode>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IDirectory> IChildren<IDirectory>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IDirectory> IChildren<IDirectory>.OnRemove
        {
            add
            {
                throw new OwnNotImplemented("DataWarehouse");
            }

            remove
            {
                throw new OwnNotImplemented("DataWarehouse");
            }
        }

        event Action<ILeaf> IChildren<ILeaf>.OnAdd
        {
            add
            {
                throw new OwnNotImplemented("DataWarehouse");
            }

            remove
            {
                throw new OwnNotImplemented("DataWarehouse");
            }
        }

        event Action<ILeaf> IChildren<ILeaf>.OnRemove
        {
            add
            {
                throw new OwnNotImplemented("DataWarehouse");
            }

            remove
            {
                throw new OwnNotImplemented("DataWarehouse");
            }
        }

        event Action<object> IDirectory.OnGetDirectories
        {
            add
            {
                throw new OwnNotImplemented();
            }

            remove
            {
                throw new OwnNotImplemented();
            }
        }

        event Action<object> IDirectory.OnGetLeaves
        {
            add
            {
                throw new OwnNotImplemented();
            }

            remove
            {
                throw new OwnNotImplemented();
            }
        }

        IDirectory IDirectory.Add(IDirectory directory)
        {

            if (!Check(directory.Name))
            {
                return null;
            }



            /*   var adapter = new DataSetWarehouseTableAdapters.InsertTreeTableAdapter();
               DataSetWarehouse.InsertTreeDataTable res = null;
               Action act = () =>
               {
                   res = adapter.GetData(Id, name, description, ext);
               };
               adapter.ConnectionAction(act);
               var r = res[0];*/
            var tree = new BinaryTree();
            tree.Name = directory.Name;
            tree.Description = directory.Description;
            tree.Ext = directory.Extension;
            tree.Parent = this;
            tree.ParentId = Id;
            tree.Id = Guid.NewGuid();
            Add(tree);
            tree.Parent = this;
            StaticExtension.Context.BinaryTrees.Add(tree);
            StaticExtension.Context.SaveChanges();
            this.OnAddDirectory?.Invoke(tree);
            return tree;
        }



        ILeaf IDirectory.Add(ILeaf leaf)
        {
            if (!Check(leaf.Name))
            {
                return null;
            }
            BinaryTable table = new BinaryTable();
            table.Id = Guid.NewGuid();
            table.ParentId = Id;
            table.Name = leaf.Name;
            table.Description = leaf.Description;
            var data = leaf as IData;
            table.Data = data.Data;
            table.Ext = leaf.Extension;
            table.Length = data.Data.Length + "";
            Add(table);
            table.Parent = this;
            StaticExtension.Context.BinaryTables.Add(table);
            StaticExtension.Context.SaveChanges();
            (this as IDirectory).Add(table);
            return table;

            /* !!! DELETE AFTER      var adapter = new DataSetWarehouseTableAdapters.InsertBinaryTableAdapter();
                  DataSetWarehouse.InsertBinaryDataTable res = null;
                  Action act = () =>
                  {
                      res = adapter.GetData(Id, name, description,
                          data, ext);
                  };
                  adapter.ConnectionAction(act);
                  var r = res[0];
                  var result = new ViewBinaryTableInfo();
                  result.Name = name;
                  result.Id = r.Id;
                  result.Description = description;
                  result.Ext = ext;
                  (this as IDirectory).AddNode(result);
                  return result;*/
        }




        void INode.RemoveItself()
        {
            try
            {
                var ctx = StaticExtension.Context;
                if (Parent != null)
                {
                    Parent.InverseParent.Remove(this);
                    Parent.Names.Remove(this.Name);
                    Parent.directories.Remove(this);
                }
                ctx.BinaryTrees.Remove(this);
                ctx.SaveChanges();
                OnDeleteItself?.Invoke(this);
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Remove database tree node");
            }
        }

        #endregion

        #region Own Members

        public override string ToString()
        {
            return Name + " " + GetType(); ;
        }

        internal void Remove(INode node)
        {
            if (node is ILeaf)
            {
                leaves.Remove(node as ILeaf);
            }
            else
            {
                directories.Remove(node as IDirectory);
            }
            Names.Remove(node.Name);
        }

        internal void Add(INode node)
        {
            if (node is ILeaf leaf)
            {
                leaves.Add(leaf);
            }
            else
            {
                IDirectory d = node as IDirectory;
                if (directories.Contains(d))
                {
                    throw new OwnException("Add node");
                }
                directories.Add(d);
            }
            Names.Add(node.Name);
        }



        protected void UpdateName(string name)
        {
            if (name == Name)
            {
                return;
            }
            if (!Check(name))
            {
                return;
            }
       /*     Action action = () => { StaticExtension.TableAdapter.UpdateBinaryTreeName(Id, name); };
            StaticExtension.TableAdapter.ConnectionAction(action);*/
            Parent.Names.Remove(Name);
            Parent.Names.Add(name);
            Name = name;
            this.Change();
            OnChangeItself?.Invoke(this);
        }

        void UpdateDescription(string description)
        {
   /*!!!         Action action = () => { StaticExtension.TableAdapter.UpdateBinaryTreeDescription(Id, description); };
            StaticExtension.TableAdapter.ConnectionAction(action);*/
            Description = description;
            this.Change();
        }

        internal bool Check(string name)
        {
            if (Names.Contains(name))
            {
                ("Name \"" + name + "\" already exists").Log();
                return false;
            }
            return true;
        }

        void INode<INode>.Add(INode<INode> node)
        {
            throw new OwnNotImplemented("DataWarehouse");
        }

        void INode<INode>.Remove(INode<INode> node)
        {
            throw new OwnNotImplemented("DataWarehouse");
        }

        void IChildren<IDirectory>.AddChild(IDirectory child)
        {
            Add(child);
        }

        void IChildren<IDirectory>.RemoveChild(IDirectory child)
        {
            Remove(child);
        }

        void IChildren<ILeaf>.AddChild(ILeaf child)
        {
            Add(child);
        }

        void IChildren<ILeaf>.RemoveChild(ILeaf child)
        {
            Remove(child);
        }

        #endregion

        #region Private

        void Change()
        {

        }

        void IDirectory.RemoveAllChilden()
        {
            throw new OwnNotImplemented();
        }

        bool IDirectory.Post()
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}

