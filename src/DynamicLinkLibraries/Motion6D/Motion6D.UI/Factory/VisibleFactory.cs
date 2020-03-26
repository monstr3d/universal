using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;




using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Factory;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;

using Motion6D.Interfaces;
using Motion6D;


namespace Motion6D.UI.Factory
{
    /// <summary>
    /// Factory for visible objects
    /// </summary>
    public class VisibleFactory : EmptyUIFactory
    {
        #region Fields

        IPositionObjectFactory factory;

        #endregion

        #region Ctor


         /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory">Factory of position objects</param>
        public VisibleFactory(IPositionObjectFactory factory)
        {
            DeleteTextures();
            this.factory = factory;
            PositionObjectFactory.Factory = factory;
            PureDesktop.DesktopPostLoad += (Diagram.UI.Interfaces.IDesktop d) => { DeleteTextures(); };
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~VisibleFactory()
        {
            DeleteTextures();
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Creates object the corresponds to button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>Created object</returns>
        public override ICategoryObject CreateObject(IPaletteButton button)
        {
            string kind = button.Kind; // Kind of the object
            Type type = button.ReflectionType;
            if (type.IsSubclassOf(typeof(Camera)))
            {
                return factory.NewCamera();
            }
            if (type.Equals(typeof(Motion6D.SerializablePosition)))
            {
                object ob = factory.CreateObject(kind);  // Usage of the kind
                if (ob != null)
                {
                    SerializablePosition pos = new SerializablePosition();
                    pos.Parameters = ob;
                    if (ob is IPositionObject)
                    {
                        IPositionObject po = ob as IPositionObject;
                        po.Position = pos;
                    }
                    return pos;
                }
            }
            return null;
        }

        /// <summary>
        /// Creates a form for component properties editor
        /// </summary>
        /// <param name="comp">The component</param>
        /// <returns>The result form</returns>
        public override object CreateForm(INamedComponent comp)
        {
            if (comp is IObjectLabel)
            {
                IObjectLabel ol = comp as IObjectLabel;
                ICategoryObject obj = ol.Object;
                Camera camera = obj.GetSimpleObject<Camera>();
                if (camera != null)
                {
                }
                if (obj is Motion6D.SerializablePosition)
                {
                    Motion6D.Interfaces.IPosition p = obj as Motion6D.Interfaces.IPosition;
                    object o = p.Parameters;
                    if (o != null)
                    {
                        if (o is Motion6D.Interfaces.IVisible)
                        {
                            Motion6D.Interfaces.IVisible v = o as Motion6D.Interfaces.IVisible;
                            object ob = factory.CreateForm(p, v);
                            if (ob != null)
                            {
                                if (ob is Form)
                                {
                                    Form f = ob as Form;
                                    return f;
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Creates object label from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The label</returns>
        public override IObjectLabelUI CreateLabel(ICategoryObject obj)
        {
            Camera camera = obj.GetSimpleObject<Camera>();
            if (camera != null)
            {
                return factory.CreateLabel(camera) as IObjectLabelUI;
            }
            if (obj is Motion6D.SerializablePosition)
            {
                Motion6D.SerializablePosition sp = obj.GetObject<Motion6D.SerializablePosition>();
                object lp = sp.Parameters;
                Motion6D.Interfaces.IVisible vis = lp.GetSimpleObject<Motion6D.Interfaces.IVisible>();
                if (vis != null)
                {
                    object vl = factory.CreateLabel(sp, vis);
                    if (vl is IObjectLabelUI)
                    {
                        return vl as IObjectLabelUI;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Creates object label
        /// </summary>
        /// <param name="button">Corresponding button</param>
        /// <returns>The object label</returns>
        public override IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            Type type = button.ReflectionType;
            if (type == null)
            {
                return null;
            }
            if (type.IsSubclassOf(typeof(Camera)))
            {
                object ob = factory.CreateLabel(type);
                if (ob != null)
                {
                    return ob as IObjectLabelUI;
                }
            }
            if (type.Equals(typeof(SerializablePosition)))
            {
                object ob = factory.CreateLabel(button.Kind);
                if (ob != null)
                {
                    return ob as IObjectLabelUI;
                }
            }
            return null;
        }

        #endregion

        #region Members

        /// <summary>
        /// Gets visual object buttons
        /// </summary>
        /// <param name="factory">The factory</param>
        /// <returns>Buttons</returns>
        public static ButtonWrapper[] GetVisualObjectButtons(IPositionObjectFactory factory)
        {
            if (factory == null)
            {
                return new ButtonWrapper[0];
            }
            ButtonWrapper[] b = new ButtonWrapper[] 
                {
                            new ButtonWrapper(factory.CameraType,
                    "", "Camera", ResourceImage.Camera, null, true, false),
                            new ButtonWrapper(typeof(Motion6D.SerializablePosition),
                    "", "3D Object", ResourceImage.Cube, null, true, false),
                            new ButtonWrapper(typeof(Motion6D.SerializablePosition),
                    "Collection", "3D Object Collection", ResourceImage.CubeCollection, null, true, false),
                            new ButtonWrapper(typeof(Motion6D.SerializablePosition),
                    "Deformed figure", "Deformed object", ResourceImage.FormFigure, null, true, false),
                            new ButtonWrapper(typeof(Motion6D.SerializablePosition),
                    "3D Field Consumer", "Consumer of 3D field", ResourceImage.Field3D_Consumer, null, true, false),
                            new ButtonWrapper(typeof(Motion6D.SerializablePosition),
                    "Reper", "Reper", ResourceImage.Reper, null, true, false),
                   };
            List<ButtonWrapper> l = new List<ButtonWrapper>();
            foreach (ButtonWrapper bw in b)
            {
                if (factory.SupportsKind(bw.Kind))
                {

                    l.Add(bw);
                }
            }
            FieldInfo fi = factory.GetType().GetField("Buttons");
            if (fi != null)
            {
                 l.AddRange(fi.GetValue(fi) as ButtonWrapper[]);
            }
            b = l.ToArray();
            return b;
        }

        /// <summary>
        /// Gets all visual arrow buttons
        /// </summary>
        public static readonly ButtonWrapper[] VisualArrowButtons
      = new ButtonWrapper[] 
                {
       /*                     new ButtonWrapper(typeof(Motion6D.CameraLink),
                    "", "Look", ResourceImage.Eye, null, false, true),*/
                            new ButtonWrapper(typeof(Motion6D.VisibleConsumerLink),
                    "", "Link with visual consumer", ResourceImage.Eye, null, true, true)
                };

        void DeleteTextures()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            if (dir[dir.Length - 1] != Path.DirectorySeparatorChar)
            {
                dir += Path.DirectorySeparatorChar;
            }
            string[] files = Directory.GetFiles(dir);
            foreach (string file in files)
            {
                if (file.Contains("delete_texture_file"))
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        #endregion

    }
}
