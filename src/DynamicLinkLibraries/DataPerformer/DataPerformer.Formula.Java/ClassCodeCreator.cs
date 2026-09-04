using BaseTypes.Attributes;
using BaseTypes.CodeCreator.Interfaces;
using DataPerformer.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;
using ErrorHandler;
using FormulaEditor;
using FormulaEditor.Interfaces;

namespace DataPerformer.Formula.Java
{
    /// <summary>
    /// Creator of TS code
    /// </summary>
    [Language("Java")]
    internal class ClassCodeCreator : Portable.Java.ClassCodeCreator, 
        IVariablesCodeCreator
    {
        protected override void InitPortable()
        {
            Performer = new DataPerformer.Formula.Performer();
            this.AddClassCodeCreator();
      //      this.AddAliasCreator();
            this.AddVariableCodeCreator();
        }



        public ClassCodeCreator()
        {
           
            dictionary = new Dictionary<Func<object, bool>, Func<string, object, List<string>>>()
         {
                   { (object o) => { return o is VectorFormulaConsumer; } , CreateObjectTreeObject },
                 { (object o) => { return o is DifferentialEquationSolver; } , CreateObjectTreeObject },
                { (object o) => { return o is Recursive; } , CreateObjectTreeObject },
          };

            classes = new Dictionary<string, string>()
            {
                {"VectorFormulaConsumer", "measurements.VectorFormulaConsumer" },
                {"DifferentialEquationSolver", "measurements.differential_equations.DifferentialEquationSolverFormula" },
                {"Recursive", "measurements.RecursiveFormula" },
            };
        }

    
        List<string> CreateObjectTreeObject(string prefix, object obj)
        {
            Exception  exception = null;
            try
            {
                CurrentObject = obj;
                return CreateTreeCollection(prefix, obj as ITreeCollection);
            }
            catch (Exception e)
            {
                exception = e;
            }
            throw new IncludedException(exception, obj);
        }

        protected virtual Dictionary<string, List<string>> CreateCode(object obj, ObjectFormulaTree[] trees,
            string className, string constructorModifier, bool checkValue)
        {
            throw new OwnNotImplemented();
        }

        Dictionary<string, List<string>> IVariablesCodeCreator.Create(IMeasurements measurements)
        {
            var d = new Dictionary<string, List<string>>();
            var l = CreateJavaVariableList(measurements);
            d["code"] = l;
            return d;
        }

        public  List<string> CreateJavaVariableList(IMeasurements measurements)
        {
            Exception exception = null;
            try
            {
                var l = new List<string>();
                var typeCreator = Performer.GetLaguageObject<ITypeCreator>(this);
                if (measurements is IStarted start)
                {
                    start.Start(0);
                }
                var n = measurements.Count;
                if (n > 0)
                {
                    l.Add("Object o;");
                }
                for (int i = 0; i < n; i++)
                {
                    var m = measurements[i];
                    var name = "\"" + m.Name + "\"";
                    var type = m.Type;
                    var v = typeCreator.GetType(type);
                    if (v.Contains("[]"))
                    {
                        v = v.Replace("[]", "[0]");
                        v = "new " + v;
                    }
                    l.Add("o = " + v + ";");
                    var pr = m.Parameter();
                //    var st = Performer.StringValue(pr);
                    l.Add("addVariableValue(" + name + ", o);");

                }
                return l;
            }
            catch (Exception e)
            {
                exception = e;
            }
            throw IncludedException.Get(exception);
        }


        protected virtual List<string> CreateTreeCollection(string preffix, ITreeCollection obj)
        {
            Exception  exception;
            try
            {
                var l = new List<string>();

                var creator = Performer.GetLaguageObject<IClassCodeCreator>(this);

                bool check = true;
                var treeCollectionCodeCreator = Performer.GetLaguageObject<ITreeCollectionCodeCreator>(this);
                var lt = treeCollectionCodeCreator.CreateCode(obj, obj.Trees, preffix, "internal ", check);

                if (treeCollectionCodeCreator is IAdditionalClassCodeCreator add)
                {
                    var classes = add.AdditionalCode;
                    if (classes != null && classes.Count > 0)
                    {
                        l.Add("");
                        l.Add("");
                        Performer.Add(l, classes, 0);
                        l.Add("");
                        l.Add("");
                    }
                }
                var constructor = creator.CreateCode(preffix, obj, "constructor");
                l.AddRange(constructor);
                if (obj is IAlias ali)
                {
                    var alicreator = Performer.GetLaguageObject<IAliasCodeCreator>(this);
                    var y = alicreator.Create("map", ali).Values.ToArray()[0];
                    l.AddRange(y);
                }
                if (obj is IMeasurements m)
                {
                    var vc = Performer.GetLaguageObject<IVariablesCodeCreator>(this);
                    var la = vc.Create(m).Values.ToArray()[0];
                    Performer.Add(l, la, 2);
                }


                if (obj is IInitialDictionary d) // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                {

                    var dic = d.Dictionary;
                    foreach (var k in dic)
                    {
                        var iname = "\"" + k.Key + "\"";
                    }
                }
                l.Add("\t}");
                l.Add("");
                Performer.Add(l, lt.Values.ToArray()[0], 1);
                var post = creator.CreateCode(preffix, obj, "post");
                l.AddRange(post);
                if (obj is IFeedbackCollectionHolder feedback)
                {

                    var dcc = Performer.GetLaguageObject<IFeedbackCollectionCodeCreator>(this);
                    var ll = dcc.Create(feedback).Values.ToArray()[0];
                    Performer.Add(l, ll, 1);
                }

                l.Add("}");
                return l;
            }
            catch (Exception ex)
            {
                 exception = IncludedException.Get(ex);
            }
            throw  exception;
        }

        
       


    }
}