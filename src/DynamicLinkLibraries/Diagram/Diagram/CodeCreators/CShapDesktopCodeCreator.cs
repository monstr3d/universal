using System;
using System.Collections.Generic;

using BaseTypes.Attributes;
using CategoryTheory;
using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;

namespace Diagram.UI.CodeCreators
{
    [Language("C#", ".cs")]
    internal class CShapDesktopCodeCreator : IDesktopCodeCreator
    {
        Performer performer = new Performer();

        public CShapDesktopCodeCreator()
        {
            this.AddDesktopCodeCreator();
        }
  
        IComponentCollection collection;

        Tuple<Dictionary<ICategoryObject, int>, Dictionary<ICategoryArrow, int>> dictionary;

        IComponentCollection IDesktopCodeCreator.ComponentCollection => collection;

        Tuple<Dictionary<ICategoryObject, int>, Dictionary<ICategoryArrow, int>> IDesktopCodeCreator.Enumeration => dictionary;

        List<string> IDesktopCodeCreator.CreateCode(IComponentCollection collection, string namespacE, string className, bool staticClass)
        {
            this.collection = collection;
            dictionary = performer.Enumerate(collection);
            return collection.CreateInitDesktopCSharpCode(namespacE, className, staticClass);
        }
    }
}
