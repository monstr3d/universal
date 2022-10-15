using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Interfaces;

using TestCategory.Interfaces;


namespace DataPerformer.TestInterface.UI.Forms
{
    /// <summary>
    /// Form for test
    /// </summary>
    public partial class FormTest : Form
    {
        /// <summary>
        /// Form test
        /// </summary>
        public FormTest()
        {
            InitializeComponent();
        }

        internal void Set(ITest test, IComponentCollection collection)
        {
            userControlDataPerformerTest.Set(test, collection);
        }

        internal bool HasTests(ITest test, IComponentCollection collection)
        {
            return userControlDataPerformerTest.HasTests(test, collection);
        }

        internal bool Set(int i)
        {
            return userControlDataPerformerTest.Set(i);
        }

        internal ITest Test
        {
            get
            {
                return userControlDataPerformerTest.Test;
            }
        }

        public event Action<object, DataRow, TestData> OnAdd
        {
            add { userControlDataPerformerTest.OnAdd += value; }
            remove {userControlDataPerformerTest.OnAdd -= value; }
        }

        public event Action<object, ICategoryObject, bool[]> OnAdmissible
        {
            add { userControlDataPerformerTest.OnAdmissible += value; }
            remove { userControlDataPerformerTest.OnAdmissible += value; }
        }
   

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (!Set(0))
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, "Illegal test");
                return;
            }
            Close();
        }

        internal Func<TestData> CreateTest
        {
            get
            {
                return userControlDataPerformerTest.CreateTestData;
            }
            set
            {
                userControlDataPerformerTest.CreateTestData = value;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Set(1);
            Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Set(2);
            Close();
        }

    }
}
