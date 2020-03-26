using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataWarehouse.Interfaces;

namespace SQLServerWarehouse
{
    partial class BinaryTable : ILeaf
    {
        #region Fields

        BinaryTree parent;

        #endregion


        #region Ctor

        internal BinaryTable(Guid id, BinaryTree parent, string name, string description, string ext)
        {
            this.parent = parent;
            _Name = name;
            _Id = id;
            _ParentId = parent.Id;
            _Description = description;
            _Ext = ext;
            this.parent = parent;
            parent.BinaryTables.Add(this);
        }

        #endregion

        #region ILeaf Members

        byte[] ILeaf.Data
        {
            get
            {
                if (_Data == null)
                {
                    DataWarehouseLinqDataContext dc = BinaryTree.Context;
                    _Data = dc.SelectBinary(_Id).First<SelectBinaryResult>().Data;
                }
                return _Data.ToArray();
            }
            set
            {
                Data = value;
            }
        }

        #endregion

        #region INode Members

        object INode.Id
        {
            get { return Id; }
        }


        void INode.RemoveItself()
        {
            BinaryTree.Context.DeleteBinary(_Id);
            _Data = null;
            parent.BinaryTables.Remove(this);
        }


        public string Extension
        {
            get { return _Ext; }
        }

        #endregion

        #region Partial Methods

        partial void OnNameChanging(string value)
        {
            parent.Contains(value);
        }

        partial void OnNameChanged()
        {
            Context.UpdateBinaryTableName(_Id, _Name);
        }

        partial void OnDescriptionChanged()
        {
            Context.UpdateBinaryTableDescription(_Id, _Description);
        }
 
        partial void OnDataChanged()
        {
            Context.UpdateBinaryData(_Id, _Data);
        }

        #endregion


        #region Own Members

        private static DataWarehouseLinqDataContext Context
        {
            get
            {
                return BinaryTree.Context;
            }
        }

        #endregion

    }
}
