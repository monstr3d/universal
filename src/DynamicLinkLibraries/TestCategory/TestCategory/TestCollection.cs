using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Diagram.UI.Interfaces;

using TestCategory.Interfaces;


namespace TestCategory
{
    /// <summary>
    /// Collection of tests
    /// </summary>
    [Serializable()]
    public class TestCollection : ITest, ISerializable
    {
        #region Fields

        ITestCreator creator = StaticExtensionTestCategory.TestCreator;

        /// <summary>
        /// Tests
        /// </summary>
        protected ITest[] tests;

        /// <summary>
        /// List of tests
        /// </summary>
        protected List<ITest> testList = new List<ITest>();

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tests">Tests</param>
        public TestCollection(ITest[] tests)
        {
            this.tests = tests;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected TestCollection(SerializationInfo info, StreamingContext context)
        {
            tests = info.GetValue("Tests", typeof(ITest[])) as ITest[];
        }

        #endregion

        #region ITest Members

        Tuple<bool, object> ITest.this[IComponentCollection collection]
        {
            get
            {
                var result = true;
                List<object> o = new List<object>();
                for (int i = 0; i < tests.Length; i++)
                {
                    var test = tests[i];
                    var ob = test[collection];
                    if (ob != null)
                    {
                        o.Add(ob);
                        if (!ob.Item1)
                        {
                            result = false;
                        }
                    }
                  
                }
                if (o.Count == 0)
                {
                    return null;
                }
                return new Tuple<bool, object>(result, o.ToArray());
            }
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Tests", tests, typeof(ITest[]));
        }

        #endregion

        /// <summary>
        /// Output
        /// </summary>
        public Dictionary<string, object[]> Output
        {
            get
            {
                Dictionary<string, object[]> d = new Dictionary<string, object[]>();
                for (int i = 0; i < tests.Length; i++)
                {
                    ITest test = tests[i];
                    creator.Process(i, test, d);
                }
                return d;
            }
        }


        /// <summary>
        /// Adds test
        /// </summary>
        /// <param name="test">The test</param>
        public void Add(ITest test)
        {
            testList.Add(test);
        }

        public void Close()
        {
            tests = testList.ToArray();
            testList.Clear();
        }


    }
}
