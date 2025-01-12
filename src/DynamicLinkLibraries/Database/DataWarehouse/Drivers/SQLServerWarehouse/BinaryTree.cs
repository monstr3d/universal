using DataWarehouse;
using DataWarehouse.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServerWarehouse.Models
{
    public partial class BinaryTree : IDirectory
    {

		#region Fields

        internal HashSet<ILeaf> leaves = 
            new HashSet<ILeaf>();

        internal HashSet<IDirectory> directories = new HashSet<IDirectory>();

        internal List<string> names = new List<string>();


        #endregion

        #region Interface implementation

        object INode.Id => Id;

        string INode.Name { get => Name; set => UpdateName(value); }
        string INode.Description { get => Description; set => UpdateDescription(value); }

        string INode.Extension => Ext;

        IDirectory IDirectory.Add(string name, string description, string ext)
        {
            if (!Check(name))
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
            tree.Name = name;
            tree.Description = description;
            tree.Ext = ext;
            tree.Parent = this;
            tree.ParentId = Id;
            tree.Id = Guid.NewGuid();
            Add(tree);
            tree.Parent = this;
            StaticExtension.Context.BinaryTrees.Add(tree);
            StaticExtension.Context.SaveChanges();
            (this as IDirectory).AddNode(tree);
            return tree;
        }



        ILeaf IDirectory.Add(string name, string description, byte[] data, string ext)
        {
            if (!Check(name))
            {
                return null;
            }
            BinaryTable table = new BinaryTable();
            table.Id = Guid.NewGuid();
            table.ParentId = Id;
            table.Name = name;
            table.Description = description;
            table.Data = data;
            table.Ext = ext;
            table.Length = data.Length + "";
            Add(table);
            table.Parent = this;
            StaticExtension.Context.BinaryTables.Add(table);
            StaticExtension.Context.SaveChanges();
            (this as IDirectory).AddNode(table);
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

        IEnumerator<IDirectory> IEnumerable<IDirectory>.GetEnumerator()
        {
            foreach (var item in directories)
            {
                yield return item;
            }
        }

        IEnumerator<ILeaf> IEnumerable<ILeaf>.GetEnumerator()
        {
            foreach (var item in leaves)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            /*          foreach (var item in InverseParent)
                      {
                          yield return item;
                      }
                      foreach (var item in tables)
                      {
                          yield return item;
                      }
                      foreach (var item in BinaryTables)
                      {
                          yield return item;
                      }*/
            return null;
        }

        void INode.RemoveItself()
        {
            var ctx = StaticExtension.Context;
            if (Parent != null)
            {
                Parent.InverseParent.Remove(this);
                Parent.names.Remove(this.Name);
                Parent.directories.Remove(this); 
            }
            ctx.BinaryTrees.Remove(this);
            ctx.SaveChanges();
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
            names.Remove(node.Name);
        }

        internal void Add(INode node)
        {
            if (node is ILeaf)
            {
                leaves.Add(node as ILeaf);
            }
            else
            {
                directories.Add(node as IDirectory);
            }
            names.Add(node.Name);
        }



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
            Action action = () => { StaticExtension.TableAdapter.UpdateBinaryTreeName(Id, name); };
            StaticExtension.TableAdapter.ConnectionAction(action);
            Parent.names.Remove(Name);
            Parent.names.Add(name);
            Name = name;
            this.Change();
        }

        void UpdateDescription(string description)
        {
            Action action = () => { StaticExtension.TableAdapter.UpdateBinaryTreeDescription(Id, description); };
            StaticExtension.TableAdapter.ConnectionAction(action);
            Description = description;
            this.Change();
        }

        internal bool Check(string name)
        {
            if (names.Contains(name))
            {
                ("Name \"" + name + "\" already exists").ShowError();
                return false;
            }
            return true;
        }

        #endregion
    }
}
