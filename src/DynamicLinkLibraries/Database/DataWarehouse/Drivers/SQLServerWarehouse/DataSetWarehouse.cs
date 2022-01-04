using DataWarehouse;
using DataWarehouse.Interfaces;
using SQLServerWarehouse.DataSetWarehouseTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            void INode.RemoveItself()
            {
                try
                {
                    TableAdapter.DeleteBinary(Id);
                }
                catch (Exception ex)
                {
                    ex.ShowError();
                }
            }

            #endregion

            #region Own Members

            SelectBinaryTreeRow Parent { get; set; }


            QueriesTableAdapter TableAdapter
            { get => StaticExtension.TableAdapter; }

            internal byte[] Data
            {
                get
                {
                    var adapter = new SelectBinaryTableAdapter();
                    adapter.SetConnecion();
                    var selects = adapter.GetData(Id);
                    return selects[0].Data;
                }
                set
                {
                    TableAdapter.UpdateBinaryData(Id, value);
                }
            }

            #endregion
        }

        public partial class SelectBinaryTreeRow : IDirectory
        {
            #region Fields

            List<SelectBinaryTreeRow> directories = new List<SelectBinaryTreeRow>();

            List<ILeaf> leaves = new List<ILeaf>();

            List<string> names = new List<string>();

            #endregion

            #region Implementation of intrfaces

            object INode.Id => Id;

            string INode.Name { get => Name; set => throw new NotImplementedException(); }
            string INode.Description { get => Description; set => UpdateDescription(value); }

            string INode.Extension => ext;

            IDirectory IDirectory.Add(string name, string description, string ext)
            {
                throw new NotImplementedException();
            }

            ILeaf IDirectory.Add(string name, string description, byte[] data, string ext)
            {
                if (!Check(name))
                {
                    return null;
                }
                var adapter = new InsertBinaryTableAdapter();
                adapter.SetConnecion();
                var result = adapter.GetData(Id, name, description, data, null, ext)[0];
                return StaticExtension.DataTable.AddSelectBinaryTableRow(result.Id,
                    Id, name, description, ext);
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
                throw new NotImplementedException();
                if (Parent != null)
                {
                    Parent.directories.Remove(this);
                }
            }

            #endregion

            #region Own Members

            SelectBinaryTreeRow Parent
            { get; set; }

            internal void Add(SelectBinaryTreeRow leaf)
            {
                directories.Add(leaf);
                leaf.Parent = this;
            }

            QueriesTableAdapter TableAdapter
            { get => StaticExtension.TableAdapter; }

            void UpdateDescription(string description)
            {
                TableAdapter.UpdateBinaryTreeDescription(Id, description);
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
