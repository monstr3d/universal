using System;
using System.Collections.Generic;

using ErrorHandler;

using DataWarehouse;
using DataWarehouse.Interfaces;

using SQLServerWarehouse.DataSetWarehouseTableAdapters;

using NamedTree;


namespace SQLServerWarehouse
{
    public partial class DataSetWarehouse
    {
        /// <summary>
        /// Binary table row
        /// </summary>
        public partial class SelectBinaryTableRow : ILeaf, IData
        {


            #region Fields


            #endregion


            #region ILeaf events

            /// <summary>
            /// Delete itself event
            /// </summary>
            protected event Action<object> OnDeleteItself;

            /// <summary>
            /// Chang itself event
            /// </summary>
            protected event Action<ILeaf> OnChangeItself;


            event Action<object> ILeaf.OnDeleteItself
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

            event Action<object> ILeaf.OnChangeItself
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



            #endregion



            #region Interface Implementation

            object INode.Id => this.Id;

            string INode.Extension => this.Ext;

            byte[] IData.Data { get => Data; set => Data = value; }

            string INamed.Name 
            { 
                get => this.Name; 
                set => UpdateName(value); 
            }


            string IDescription.Description { get => this.Description; set => UpdateDescription(value); }

            event Action<INode> INode<INode>.OnAdd
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

            event Action<INode> INode<INode>.OnRemove
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

            void INode.RemoveItself()
            {
                Action action = () => { TableAdapter.DeleteBinary(Id); };
                TableAdapter.ConnectionAction(action);
                if (Parent != null)
                {
                    Parent.Remove(this);
                }
            }

            #endregion

            #region Own Members

            void UpdateName(string name)
            {
                if (name == Name)
                {
                    return;
                }
                if (!Parent.Check(name))
                {
                    return;
                }
                Action action = () => { TableAdapter.UpdateBinaryTableName(Id, name); };
                TableAdapter.ConnectionAction(action);
                Parent.names.Remove(Name);
                Parent.names.Add(name);
                Name = name;
                this.Change();
            }

            void UpdateDescription(string description)
            {
                if (Description == description)
                {
                    return;
                }
                Action action = () => { TableAdapter.UpdateBinaryTableDescription(Id, description); };
                TableAdapter.ConnectionAction(action);
                Description = description;
                this.Change();
            }

            void INode<INode>.Add(INode<INode> node)
            {
                throw new OwnNotImplemented("DataWarehouse");
            }

            void INode<INode>.Remove(INode<INode> node)
            {
                throw new OwnNotImplemented("DataWarehouse");
            }

            internal SelectBinaryTreeRow Parent { get; set; }


            QueriesTableAdapter TableAdapter
            { get => StaticExtension.TableAdapter; }

            internal byte[] Data
            {
                get
                {
                    DataSetWarehouse.SelectBinaryDataTable selects = null;
                    var adapter = new SelectBinaryTableAdapter();
                    adapter.ConnectionAction(() => { selects = adapter.GetData(Id); });
                    return selects[0].Data;
                }
                set
                {
                    TableAdapter.ConnectionAction(() => { TableAdapter.UpdateBinaryData(Id, value); });
                }
            }

            INode<INode> INode<INode>.Parent { get => Parent; set => Parent = value as SelectBinaryTreeRow; }
            IEnumerable<INode<INode>> INode<INode>.Nodes { get => throw new OwnNotImplemented("DataWarehouse"); set => throw new OwnNotImplemented("DataWarehouse"); }

            INode INode<INode>.Value => this;


            #endregion
        }

        public partial class SelectBinaryTreeRow : IDirectory
        {
            #region Fields

   //         List<SelectBinaryTreeRow> directories = new List<SelectBinaryTreeRow>();

   //         List<SelectBinaryTableRow> leaves = new List<SelectBinaryTableRow>();

            internal List<string> names = new List<string>();

            #endregion


            #region IDirectory events

            /// <summary>
            /// Add child event
            /// </summary>
            protected event Action<object> OnAddDirectory;

            /// <summary>
            /// Delete itself event
            /// </summary>
            protected event Action<object> OnDeleteItself;

            /// <summary>
            /// Change itself event
            /// </summary>
            protected event Action<object> OnChangeItself;

            /// <summary>
            /// Add leaf event
            /// </summary>
            protected event Action<object> OnAddLeaf;

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

            event Action<Object> IDirectory.OnAddLeaf
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



            #region Implementation of intrfaces

            object INode.Id => Id;

            string INamed.Name
            { 
                get => this.Name; 
                set => UpdateName(value); 
            }


            string IDescription.Description { get => Description; set => UpdateDescription(value); }

            string INode.Extension => ext;

            event Action<INode> INode<INode>.OnAdd
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

