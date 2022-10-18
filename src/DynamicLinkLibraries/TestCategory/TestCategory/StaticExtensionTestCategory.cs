using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Diagram.UI;
using Diagram.UI.Interfaces;


using TestCategory.Interfaces;



namespace TestCategory
{
    /// <summary>
    /// Extension methods
    /// </summary>
    public static class StaticExtensionTestCategory
    {
        /// <summary>
        /// Converts bytes to stream
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <returns>Stream</returns>
        public static Stream ToStream(this byte[] bytes)
        {
            return new MemoryStream(bytes);
        }


        /// <summary>
        /// Loads test
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="collection">Component collection</param>
        /// <returns>Test</returns>
        public static ITest Load(this Stream stream, out IComponentCollection collection)
        {
            PureDesktopPeer d = new PureDesktopPeer();
            d.Load(stream, SerializationInterface.StaticExtensionSerializationInterface.Binder, true);
            collection = d;
            BinaryFormatter bf = new BinaryFormatter();
            while (true)
            {
                try
                {
                    object o = bf.Deserialize(stream);
                    if (o is ITest)
                    {
                        return o as ITest;
                    }
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                    break;
                }
            }
            return null;
        }

        /// <summary>
        /// Test of stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns>Test object</returns>
        public static object Test(this Stream stream)
        {
            IComponentCollection collection;
            ITest t = stream.Load(out collection);
            if (t == null)
            {
                return null;
            }
            return t[collection];
        }

        /// <summary>
        /// Tests saved object
        /// </summary>
        /// <param name="stream">Stream to save</param>
        /// <param name="testInterface">Test interface</param>
        public static void CreateTestReport(this Stream stream, ITestInterface testInterface)
        {
            IComponentCollection collection;
            ITest test = stream.Load(out collection);
            if (test != null)
            {
                testInterface.CreateTestReport(test, collection);
            }
        }

        /// <summary>
        /// Tests saved object
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <param name="testInterface">Test interface</param>
        public static void CreateTestReport(this byte[] bytes, ITestInterface testInterface)
        {
            bytes.ToStream().CreateTestReport(testInterface);
        }
    }
}