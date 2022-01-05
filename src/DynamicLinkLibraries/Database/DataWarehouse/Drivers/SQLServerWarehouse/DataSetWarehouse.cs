using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataWarehouse;
using DataWarehouse.Interfaces;
using SQLServerWarehouse.DataSetWarehouseTableAdapters;


namespace SQLServerWarehouse
{
    public partial class DataSetWarehouse
    {
        /// <summary>
        /// Binary table row
        /// </summary>
        public partial class SelectBinaryTableRow : ILeaf
        {


            #region Fields


            #endregion

            #region Interface Implementation

            object INode.Id => this.Id;

            string INode.Extension => this.Ext;

            byte[] ILeaf.Data { get => Data; set => Data = value; }


            string INode.Name { get  => this.Name; set => UpdateName(value); }

            string INode.Description { get => this.Description; set => UpdateDescription(value); }

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

            #endregion
        }

        public partial class SelectBinaryTreeRow : IDirectory
        {
            #region Fields

            List<SelectBinaryTreeRow> directories = new List<SelectBinaryTreeRow>();

            List<SelectBinaryTableRow> leaves = new List<SelectBinaryTableRow>();

            internal List<string> names = new List<string>();

            #endregion

            #region Implementation of intrfaces

            object INode.Id => Id;

            string INode.Name { get => Name; set => UpdateName(value); }
            string INode.Description { get => Description; set => UpdateDescription(value); }

            string INode.Extension => ext;

            IDirectory IDirectory.Add(string name, string description, string ext)
            {
                if (!Check(name))
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

            ILeaf IDirectory.Add(string name, string description, byte[] data, string ext)
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
                        data, null, ext);
                };
                adapter.ConnectionAction(act);
                var r = res[0];
                var result = StaticExtension.DataTable.AddSelectBinaryTableRow(r.Id,
                    Id, name, description, ext);
                Add(result);
                directory.AddNode(result);
                return result;
            }

            IEnumerator<IDirectory> IEnumerable<IDirectory>.GetEnumerator()
            {
                return directories.GetEnumerator();
            }

            IEnumerator<ILeaf> IEnumerable<ILeaf>.GetEnumerator()
            {
                return leaves.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return null;
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

            internal void Add(SelectBinaryTreeRow dir)
            {
                directories.Add(dir);
                dir.Parent = this;
                names.Add(dir.Name);
            }


            internal void Add(SelectBinaryTableRow leaf)
            {
                leaves.Add(leaf);
                leaf.Parent = this;
                names.Add(leaf.Name);
            }

            internal void Remove(SelectBinaryTreeRow dir)
            {
                directories.Remove(dir);
                names.Remove(dir.Name);
            }


            internal void Remove(SelectBinaryTableRow leaf)
            {
                leaves.Remove(leaf);
                names.Remove(leaf.Name);
            }



            QueriesTableAdapter TableAdapter
            { get => StaticExtension.TableAdapter; }

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
                    ("Name \"" + name + "\" already exists").ShowError();
                    return false;
                }
                return true;
            }

            #endregion
        }
    }

}
