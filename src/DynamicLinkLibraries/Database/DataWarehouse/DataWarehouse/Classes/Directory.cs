using System.Collections.Generic;

using DataWarehouse.Interfaces;

using ErrorHandler;

using NamedTree.Interfaces;

namespace DataWarehouse.Classes
{
    public class Directory : Abstract.Directory
    {
        protected override object Id { get => base.Id; set => base.Id = value; }
        protected override string Name { get => base.Name; set => base.Name = value; }
        protected override string Extension { get => base.Extension; set => base.Extension = value; }
        protected override string Description { get => base.Description; set => base.Description = value; }

        protected override INode Value => base.Value;

        protected override INode<INode> Parent { get => base.Parent; set => base.Parent = value; }
        protected override IEnumerable<INode<INode>> Nodes { get => base.Nodes; set => base.Nodes = value; }
        protected override IEnumerable<IDirectory> Children { get => base.Children; set => base.Children = value; }
        protected override IEnumerable<ILeaf> Leaves { get => base.Leaves; set => base.Leaves = value; }
        #region Ctor


        public Directory(object Id, string Name, string Description, string Extension, bool children) : 
            base(Id, Name, Description, Extension, children)
        {
        }

        #endregion

        #region Overriden properties and methods

        protected override void Add(INode<INode> node)
        {
          //  OnAdd?.Invoke(node as INode<INode>);
            throw new OwnNotImplemented("Directory Add");
        }


        protected override bool RemoveFromDatabase()
        {
            throw new OwnNotImplemented("Directory Remove");

        }

        protected override void Remove(INode<INode> node)
        {
            throw new OwnNotImplemented("Directory Remove");
        }

        protected override void RemoveItself()
        {
            throw new OwnNotImplemented("Directory Remove itself");
        }

        protected override IDirectory Add(IDirectory directory)
        {
            //AddDirectory(directory);
            throw new OwnNotImplemented("Directory Remove itself");
        }

        protected override IDirectory AddToDatabase(IDirectory directory)
        {
            throw new OwnNotImplemented("Directory Add to database");
        }

        protected override ILeaf Add(ILeaf leaf)
        {
            //AddLeaf(leaf);
            throw new OwnNotImplemented("Directory Remove itself");
        }


        protected override void Remove(IDirectory directory, string ext)
        {
            throw new OwnNotImplemented("Directory remove directory");
        }

        protected override void Remove(ILeaf leaf, string ext)
        {
            throw new OwnNotImplemented("Directory remove leaf");
        }


        #region Abstract

        protected override bool SetDatabaseName(string name)
        {
            throw new OwnNotImplemented();
        }

        protected override bool SetDatabaseDescription(string description)
        {
            throw new OwnNotImplemented();
        }

        protected override List<ILeaf> GetLeavesFormDatabase()
        {
            throw new OwnNotImplemented();
        }

        protected override List<IDirectory> GetDirectoriesFormDatabase()
        {
            throw new OwnNotImplemented();
        }

        protected override ILeaf AddToDatabase(ILeaf leaf)
        {
            throw new OwnNotImplemented("Directory Add");
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override void RemoveAllChildren()
        {
            base.RemoveAllChildren();
        }

        public override void Add(string name)
        {
            base.Add(name);
        }

        public override void Remove(string name)
        {
            base.Remove(name);
        }

        protected override bool UpdateName(string name)
        {
            return base.UpdateName(name);
        }

        protected override bool UpdateDescription(string description)
        {
            return base.UpdateDescription(description);
        }

        protected override void RemoveChild(IDirectory child)
        {
            base.RemoveChild(child);
        }

        protected override void RemoveChild(ILeaf child)
        {
            base.RemoveChild(child);
        }

        protected override List<IDirectory> GetFuncInitial()
        {
            return base.GetFuncInitial();
        }

        protected override List<ILeaf> GetFuncLeafInitial()
        {
            return base.GetFuncLeafInitial();
        }

        protected override bool AcceptUpdate(string name)
        {
            return base.AcceptUpdate(name);
        }

        protected override bool Change(INamed named, string newname)
        {
            return base.Change(named, newname);
        }

        protected override bool Post()
        {
            return base.Post();
        }

        public override bool Check(INamed named)
        {
            throw new System.NotImplementedException();
        }

        public override bool Add(INamed named)
        {
            throw new System.NotImplementedException();
        }

        public override bool Remove(INamed named)
        {
            throw new System.NotImplementedException();
        }



        #endregion


        #endregion
    }
}