            event Action<INode> INode<INode>.OnRemove
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

            event Action<IDirectory> IChildren<IDirectory>.OnAdd
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
                     
                }

                remove
                {
                     
                }
            }

            event Action<object> IDirectory.OnGetLeaves
            {
                add
                {
                     
                }

                remove
                {
                     
                }
            }

            IDirectory IDirectory.Add(IDirectory directory)
            {
                return null;
                /*          if (!Check(name))
                          {
                              return null;
                          }
                          var adapter = new InsertTreeTableAdapter();
                          DataSetWarehouse.InsertTreeDataTable res = null;
                          Action act = () =>
                          {
                              res = adapter.GetData(Id, name, description, ext);
                          };
                          adapter.ConnectionAction(act);
                          var r = res[0];
                          var result = StaticExtension.TreeTable.AddSelectBinaryTreeRow(r.Id,
                              Id, name, description, ext);
                          Add(result);
                          directory.AddNode(result);
                          return result;
                      }

                      void IDirectory.Add(string name, string description, byte[] data, string ext)
                      {
                          if (!Check(name))
                          {
                              return null;
                          }
                          var adapter = new InsertBinaryTableAdapter();
                          DataSetWarehouse.InsertBinaryDataTable res = null;
                          Action act = () =>
                          {
                              res = adapter.GetData(Id, name, description,
                                  data, ext);
                          };
                          adapter.ConnectionAction(act);
                          var r = res[0];
                          var result = StaticExtension.DataTable.AddSelectBinaryTableRow(r.Id,
                              Id, name, description, ext);
                          Add(result);
                          directory.AddNode(result);
                          return result;
                      }
                */
            }

 
            void INode.RemoveItself()
            {
                Action action = () => { TableAdapter.DeleteBinaryTree(Id); };
                TableAdapter.ConnectionAction(action);
                if (Parent != null)
                {
                    Parent.Remove(this);
                }
            }

            #endregion

            #region Own Members

            IDirectory directory { get => this; }

            SelectBinaryTreeRow Parent
            { get; set; }

   

   
   
            protected virtual List<IDirectory> Directories
            {
                get;
            } = new();


            protected virtual List<ILeaf> Leaves
            {
                get;
            } = new();


            QueriesTableAdapter TableAdapter
            { get => StaticExtension.TableAdapter; }

  
            INode<INode> INode<INode>.Parent { get => Parent; set => Parent = value as SelectBinaryTreeRow; }
            IEnumerable<INode<INode>> INode<INode>.Nodes { get => throw new OwnNotImplemented("DataWarehouse"); set => throw new OwnNotImplemented("DataWarehouse"); }

            INode INode<INode>.Value => this;

            IEnumerable<IDirectory> IChildren<IDirectory>.Children => Directories;

            IEnumerable<ILeaf> IChildren<ILeaf>.Children => Leaves;

            void UpdateName(string name)
            {
                if (name == Name)
                {
                    return;
                }
                if (!Check(name))
                {
                    return;
                }
                Action action = () => { TableAdapter.UpdateBinaryTreeName(Id, name); };
                TableAdapter.ConnectionAction(action);
                Parent.names.Remove(Name);
                Parent.names.Add(name);
                Name = name;
                this.Change();
            }

            void UpdateDescription(string description)
            {
                Action action = () => { TableAdapter.UpdateBinaryTreeDescription(Id, description); };
                TableAdapter.ConnectionAction(action);
                Description = description;
                this.Change();
            }

            internal bool Check(string name)
            {
                if (names.Contains(name))
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
                throw new OwnNotImplemented("DataWarehouse");
            }

            internal void Add(ILeaf leaf)
            {
                Leaves.Add(leaf);
                leaf.Parent = this;
                names.Add(leaf.Name);
            }

            internal void Add(IDirectory directory)
            {
                Directories.Add(directory);
                directory.Parent = this;
                names.Add(directory.Name);
            }

            internal void Remove(ILeaf leaf)
            {
                Leaves.Remove(leaf);
                names.Remove(leaf.Name);
            }

            internal void Remove(IDirectory directory)
            {
                Directories.Remove(directory);
                names.Remove(directory.Name);
            }




            void IChildren<ILeaf>.AddChild(ILeaf child)
            {
                Add(child);
            }

            void IChildren<ILeaf>.RemoveChild(ILeaf child)
            {
                throw new OwnNotImplemented("DataWarehouse");
            }

            ILeaf IDirectory.Add(ILeaf leaf)
            {
                throw new OwnNotImplemented("DataWarehouse");
            }

            void IDirectory.RemoveAllChilden()
            {
                throw new OwnNotImplemented();
            }

            bool IDirectory.Post()
            {
                throw new OwnNotImplemented("DataWarehouse");
            }

            #endregion
        }
    }

}
