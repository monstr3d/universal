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
using DataPerformer.Interfaces;

namespace DataPerformer.TestInterface.UI.UserConrols
{
    public partial class UserControlDataPerformerTest : UserControl
    {
        #region Fields

        TestData test;

        List<object> l = new List<object>();
        Dictionary<string, object[]> output;

        IComponentCollection collection;

        event Action<object, DataRow, TestData> onAdd = (object o, DataRow row, TestData td) => { };

        event Action<object, ICategoryObject, bool[]> isAdmissible = (object l, ICategoryObject o, bool[] b) => { b[0] = false; };

        private Func<TestData> createTest; 

        #endregion

        #region Ctor
        
        public UserControlDataPerformerTest()
        {
            InitializeComponent();
        }

        #endregion

        #region Public

        public event Action<object, DataRow, TestData> OnAdd
        {
            add { onAdd += value; }
            remove { onAdd -= value; }
        }

        public event Action<object, ICategoryObject, bool[]> OnAdmissible
        {
            add { isAdmissible += value; }
            remove { isAdmissible -= value; }
        }

        public Func<TestData> CreateTestData
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

        protected void Add(object o, DataRow row, TestData test)
        {
            IObjectLabel l = o as IObjectLabel;

            ICategoryObject co = l.Object;
            string name = l.GetName(collection);
            switch (co)
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
                    test.AddChart(name, cons.Start, cons.Step, cons.Steps, data.Item4[1], keys.ToArray<string>(), collection);
                    return;
                }
            }
            onAdd(o, row, test);
        }


        protected virtual bool IsAdmissible(object o, ICategoryObject cob)
        {
           switch(cob)
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
                this.test = test as TestData;
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
