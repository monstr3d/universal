using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Diagram.UI.Interfaces;

using TestCategory.Interfaces;

namespace DataPerformer.TestInterface
{
    /// <summary>
    /// Test intreface for data
    /// </summary>
    public class TestInterfaceDataPerformer : ITestInterface
    {

        #region Fields

        IEnumerable<TextWriter> writers;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="writers">Writers</param>
        public TestInterfaceDataPerformer(IEnumerable<TextWriter> writers)
        {
            this.writers = writers;
        }

        #endregion

        #region ITestInterface Members

        ITest ITestInterface.Edit(ITest test, IComponentCollection collection)
        {
            return null;
        }

        void ITestInterface.CreateTestReport(ITest test, IComponentCollection collection)
        {
            CreateTestReportProtected(test, collection);
        }

        #endregion

        #region Protected Virtual

        protected virtual void CreateTestReportProtected(ITest test, IComponentCollection collection)
        {
            if (test == null)
            {
                return;
            }
            Write("This calculation has tests");
            Write("=======Test results=======");
            object o = test[collection];
            if (o == null)
            {
                Write("Succcess");
                Write("=========================");
                return;
            }
            else
            {
                List<string> l = o.ToTestStringList();
                int i = 1;
                foreach (string s in l)
                {
                    Write(i + ".) " + s);
                    ++i;
                }
                Write("=========================");
            }
         }

        private void Write(string text)
        {
            foreach (TextWriter w in writers)
            {
                w.WriteLine(text);
            }
        }


        #endregion
    }
}
