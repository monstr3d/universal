using System;
using System.Collections.Generic;

using DataWarehouse.Interfaces;

using ErrorHandler;

using NamedTree;

namespace DataWarehouse.Classes
{
    public class Directory : Abstract.Directory
    {
         #region Ctor

        public Directory(object Id, string Name, string Description, string Extension = null) : 
            base(Id, Name, Description, Extension)
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



        #endregion


        #endregion
    }
}
