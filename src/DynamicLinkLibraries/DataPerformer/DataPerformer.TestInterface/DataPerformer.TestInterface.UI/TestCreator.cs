using CategoryTheory;
using DataPerformer.Interfaces;
using DataPerformer.TestInterface.Regression;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TestCategory;
using TestCategory.Interfaces;

namespace DataPerformer.TestInterface.UI
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
            switch (co)
            {
                case global::Regression.Portable.AliasRegression reg:
                    Regression.RegressionTest rt = new RegressionTest(name, (int)number);
                    rt.Create(collection);
                    return rt;
                case global::Regression.Portable.IteratorGLM it:
                    Regression.IteratorGLMTest itt = new IteratorGLMTest(name, (int)number);
                    itt.Create(collection);
                    return itt;
                    case IStructuredSelectionCollection iss:
                    var isst = new StruturedSeletionCollectionTest(name);
                    isst.Create(collection);
                    return isst;
                default:
                    break;
            }
            if (label is IProperties)
            {
                object ob = (label as IProperties).Properties;
                if (ob.GetType().Equals(typeof(DataPerformer.UI.Labels.GraphLabel)))
                {
                    var lab = ob as DataPerformer.UI.Interfaces.IGraphLabel;
                    var data = lab.Data;
                    // var  t = data.Item1[0];
                    Dictionary<string, Color[]> d = data.Item1;
                    IEnumerable<string> keys = d.Keys;
                    DataConsumer cons = co as DataConsumer;
                    var lc =
                    new SeriesWrapper.LocalChart(name, cons.Start,
                    cons.Step, cons.Steps, data.Item4[1], keys.ToArray());
                    lc.Create(collection);
                    return lc;
                }
            }
            return null;
        }

        bool ITestCreator.IsAdmissible(object o, ICategoryObject cob)
        {
            switch (cob)
            {
                case global::Regression.Portable.AliasRegression ar:
                    return true;
                case global::Regression.Portable.IteratorGLM it:
                    return true;
                default:
                    break;
            }
            if (cob is IStructuredSelectionCollection)
            {
                return true;
            }
            if (o is IProperties)
            {
                object ob = (o as IProperties).Properties;
                if (ob.GetType().Equals(typeof(DataPerformer.UI.Labels.GraphLabel)))
                {
                    return true;
                }
            }
            return false;
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
