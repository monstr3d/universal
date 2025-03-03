using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


using CategoryTheory;

using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;
using ErrorHandler;


namespace Diagram.UI
{
    /// <summary>
    /// The tools of diagram
    /// </summary>
    public class ToolsDiagram : IToolsDiagram
    {
        /// <summary>
        /// The active button
        /// </summary>
        protected PaletteButton active = null;


  
        /// <summary>
        /// Buutons
        /// </summary>
        Dictionary<Type, Dictionary<string, IPaletteButton>> buttons = new Dictionary<Type, Dictionary<string, IPaletteButton>>();


        /// <summary>
        /// The button on click event handler
        /// </summary>
        ToolStripItemClickedEventHandler handler;

        /// <summary>
        /// The UI factory
        /// </summary>
        private IUIFactory factory;

  

        /// <summary>
        /// Image list of buttons
        /// </summary>
        private ImageList buttonImages = new ImageList();

        /// <summary>
        /// The tree view
        /// </summary>
        private TreeView tree;

        /// <summary>
        /// Objects node
        /// </summary>
        private TreeNode objectsNode;


        /// <summary>
        /// Arrows node;
        /// </summary>
        private TreeNode arrowsNode;

 

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory">The UI factory</param>
        public ToolsDiagram(IUIFactory factory)
        {
            StaticExtensionDiagramUISerializable.Init();
            handler = ToolBar_ButtonClick;
            this.factory = factory;
            factory.Tools = this;
        }

        /// <summary>
        /// Button click event
        /// </summary>
        public ToolStripItemClickedEventHandler BtnCkick
        {
            get { return handler;  }
        }

        /// <summary>
        /// The tree view
        /// </summary>
        public TreeView Tree
        {
            get
            {
                return tree;
            }
            set
            {
                tree = value;
                tree.ImageList = buttonImages;
                objectsNode = new TreeNode(ResourceService.Resources.GetControlResource("Objects", ControlUtilites.Resources));
                arrowsNode = new TreeNode(ResourceService.Resources.GetControlResource("Arrows", ControlUtilites.Resources));
                objectsNode.ImageIndex = 0;
                arrowsNode.ImageIndex = 1;
                arrowsNode.SelectedImageIndex = 1;
                tree.Nodes.Add(objectsNode);
                tree.Nodes.Add(arrowsNode);
                tree.MouseUp += new MouseEventHandler(treeUp);
                tree.AfterLabelEdit += new NodeLabelEditEventHandler(editNode);
                tree.AfterSelect += new TreeViewEventHandler(selectTree);
                tree.LabelEdit = true;
            }
        }


        /// <summary>
        /// Adds node to tree
        /// </summary>
        /// <param name="label">Corresponding label</param>
        public void AddObjectNode(IObjectLabel label)
        {
            addObjectNode(objectsNode, label);
        }

