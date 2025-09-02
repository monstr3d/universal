using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Diagram.UI;
using Diagram.UI.Labels;

using Motion6D.Interfaces;
using Motion6D.Portable;


using WpfInterface.CameraInterface;
using WpfInterface.UI.Labels;

namespace WpfInterface.UI.Factory
{
    /// <summary>
    /// WPF implementation of 3D Graphics
    /// </summary>
    public class WpfFactory : PositionObjectFactory
    {
        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly WpfFactory Singleton =
            new WpfFactory();

        private static readonly List<string> types = new List<string>()
        {
                     "",
                    "Collection",
                    "Deformed figure",
                    "3D Field Consumer",
                    "Reper",
         };


        #endregion

        #region Ctor

        /// <summary>
        /// Private default constructor
        /// </summary>
        protected WpfFactory()
        {
        
        }

        static WpfFactory()
        {
            new WpfBinder();
        }

        #endregion

        #region Overriden

        public override object CreateObject(string type)
        {
            if (type.Equals(""))
            {
                return new Objects3D.WpfShape();
            }
            if (type.Equals("Deformed figure"))
            {
                return new Objects3D.DeformedWpfShape();
            }
            if (type.Equals("Collection"))
            {
                return new Objects3D.WpfVisibleCollectionObject();
            }
            return null;
        }

        public override Motion6D.Camera NewCamera()
        {
            return new WpfCamera();
        }

        public override object CreateForm(Camera camera)
        {
            return null;
        }

        public override object CreateForm(IPosition position, IVisible visible)
        {
            if (visible is Objects3D.DeformedWpfShape)
            {
                return new Forms.FormDeformed(position, visible);
            }
            return null;
        }

        public override Type CameraType
        {
            get { return typeof(WpfCamera); }
        }

        public override IObjectLabel CreateLabel(object obj)
        {
            if (obj.Equals(CameraType))
            {
                return (new CameraLabel()).CreateLabelUI(ResourceImage.Camera, false);
            }
            if (obj.Equals(""))
            {
                IObjectLabel l = new ShapeLabel("", ResourceImage.Cube.ToBitmap());
                return l.CreateLabelUI(ResourceImage.Cube, false);
            }
            return null;
        }

        public override object CreateLabel(IPosition position, IVisible visible)
        {
            return null;
        }

        /// <summary>
        /// Checks whether the factory supports a kind
        /// </summary>
        /// <param name="kind">Kind of object</param>
        /// <returns>True is supports and false otherwise</returns>
        public override bool SupportsKind(string kind)
        {
            return types.Contains(kind);
        }

        #endregion

        #region Version Binder

        class WpfBinder : SerializationBinder
        {
            internal WpfBinder()
            {
                ass = typeof(ShapeLabel).Assembly.FullName;
                this.Add();
            }

            static readonly Type[] types = new Type[] { typeof(CameraLabel), typeof(ShapeLabel) };

            static readonly Dictionary<string, Type> dt = new Dictionary<string, Type>()
            {
                {"WpfInterface.Labels.CameraLabel", typeof(CameraLabel)},
                {"WpfInterface.Labels.ShapeLabel", typeof(ShapeLabel)},
            };

            static string ass;

   
            public override Type BindToType(string assemblyName, string typeName)
            {
                string asss = assemblyName;
                
                if (dt.ContainsKey(typeName))
                {
                    asss = ass;
                    return dt[typeName];
                }
                try
                {
                    Type t = Type.GetType(string.Format("{0}, {1}", typeName, asss));
                    if (t == null)
                    {
                    }
                    return t;
                }
                catch (Exception)
                {
                }
                return null;
            }

            static void Init()
            {
                foreach (Type t in types)
                {
                    dt[t.FullName] = t;
                }
                ass = types[0].Assembly.FullName;
            }
        }
  
        #endregion
    }
}
