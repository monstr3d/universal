using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;

namespace Diagram.UI.Factory
{
    /// <summary>
    /// Default Factory
    /// </summary>
    public class DefaultFactory : EmptyUIFactory
    {
        #region Fields

        private string ext;

        /// <summary>
        /// Buttons of default objects
        /// </summary>
        public static readonly ButtonWrapper[] DefaultObjectButtons =
            new ButtonWrapper[]
             {
             new ButtonWrapper(typeof(MultiLibraryObject),
                    "", "Multi library", ResourceImage.MultiInterface, null, true, false),
             new ButtonWrapper(typeof(ObjectsCollection),
                    typeof(object).FullName, "Collection of objects", ResourceImage.Collection, null, true, false)
             };

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ext">Extension</param>
        public DefaultFactory(string ext)
        {
            this.ext = ext;
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Creates object from button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The object</returns>
        public override ICategoryObject CreateObject(IPaletteButton button)
        {
            if (button.ReflectionType.Equals(typeof(LibraryObjectWrapper)))
            {
                return LibraryObjectWrapper.Create(button.Kind);
            }
            if (button.ReflectionType.Equals(typeof(ObjectContainer)))
            {
                return load(button.Kind);
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
            Type t = button.ReflectionType;
            if (t.Equals(typeof(IObjectContainer)))
            {
                return new ContainerObjectLabel(button);
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
                IObjectLabel l = comp as IObjectLabel;
                if (l.Object is ObjectContainer)
                {
                    return new Forms.FormContainer(l);
                }
            }
            return null;
        }

        #endregion

        #region Members

        ICategoryObject load(string str)
        {
            Stream stream = null;
            bool cont = true;
            string fn = ResourceService.Resources.CurrentDirectory + "Containers" + Path.DirectorySeparatorChar + str;
            if (File.Exists(fn))
            {
                stream = File.OpenRead(fn);
                int n = fn.LastIndexOf('.');
                if (fn.Substring(n + 1).ToLower().Equals(ext))
                {
                    cont = false;
                }
            }
            if (cont)
            {
                return loadContainer(stream) as ICategoryObject;
            }
            return loadMultilibrary(stream);
        }

        IObjectContainer loadContainer(Stream stream)
        {
            BinaryFormatter binary = StaticExtensionDiagramUISerializable.CreateBinaryFormatter();
            IObjectContainer ob = binary.Deserialize(stream) as IObjectContainer;
            stream.Close();
            return ob;
        }

        MultiLibraryObject loadMultilibrary(Stream stream)
        {
            BinaryFormatter binary = StaticExtensionDiagramUISerializable.CreateBinaryFormatter();
            SerializationBinder binder = SerializationInterface.StaticExtensionSerializationInterface.Binder;
            PureDesktopPeer d = new PureDesktopPeer();
            d.Load(stream, binder, true);
            stream.Close();
            IObjectLabel l = null;
            foreach (IObjectLabel ll in d.Objects)
            {
                l = ll;
                break;
            }
            ICategoryObject ob = l.Object;
            return ob as MultiLibraryObject;
        }

        #endregion
    }
}
