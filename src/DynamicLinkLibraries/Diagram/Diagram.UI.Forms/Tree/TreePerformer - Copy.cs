using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace Diagram.UI.Tree
{
    /// <summary>
    /// Performer of tree
    /// </summary>
    public static class TreePerformer
    {

        /// <summary>
        /// Creates element from Node
        /// </summary>
        /// <param name="doc">Parent document</param>
        /// <param name="node">Node</param>
        /// <param name="parent">Parent element</param>
        public static void CreateElement(XmlDocument doc, TreeNode node, XmlElement parent)
        {
            object ob = node.Tag;
            string t = ob.GetType().Name;
            XmlElement element = doc.CreateElement(t);
            element.SetAttribute("name", node.Text);
            element.SetAttribute("imageIndex", node.ImageIndex + "");
            parent.AppendChild(element);
            foreach (TreeNode n in node.Nodes)
            {
                CreateElement(doc, n, element);
            }
        }

        /// <summary>
        /// Creates element from Node
        /// </summary>
        /// <param name="doc">Parent document</param>
        /// <param name="node">Node</param>
        /// <param name="parent">Parent element</param>
        /// <param name="level">Level of element</param>
        public static void CreateElement(XmlDocument doc, TreeNode node, XmlElement parent, int level)
        {
            object ob = node.Tag;
            string t = ob.GetType().Name;
            XmlElement element = doc.CreateElement(t);
            element.SetAttribute("name", node.Text);
            element.SetAttribute("imageIndex", level + "");
            parent.AppendChild(element);
            foreach (TreeNode n in node.Nodes)
            {
                CreateElement(doc, n, element, level + 1);
            }
        }

    }
}
