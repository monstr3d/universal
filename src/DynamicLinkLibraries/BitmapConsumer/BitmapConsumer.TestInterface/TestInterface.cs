using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using TestCategory.Interfaces;

using BitmapConsumer.TestInterface.Tests;
using TestCategory;

namespace BitmapConsumer.TestIntefface
{
    internal class TestCreator : ITestCreator
    {
        internal TestCreator()
        {
            this.Add();
        }

        ITest ITestCreator.Create(out string name, uint number, IObjectLabel label, IComponentCollection collection)
        {
            ICategoryObject co = label.Object;
            name = label.GetName(collection);
            switch (co)
            {
                case IBitmapProvider pr:
                    return new BitmapProviderTest(pr.Bitmap, name);
                default:
                    break;

            }
            return null;
        }

        bool ITestCreator.IsAdmissible(object o, ICategoryObject cob)
        {
            switch (cob)
            {
                case IBitmapProvider pr:
                    return true;
                default:
                    break;
            }
            return false;
        }

        bool ITestCreator.Process(int i, ITest test, Dictionary<string, object[]> dictionary)
        {
            var d = dictionary;
            switch (test)
            {
                case BitmapProviderTest bpc:
                    d[bpc.Name] = new object[] { i };
                    return true;
                default: break;
            }
            return false;
        }
    }
}

