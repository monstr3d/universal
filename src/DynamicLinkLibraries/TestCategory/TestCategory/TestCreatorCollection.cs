using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestCategory.Interfaces;

namespace TestCategory
{
    /// <summary>
    /// Creator of test
    /// </summary>
    public class TestCreatorCollection : ITestCreator
    {
        #region Fields

        List<ITestCreator> list= new List<ITestCreator>();

        #endregion


        ITest ITestCreator.Create(out string name, uint number, IObjectLabel label, IComponentCollection collection)
        {
            name= string.Empty;
            foreach (var creator in list)
            {
                var test = creator.Create(out name, number, label, collection);
                if (test != null)
                {
                    return test;
                }
            }
            return null;
        }

        bool ITestCreator.Process(int i, ITest test, Dictionary<string, object[]> dictionary)
        {
            foreach (var creator in list)
            {
                if (creator.Process(i, test, dictionary))
                {
                    return true;
                }
            }
            return false;
        }

        public void Add(ITestCreator creator)
        {
            list.Add(creator);
        }
    }
}
