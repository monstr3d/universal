using System;
using System.Collections;
using System.Collections.Generic;

using DataWarehouse.Interfaces;

using ErrorHandler;

using NamedTree;


namespace DataWarehouse.Classes.Abstract
{
    public abstract class Directory : IDirectory, IChildrenName
    {
        private void Init()
        {

        }

        #region Fields

        protected string name;

        protected string description;

        protected List<string> Names
        {
            get;
        } = new List<string>();

        protected List<IDirectory> directories;

        protected List<ILeaf> leaves;

        protected Func<List<IDirectory>> GetChildern;

        protected Func<List<ILeaf>> GetLeaves;


        #endregion

        #region Ctor


        protected Directory(bool childen)
        {
            Init();
            if (childen)
            {
                directories = new List<IDirectory>();
                GetChildern = () => directories;
                leaves = new List<ILeaf>();
                GetLeaves = () => leaves;
                return;
            }
            GetChildern = GetFuncInitial;
            GetLeaves = GetFuncLeafInitial;
        }

        public Directory(object Id, string Name, string Description, string Extension, bool children) : this(children)
        {
            this.Id = Id;
            this.name = Name;
            this.description = Description;
            this.Extension = Extension;
        }

        #endregion

        protected IDirectory ThisDirectory
        {
            get => this;
        }


        #region Event execution


        protected void OnAddLeafAct(object obj)
        {
            OnAddLeafObj?.Invoke(obj);
        }


        protected void OnAddDirectoryAct(object obj)
        {
            OnAddDirectoryObject?.Invoke(obj);
        }

        protected void OnDeleteItselfAct(object obj)
        {
            OnDeleteItself?.Invoke(obj);
        }

        /// <summary>
        /// Change itself event
        /// </summary>
        protected void OnChangeItselfAct(Object obj)
        {
            OnChangeItself?.Invoke(obj);
        }


        protected void OnAddDirectoryObjectAct(object obj)
        {
            OnAddDirectoryObject?.Invoke(obj);
        }


        #endregion


        #region IDirectory events

        protected event Action<object> OnAddDirectoryObject;


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
        protected event Action<object> OnChangeItself;


        /// <summary>
        /// Add leaf event
        /// </summary>
        protected event Action<ILeaf> OnAddLeaf;

        protected event Action<object> OnAddLeafObj;

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
                OnAddLeafObj += value;
            }

