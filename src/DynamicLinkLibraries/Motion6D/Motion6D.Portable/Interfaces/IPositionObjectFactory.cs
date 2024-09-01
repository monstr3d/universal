using System;

using Diagram.UI.Labels;

using Motion6D.Interfaces;

namespace Motion6D.Portable.Interfaces
{
    /// <summary>
    /// Factory of 3D objects and cameras
    /// </summary>
    public interface IPositionObjectFactory
    {
        /// <summary>
        /// Crreates  3D object
        /// </summary>
        /// <param name="type">Object's type</param>
        /// <returns>The object</returns>
        object CreateObject(string type);

        /// <summary>
        /// Creates new camera
        /// </summary>
        /// <returns></returns>
        Camera NewCamera();

        /// <summary>
        /// Creates editor of properties of camera
        /// </summary>
        /// <param name="camera">The camera</param>
        /// <returns>The property editor</returns>
        object CreateForm(Camera camera);

        /// <summary>
        /// Creates editor of properties of visible object
        /// </summary>
        /// <param name="position">Position of object</param>
        /// <param name="visible">Visible object</param>
        /// <returns>Editor of properties of visible object</returns>
        object CreateForm(IPosition position, IVisible visible);

        /// <summary>
        /// Type of camera
        /// </summary>
        Type CameraType
        {
            get;
        }

        /// <summary>
        /// Creates label on desktop
        /// </summary>
        /// <param name="obj">Object for label</param>
        /// <returns>The label</returns>
        IObjectLabel CreateLabel(object obj);

        /// <summary>
        /// Creates label of visible object
        /// </summary>
        /// <param name="position">Position of object</param>
        /// <param name="visible">Visible object</param>
        /// <returns>Editor of properties of visible object</returns>
        object CreateLabel(IPosition position, IVisible visible);

        /// <summary>
        /// Checks whether the factory supports a kind
        /// </summary>
        /// <param name="kind">Kind of object</param>
        /// <returns>True is supports and false otherwise</returns>
        bool SupportsKind(string kind);

    }
}
