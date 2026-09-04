using BaseTypes.Attributes;
using BaseTypes.CodeCreator.Interfaces;
using Diagram.Interfaces;
using Diagram.UI;
using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;
using Diagram.UI.Portable;

namespace Diagram.UI.TypeScript
{
    [Language("TS")]
    public class ClassCodeCreator : IClassCodeCreator//, IParametersCodeCreator, IPropertiesCodeCreator
    {
        protected virtual IChildrenCodeCreator ChildrenCodeCreator { get; set; }
        protected List<object> loaded = new List<object>();
        protected Performer performer = new Performer();
        protected Dictionary<Func<object, bool>, Func<string, object, List<string>>> dictionary;

        protected ITypeCreator typeCreator;

        protected virtual ITypeCreator TypeCreator
        {
            get { return typeCreator; }
        }
 
        internal ClassCodeCreator()
        {
            CreateAll();
            
         //   par = this;
         //   pr = this;
            dictionary = new Dictionary<Func<object, bool>, Func<string, object, List<string>>>
            {
                { (object o) => { return o is BelongsToCollection; } , CreateBelongs },

            };
            this.AddClassCodeCreator();
        }

        protected virtual void CreateAll()
        {
           this.typeCreator = performer.GetLaguageObject<ITypeCreator>(this);
        }

        protected ClassCodeCreator(bool b)
        {
            CreateAll();
        }

        protected virtual IDesktopCodeCreator DesktopCodeCreator { get; set; }

        IDesktopCodeCreator IClassCodeCreator.DesktopCodeCreator { get => DesktopCodeCreator; set => DesktopCodeCreator = value; }

    
        protected virtual List<string> CreateCode(string prefix, object obj, string volume)
        {
            foreach (var val in dictionary)
            {
                if (val.Key(obj))
                {
                    return val.Value(prefix, obj);
                }
            }
            return null;
        }
        protected void Add(List<string> l, List<string> ll, int shift)
        {
            if (ll == null) return;
            performer.Add(l, ll, shift);
        }

        List<string> IClassCodeCreator.CreateCode(string prefix, object obj, string volume)
        {
            return CreateCode(prefix, obj, volume);
        }


        /// <summary>
        /// Array to list
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="x">x</param>
        /// <returns></returns>
        protected List<string> Get(string id, double[] x)
        {
            return performer.Get(id, x).ToList();
        }

        List<string> CreateBelongs(string preffix, object obj)
        {
            return CreatePure(preffix, "BelongsToCollection");
        }

        protected virtual List<string> CreatePure(string preffix, string name)
        {
            return performer.CreatePure(preffix, name); 
        }


        /// <summary>
        /// Enumerable to list
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="x">x</param>
        /// <returns></returns>
        protected List<string> Get(string id, IEnumerable<string> x)
        {
            return performer.CreateList(id, x).ToList();
        }

 
        protected virtual List<string> CreateParameters(string prefix, object parent, object obj, string volume)
        {
            return null;
        }

        protected virtual List<string> SetParameters(string prefix, object parent, object obj, string volume)
        {
            return null;
        }

/*
        List<string> IPropertiesCodeCreator.CreateProperties(string prefix, object obj, string volume)
        {
            return CreateProperties(prefix, obj, volume);
        }
        List<string> IPropertiesCodeCreator.SetProperties(string prefix, object obj, string volume)
        {
            return SetProperties(prefix, obj, volume);
   *    }*/

        protected virtual List<string> SetProperties(string prefix, object obj, string volume)
        {
            return null;
        }


        protected virtual List<string> CreateProperties(string prefix, object obj, string volume)
        {
            return null;
        }

  




    }
}
