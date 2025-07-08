using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using ResourceService;
using CommonService;
using Diagram.UI.Interfaces;


namespace Diagram.UI
{
    /// <summary>
    /// Wrapper of button
    /// </summary>
    public class ButtonWrapper
    {
        #region Fields

        private Type type;

        private string stringKind;

        private string toolTipText;

        private Image buttonImage;

        private bool isVisible;

        private bool isArrow;

        private IUIFactory factory;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="toolTipText">ToolTip</param>
        /// <param name="factory">Factory</param>
        /// <param name="buttonImage">Image</param>
        /// <param name="isVisible">The "is visible" sign</param>
        /// <param name="isArrow">The "is arrow" sign</param>
        public ButtonWrapper(Type type, string kind, string toolTipText, Image buttonImage, IUIFactory factory, bool isVisible, bool isArrow)
        {
            this.type = type;
            this.stringKind = kind;
            this.toolTipText = toolTipText;
            this.buttonImage = buttonImage;
            this.factory = factory;
            this.isVisible = isVisible;
            this.isArrow = isArrow;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="toolTipText">ToolTip</param>
        /// <param name="factory">Factory</param>
        /// <param name="icon">Icon</param>
        /// <param name="isVisible">The "is visible" sign</param>
        /// <param name="isArrow">The "is arrow" sign</param>
        public ButtonWrapper(Type type, string kind, string toolTipText, Icon icon, IUIFactory factory, bool isVisible, bool isArrow) :
            this(type, kind, toolTipText, icon.ToBitmap(), factory, isVisible, isArrow)
        {
        }


        #endregion

        #region Public Members

        /// <summary>
        /// Kind
        /// </summary>
        public string Kind
        {
            get
            {
                return stringKind;
            }
        }

        /// <summary>
        /// Creates toolbar
        /// </summary>
        /// <param name="buttons">Buttons</param>
        /// <param name="tools">Tools</param>
        /// <param name="size">Size</param>
        /// <param name="translate">The "translate" sign</param>
        /// <param name="resources">Resources</param>
        /// <returns>Toolbar</returns>
        public static PaletteToolBar CreateToolBar(IList<ButtonWrapper> buttons, ToolsDiagram tools, Size size, bool translate,
            Dictionary<string, object>[] resources)
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = size;
            foreach (ButtonWrapper bw in buttons)
            {
                imageList.Images.Add(bw.buttonImage);
            }
            PaletteToolBar toolbar = new PaletteToolBar(tools);
            toolbar.ImageList = imageList;
            for (int i = 0; i < buttons.Count; i++)
            {
                ButtonWrapper b = buttons[i];
                string tt = b.toolTipText;
                if (translate)
                {

                    tt = Resources.GetControlResource(tt, resources);
                }
                PaletteButton pb = new PaletteButton(toolbar, b.type, b.stringKind, tt, b.buttonImage, i, b.isArrow);
                if (!b.isVisible)
                {
                    pb.Visible = false;
                }
            }
            return toolbar;
        }


        /// <summary>
        /// Creates toolbar
        /// </summary>
        /// <param name="buttons">Buttons</param>
        /// <param name="tools">Tools</param>
        /// <param name="size">Size</param>
        /// <param name="resources">Resources</param>
        /// <param name="translate">The "translate" sign</param>
        /// <returns>Toolbar</returns>
        public static PaletteToolBar CreateToolBar(ButtonWrapper[] buttons, ToolsDiagram tools, Size size,
            Dictionary<string, object>[] resources, bool translate)
        {
            List<ButtonWrapper> l = new List<ButtonWrapper>(buttons);
            return CreateToolBar(l, tools, size, translate, resources);
        }

        /// <summary>
        /// Adds buttons to Tab control
        /// </summary>
        /// <param name="tab">The tab</param>
        /// <param name="buttons">Buttons</param>
        /// <param name="tools">Tools</param>
        /// <param name="size">Size</param>
        /// <param name="resources">Resources</param>
        /// <param name="translate">The "translate" sign</param>
        public static void Add(LightDictionary<string, ButtonWrapper[]> buttons, TabControl tab, 
            ToolsDiagram tools, Size size, Dictionary<string, object>[] resources, bool translate)
        {
            IList<string> keys = buttons.Keys;
            foreach (string key in keys)
            {
                Add(key, buttons[key], tab, tools, size, resources, translate);
            }
        }

        /// <summary>
        /// Adds buttons
        /// </summary>
        /// <param name="keys">Keys</param>
        /// <param name="buttons">Buttons</param>
        /// <param name="tab">Tab control</param>
        /// <param name="tools">Tools</param>
        /// <param name="size">Size</param>
        /// <param name="resources">Resources</param>
        /// <param name="translate">Translate sign</param>
        public static void Add(string[] keys, ButtonWrapper[][] buttons, TabControl tab, ToolsDiagram tools, Size size,
            Dictionary<string, object>[] resources, bool translate)
        {
            LightDictionary<string, ButtonWrapper[]> d = new LightDictionary<string, ButtonWrapper[]>();
            d.Add(keys, buttons);
            Add(d, tab, tools, size, resources, translate);
        }

        /// <summary>
        /// Creates dictionary of images
        /// </summary>
        /// <param name="buttons"></param>
        /// <returns></returns>
        public static Dictionary<Type, Image> CreateImageDictionary(ICollection<ButtonWrapper> buttons)
        {
            Dictionary<Type, Image> dic = new Dictionary<Type, Image>();
            foreach (ButtonWrapper bw in buttons)
            {
                dic[bw.type] = bw.buttonImage;
            }
            return dic;
        }



        static private void Add(string key, ButtonWrapper[] buttons, TabControl tab, ToolsDiagram tools, Size size,
            Dictionary<string, object>[] resources, bool translate)
        {
            TabPage tp = new TabPage();
            string tt = key + "";
            bool vis = true;
            if (tt[tt.Length - 1] == '@')
            {
                tt = tt.Substring(0, tt.Length - 1);
                vis = false;
                return;
            }
            if (translate)
            {
                tt = Resources.GetControlResource(tt, resources);
            }
            tp.Text = tt;
            PaletteToolBar toolbar = CreateToolBar(buttons, tools, size, resources, translate);
            tp.Controls.Add(toolbar);
            tab.Controls.Add(tp);
            if (!vis)
            {
                tp.Visible = false;
                toolbar.Visible = false;
            }
        }


        #endregion
    }
}
