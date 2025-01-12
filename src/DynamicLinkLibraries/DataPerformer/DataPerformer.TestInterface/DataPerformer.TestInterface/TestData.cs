using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Diagram.UI.Interfaces;

using TestCategory;
using TestCategory.Interfaces;

namespace DataPerformer.TestInterface
{
    [Serializable()]
    public class TestData1 : TestCollection
    {

    
        #region Ctor

        /// <summary>
        /// Default
        /// </summary>
        public TestData1() : base(null)
        {
            
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected TestData1(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        #endregion

        #region Members

 
        // +++TEST+++
        protected virtual bool Process(int i, ITest test, Dictionary<string, object[]> d)
        {
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

        public void AddChart(string name, double start, double step, 
            int stepCount, string argument, string[] values, IComponentCollection collection)
        {
            SeriesWrapper.LocalChart lc = 
                new SeriesWrapper.LocalChart(name, start, step, stepCount, argument, values);
            lc.Create(collection);
            testList.Add(lc);
        }

        public void AddRegression(string name, uint number, IComponentCollection collection)
        {
            Regression.RegressionTest rt = new Regression.RegressionTest(name, (int)number);
            rt.Create(collection);
            testList.Add(rt);
        }

        public void AddIteratorGLM(string name, uint number, IComponentCollection collection)
        {
            Regression.IteratorGLMTest it = new Regression.IteratorGLMTest(name, (int)number);
            it.Create(collection);
            testList.Add(it);
        }

        public void AddStructuredSelection(string name, IComponentCollection collection)
        {
            var it = new Regression.StruturedSeletionCollectionTest(name);
            it.Create(collection);
            testList.Add(it);
        }



 
        #endregion


    }
}
