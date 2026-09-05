using BaseTypes.Attributes;
using BaseTypes.CodeCreator.Interfaces;
using DataPerformer.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;
using ErrorHandler;



namespace DataPerformer.Portable.Java
{
    [Language("Java")]
    public class ClassCodeCreator : Diagram.Java.ClassCodeCreator, IAliasCodeCreator
    {
        static Performer  p = new Performer();

        protected virtual void InitPortable()
        {
            Performer = new Portable.Performer();
            this.AddClassCodeCreator();
            this.AddAliasCreator();

        }



        public ClassCodeCreator() : base(false)
        {
            InitPortable();
            
            classes = new Dictionary<string, string>()
            {
                {"DataLink", "measurements.arrows.DataLink" },
                {"IteratorConsumerLink", "measurements.arrows.IteratorConsumerLink" },
                   {"ObjectTransformerLink", "measurements.arrows.ObjectTransformerLink" },
                { "DataConsumer", "measurements.DataConsumer"},
                { "RandomGenerator", "measurements.RandomGenerator"},
               { "ObjectTransformer", "measurements.ObjectTransformer"},
               { "FilterWrapper", "measurements.FilterWrapper"},
         };

            dictionary = new Dictionary<Func<object, bool>, Func<string, object, List<string>>>()
         {
                   { (object o) => { return DetectType(o, "DataConsumer"); } , CreateDataConsumer },
                   { (object o) => { return o is DataLink; } , CreateDataLink },
                   { (object o) => { return o is IteratorConsumerLink; } , CreateIteratorConsumerLink },
                   { (object o) => { return o is ObjectTransformerLink; } , CreateObjectTransformerLink },
                 { (object o) => { return o is RandomGenerator; } , CreateRandom },
                 { (object o) => { return o is ObjectTransformer; } , CreateObjectTransformer },
                 { (object o) => { return o is FilterWrapper; } , CreateFilterWrapper },
          };
           this.AddClassCodeCreator(); 
        
        }
    

        static List<string> CreateDataLink(string preffix, object obj)
        {
            return new List<string>() { "}", "}" };
        }


        static List<string> CreateIteratorConsumerLink(string preffix, object obj)
        {
            return new List<string>() { "}", "}" };
        }



        static List<string> CreateObjectTransformerLink(string preffix, object obj)
        {
            return new List<string>() { "}", "}" };
        }

        static List<string> CreateObjectTransformer(string preffix, object obj)
        {
            var ot = obj as ObjectTransformer;
            var io = ot.InputOutput;
            var dl = ot.Links;
            var d = enumerableIntCodeCreator.Create("array", io);
            var l = d.Values.ToArray()[0];
            l.Add("this.array = array;");
            l.Add("}");
            l.Add("}");
            return l;
        }

        static List<string> CreateFilterWrapper(string preffix, object obj)
        {
            var fw = obj as FilterWrapper;
            var l = new List<string>();
            l.Add("\tinput = " + p.Wrap(fw.Input) + ";");
            l.Add("}");
            l.Add("}");
            return l;
        }
  


        static List<string> CreateDataConsumer(string preffix, object obj)
        {
            return new List<string>() { "}", "}" };
        }


        static List<string> CreateRandom(string preffix, object obj)
        {
            return new List<string>() { "}", "}" };
        }


        Dictionary<string, List<string>> IAliasCodeCreator.Create(string id, IAlias alias)
        {
            var typeCreator = Performer.GetLaguageObject<ITypeCreator>(this);
           var d = new Dictionary<string, List<string>>();
            var l = new List<string>();
            l.Add("java.util.Map< String, general_service.Entry<Object, Object >> " + id + " = new java.util.HashMap<>();");
            var names = alias.AliasNames;
            foreach (var name in names)
            {
                var type =  typeCreator.GetType(alias.GetType(name));
                type = "new " +  type.Replace("[]", "[0]");
                var val = typeCreator.GetStringValue(alias[name]);
                var s = id + ".put(\"" + name + "\", new general_service.Entry<Object, Object>(";
                s += type + ", " + val + "));";
                l.Add(s);
            }
            l.Add("setMap(" + id + ");");
            d["code"] = l;
            return d;
        }
    }
}