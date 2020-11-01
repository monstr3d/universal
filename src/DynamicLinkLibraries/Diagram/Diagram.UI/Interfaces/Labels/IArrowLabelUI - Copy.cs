using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Diagram.UI.Labels;

namespace Diagram.UI.Interfaces.Labels
{
    /// <summary>
    /// UI of arrow label
    /// </summary>
    public interface IArrowLabelUI : IArrowLabel
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
        /// Pair of objects
        /// </summary>
        IObjectsPair Pair
        {
            get;
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
        /// Removes control from component
        /// </summary>
        void RemoveFromComponent();

        /// <summary>
        /// Removes Form
        /// </summary>
        void RemoveForm();

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
        /// Draws itself
        /// </summary>
        /// <param name="g">Graphics to draw</param>
        void Draw(object g);

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
        /// Creates Xml document
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        XmlElement CreateXml(XmlDocument doc);

        /// <summary>
        /// Component button
        /// </summary>
        IPaletteButton ComponentButton
        {
            get;
            set;
        }
        /// <summary>
        /// Order
        /// </summary>
        new int Ord
        {
            get;
            set;
        }

    }
}
