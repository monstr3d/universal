using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Diagram.UI.Labels;

namespace Diagram.UI.Interfaces.Labels
{
    /// <summary>
    /// UI of object label
    /// </summary>
    public interface IObjectLabelUI : IObjectLabel, IStartStop 
    {
        /// <summary>
        /// Associated control
        /// </summary>
        object Control
        {
            get;
        }

        /// <summary>
        /// Name of component
        /// </summary>
        string ComponentName
        {
            set;
        }

        /// <summary>
        /// The selected sign
        /// </summary>
        bool Selected
        {
            get;
            set;
        }

        /// <summary>
        /// Updates Form UI
        /// </summary>
        void UpdateForm();

        /// <summary>
        /// Associated Tree node
        /// </summary>
        object Node
        {
            get;
            set;
        }

        /// <summary>
        /// Image
        /// </summary>
        object Image
        {
            get;
        }
        
        /// <summary>
        /// Order
        /// </summary>
        new int Ord
        {
            get;
            set;
        }

        /// <summary>
        /// Initialization
        /// </summary>
        void Initialize();


        /// <summary>
        /// Removes itself
        /// </summary>
        /// <param name="removeForm">The "Remove Form" sign</param>
        void Remove(bool removeForm);

        /// <summary>
        /// The "Arrow Selected" sign
        /// </summary>
        bool ArrowSelected
        {
            get;
            set;
        }

        /// <summary>
        /// Creates Xml document
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        XmlElement CreateXml(XmlDocument doc);

        /// <summary>
        /// Removes itself from component
        /// </summary>
        void RemoveFromComponent();

        /// <summary>
        /// Component button
        /// </summary>
        IPaletteButton ComponentButton
        {
            get;
            set;
        }


    }
}
