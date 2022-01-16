using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataWarehouse.Interfaces;

namespace SQLServerWarehouse.Models
{
    public partial class BinaryTable : ILeaf
    {
        #region Fields

 
        #endregion

        object INode.Id => Id;

        string INode.Extension => Ext;

        byte[] ILeaf.Data { get=> Data; set => SetData(value); }

        void INode.RemoveItself()
        {
            StaticExtension.Context.BinaryTables.Remove(this);
            Parent.Remove(this);
            StaticExtension.Context.SaveChanges();
            
        }

        void SetData(byte[] data)
        {
            using (DataWarehouseContext context = new DataWarehouseContext())
            {
                Data = data;
                context.SaveChanges();
            }
        }
    }
}
