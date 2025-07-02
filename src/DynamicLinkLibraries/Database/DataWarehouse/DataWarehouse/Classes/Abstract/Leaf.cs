using System;
using System.Collections.Generic;

using DataWarehouse.Interfaces;
using ErrorHandler;
using NamedTree;

namespace DataWarehouse.Classes.Abstract
{
    /// <summary>
    /// Leaf 
    /// </summary>
    public abstract class Leaf : ILeafData
    {
        private void Init()
        {

        }

        #region Fields

        protected string name;

        protected byte[] data;

        protected string description;

        protected Func<byte[]> GetData;

        protected byte[] GetDataInitial()
        {
            if (data == null)
            {
                data = GetDatabaseData();
            }
            GetData = () => data;
            return data;
        }


        #endregion
        protected Leaf() 
        {
            Init();
            GetData = GetDataInitial;
        }


        protected Leaf(object id, string name,  string description, string extension,
         byte[] data) : this()
        {
            Id = id;
            this.name = name;
            Extension = extension;
            this.description = description;
            this.data = data;
            GetData = () => this.data;
        }


        protected Leaf(object id, string name, string extension, string description, 
            INode<INode> parent, IEnumerable<INode<INode>> nodes, byte[] data) : 
            this(id, name, extension, description, data)

        {
            Parent = parent;
            Nodes = nodes;
        }

        protected Leaf(ILeafData leaf, IDirectory directory) : this() 
        {
            this.name = leaf.Name;
            Extension = leaf.Extension;
            this.description = leaf.Description;
            this.data = leaf.Data;
            Parent = directory;
        }

        #region Virtual


        protected virtual object Id { get; set; }

        protected virtual string Name { get => name; set => UpdateName(value); }

        protected virtual string Extension { get; set; }

        protected virtual string Description { get => description; set => UpdateDescription(value); }

        protected virtual byte[] Data { get => GetData(); set => UpdateData(value); }


        protected virtual INode Value => this;

        protected virtual INode<INode> Parent { get; set; }

        protected virtual IEnumerable<INode<INode>> Nodes { get; set; } = new List<INode<INode>>();

   
        protected event Action<INode> OnAdd;

        protected event Action<INode> OnRemove;

        protected abstract void Add(INode<INode> node);

        protected abstract void Remove(INode<INode> node);

        protected abstract bool RemoveFromDatabase();


        protected virtual void RemoveItself()
        {
            try
            {
                var b = RemoveFromDatabase();
                if (!b)
                {
                    return;
                }
                Parent.Remove(this);
                OnDeleteItself?.Invoke(this);
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Remove database binary item");
            }
        }

        #region Event calls

        protected void OnDeleteItselfAct(object obj)
        {
            OnDeleteItself?.Invoke(obj);
        }
        protected void OnChangeItselfAct(object obj)
        {
            OnChangeItself.Invoke(obj);
        }



        #endregion

        #region Events



    
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


        #region ILeaf events


        /// <summary>
        /// Delete itself event
        /// </summary>
        protected event Action<object> OnDeleteItself;

        /// <summary>
        /// Change itself event
        /// </summary>
        protected event Action<object> OnChangeItself;


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



        #endregion


        #endregion


        object INode.Id => Id;

        string INode.Extension =>   Extension;

        string INamed.Name { get => Name; set => Name = value; }
        INode<INode> INode<INode>.Parent { get => Parent; set => Parent = value; }
        IEnumerable<INode<INode>> INode<INode>.Nodes { get => Nodes; set => Nodes = value; }

        INode INode<INode>.Value => Value;

        string IDescription.Description { get => Description; set => Description = value; }
        byte[] IData.Data { get => Data; set => Data = value; }
        string INamed.NewName { get; set; }

        event Action<INode> INode<INode>.OnAdd
        {
            add
            {
                OnAdd += value;
            }

            remove
            {
                OnAdd -= value;
            }
        }

        event Action<INode> INode<INode>.OnRemove
        {
            add
            {
                OnRemove += value;
            }

            remove
            {
                OnRemove -= value;
            }
        }


        void INode<INode>.Add(INode<INode> node)
        {
            Add(node);
        }

        void INode<INode>.Remove(INode<INode> node)
        {
            Remove(node);
        }

        void INode.RemoveItself()
        {
            RemoveItself();
        }

        protected virtual bool UpdateName(string name)
        {

            try
            {
                INamed named = this;
                named.NewName = name;
                if (name != this.name)
                {
                    var d = Parent as Directory;
                    named.Name = name;
                    if (d != null && d.Check(name))
                    {
                        var b = SetDatabaseName(name);
                        if (b)
                        {
                            d.Change(this.name, name);
                            this.name = name;
                            OnChangeItself?.Invoke(this);
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
            return false;
        }

        protected virtual byte[] UpdateData(byte[] data)
        {
            try
            {
                if (SetDatabaseData(data))
                {
                    this.data = data;
                    OnChangeItself?.Invoke(this);
                    return data;
                }
                else
                {
                    var s = "Fails update data \"" + name + "\"";
                    s.Log();
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
            return this.data;
        }

        protected virtual bool UpdateDescription(string description)
        {
            try
            {

                if (description == this.description)
                {
                    return false;
                }
                if (SetDatabaseDescription(description))
                {
                    this.description = description;
                    OnChangeItself?.Invoke(this);
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
            var s = "Error update leaf description \"" + name + "\"";
            s.Log();
            return false;
        }

        #region Abstract

        protected abstract bool SetDatabaseName(string name);

        protected abstract bool SetDatabaseDescription(string description);

        protected abstract bool SetDatabaseData(byte[] data);

        protected abstract byte[] GetDatabaseData();


        #endregion

    }
}
