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
        public Leaf(object Id, string Name, string Description, byte[] Data, string Extension = null) :
            base(Id, Name, Description, Data, Extension)
        {
        }

        #region Overriden properties and methods

    
        protected override void Add(INode<INode> node)
        {
            throw new OwnNotImplemented("Leaf Add");
        }

        protected override void Remove(INode<INode> node)
        {
            throw new OwnNotImplemented("Leaf Remove");
        }

        protected override void RemoveItself()
        {
            throw new OwnNotImplemented("Leaf Remove itself");
        }

        #endregion

    }
}
