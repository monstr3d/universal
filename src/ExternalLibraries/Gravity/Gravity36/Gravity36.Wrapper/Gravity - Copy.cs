using CategoryTheory;
using DataPerformer.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SerializationInterface;
using Web.Interfaces;
using System.IO;
using System.Net;

namespace Gravity36.Wrapper
{
    /// <summary>
    /// Gravity field wrapper
    /// </summary>
    [Serializable()]
    public class Gravity : CategoryObject, IObjectTransformer,
        IPropertiesEditor,  ISeparatedAssemblyEditedObject,
        ISerializable, IUrlProvider, IUrlConsumer, IObjectFactory
    {
        #region Fields

        Tuple<string, List<object>, byte[]> tuple = 
            new Tuple<string, List<object>, byte[]>("", new List<object>(), null);

        Gravity36.Gravity gravity = new Gravity36.Gravity();

        ISeparatedPropertyEditor editor;

        const Double ret = 0;

        /// <summary>
        /// Inputs
        /// </summary>
        static private readonly string[] inputs = new string[] { "x", "y", "z" };

        /// <summary>
        /// Outputs
        /// </summary>
        static private readonly string[] outputs = new string[] { "Gx", "Gy", "Gz" };

        protected Action<string> changeInput = (string s) => { };

        protected Action<string> changeOutput = (string s) => { };


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Gravity()
        {
            gravity.N0 = 36;
            gravity.NK = 36;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="url">Url</param>
        public Gravity(string url)
            : this()
        {
            (this as IUrlConsumer).Url = url;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Gravity(SerializationInfo info, StreamingContext context)
        {
            (this as IPropertiesEditor).Properties =
                info.Deserialize<object>("Properties");
        }

        #endregion

        #region IPropertiesEditor Members

        object IPropertiesEditor.Editor
        {
            get { return this.GetEditor(); }
        }

        object IPropertiesEditor.Properties
        {
            get
            {
                tuple = new Tuple<string,List<object>,byte[]>(tuple.Item1, 
                    gravity.Saver, tuple.Item3);
                return tuple;
            }
            set
            {
                if (value is List<object>)
                {
                    string s = this.GetType().Assembly.Location;
                    using (System.IO.Stream stream = File.OpenRead(s))
                    {
                        byte[] b = new byte[stream.Length];
                        stream.Read(b, 0, b.Length);
                        Tuple = new Tuple<string, List<object>, byte[]>("", value as List<object>, b);
                    }
                    return;
                }
                Tuple = value as Tuple<string, List<object>, byte[]>;
            }
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<object>("Properties", (this as IPropertiesEditor).Properties);
        }

        #endregion

        #region ISeparatedAssemblyEditedObject Members

        byte[] ISeparatedAssemblyEditedObject.AssemblyBytes
        {
            get
            {
                return tuple.Item3;
            }
            set
            {
                tuple = new Tuple<string, List<object>, byte[]>(tuple.Item1, tuple.Item2, value);
            }
        }

        ISeparatedPropertyEditor ISeparatedAssemblyEditedObject.Editor
        {
            get
            {
                return editor;
            }
            set
            {
                editor = value;
            }
        }

        void ISeparatedAssemblyEditedObject.FirstLoad()
        {
            this.LoadAssembly();
        }

        #endregion

        #region IUrlProvider Members

        string IUrlProvider.Url
        {
            get { return tuple.Item1; }
        }

        event Action<string> IUrlProvider.Change
        {
            add { changeOutput += value; }
            remove { changeOutput -= value; }
        }
        
        #endregion

        #region IUrlConsumer Members

        string IUrlConsumer.Url
        {
            set 
            {
                if (value.Equals(tuple.Item1))
                {
                    return;
                }
                Tuple = new Tuple<string, List<object>, byte[]>(
                    value, tuple.Item2, tuple.Item3);
            }
        }


        event Action<string> IUrlConsumer.Change
        {
            add { changeInput += value; }
            remove { changeInput -= value; }
        }



        #endregion

        #region IObjectTransformer Members

        string[] IObjectTransformer.Input
        {
            get { return inputs; }
        }

        string[] IObjectTransformer.Output
        {
            get { return outputs; }
        }

        object IObjectTransformer.GetInputType(int i)
        {
            return ret;
        }

        object IObjectTransformer.GetOutputType(int i)
        {
            return ret;
        }

        void IObjectTransformer.Calculate(object[] input, object[] output)
        {
            // Input cast
            double x = (double)input[0];
            double y = (double)input[1];
            double z = (double)input[2];

            double fx, fy, fz;

            // Call of forces
            gravity.Forces(x, y, z, out fx, out fy, out fz);

            // filling of output
            output[0] = fx;
            output[1] = fy;
            output[2] = fz;
        }

        #endregion

        #region IObjectFactory Members

        string[] IObjectFactory.Names
        {
            get { return new string[] { "Gravity 36 * 36" }; }
        }

        ICategoryObject IObjectFactory.this[string name]
        {
            get { return new Gravity(); }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gravity field
        /// </summary>
        public Gravity36.Gravity GravityField
        {
            get
            {
                return gravity;
            }
        }

        /// <summary>
        /// Tuple of parameters
        /// </summary>
        Tuple<string, List<object>, byte[]> Tuple
        {
            get
            {
                return tuple;
            }
            set
            {
                tuple = value;
                if (tuple.Item2.Count > 0)
                {
                    gravity.Saver = tuple.Item2;
                }
                Post();
            }
        }

        /// <summary>
        /// Loads from file
        /// </summary>
        /// <param name="filename">File name</param>
        public void LoadFromFile(string filename)
        {
            (this as IUrlConsumer).Url = "";
            try
            {
                using (TextReader reader = new StreamReader(filename))
                {
                    gravity.Load(reader);
                }
            }
            catch (Exception exception)
            {
                exception.ShowError(10);
            }
        }

        #endregion

        #region Private Members

        void Post()
        {
            if (tuple.Item1.Length == 0)
            {
                return;
            }
            Gravity36.Gravity g = Load(tuple.Item1);
            if (g != null)
            {
                g.N0 = gravity.N0;
                g.NK = gravity.NK;
                gravity = g;
            }
        }

        Gravity36.Gravity Load(string url)
        {
            if (url == null)
            {
                return null;
            }
            if (url.Length == 0)
            {
                return null;
            }
            string[] files = new string[] { url, AppDomain.CurrentDomain.BaseDirectory };
            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    using (TextReader reader = new StreamReader(file))
                    {
                        return Load(reader);
                    }
                }
            }
            try
            {
                WebRequest req = WebRequest.Create(url);
                WebResponse resp = req.GetResponse();
                using (TextReader reader = new StreamReader(resp.GetResponseStream()))
                {
                    return Load(reader);
                }
            }
            catch (Exception exception)
            {
                exception.ShowError(10);
            }
            return null;
        }

        Gravity36.Gravity Load(TextReader reader)
        {
            try
            {
                Gravity36.Gravity g = new Gravity36.Gravity();
                g.Load(reader);
                return g;
            }
            catch (Exception)
            {
            }
            return null;
        }

        #endregion

       }
}
