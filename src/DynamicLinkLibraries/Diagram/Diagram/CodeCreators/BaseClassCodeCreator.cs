using BaseTypes.Attributes;
using CategoryTheory;
using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;

namespace Diagram.UI.CodeCreators
{

    [Language("C#")]
    public class BaseClassCodeCreator : IClassCodeCreator
    {

        static protected NamedTree.Performer performer = new();

        protected Dictionary<Func<object, bool>, Func<string, object, List<string>>> dictionary =
            new Dictionary<Func<object, bool>, Func<string, object, List<string>>>();

        protected virtual IDesktopCodeCreator DesktopCodeCreator {  get; set; }

        IDesktopCodeCreator IClassCodeCreator.DesktopCodeCreator { get => DesktopCodeCreator; set => DesktopCodeCreator = value; }

        protected BaseClassCodeCreator(bool b)
        {
        }


        internal BaseClassCodeCreator()
        {
            this.AddClassCodeCreator();
        }

        protected virtual string BaseClassString(string prefix, object obj)
        {
            return obj.GetType().Name;
        }


        protected virtual List<string> CreateArrow(object obj)
        {
            if (obj is ICategoryArrow arrow)
            {
                var str = arrow.GetType().FullName;
                List<string> l = new List<string>();
                l.Add(str);
                l.Add("{");
                l.Add("}");
                return l;
            }
            return null;

        }

        List<string> IClassCodeCreator.CreateCode(string prefix, object obj, string volume)
        {
            return CreateCode(prefix, obj, volume);
        }

        protected virtual List<string> CreateCode(string prefix, object obj, string volume)
        {
            List<string> l = CreateArrow(obj);
            if (l != null)
            {
                return l;
            }
            foreach (Func<object, bool> key in dictionary.Keys)
            {
                if (key(obj))
                {
                    return dictionary[key](prefix, obj);
                }
            }
            return null;

        }

    }
}
