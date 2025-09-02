using BaseTypes.Attributes;
using BaseTypes.CodeCreator.Interfaces;
using Diagram.UI;
using ErrorHandler;


namespace Diagram.Java
{
    [Language("Java")]
    internal class TypeCreator : ITypeCreator
    {
        const double a = 0;
        Dictionary<Type, Func<object, string>[]> d = new Dictionary<Type, Func<object, string>[]>()
        {
            { typeof(double), new Func<object, string>[]
            { (o) =>  "double[]",
                (o) =>  "new double[]{0}",
                 GetStringDoubleValue,


            }
            },
                          { typeof(bool), new Func<object, string>[]
            { (o) =>  "boolean[]",
                (o) =>  "new boolean[]{true}",
                 GetStringBoolValue,


            }


        }
        };

        string Get(object o, int n)
        {
            var t = o.GetType();
            if (d.ContainsKey(t))
            {
                return d[t][n](o);
            }
            throw new OwnNotImplemented();
        }

        internal TypeCreator()
        {
            this.AddTypeCreator();
        }

        string ITypeCreator.GetType(object o)
        {
            return Get(o, 0);
        }
        string ITypeCreator.GetDefaultValue(object o)
        {
            return Get(o, 1);
        }

        string ITypeCreator.GetStringValue(object o)
        {
            return Get(o, 2);
            if (o.GetType() == typeof(double))
            {
                var x = (double)o;
                var c = performer.DoubleToString(x);
                return "new double[]{" + c + "}";
            }
            throw new OwnNotImplemented();
        }

   

        static string GetStringDoubleValue(object o)
        {
            var x = (double)o;
            var c = performer.DoubleToString(x);
            return "new double[]{" + c + "}";
        }

        static string GetStringBoolValue(object o)
        {
            var x = (bool)o;
            var c = (o + "").ToLower();
            return "new boolean[]{ " + c + " }";
        }


        static Performer performer = new Performer();
    }
}
