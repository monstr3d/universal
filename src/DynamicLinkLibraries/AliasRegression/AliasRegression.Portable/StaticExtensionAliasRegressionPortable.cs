using System;
using System.Collections.Generic;
using AssemblyService.Attributes;
using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Interfaces;

namespace Regression.Portable
{
    /// <summary>
    /// Static extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionAliasRegressionPortable
    {
        #region Public Members

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        #endregion

        #region Private

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionAliasRegressionPortable()
        {
            new CSCodeCreator();
        }

        #endregion

        #region Code Creator

        class CSCodeCreator : IClassCodeCreator
        {

            internal CSCodeCreator()
            {
                this.AddCSharpCodeCreator();
            }


            #region IClassCodeCreator Members

            List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
            {
                List<string> l = new List<string>();
                string str = null;
                if ((obj is SelectionLink))
                {
                    str = "Regression.Portable.SelectionLink";
                }
                if (obj is AliasRegression)
                {
                    return Create(obj as AliasRegression);
                }
                if (str == null)
                {
                    return null;
                }
                l.Add(str);
                l.Add("{");
                l.Add("}");
                return l;
            }

            List<string> Create(AliasRegression ar)
            {
                List<string> l = new List<string>();
                string str = "Regression.Portable.AliasRegression";
                l.Add(str);
                l.Add("{");
                l.Add("\tinternal CategoryObject()");
                l.Add("\t{");
      /*          l.Add("");
                l.Add("\t}");
                l.Add("");
                l.Add("\tpublic override void PostSetArrow()");
                l.Add("\t{");*/
                var ali = ar.Aliases;
                l.Add("\t\tvar d = new  Dictionary<int, object[]>();");
                l.Add("\t\tdouble x = 0;");
                l.Add("\t\tdouble y = 0;");
                l.Add("\t\tstring s = \"\";");
                l.Add("\t\tvar la = new List<double>();");
                l.Add("\t\tvar ld = new List<double>();");
                foreach (var key in ali.Keys)
                {
                    object[] o = ali[key];
                    string s = o[0] as string;
                    double x = (double)o[1];
                    double y = (double)o[2];
                    l.Add("\t\tx = " + x.StringValue() + ";");
                    l.Add("\t\ty = " + y.StringValue() + ";");
                    l.Add("\t\ts = \"" + s + "\";");
                    l.Add("\t\td[" + key + "] = new object[] {s, x, y};");
                    l.Add("\t\taliasNames.Add(s);");
                    l.Add("\t\tla.Add(x);");
                    l.Add("\t\tld.Add(y);");
                }
                l.Add("\t\tdispersions =  la.ToArray();");
                l.Add("\t\tdelta =  ld.ToArray();");
                //   l.Add("\t\tAliases = d;");
                l.Add("\t\tstandardDeviation = " +
                    ar.StandardDeviation.StringValue() + ";");
                var mn = ar.MeasuresNames;
                l.Add("\t\tint i = 0;");
                foreach (int i in mn.Keys)
                {
                    l.Add("\t\ti = " + i + ";");
                    l.Add("\t\tmeasurementsNames[i] = \"" + mn[i] + "\";");
                }
                var sn = ar.SelectionsNames;
                foreach (int i in sn.Keys)
                {
                    l.Add("\t\ti = " + i + ";");
                    l.Add("\t\tselectionNames[i] = \"" + sn[i] + "\";");
                }
                l.Add("\t}");
                l.Add("}");
                return l;
            }

            #endregion
        }

        #endregion

    }
}
