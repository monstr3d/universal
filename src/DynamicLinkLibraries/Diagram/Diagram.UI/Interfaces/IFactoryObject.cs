using System;
using System.Collections.Generic;
using System.Text;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// The linked with factory object
    /// This object has link with domain UI factory
    /// </summary>
    public interface IFactoryObject
    {
        /// <summary>
        /// The UI factory of domain
        /// </summary>
        IUIFactory Facrory
        {
            get;
            set;
        }
    }


}
