using System.Data;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Diagram.UI;
using Diagram.UI.Interfaces;

using TestCategory.Interfaces;

namespace DataSetService.TestInterface.Tests
{
    [Serializable()]
    internal class TestDataSetProvider : ITest, ISerializable
    {
        #region Fields

        /// <summary>
        /// Name of component on desktop
        /// </summary>
        protected string name;



        /// <summary>
        /// Residual parameter
        /// </summary>
        protected DataSet data;

        #endregion

        #region Ctor


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of component on desktop</param>
        /// <param name="collection">collection of components</param>
        internal TestDataSetProvider(string name, IComponentCollection collection)
        {
            this.name = name;
            data = collection.GetObject<IDataSetProvider>(name).DataSet;
        }

        private  TestDataSetProvider(SerializationInfo info, StreamingContext context)
        {
            name = info.GetString("Name");
            data = info.GetValue("Data", typeof(DataSet)) as DataSet;
        }

        #endregion

        #region ITest implementation

        Tuple<bool, object> ITest.this[IComponentCollection collection]
        {
            get
            {
                var d = collection.GetObject<IDataSetProvider>(name).DataSet;
                if  (data.ComputateDiff(d) == null)
                {
                    return new Tuple<bool, object>(true, "Success. Object - " + name);
                }
                return new Tuple<bool, object>(false, "Different datasets. Object - " + name);

                /*
                if (d.Length != data.Length)
                {
                    return new Tuple<bool, object>(false, "Different datasets. Object - " + name);
                }
                for (var i = 0; i < data.Length; i++)
                {
                    if (d[i] != data[i])
                    {
                        return new Tuple<bool, object>(false, "Different datasets. Object - " + name);
                    }
                }*/
                //  return new Tuple<bool, object>(true, "Success. Object - " + name);
            }
        }

        #endregion

        #region ISerializable implementation

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", name);
            info.AddValue("Data", data, typeof(byte[]));
        }

        #endregion

        internal string Name => name;

        #region Protected

        protected virtual byte[] GetBytes(IComponentCollection collection)
        {
            var d = collection.GetObject<IDataSetProvider>(name);
            using (var ms = new MemoryStream()) 
            {
                var bf = new BinaryFormatter();
                var dataSet = d.DataSet;
                bf.Serialize(ms, dataSet);
                return ms.GetBuffer();
            }
        }

        #endregion
    }
}
