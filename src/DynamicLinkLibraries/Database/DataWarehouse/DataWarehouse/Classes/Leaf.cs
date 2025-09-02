using System;
using System.Collections.Generic;

using DataWarehouse.Interfaces;

using ErrorHandler;

using NamedTree;

namespace DataWarehouse.Classes
{
    /// <summary>
    /// Leaf 
    /// </summary>
    public class Leaf :  Abstract.Leaf
    {
        public Leaf(object Id, string Name, string Description, string  Extension, byte[] Data) :
            base(Id, Name, Description, Extension, Data)
        {
        }

        #region Overriden properties and methods

    
        protected override void Add(INode<INode> node)
        {
            throw new OwnNotImplemented("Leaf Add");
        }

        protected override byte[] GetDatabaseData()
        {
            throw new OwnNotImplemented();
        }

        protected override void Remove(INode<INode> node)
        {
            throw new OwnNotImplemented("Leaf Remove");
        }

        protected override bool RemoveFromDatabase()
        {
            throw new OwnNotImplemented("Leaf Remove");
        }

        protected override void RemoveItself()
        {
            throw new OwnNotImplemented("Leaf Remove itself");
        }

        protected override bool SetDatabaseData(byte[] data)
        {
            throw new OwnNotImplemented();
        }

        protected override bool SetDatabaseDescription(string description)
        {
            throw new OwnNotImplemented();
        }

        protected override bool SetDatabaseName(string name)
        {
            throw new OwnNotImplemented();
        }

        #endregion

    }
}
