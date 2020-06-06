using System;
using System.Collections.Generic;
using System.Data;


using CategoryTheory;

using Diagram.UI.Interfaces;

using TestCategory.Interfaces;



namespace DataPerformer.TestInterface.UI
{
    /// <summary>
    /// Interface of tests
    /// </summary>
    public class TestInterface : ITestInterface
    {
        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly ITestInterface Singleton = new TestInterface();

        protected event Action<object, DataRow, TestData> add =
            (object o, DataRow r, TestData d) => { };

        protected Action<object, ICategoryObject, bool[]> addmissible =
            (object l, ICategoryObject o, bool[] b) => { b[0] = false; }; 

        protected Func<TestData> createTest = () => { return new TestData(); };

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected TestInterface()
        {
            
        }

        #endregion

        #region ITestInterface Members

        ITest ITestInterface.Edit(ITest test, IComponentCollection collection)
        {
            return Edit(test, collection);
        }


        void ITestInterface.CreateTestReport(ITest test, IComponentCollection collection)
        {
            CreateTestReport(test, collection);
        }

        #endregion

        #region Members

        protected virtual ITest Edit(ITest test, IComponentCollection collection)
        {
            Forms.FormTest form = new Forms.FormTest();
            if (!form.HasTests(test, collection))
            {
                return null;
            }
            form.OnAdd += add;
            form.OnAdmissible += addmissible;
            form.CreateTest = createTest;
            form.Set(test, collection);
            form.ShowDialog();
            return form.Test;
        }


        protected virtual void CreateTestReport(ITest test, IComponentCollection collection)
        {
            object o = test[collection];
            if (o == null)
            {
                return;
            }
            List<string> l = o.ToTestStringList();
            if (l.Count != 0)
            {
                Forms.FormReport form = new Forms.FormReport(l);
                form.Show();
            }
        }

        #endregion
    }
}
