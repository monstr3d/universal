using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

using Diagram.UI.Interfaces;

using TestCategory.Interfaces;

using DataPerformer.TestInterface;



namespace SoundService.Test
{
     /// <summary>
    /// Tests data with sound
    /// </summary>
    [Serializable()]
    public class TestDataSound : TestData
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TestDataSound()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected TestDataSound(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Public Members

        public void AddSound(string name, double start, double step,
            int stepCount, IComponentCollection collection)
        {
            SoundTest st = new SoundTest(collection, name, start, step, stepCount);
            testList.Add(st);
        }

  
        #endregion

        #region Overriden

        protected override bool Process(int i, ITest test, Dictionary<string, object[]> d)
        {
            if (base.Process(i, test, d))
            {
                return true;
            }
            if (test is SoundTest)
            {
                SoundTest st = test as SoundTest;
                d[st.Name] = new object[]{i};
                return true;
            }
            return false;
        }


        #endregion
    }
}