        /// <summary>
        /// Adds arrow node
        /// </summary>
        /// <param name="label"></param>
        public void AddArrowNode(IArrowLabelUI label)
        {
            if (tree == null)
            {
                return;
            }
            NamedNode node = new NamedNode(label, false);
            label.Node = node;
            arrowsNode.Nodes.Add(node);
            NamedNode ns = new NamedNode(label.Source, true);
            node.Nodes.Add(ns);
            NamedNode nt = new NamedNode(label.Target, true);
            node.Nodes.Add(nt);
        }
        /// <summary>
        /// Removes object node
        /// </summary>
        /// <param name="label">The object label</param>
        public void RemoveObjectNode(IObjectLabelUI label)
        {
            if (tree == null)
            {
                return;
            }
            try
            {
                TreeNode n = label.Node as TreeNode;
                objectsNode.Nodes.Remove(n);
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }


        /// <summary>
        /// Removes arrow node
        /// </summary>
        /// <param name="label">The arrow label</param>
        public void RemoveArrowNode(IArrowLabelUI label)
        {
            if (tree == null)
            {
                return;
            }
            try
            {
                TreeNode n = label.Node as TreeNode;
                arrowsNode.Nodes.Remove(n);
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
        }


        /// <summary>
        /// Count of images
        /// </summary>
        public int Count
        {
            get
            {
                return buttonImages.Images.Count;
            }
        }

        /// <summary>
        /// The active button
        /// </summary>
        public PaletteButton Active
        {
            get
            {
                return active;
            }
        }

  
        /// <summary>
        /// The UI factory
        /// </summary>
        public IUIFactory Factory
        {
            get
            {
                return factory;
            }
        }

        /// <summary>
        /// Adds button to this panel
        /// </summary>
        /// <param name="button">The button to add</param>
        public void AddButton(IPaletteButton button)
        {
            var img = button.ButtonImage;
            if (img is Image im)
            {
                buttonImages.Images.Add(im);
            }
            else
            {

            }
            
            
            Type t = button.ReflectionType;
            if (t == null)
            {
                return;
            }
            Dictionary<string, IPaletteButton> d = null;
            if (!buttons.ContainsKey(t))
            {
                d = new Dictionary<string, IPaletteButton>();
                buttons[t] = d;
            }
            else
            {
                d = buttons[t];
            }
            string kind = button.Kind;
            d[kind] = button;
        }

        /// <summary>
        /// Finds required button
        /// </summary>
        /// <param name="nc">Corresponding component</param>
        /// <returns>The button</returns>
        public IPaletteButton FindButton(INamedComponent nc)
        {
            string type = nc.Type;
            if (type == null)
            {
                type = "";
            }
            if (type.Length == 0)
            {
                if (nc is IObjectLabel)
                {
                    IObjectLabel l = nc as IObjectLabel;
                    object o = l.Object;
                    if (o != null)
                    {
                        type = o.GetType() + "";
                    }
                }
            }
            if (type.Length == 0)
            {
                if (nc is IArrowLabel)
                {
                    IArrowLabel l = nc as IArrowLabel;
                    object o = l.Arrow;
                    if (o != null)
                    {
                        type = o.GetType() + "";
                    }
                }
            }
            if (type.Length == 0)
            {
                return null;
            }
            return FindButton(type, nc.Kind);
        }

        /// <summary>
        /// Finds button
        /// </summary>
        /// <param name="type">Button type</param>
        /// <param name="kind">Button kind</param>
        /// <returns>The button</returns>
        public IPaletteButton FindButton(string type, string kind)
        {
            foreach (Type t in buttons.Keys)
            {
                if (type./*Replace("Diagram.UI", "Diagram.UI").*/Equals(t + ""))
                {
                    Dictionary<string, IPaletteButton> d = buttons[t];
                    string kk = kind;
                    if (kk == null)
                    {
                        kk = "";
                    }
                    if (d.ContainsKey(kk))
                    {
                        return d[kk];
                    }
                }
            }
            return null;
        }


        /// <summary>
        /// Creates object editor form of property editor object
        /// </summary>
        /// <param name="obj">The property editor ofject</param>
        /// <returns>The property editor form</returns>
        static public Form CreateEditorForm(object obj)
        {
            if (obj is IAssociatedObject)
            {
                IAssociatedObject ao = obj as IAssociatedObject;
                IPropertiesEditor pe = ao.GetObject<IPropertiesEditor>();
                if (pe != null)
                {
                    object ob = pe.Editor;
                    if (ob != null)
                    {
                        if (ob is Form)
                        {
                            Form f = ob as Form;
                            return f;
                        }
                        if (ob is Array)
                        {
                            Array arr = ob as Array;
                            object h = arr.GetValue(0);
                            if (h is Form)
                            {
                                Form f = h as Form;
                                return f;
                            }
                        }
                    }

                }
            }
            if (obj is MultiLibraryObject)
            {
                MultiLibraryObject mo = obj as MultiLibraryObject;
                IObjectLabel lab = mo.Object as IObjectLabel;
                return new FormMultilibrary(lab);
            }
            return null;
        }

        /// <summary>
        /// The "is active" sign
        /// </summary>
        public bool IsMoved
        {
            get
            {
                if (active == null)
                {
                    return true;
                }
                if (active.IsArrow & active.ReflectionType != null)
                {
                    return false;
                }
                return true;
            }
        }

        #region Protected Members

        /// <summary>
        /// The "on click" event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event handler arguments</param>
        protected void ToolBar_ButtonClick(Object sender, ToolStripItemClickedEventArgs e)
        {
            PaletteButton but = (PaletteButton)e.ClickedItem;
            if (active != but)
            {
                if (active != null)
                {
                    active.CheckState = CheckState.Unchecked;
                }
                active = but;
                active.CheckState = CheckState.Checked;
            }
        }

        #endregion

        #region Private members

        /// <summary>
        /// Tree mouse up event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            TreeNode n = tree.SelectedNode;
            if (!(n is NamedNode))
            {
                return;
            }
            NamedNode node = n as NamedNode;
            node.ShowForm();
        }

        /// <summary>
        /// Adds Object node
        /// </summary>
        /// <param name="parent">Parent tree node</param>
        /// <param name="label">Object label</param>
        private void addObjectNode(TreeNode parent, IObjectLabel label)
        {
            if (tree == null)
            {
                return;
            }
            NamedNode node = new NamedNode(label, false);
            if (label is IObjectLabelUI)
            {
                IObjectLabelUI lab = label as IObjectLabelUI;
                lab.Node = node;
            }
            parent.Nodes.Add(node);
            if (!(label.Object is IObjectContainer))
            {
                return;
            }
            IObjectContainer cont = label.Object as IObjectContainer;
            IDesktop desk = cont.Desktop;
            Dictionary<string, object> t = cont.Interface;
            foreach (string str in t.Keys)
            {
                INamedComponent comp = desk[str];
                NamedNode n = new NamedNode(comp, false);
                node.Nodes.Add(n);
            }
        }

        /// <summary>
        /// Edit tree node event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        private void editNode(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
        {
            string name = e.Label;
            if (!(e.Node is NamedNode))
            {
                return;
            }
            NamedNode node = e.Node as NamedNode;
            node.SetName(name);
        }

        /// <summary>
        /// Select event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        private void selectTree(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {

            if (!(e.Node is NamedNode))
            {
                return;
            }
            NamedNode node = e.Node as NamedNode;
        }


        #endregion

    }
}
