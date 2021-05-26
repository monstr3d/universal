using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CommonService;
using Diagram.UI;
using System.Drawing;
using Diagram.UI.Interfaces;

using DataWarehouse;
using DataWarehouse.Interfaces;
using System.IO;
using TestCategory.Interfaces;

namespace BasicEngineering.UI.Factory.Interfaces
{
    /// <summary>
    /// Application creator
    /// </summary>
    public interface IApplicationCreator
    {
        /// <summary>
        /// Buttons
        /// </summary>
        LightDictionary<string, ButtonWrapper[]> Buttons
        {
            get;
        }

        /// <summary>
        /// Icon
        /// </summary>
        Icon Icon
        {
            get;
        }

        /// <summary>
        /// Factory
        /// </summary>
        IUIFactory Factory
        {
            get;
        }

        /// <summary>
        /// File name
        /// </summary>
        string Filename
        {
            get;
        }

        /// <summary>
        /// Start animation action
        /// </summary>
        Action<double, double, int, int, int, IDesktop> Start
        {
            get;
        }

        /// <summary>
        /// Caption text
        /// </summary>
        string Text
        {
            get;
        }

        /// <summary>
        /// File extension
        /// </summary>
        string Ext
        {
            get;
        }

        /// <summary>
        /// File filter
        /// </summary>
        string FileFilter
        {
            get;
        }

        /// <summary>
        /// Initializer
        /// </summary>
        IApplicationInitializer ApplicationInitializer
        {
            get;
        }

        /// <summary>
        /// Holder of inserted
        /// </summary>
        ByteHolder Holder
        {
            get;
            set;
        }

        /// <summary>
        /// Localization resources
        /// </summary>
        Dictionary<string, object>[] Resources
        {
            get;
        }

        /// <summary>
        /// Loads resources
        /// </summary>
        void LoadResources();

        /// <summary>
        /// Database coordinator
        /// </summary>
        IDatabaseCoordinator DatabaseCoordinator
        {
            get;
        }

        TextWriter Log
        {
            get;
        }

        /// <summary>
        /// Test interface
        /// </summary>
        ITestInterface TestInterface
        {
            get;
        }
       
    }
}
