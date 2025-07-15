using System;

namespace Diagram.UI.Attributes
{
    /// <summary>
    /// Attribute of liked type
    /// </summary>
    public class LinkedTypeAttribute : Attribute
    {
        #region Fields

        Type type;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">The type</param>
        public LinkedTypeAttribute(Type type)
        {
            this.type = type;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// The type
        /// </summary>
        public Type Type
        {
            get { return type; }
        }

        #endregion
    }
}
