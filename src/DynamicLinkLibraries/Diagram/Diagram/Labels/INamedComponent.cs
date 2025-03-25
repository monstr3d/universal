using Diagram.UI.Interfaces;

namespace Diagram.UI.Labels
{
    /// <summary>
    /// Named component
    /// </summary>
    public interface INamedComponent
    {
        /// <summary>
        /// Name
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// Kind
        /// </summary>
        string Kind
        {
            get;
        }

        /// <summary>
        /// Type
        /// </summary>
        string Type
        {
            get;
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        void Remove();

        /// <summary>
        /// X coordinate
        /// </summary>
        int X
        {
            get;
            set;
        }

        /// <summary>
        /// Y coordinate
        /// </summary>
        int Y
        {
            get;
            set;
        }

        /// <summary>
        /// Desktop
        /// </summary>
        IDesktop Desktop
        {
            get;
            set;
        }

        /// <summary>
        /// Order
        /// </summary>
        int Ord
        {
            get;
        }

        /// <summary>
        /// Parent component
        /// </summary>
        INamedComponent Parent
        {
            get;
            set;
        }

        /// <summary>
        /// Root
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <returns>Root</returns>
        INamedComponent GetRoot(IDesktop desktop);

        /// <summary>
        /// Gets component name relatively desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>Relalive name</returns>
        string GetName(IDesktop desktop);

        /// <summary>
        /// Gets name relatively root
        /// </summary>
        string RootName
        {
            get;
        }

        /// <summary>
        /// Root control
        /// </summary>
        INamedComponent Root
        {
            get;
        }

    }
}
