using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Diagram.UI.Utils;
using Diagram.UI;

namespace BasicEngineering.UI.Factory.Advanced.Forms
{
    /// <summary>
    /// Form that contains desktop
    /// </summary>
    public partial class FormDesktop : DockContent
    {
        #region Fields


        PanelDesktop desktop;

        static int nDesktop = 1;

        #endregion

        #region Ctor

        private FormDesktop()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tools">Tools</param>
        /// <param name="ext">Extension of files</param>
        public FormDesktop(ToolsDiagram tools, string ext)
            : this()
        {
            Text = ResourceService.Resources.GetControlResource("Desktop", ControlUtilites.Resources) + " " + nDesktop;
            ++nDesktop;
            desktop = new PanelDesktop(tools);
            StaticExtensionDiagramUI.CurrentDeskop = desktop;
            desktop.Extension = ext;
            desktop.AutoScroll = true;
            desktop.Dock = DockStyle.Fill;
            panelCenter.Controls.Add(desktop);
            desktop.ResizeImage();
            ToolBox.EditorReceiver.AddEditorDrag(desktop);
            ToolBox.PictureReceiver.AddImageDrag(desktop);
           
        }

        #endregion

        #region Members

        /// <summary>
        /// Desktop
        /// </summary>
        public PanelDesktop Desktop
        {
            get
            {
                return desktop;
            }
        }

        #endregion

    }
}