using Diagram.UI;
using Diagram.UI.Interfaces;
using ErrorHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestCategory.Interfaces;



namespace TestCategory
{
    /// <summary>
    /// Extension methods
    /// </summary>
    public static class StaticExtensionTestCategory
    {
        /// <summary>
        /// Test creator
        /// </summary>
        public static ITestCreator TestCreator
        {
            get;
            set;
        } = new TestCreatorCollection();

        /// <summary>
        /// Adds test creator
        /// </summary>
        /// <param name="creator"></param>
        public static void Add(this ITestCreator creator)
        {
            if (TestCreator is TestCreatorCollection)
            {
                (TestCreator as TestCreatorCollection).Add(creator);
            }
        }

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
        public static async Task<Tuple<ITest, IComponentCollection>> Load(this Stream stream)
        {
            var ct = new CancellationToken();

            PureDesktopPeer d = new PureDesktopPeer();
            await d.Load(stream, SerializationInterface.StaticExtensionSerializationInterface.Binder, 
                true, ct);
            BinaryFormatter bf = new BinaryFormatter();
            while (true)
            {
                try
                {
                    object o = bf.Deserialize(stream);
                    if (o is ITest t)
                    {
                        return new Tuple<ITest, IComponentCollection>(t, d);
                    }
                }
                catch (Exception ex)
                {
                    ex.HandleException(10);
                    break;
                }
            }
            return null;

        }

        /// <summary>
        /// Test
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <returns>Test result</returns>
        public static async Task<Tuple<bool, object>> Test(this byte[] bytes)
        {
            try
            {
                using (var stream = new MemoryStream(bytes))
                {
                    var o = await stream.Test();
                    return o;
                }
            }
            catch (Exception exception)
            {
                exception.HandleException();
                return new Tuple<bool, object>(false, exception);
            }
        }

        public static async Task<Tuple<bool, object>> Test(this string filename)
        {
            using (var stream = File.OpenRead(filename))
            {
                return await stream.Test();
            }
        }

        static public object ReadObject(this Stream stream)
        {
            try
            {
                var bf = new BinaryFormatter();
                var a = bf.Deserialize(stream);
                return a;
            }
            catch (Exception ex)
            {

            }
            return null;
        }




        /// <summary>
        /// Test of stream
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns>Test object</returns>
        public static async Task<Tuple<bool, object>> Test(this Stream stream)
        {
            var t = await stream.Load();
            if (t == null)
            {
                return null;
            }
            return  t.Item1[t.Item2];
        }

        /// <summary>
        /// Tests saved object
        /// </summary>
        /// <param name="stream">Stream to save</param>
        /// <param name="testInterface">Test interface</param>
        public static async Task CreateTestReport(this Stream stream, ITestInterface testInterface)
        {
            var test = await stream.Load();
            if (test != null)
            {
                testInterface.CreateTestReport(test.Item1, test.Item2);
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