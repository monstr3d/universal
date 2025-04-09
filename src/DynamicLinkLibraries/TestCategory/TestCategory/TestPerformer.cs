using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataWarehouse;


using TestCategory.Interfaces;
using ErrorHandler;

namespace TestCategory
{

    /// <summary>
    /// Performer of tests
    /// </summary>
    public class TestPerformer 
    {

        #region Fields

        /// <summary>
        /// Write delegate
        /// </summary>
        protected Action<TestException> write = (TestException e) =>
        {
        };

        /// <summary>
        /// Write header delegate
        /// </summary>
        protected event Action<object> writeHeader = (object o) =>
        {
        };

        private event Action<IDesktop> test = (IDesktop d) => { };

        ITestInterface testInterface = null;


        private event Action<byte[]> byteTest = (byte[] b) => { };

        private List<Exception> le = new List<Exception>();



        private bool stopAtFirst;

        private Exception current;

   

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected TestPerformer()
        {
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public TestPerformer(IExceptionHandler errorHandler, ITestInterface testInterface)
        {
            errorHandler.Set();
            this.testInterface = testInterface;
        }

        #endregion

        #region Members

        /// <summary>
        /// The on test additional event handler
        /// </summary>
        public event Action<IDesktop> Test
        {
            add
            {
                test += value;
            }
            remove
            {
                test -= value;
            }
        }

        /// <summary>
        /// Test saved with desktop
        /// </summary>
        public event Action<byte[]> ByteTest
        {
            add
            {
                byteTest += value;
            }
            remove
            {
                byteTest -= value;
            }
        }

        /// <summary>
        /// Adds writer
        /// </summary>
        /// <param name="writer">The writer for adding</param>
        public void Add(IExceptionWriter writer)
        {
            write += writer.Write;
            writeHeader += writer.WriteHeader;
        }

        /// <summary>
        /// The "stop at first error" sign
        /// </summary>
        public bool StopAtFirstError
        {
            get
            {
                return stopAtFirst;
            }
            set
            {
                stopAtFirst = value;
            }
        }

        /// <summary>
        /// Tests scenario
        /// </summary>
        /// <param name="buffer">Byte buffer that contains scenario</param>
        /// <returns>Test exception</returns>
        public bool TestBuffer(byte[] buffer)
        {
            try
            {
                List<Exception> l = PureDesktopPeer.Check(buffer);
                if (l != null)
                {
                    foreach (Exception e in l)
                    {
                        e.HandleException();
                    }
                }
                PureDesktopPeer d = new PureDesktopPeer();
                d.Load(buffer);
                test(d);
                foreach (Exception e in le)
                {
                    e.HandleException();
                }
                d.Dispose();
                d = null;
            }
            catch (Exception ex)
            {
                le.Clear();
                try
                {
                    current = TestException.GetRoot(ex);
                    ex.HandleException(0);
                }
                catch (Exception)
                {
                }
                return false;
            }
            if (byteTest != null)
            {
                byteTest(buffer);
            }
            le.Clear();
            if (testInterface != null)
            {
                buffer.CreateTestReport(testInterface);
            }
            return true;
        }

        /// <summary>
        /// Tests necessity of change
        /// </summary>
        /// <param name="buffer">Byte buffer that contains scenario</param>
        /// <returns>True if change is necessary and false otherwise</returns>
        public bool TestChange(byte[] buffer)
        {
            PureDesktopPeer.NeedChange = false;
            PureDesktopPeer d = new PureDesktopPeer();
            d.Load(buffer);
            bool b = PureDesktopPeer.NeedChange;
            PureDesktopPeer.NeedChange = false;
            return b;
        }


        /// <summary>
        /// Test buffer that is stored in database
        /// </summary>
        /// <param name="data">Database</param>
        /// <param name="id">Buffer Id</param>
       public void TestDataBuffer(DatabaseInterface data, string id)
        {
            string s = null;
            byte[] buffer = data.GetData(id, ref s);
            TestBuffer(buffer);
        }


        /// <summary>
        /// Tests database
        /// </summary>
        /// <param name="data">Database</param>
        /// <param name="ext">Extension</param>
        public void TestData(DatabaseInterface data, string ext)
        {
            IDictionary<object, object> dic = data.GetItems(ext);
            foreach (object o in dic.Keys)
            {
                string e = ext + "";
                object id = o;
                object ob = dic[o];
                if (ob is object[])
                {
                    ob = ((object[])ob)[0];
                }
                string s = ob + "";
                writeHeader(ob);
                TestDataItem(data, s, id, ext);
            }
        }

        /// <summary>
        /// Tests database item
        /// </summary>
        /// <param name="data">Data</param>
        /// <param name="name">Item name</param>
        /// <param name="id">Item id</param>
        /// <param name="ext">Extension</param>
        public void TestDataItem(DatabaseInterface data, string name, object id, string ext)
        {
            byte[] buffer = data.GetData(id + "", ref ext);
            bool b = TestBuffer(buffer);
            if (!b)
            {
                TestException te = new TestException(name, id, current);
                current = null;
                write(te);
                le.Clear();
                if (stopAtFirst)
                {
                    return;
                }
            }
            buffer = null;
            GC.Collect();
        }

        /// <summary>
        /// Testing for change
        /// </summary>
        /// <param name="data">Database</param>
        /// <param name="ext">Extension</param>
        /// <param name="refresh">The "refresh" sing</param>
        /// <returns>List of changes</returns>
        public List<object> TestChange(DatabaseInterface data, string ext, bool refresh)
        {
            List<object> l = new List<object>();
            IDictionary<object, object> dic = data.GetItems(ext);
            foreach (object o in dic.Keys)
            {
                string e = ext + "";
                object id = o;
                byte[] buffer = data.GetData(o + "", ref e);
                bool b = TestChange(buffer);
                if (b)
                {
                    l.Add(o);
                    if (refresh)
                    {
                        Refresh(data, o, ext);
                    }
                }
                buffer = null;
                GC.Collect();
            }
            return l;
        }

        /// <summary>
        /// Refreshes database
        /// </summary>
        /// <param name="data">Database</param>
        /// <param name="ext">Extension</param>
        public static void Refresh(DatabaseInterface data, string ext)
        {
            IDictionary<object, object> dic = data.GetItems(ext);
            foreach (object key in dic.Keys)
            {
                Refresh(data, key, ext);
            }
        }


        /// <summary>
        /// Refreshes database object
        /// </summary>
        /// <param name="data">Database</param>
        /// <param name="key">Object key</param>
        /// <param name="ext">Extension</param>
        public static void Refresh(DatabaseInterface data, object key, string ext)
        {
            string e = ext + "";
            byte[] buffer = data.GetData(key + "", ref e);
            MemoryStream msi = new MemoryStream(buffer);
            PureDesktopPeer d = new PureDesktopPeer();
            if (!d.Load(msi))
            {
                throw new OwnException(key + "");
            }
            BinaryFormatter bf = new BinaryFormatter();
            object ob = null;
            try
            {
                ob = bf.Deserialize(msi);
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
            MemoryStream mso = new MemoryStream();
            d.Save(mso);
            if (ob != null)
            {
                bf.Serialize(mso, ob);
            }
            // data.UpdateData(key + "", mso.GetBuffer());
        }

        private void emptyStart()
        {
        }

        private void emptyTest(IDesktop desktop)
        {
        }

        #endregion


    }
}