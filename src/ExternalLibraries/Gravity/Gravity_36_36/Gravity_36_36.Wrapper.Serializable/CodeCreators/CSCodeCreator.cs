using BaseTypes.Attributes;
using Diagram.UI;
using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;
using ErrorHandler;
using System;
using System.Collections.Generic;


namespace Gravity_36_36.Wrapper.CodeCreators
{
    [Language("C#")]
    class CSCodeCreator : IClassCodeCreator
    {

        internal CSCodeCreator()
        {
           this.AddClassCodeCreator();
        }


        #region IClassCodeCreator Members


        protected IDesktopCodeCreator DesktopCodeCreator
        { get; set; }



  
        protected virtual string BaseClassString(string prefix, object obj)
        {
            return obj.GetType().Name;
        }


        List<string> IClassCodeCreator.CreateCode(string preffix, object obj, string volume)
        {
            var b = obj is Gravity_36_36.Wrapper.Gravity;
            if (!b)
            {
                return null;
            }
            var gravity = obj as Gravity_36_36.Wrapper.Gravity;
            if (gravity == null)
            {
                return null;
            }
            string str = "Gravity_36_36.Wrapper.Gravity";
            List<string> l = new List<string>();
            l.Add(str);
            l.Add("{");
            l.Add("internal CategoryObject()");
            l.Add("{");
            l.Add("\tobject o = null;");
            l.Add("\tdouble[] arr = null;");
            l.Add("\tList<object> l = new List<object>();");
            List<object> saver = gravity.Saver;
            foreach (object o in saver)
            {
                Type t = o.GetType();
                if (t == typeof(double))
                {
                    l.Add("\tl.Add((double)(" + o.StringValue() + "));");
                }
                if (t == typeof(int))
                {
                    l.Add("\tl.Add((int)(" + o.StringValue() + "));");
                }
                else if (t.IsArray)
                {
                    Type te = t.GetElementType();
                    if (te == typeof(double))
                    {
                        l.Add("\tarr = new double[]");
                        l.Add("\t{");
                        double[] arr = o as double[];
                        for (int i = 0; i < arr.Length; i++)
                        {
                            string s = "\t\t" + arr[i].StringValue();
                            if (i < arr.Length - 1)
                            {
                                s += " ,";
                            }
                            l.Add(s);
                        }
                        l.Add("\t};");
                     }
                    l.Add("l.Add(arr);");
                }
                else
                {
                    throw new OwnException();
                }
            }
            l.Add("Saver = l;");
            l.Add("}");
            l.Add("}");
            return l;
        }

        #endregion
    }
}
