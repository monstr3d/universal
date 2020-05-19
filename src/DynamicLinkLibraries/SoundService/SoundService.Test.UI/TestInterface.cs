using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using CategoryTheory;

using Diagram.UI.Labels;

using TestCategory.Interfaces;

using DataPerformer.TestInterface;



namespace SoundService.Test.UI
{
    public class TestInterface : DataPerformer.TestInterface.UI.TestInterface
    {

        #region Fields

        public static new readonly ITestInterface Singleton = new TestInterface();

        #endregion

        #region Ctor

        protected TestInterface()
        {
            add += Add;
            addmissible += Admissible;
            base.createTest = () => { return new TestDataSound(); };
        }

        #endregion

        #region Overriden

 

        #endregion

        void Admissible(object l, ICategoryObject o, bool[] b)
        {
            if (o is SoundCollection)
            {
                b[0] = true;
            }
        }

        void Add(object o, DataRow row, TestData test)
        {

            IObjectLabel l = o as IObjectLabel;

            string name = l.Name;
            ICategoryObject co = l.Object;

            if (co is SoundCollection)
            {
                SoundCollection sc = co as SoundCollection;
                TestDataSound tds = test as TestDataSound;
                if (l is IProperties)
                {
                    object p = (l as IProperties).Properties;
                    SoundService.UI.Labels.SoundCollectionLabel sl = p as SoundService.UI.Labels.SoundCollectionLabel;
                    object[] ob = sl.TestData;
                    tds.AddSound(name, (double)ob[0], (double)ob[1], (int)ob[2], l.Desktop);
                }
            }
        }
    }
}
