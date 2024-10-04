using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CategoryTheory
{
    /// <summary>
    /// Acceptor of functor
    /// </summary>
    public interface IFunctorAcceptor
    {
        /// <summary>
        /// Accepts an object
        /// </summary>
        /// <param name="categoryObject">Object of category</param>
        /// <returns>True if object is accepted</returns>
        bool Accept(ICategoryObject categoryObject);
        
        /// <summary>
        /// Accepts an arrow
        /// </summary>
        /// <param name="categoryArrow">Arrow of category</param>
        /// <returns>True if arrow is accepted</returns>
        bool Accept(ICategoryArrow categoryArrow);
    }
}
