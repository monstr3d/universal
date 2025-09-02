using System.Drawing;
using System.Runtime.Serialization;

using Diagram.UI;
using Diagram.UI.Interfaces;
using TestCategory.Interfaces;

namespace BitmapConsumer.TestInterface.Tests
{
    [Serializable()]
    internal class BitmapProviderTest : ITest, ISerializable
    {

        private Bitmap bitmap;

        private string name;

        internal BitmapProviderTest(Bitmap bitmap, string name)
        {
            this.bitmap = bitmap;
            this.name = name;
        }

        private BitmapProviderTest(SerializationInfo info, StreamingContext context)
        {
            bitmap = info.GetValue("Bitmap", typeof(Bitmap)) as Bitmap;
            name = info.GetString("Name");
        }

        Tuple<bool, object> ITest.this[IComponentCollection collection]
        {
            get
            {
                var pr = collection.GetObject<IBitmapProvider>(name);
                if (pr.Bitmap.CompareBitmaps(bitmap))
                {
                    return new Tuple<bool, object>(true, "Success. Object - " + name);
                }
                return new Tuple<bool, object>(false, "Different series. Object - " + name);
            }
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Bitmap", bitmap, typeof(Bitmap));
            info.AddValue("Name", name);
        }

        internal string Name
        {
            get { return name; }
        }
    }
}
