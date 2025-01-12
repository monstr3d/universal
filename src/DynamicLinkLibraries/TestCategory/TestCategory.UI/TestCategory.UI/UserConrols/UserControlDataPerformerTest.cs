using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Diagram.UI;

using TestCategory.Interfaces;
using System.Runtime.CompilerServices;
using TestCategory;

namespace TestCategory.UI.UserConrols
{
    public partial class UserControlDataPerformerTest : UserControl
    {
        #region Fields

        ITestCreator creator = StaticExtensionTestCategory.TestCreator;

        TestCollection test;

        List<object> l = new List<object>();
        Dictionary<string, object[]> output;

        IComponentCollection collection;

        event Action<object, DataRow, TestCollection> onAdd = (object o, DataRow row, TestCollection td) => { };

        event Action<object, ICategoryObject, bool[]> isAdmissible = (object l, ICategoryObject o, bool[] b) => { b[0] = false; };

        private Func<TestCollection> createTest; 

        #endregion

        #region Ctor
        
        public UserControlDataPerformerTest()
        {
            InitializeComponent();
        }

        #endregion

        #region Public

        public event Action<object, DataRow, TestCollection> OnAdd
        {
            add { onAdd += value; }
            remove { onAdd -= value; }
        }

        public event Action<object, ICategoryObject, bool[]> OnAdmissible
        {
            add { isAdmissible += value; }
            remove { isAdmissible -= value; }
        }

        public Func<TestCollection> CreateTestData
        {
            get
            {
                return createTest;
            }
            set
            {
                createTest = value;
            }
        }

        #endregion

        #region Protected

        // +++TEST+++
        protected void Add(object o, DataRow row, TestCollection test)
        {
            IObjectLabel label = o as IObjectLabel;
            string name;
            var t = creator.Create(out name, (uint)row[3], label, collection);
            test.Add(t);
            ICategoryObject co = label.Object;
              onAdd(o, row, test);
        }


        protected virtual bool IsAdmissible(object o, ICategoryObject cob)
        {
            if (creator.IsAdmissible(o, cob))
            {
                return true;
            }
            bool[] b = new bool[1];
            isAdmissible(o, cob, b);
            return b[0];
        }


        protected void Add(object o, DataRow row)
        {
            Add(o, row, test);
        }

        #endregion

        #region Internal & Private

        internal bool HasTests(ITest test, IComponentCollection collection)
        {
            List<object> l = new List<object>();
            IEnumerable<object> c = collection.AllComponents;
            foreach (object o in c)
            {
                string name = "";
                IObjectLabel ol = null;
                ICategoryObject cob = null;
                if (o is IObjectLabel)
                {
                    ol = o as IObjectLabel;
                    cob = ol.Object;
                    name = ol.GetName(collection);
                }
                if (IsAdmissible(o, cob))
                {
                    return true;
                }
            }
            return false;
        }

        internal void Set(ITest test, IComponentCollection collection)
        {
            this.collection = collection;
            if (test != null)
            {
                this.test = test as TestCollection;
                output = this.test.Output;
            }
            IEnumerable<object> c = collection.AllComponents;
            foreach (object o in c)
            {
                string name = "";
                IObjectLabel ol = null;
                ICategoryObject cob = null;
                if (o is IObjectLabel)
                {
                    ol = o as IObjectLabel;
                    cob = ol.Object;
                    name = ol.GetName(collection);
                }
                if (IsAdmissible(o, cob))
                {
                    l.Add(o);
                }
           }
            List<string> ls = new List<string>();
            List<Control> controls = new List<Control>();
            uint i = 1;
            foreach (object o in l)
            {
                int num;
                int count;
                Create(o, out num, out count);
                object[] ob = new object[] { i, (o as IObjectLabel).GetName(collection), (uint)num, (uint)count };
                dataTable.Rows.Add(ob);
                ++i;
            }
        }

        internal bool Set(int i)
        {
            if (i == 0)
            {
                return CreateTest();
            }
            if (i == 2)
            {
                test = null;
            }
            return true;

        }

        internal ITest Test
        {
            get
            {
                return test;
            }
        }

        private void Create(object o, out int num, out int count)
        {

            num = 0;
            count = 1;
            if (output != null)
            {
                string name = (o as IObjectLabel).GetName(collection);
                if (output.ContainsKey(name))
                {
                    object[] ob = output[name];
                    num = (int)ob[0] + 1;
                    if (ob.Length > 1)
                    {
                        count = (int)ob[1];
                    }
                }
            }
        }


        private bool CreateTest()
        {
            Dictionary<uint, DataRow> d = new Dictionary<uint, DataRow>();
            Dictionary<uint, int> di = new Dictionary<uint, int>();
            int i = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                uint n = (uint)row[2];
                if (n > 0)
                {
                    if (di.ContainsKey(n))
                    {
                        return false;
                    }
                    di[n] = i;
                    d[n] = row;
                }
                ++i;
            }
            List<uint> ll = new List<uint>();
            ll.AddRange(di.Keys);
            ll.Sort();
            test = createTest();
            foreach (uint ik in ll)
            {
                Add(l[di[ik]], d[ik]);
            }
            test.Close();
            return true;
        }

        #endregion
    }
}
