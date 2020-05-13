using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;


using CategoryTheory;
using Diagram.UI;

namespace Simulink.Proxy.Interfaces
{
    /// <summary>
    /// Factory of blokcs
    /// </summary>
    public interface IBlockFactory
    {
        /// <summary>
        /// Creates objects
        /// </summary>
        /// <param name="element">XmlElement</param>
        /// <param name="categoryObject">Object</param>
        void Create(XmlElement element, ref ICategoryObject categoryObject);

        /// <summary>
        /// Objects of factrory
        /// </summary>
        Dictionary<string, ICategoryObject> Objects
        {
            get;
        }

        /// <summary>
        /// Desktop
        /// </summary>
        PureDesktopPeer Desktop
        {
            get;
        }

        /// <summary>
        /// Creates factory from desktop
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <returns>Factory</returns>
        IBlockFactory Create(PureDesktopPeer desktop);
        
           
    }
}