            remove
            {
                OnAddLeafObj -= value;
            }
        }

        event Action<object> IDirectory.OnAddDirectory
        {
            add
            {
               OnAddDirectoryObject += value;
            }

            remove
            {
                OnAddDirectoryObject -= value;
            }
        }

        #endregion


        #region Protected


        protected virtual object Id { get; set; }

        protected virtual string Name { get => name; set => UpdateName(name); }

        protected virtual string Extension { get; set; }

        protected virtual string Description { get => description; set => UpdateDescription(value); }


        protected virtual INode Value => this;

        protected virtual INode<INode> Parent { get; set; }

        protected virtual IEnumerable<INode<INode>> Nodes { get; set; } = new List<INode<INode>>();


        protected virtual IEnumerable<IDirectory> Children { get => GetChildern(); set { } }

        protected virtual IEnumerable<ILeaf> Leaves { get => GetLeaves(); set { } }



        protected event Action<INode> OnAdd;

        protected event Action<INode> OnRemove;

        protected event Action<IDirectory> OnRemoveDirectory;

        protected event Action<ILeaf> OnRemoveLeaf;

        protected abstract void Add(INode<INode> node);

        protected abstract void Remove(INode<INode> node);
        protected virtual void RemoveItself()
        {
            try
            {
                var b = RemoveFromDatabase();
                if (!b)
                {
                    var x = "Directory \"" + name + "\" is not deleted";
                    x.Log();
                    return;
                }
                OnDeleteItself?.Invoke(this);
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Remove database binary item");
            }

        }

        protected abstract bool RemoveFromDatabase();



        protected abstract IDirectory AddToDatabase(IDirectory directory);


        protected abstract ILeaf AddToDatabase(ILeaf leaf);



        protected virtual IDirectory Add(IDirectory directory)
        {
            try
            {

                if (!Check(directory.Name))
                {
                    var m = "Name of directory " + directory.Name + "alreary exists";
                    m.Log();
                    return null;
                }
                var dir = AddToDatabase(directory);
                if (dir != null)
                {
                    dir.Parent = this;
                    directories.Add(dir);
                    Names.Add(dir.Name);
                    OnAddDirectory?.Invoke(dir);
                    return dir;
                }
            }
            catch (Exception exception)
            {
                exception.HandleException();
            }
            return null;
        }

        protected void AddDirectory(IDirectory directory)
        {
            OnAddDirectory?.Invoke(directory);
        }

        protected void AddLeaf(ILeaf leaf)
        {
            OnAddLeaf?.Invoke(leaf);
        }


        protected virtual ILeaf Add(ILeaf leaf)
        {
            try
            {
                if (!Check(leaf.Name))
                {
                    return null;
                }
                var l = AddToDatabase(leaf);
                if (l != null)
                {
                    l.Parent = this;
                    leaves.Add(l);
                    Names.Add(l.Name);
                    OnAddLeaf?.Invoke(l);
                    return l;
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
            return null;
        }

        protected abstract void Remove(IDirectory directory, string ext);

        protected abstract void Remove(ILeaf leaf, string ext);

        internal virtual bool Check(string name)
        {
            if (Names.Contains(name))
            {
                ("Name \"" + name + "\" already exists").Log();
                return false;
            }
            return true;
        }

        public virtual void Add(string name)
        {
            Names.Add(name);
        }

        public virtual void Remove(string name)
        {
            Names.Remove(name);
        }




        internal void Change(string old, string name)
        {
            Names.Remove(old);
            Names.Add(name);
        }




        protected virtual bool UpdateName(string name)
        {

            try
            {
                if (name == this.name)
                {
                    return false;
                }
                var d = Parent as Directory;
                if (d != null && !d.Check(name))
                {
                    return false;
                }
                if (SetDatabaseName(name))
                {
                    d.Change(this.name, name);
                    this.name = name;
                    OnChangeItself?.Invoke(this);
                    return true;
                }
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
            return false;
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
            var s = "Error update directory description \"" + name + "\"";
            s.Log();
            return false;
        }

        #endregion

        object INode.Id => Id;

        string INode.Extension => Extension;

        string INamed.Name { get => name; set => UpdateName(value); }
        INode<INode> INode<INode>.Parent { get => Parent; set => Parent = value; }
        IEnumerable<INode<INode>> INode<INode>.Nodes { get => Nodes; set => Nodes = value; }

        INode INode<INode>.Value => Value;

        string IDescription.Description { get => description; set => UpdateDescription(value); }


        IEnumerable<IDirectory> IChildren<IDirectory>.Children => Children;

        IEnumerable<ILeaf> IChildren<ILeaf>.Children => Leaves;

       

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



        event Action<IDirectory> IChildren<IDirectory>.OnAdd
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

        event Action<ILeaf> IChildren<ILeaf>.OnAdd
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


        event Action<IDirectory> IChildren<IDirectory>.OnRemove
        {
            add
            {
                OnRemoveDirectory += value;
            }

            remove
            {
                OnRemoveDirectory -= value;
            }
        }

        event Action<ILeaf> IChildren<ILeaf>.OnRemove
        {
            add
            {
                OnRemoveLeaf += value;
            }

            remove
            {
                OnRemoveLeaf -= value;
            }
        }

        IDirectory IDirectory.Add(IDirectory directory)
        {
            return Add(directory);
        }

        ILeaf IDirectory.Add(ILeaf leaf)
        {
            return Add(leaf);
        }

        void IChildren<IDirectory>.AddChild(IDirectory child)
        {
            Add(child);
        }

        void IChildren<ILeaf>.AddChild(ILeaf child)
        {
            Add(child);
        }

        void IChildren<IDirectory>.RemoveChild(IDirectory child)
        {
            RemoveChild(child);
        }

        void IChildren<ILeaf>.RemoveChild(ILeaf child)
        {
            Names.Remove(child.Name);
            leaves.Remove(child);
        }

        #region Protected

        protected virtual void RemoveChild(IDirectory child)
        {
            Names.Remove(child.Name);
            directories.Remove(child);
        }

        protected virtual void RemoveChild(ILeaf child)
        {
            Names.Remove(child.Name);
            leaves.Remove(child);
        }


        protected List<IDirectory> GetFuncInitial()
        {
            directories = GetDirectoriesFormDatabase();
            foreach (var directory in directories)
            {
                AddExternalDirectory(directory);
            }
            GetChildern = () => directories;
            return directories;

        }

        protected bool AddExternalDirectory(IDirectory directory)
        {
            directory.Parent = this;
            Names.Add(directory.Name);
            directories.Add(directory);
            return true;
        }

        #region Absract
        protected abstract bool SetDatabaseName(string name);

        protected abstract bool SetDatabaseDescription(string description);


        protected abstract List<ILeaf> GetLeavesFormDatabase();

        protected abstract List<IDirectory> GetDirectoriesFormDatabase();

        #endregion


        protected List<ILeaf> GetFuncLeafInitial()
        {
            var leaves = GetLeavesFormDatabase();
            foreach (var leaf in leaves)
            {
                AddExternalLeaf(leaf);
            }
            GetLeaves = () => leaves;
            return leaves;
        }

        protected bool AddExternalLeaf(ILeaf leaf, bool add = false)
        {
            leaf.Parent = this;
            Names.Add(leaf.Name);
            if (add)
            {
                leaves.Add(leaf);
            }
            return true;

        }

        bool IChildrenName.Check(INamed named)
        {
            return !Names.Contains(named.Name);
        }

        bool IChildrenName.Check(string name)
        {
            return !Names.Contains(name);
        }

        bool IChildrenName.Add(INamed named)
        {
            Names.Add(named.Name);
            if (named is ILeaf leaf)
            {
                leaves.Add(leaf);
                leaf.Parent = this;
            }
            else if (named is IDirectory directory)
            {
                directories.Add(directory);
                directory.Parent = this;
            }
            return true;
        }

        bool IChildrenName.Remove(INamed named)
        {
            {
                Names.Remove(named.Name);
                if (named is ILeaf leaf)
                {
                    leaves.Remove(leaf);
                    leaf.Parent = null;
                }
                else if (named is IDirectory directory)
                {
                    directories.Remove(directory);
                    directory.Parent = null;
                }
                return true;
            }
        }

        protected Issue Get(object o, ErrorType errorType, OperationType operationType)
        {
            return new Issue(o, errorType, operationType);
        }

 
        #endregion
    }
}