using BaseTypes.Attributes;
using Diagram.UI;
using Diagram.UI.Interfaces;

namespace DinAtm.Portable.TypeScript
{
    [Language("TS")]
    internal class ClassCodeCreator : IClassCodeCreator
    {


        static Diagram.UI.TypeScript.Performer performer = new();

        internal ClassCodeCreator()
        {
            this.AddClassCodeCreator();
        }


    

        List<string> IClassCodeCreator.CreateCode(string preffix, object obj, string volume)
        {
            if (obj is Atmosphere atmosphere)
            {
                var l = CreateObjectTransformer(preffix, atmosphere);
                return l;
            }
            return null;

        }

        protected virtual string BaseClassString(string prefix, object obj)
        {
            return obj.GetType().Name;
        }

        static List<string> CreateObjectTransformer(string preffix, Atmosphere atmosphere)
        {
            List<string> l = new List<string>();
            var s = performer.ClassString(preffix, "AtmosphereCategoryObject");
            l.Add(s);
            l.Add("{");
            var iff = atmosphere.If;
            performer.AddObjectConstructor(l);
            s = "let iff : number[] =  [" + iff[0] + "," + iff[1] + "," + iff[2] + "];\n this.setIf(iff);";
            l.Add(s);
            l.Add("\t}");
            l.Add("}");
            return l;
        }
    }
}

