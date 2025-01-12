using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataWarehouse;
using DataWarehouse.Interfaces;

namespace SQLServerWarehouse.Models
{
    public partial class ViewBinaryTableInfo : ILeaf
    {
        

        #region Implementation of interfaces
        byte[] ILeaf.Data { get => Id.GetData(); set => Id.SetData(value); }

        object INode.Id => Id;

        string INode.Name { get => Name; set => UpdateName(value); }
        string INode.Description { get => Description; set => UpdateDescription(value); }

        string INode.Extension => Ext;

        void INode.RemoveItself()
        {
            Action action = () => { StaticExtension.TableAdapter.DeleteBinary(Id); };
            StaticExtension.TableAdapter.ConnectionAction(action);
            if (Parent != null)
            {
                Parent.Remove(this);
            }
            //StaticExtension.Context.ViewBinaryTableInfos.Remove(this);
        }

        #endregion

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

        internal BinaryTree Parent
        { get; set; }


        public override string ToString()
        {
            return Name + " " + GetType(); 
        }



    }
}
