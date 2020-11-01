using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

using SerializationInterface;

using CommonService;

namespace Diagram.UI
{
    /// <summary>
    /// Performer of container UI
    /// </summary>
    static public class ContainerPerformerUI
    {
        /// <summary>
        /// Initialization of containers tools
        /// </summary>
        /// <param name="baseDirectory">Base directory</param>
        /// <param name="tools">Tools</param>
        /// <param name="tabControl">Tab control</param>
        /// <param name="resources">Resources</param>
        static public void InitContainers(string baseDirectory, ToolsDiagram tools, TabControl tabControl,
            Dictionary<string, object>[] resources)
        {
            string cont = baseDirectory;
            if (cont[cont.Length - 1] != Path.DirectorySeparatorChar)
            {
                cont = cont + Path.DirectorySeparatorChar;
            }
            cont = cont + "Containers" +
                Path.DirectorySeparatorChar + "Containers.xml";
            if (!File.Exists(cont))
            {
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(cont);
            XmlNodeList nl = doc.GetElementsByTagName("Assemblies");
            if (nl.Count > 0)
            {
                XmlElement ass = nl[0] as XmlElement;
                string dir = AppDomain.CurrentDomain.BaseDirectory;
                foreach (XmlNode ndll in ass.ChildNodes)
                {
                    if (!(ndll is XmlElement))
                    {
                        continue;
                    }
                    XmlElement dll = ndll as XmlElement;
                    string fn = dir + dll.GetAttribute("file");
                    if (!File.Exists(fn))
                    {
                        throw new Exception("File + \"" + fn + "\" does not exist");
                    }
                    byte[] b = fn.GetFileBytes();
                    AppDomain.CurrentDomain.Load(b);
                }
            }
            XmlNodeList contPages = doc.GetElementsByTagName("Page");
          //  int k = 0;
            LightDictionary<string, ButtonWrapper[]> dict = new LightDictionary<string, ButtonWrapper[]>();
            foreach (XmlElement page in contPages)
            {
                XmlNodeList list = page.ChildNodes;   
                List<ButtonWrapper> buttons = new List<ButtonWrapper>();
                foreach (XmlNode eln in list)
                {
                    if (!(eln is XmlElement))
                    {
                        continue;
                    }
                    XmlElement el = eln as XmlElement;
                    string tag = el.Name;
                    string ico = AppDomain.CurrentDomain.BaseDirectory + el.Attributes["icon"].Value;
                    Image image = Image.FromFile(ico);
                    string name = el.GetAttribute("name");
                    string hint = el.Attributes["hint"].Value;
                    bool isArrow = el.Attributes["arrow"].Value.Equals("true");
                    ButtonWrapper button = null;
                    if (isArrow)
                    {
                        button = new ButtonWrapper(typeof(LibraryArrowWrapper), name, hint, image, null, true, true);
                    }
                    else
                    {
                        if (tag.Equals("Aggregate"))
                        {
                            bool b = true;
                            if (el.Attributes["wrapper"] != null)
                            {
                                if (el.GetAttribute("wrapper").Equals("true"))
                                {
                                    button = new ButtonWrapper(typeof(LibraryObjectWrapper), name, hint, image, null, true, false);
                                    b = false;
                                }
                            }
                            if (b)
                            {
                                button = new ButtonWrapper(typeof(ObjectContainer), name, hint, image, null, true, false);
                            }
                        }
                        if (tag.Equals("Object"))
                        {
                            string tp = el.GetAttribute("type");
                            Type t = Type.GetType(tp);
                            if (t == null)
                            {
                                throw new Exception("Type \"" + tp + "\" does not exist");
                            }
                            button = new ButtonWrapper(t, el.GetAttribute("param"), hint, image, null, true, false);
                        }
                    }
                    buttons.Add(button);
                }
                XmlAttribute an = page.Attributes["pageName"];
                string vis = page.GetAttribute("visible");
                if (vis == "false")
                {
                    vis = "@";
                }
                else
                {
                    vis = "";
                }
                dict.Add(new string[] { an.Value + vis }, new ButtonWrapper[][] { buttons.ToArray() });
            }
            ButtonWrapper.Add(dict, tabControl, tools, new Size(25, 25), resources, false);
        }
    }
}