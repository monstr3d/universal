using System;
using System.Collections.Generic;
using CategoryTheory;
using DataPerformer.Interfaces;
using System.Drawing;
using System.Linq;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using TestCategory;
using TestCategory.Interfaces;
using Diagram.UI;

namespace DataPerformer.TestInterface
{
    internal class TestCreator : ITestCreator
    {
        internal TestCreator() 
        {
            this.Add();
        }

        ITest ITestCreator.Create(out string name, uint number, 
            IObjectLabel label, IComponentCollection collection)
        {
            ICategoryObject co = label.Object;
            name = label.GetName(collection);
        // +++TEST+++
            /*         switch (co)
                     {
                         case global::Regression.Portable.AliasRegression reg:
                             test.AddRegression(name, (uint)row[3], collection);
                             return;
                         case global::Regression.Portable.IteratorGLM it:
                             test.AddIteratorGLM(name, (uint)row[3], collection);
                             return;
                         default:
                             break;
                     }
                     if (co is IStructuredSelectionCollection)
                     {
                         test.AddStructuredSelection(name, collection);
                     }

                     if (co is global::Regression.Portable.AliasRegression)
                     {
                         test.AddRegression(name, (uint)row[3], collection);
                         return;
                     }
                     if (o is IProperties)
                     {
                         object ob = (o as IProperties).Properties;
                         if (ob.GetType().Equals(typeof(DataPerformer.UI.Labels.GraphLabel)))
                         {
                             var lab = ob as DataPerformer.UI.Interfaces.IGraphLabel;
                             var data = lab.Data;
                             // var  t = data.Item1[0];
                             Dictionary<string, Color[]> d = data.Item1;
                             IEnumerable<string> keys = d.Keys;
                             DataConsumer cons = co as DataConsumer;
                             test.AddChart(name, cons.Start, cons.Step, cons.Steps,
                                 data.Item4[1], keys.ToArray<string>(), collection);
                             return;
                         }
                     }*/
            return null;
        }

        bool ITestCreator.Process(int i, ITest test, Dictionary<string, object[]> dictionary)
        {
            var d = dictionary;
            switch (test)
            {
                case SeriesWrapper.LocalChart lc:
                    d[lc.Name] = new object[] { i };
                    return true;
                case Regression.RegressionTest rt:
                    d[rt.Name] = new object[] { i };
                    return true;
                case Regression.IteratorGLMTest it:
                    d[it.Name] = new object[] { i };
                    return true;
                default:
                    return false;
            }
        }
    }
}
