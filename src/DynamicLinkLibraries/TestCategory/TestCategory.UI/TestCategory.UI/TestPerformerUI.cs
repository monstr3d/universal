using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;
using System.Runtime.Serialization;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataWarehouse;

using TestCategory;
using ErrorHandler;

namespace TestCategory.UI
{
    /// <summary>
    /// Performer of tests with UI
    /// </summary>
    public class TestPerformerUI : TestPerformer
    {

        #region Ctor

 
        #endregion

        /// <summary>
        /// Test database with UI
        /// </summary>
        /// <param name="data">Database</param>
        /// <param name="binder">Serialization binder</param>
        /// <param name="pan">Desktop</param>
        /// <param name="ext">Extension</param>
        /// <param name="extd">Required extension</param>
        /// <param name="logWriter">Log writer</param>
        public void TestData(DatabaseInterface data, SerializationBinder binder, PanelDesktop pan, string ext, 
            string extd, TextWriter logWriter)
        {
            IDictionary<object, object> t = data.GetItems(ext);
            foreach (object o in t.Keys)
            {
                string e = ext + "";
                object id = o;
                byte[] buffer = data.GetData(o + "", ref e);
                object ob = t[o];
                if (ob is object[])
                {
                    ob = ((object[])ob)[0];
                }
                string s = ob + "";
                if (logWriter != null)
                {
                    logWriter.WriteLine("+++++++++++");
                    logWriter.WriteLine(s);
                    logWriter.WriteLine("+++++++++++");
                }
                Exception ex = TestBuffer(buffer, binder, pan, ext, extd);
                if (ex != null)
                {
                    TestException te = new TestException(s, id, ex);
                    write(te);
                    if (StopAtFirstError)
                    {
                        return;
                    }
                }
                buffer = null;
                GC.Collect();
            }
        }

        /// <summary>
        /// Test buffer with UI
        /// </summary>
        /// <param name="buffer">Byte buffer that contains scenario</param>
        /// <param name="binder">Serialization binder</param>
        /// <param name="pan">Desktop</param>
        /// <param name="ext">Extension</param>
        /// <param name="extd">Required extension</param>
        /// <returns>Test exception</returns>
        public Exception TestBuffer(byte[] buffer, SerializationBinder binder, PanelDesktop pan, string ext, string extd)
        {
            try
            {
                MemoryStream ms = new MemoryStream(buffer);
                pan.LoadFromStream(ms, binder, ext, extd);
                foreach (object o in pan.Controls)
                {
                    if (o is IShowForm)
                    {
                        IShowForm sf = o as IShowForm;
                        sf.ShowForm();
                    }
                }
                pan.TempDelete();
            }
            catch (Exception e)
            {
                e.HandleException(10);
                return TestException.GetRoot(e);
            }
            return null;
        }


    }
}
