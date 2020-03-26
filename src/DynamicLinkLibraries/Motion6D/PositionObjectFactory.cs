using System;
using System.Collections.Generic;
using System.Text;

using Diagram.UI;
using CategoryTheory;
using Diagram.UI.Labels;

using Motion6D.Interfaces;

namespace Motion6D
{
    /// <summary>
    /// Factory of 3D objects and cameras
    /// </summary>
    public abstract class PositionObjectFactory : IPositionObjectFactory
    {
        /// <summary>
        /// Global factory
        /// </summary>
        static private IPositionObjectFactory factory;


        static private IPositionObjectFactory baseFactory;

        /// <summary>
        /// Global factory
        /// </summary>
        public static IPositionObjectFactory BaseFactory
        {
            get
            {
                try
                {
                    if (baseFactory == null)
                    {
                        baseFactory =
                            AssemblyService.StaticExtensionAssemblyService.GetFirstInterfaceObjectFromBaseDirectory<IPositionObjectFactory>();
                    }
                    return baseFactory;
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                }
                return null;
            }
         }


        /// <summary>
        /// Global factory
        /// </summary>
        public static IPositionObjectFactory Factory
        {
            get
            {
                return factory;
            }
            set
            {
                factory = value;
            }
        }

        /// <summary>
        /// Crreates  3D object
        /// </summary>
        /// <param name="type">Object's type</param>
        /// <returns>The object</returns>
        public abstract object CreateObject(string type);

        /// <summary>
        /// Creates new camera
        /// </summary>
        /// <returns></returns>
        public abstract Camera NewCamera();

        /// <summary>
        /// Creates editor of properties of camera
        /// </summary>
        /// <param name="camera">The camera</param>
        /// <returns>The property editor</returns>
        public abstract object CreateForm(Camera camera);

        /// <summary>
        /// Creates editor of properties of visible object
        /// </summary>
        /// <param name="position">Position of object</param>
        /// <param name="visible">Visible object</param>
        /// <returns>Editor of properties of visible object</returns>
        public abstract object CreateForm(IPosition position, IVisible visible);
        
        /// <summary>
        /// Type of camera
        /// </summary>
        public abstract Type CameraType
        {
            get;
        }

        /// <summary>
        /// Creates label on desktop
        /// </summary>
        /// <param name="obj">Object for label</param>
        /// <returns>The label</returns>
        public abstract IObjectLabel CreateLabel(object obj);

        /// <summary>
        /// Creates label of visible object
        /// </summary>
        /// <param name="position">Position of object</param>
        /// <param name="visible">Visible object</param>
        /// <returns>Editor of properties of visible object</returns>
        public abstract object CreateLabel(IPosition position, IVisible visible);

          /// <summary>
        /// Checks whether the factory supports a kind
        /// </summary>
        /// <param name="kind">Kind of object</param>
        /// <returns>True is supports and false otherwise</returns>
        public abstract bool SupportsKind(string kind);
         
    }
}
