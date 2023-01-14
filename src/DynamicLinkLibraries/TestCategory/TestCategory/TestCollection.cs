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

        /// <summary>
        /// Tests
        /// </summary>
        protected ITest[] tests;

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
                    var ob = tests[i][collection];
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
    }
}
