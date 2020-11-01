using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;


namespace Diagram.UI
{
    /// <summary>
    /// The tree node
    /// </summary>
    public class NamedNode : TreeNode
    {
        /// <summary>
        /// Linked component
        /// </summary>
        protected INamedComponent component;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="component">Linked component</param>
        /// <param name="fullName">The "show full" name sign</param>
        public NamedNode(INamedComponent component, bool fullName)
        {
            this.component = component;
            if (component is NamedComponent)
            {
                NamedComponent comp = component as NamedComponent;
                comp.AddNode(this);
                Text = component.Name;
            }
            else
            {
                INamedComponent nc = component;
                IDesktop root = component.Root.Desktop;
                if (fullName)
                {
                    Text = component.RootName;
                }
                else
                {
                    Text = component.GetName(nc.Desktop);
                }
            }
            ImageIndex = NamedComponent.GetImageNumber(component);
            SelectedImageIndex = ImageIndex;
        }

        /// <summary>
        /// Shows component form
        /// </summary>
        public void ShowForm()
        {
            if (component is IShowForm)
            {
                IShowForm sf = component as IShowForm;
                sf.Show();
                return;
            }
            IChildObjectLabel panel = ContainerPerformer.GetPanel(component as IObjectLabel) as IChildObjectLabel;
            panel.ShowForm();
        }




        /// <summary>
        /// Sets new name
        /// </summary>
        /// <param name="name">The name</param>
        public void SetName(string name)
        {

            if (component is NamedComponent)
            {
                NamedComponent comp = component as NamedComponent;
                comp.SetName(name);
            }
            else if (component is IObjectLabelUI)
            {
                IObjectLabelUI olui = component as IObjectLabelUI;
                olui.ComponentName = name;
            }
            else if (component is IArrowLabelUI)
            {
                IArrowLabelUI alui = component as IArrowLabelUI;
                alui.ComponentName = name;
            }
        }
    }
}
