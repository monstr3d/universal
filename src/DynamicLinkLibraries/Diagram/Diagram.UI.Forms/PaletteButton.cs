using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Diagram.UI.Interfaces;

namespace Diagram.UI
{
    /// <summary>
    /// The button of objects and arrows palette
    /// </summary>
    public class PaletteButton : ToolBarButton, IPaletteButton
    {
        /// <summary>
        /// The type
        /// </summary>
        private string type;

        /// <summary>
        /// Is arrow flag
        /// </summary>
        private bool isArrow;

        /// <summary>
        /// kind
        /// </summary>
        private string kind;
 
        /// <summary>
        /// The image
        /// </summary>
        private Image buttonImage;

        /// <summary>
        /// Tools of diagram
        /// </summary>
        private ToolsDiagram diagram;

        /// <summary>
        /// Number of image
        /// </summary>
        private int imageNumber;

        /// <summary>
        /// Type of object
        /// </summary>
        private Type objectType;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="toolbar">The toolbar</param>
        /// <param name="type">The type</param>
        /// <param name="kind">The string kind</param>
        /// <param name="toolTipText">The tip</param>
        /// <param name="buttonImage">The image</param>
        /// <param name="ImageIndex">The image index</param>
        /// <param name="IsArrow">The "is arrow" flag</param>
        public PaletteButton(PaletteToolBar toolbar, Type type, string kind, string toolTipText, Image buttonImage, int ImageIndex, bool IsArrow) :
            this(toolbar, type.ToString(), type, kind, toolTipText, buttonImage, ImageIndex, IsArrow)
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="toolbar">The toolbar</param>
        /// <param name="type">The type</param>
        /// <param name="objectType">The object type</param>
        /// <param name="kind">The string kind</param>
        /// <param name="toolTipText">The tip</param>
        /// <param name="buttonImage">The image</param>
        /// <param name="ImageIndex">The image index</param>
        /// <param name="IsArrow">The "is arrow" flag</param>
        internal PaletteButton(PaletteToolBar toolbar, string type, Type objectType, string kind, string toolTipText, Image buttonImage, int ImageIndex, bool IsArrow)
        {
            this.objectType = objectType;
            this.kind = kind;
            this.isArrow = IsArrow;
            if (objectType != null)
            {
                this.type = objectType.ToString();
            }
            this.ToolTipText = toolTipText;
            this.ImageIndex = ImageIndex;
            this.buttonImage = buttonImage;
            toolbar.Buttons.Add(this);
            Style = ToolBarButtonStyle.ToggleButton;
            diagram = toolbar.ToolDiagram;
            imageNumber = diagram.Count;
            diagram.AddButton(this);
            int i = diagram.Count;
        }

        /// <summary>
        /// Number of image
        /// </summary>
        public int ImageNumber
        {
            get
            {
                return imageNumber;
            }
        }





        /// <summary>
        /// The type
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// The "is arrow" flag
        /// </summary>
        public bool IsArrow
        {
            get
            {
                return isArrow;
            }
        }


        /// <summary>
        /// The kind
        /// </summary>
        public string Kind
        {
            get
            {
                return kind;
            }
        }

        /// <summary>
        /// The image
        /// </summary>
        public object ButtonImage
        {
            get
            {
                return buttonImage;
            }
        }

        /// <summary>
        /// Object type
        /// </summary>
        public Type ReflectionType
        {
            get
            {
                return objectType;
            }
        }

        /// <summary>
        /// Tooltip text
        /// </summary>
        public string ToolTip
        {
            get
            {
                return ToolTipText;
            }
        }

    }
}
