using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


using Diagram.UI;
using Diagram.UI.Interfaces;

using SerializationInterface;

namespace ImageTransformations
{
    /// <summary>
    /// Image with external UI
    /// </summary>
    [Serializable()]
    public class ExternalUIImage : ExternalImage, IPropertiesEditor,
       ISeparatedAssemblyEditedObject
    {
        #region Fields

        /// <summary>
        /// Assemblies
        /// </summary>
        private new static Dictionary<string, Assembly[]> types =
          new Dictionary<string, Assembly[]>();

        /// <summary>
        /// 
        /// </summary>
        byte[][] assemblies;

        /// <summary>
        /// Editor of properties
        /// </summary>
        ISeparatedPropertyEditor editor;

        /// <summary>
        /// Saver object
        /// </summary>
        List<object> saver;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        public ExternalUIImage(string type)
            : base(type)
        {
            LoadBytes();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ExternalUIImage(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            (this as IPropertiesEditor).Properties = info.Deserialize<object>("Properties");
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.Serialize<object>("Properties", (this as IPropertiesEditor).Properties);
        }

        #endregion

        #region IPropertiesEditor Members

        object IPropertiesEditor.Editor
        {
            get
            {
                if (editor == null)
                {
                    LoadAssemblies();
                }
                if (editor == null)
                {
                    Assembly[] aa = ExternalUIImage.types[this.type];
                    Type[] types = aa[aa.Length - 1].GetTypes();
                    foreach (Type t in types)
                    {
                        if (t.GetInterface(typeof(ISeparatedPropertyEditor).FullName) != null)
                        {
                            if (GetType().CompareLinkedType(t))
                            {
                                ConstructorInfo ci = t.GetConstructor(new Type[0]);
                                ISeparatedPropertyEditor se = ci.Invoke(new object[0]) as ISeparatedPropertyEditor;
                                editor = se;
                                if (saver != null)
                                {
                                    if (saver.Count > 1)
                                    {
                                        if (editor is IPropertiesEditor)
                                        {
                                            (editor as IPropertiesEditor).Properties = saver[1];
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
                return editor.GetEditor(this);
            }
        }

        object IPropertiesEditor.Properties
        {
            get
            {
                return Saver;
            }
            set
            {
                Saver = value as List<object>;
            }
        }

        #endregion

        #region ISeparatedAssemblyEditedObject Members

        byte[] ISeparatedAssemblyEditedObject.AssemblyBytes
        {
            get
            {
                return assemblies[assemblies.Length - 1];
            }
            set
            {
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

        }

        #endregion

        #region Overriden

        /// <summary>
        /// Creates bitmap
        /// </summary>
        protected override void CreateBitmap()
        {
            LoadWeb();
            base.CreateBitmap();
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Saver object
        /// </summary>
        private List<object> Saver
        {
            get
            {
                List<object> l = new List<object>();
                if (assemblies != null)
                {
                    l.Add(assemblies);
                }
                if (editor != null)
                {
                    if (editor is IPropertiesEditor)
                    {
                        l.Add((editor as IPropertiesEditor).Properties);
                    }
                }
                if (editor == null & saver != null)
                {
                    return saver;
                }
                return l;
            }
            set
            {
                assemblies = value[0] as byte[][];
                saver = value;
            }
        }

        /// <summary>
        /// Loads assemblies
        /// </summary>
        void LoadAssemblies()
        {
            LoadBytes();
            Assembly[] ass = null;
            if (types.ContainsKey(type))
            {
                ass = types[type];
            }
            else
            {
                char[] s = ";".ToCharArray();
                string[] ss = type.Split(s);
                ass = new Assembly[assemblies.Length];
                Assembly[] aa = AppDomain.CurrentDomain.GetAssemblies();
                for (int i = 0; i < assemblies.Length; i++)
                {
                    foreach (Assembly a in aa)
                    {
                        try
                        {
                            string l = a.Location;
                            string fn = System.IO.Path.GetFileName(l);
                            if (ss[i].Contains(fn))
                            {
                                ass[i] = a;
                                goto m;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                    ass[i] = AppDomain.CurrentDomain.Load(assemblies[i]);
                m:
                    continue;
                }
                types[type] = ass;
            }

        }

        /// <summary>
        /// Loads bytes
        /// </summary>
        void LoadBytes()
        {
            if (assemblies != null)
            {
                return;
            }
            char[] s = ";".ToCharArray();
            string[] ss = type.Split(s);
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            assemblies = new byte[ss.Length][];
            for (int i = 0; i < ss.Length; i++)
            {
                assemblies[i] = (dir + ss[i]).GetFileBytes();
            }
        }

        #endregion
    }
}
