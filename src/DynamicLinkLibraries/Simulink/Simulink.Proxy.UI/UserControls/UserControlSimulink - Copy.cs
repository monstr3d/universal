using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

using CategoryTheory;
using Diagram.UI;


using Simulink.Proxy.CategoryObjects;
using Xml.Parser.Library;
using Simulink.Drawing.Library;
using Simulink.Proxy.UI.Objects;
using Simulink.CSharp.Proxy;
using Simulink.Parser.Library;
using Simulink.Parser.Library.CodeCreators;
using Simulink.Parser.Library.DiagramElements;

namespace Simulink.Proxy.UI.UserControls
{
    /// <summary>
    /// User control for simulink proxy
    /// </summary>
    public partial class UserControlSimulink : UserControl
    {

        #region Fields

        ICategoryObject theObject;

        TextObject to;

        ObjectContainerBase cont;

        UserControlProxyAlias ucproxy;


        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public UserControlSimulink()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Associated object
        /// </summary>
        public ICategoryObject TheObject
        {
            set
            {
                theObject = value;
                to = new TextObject(value);
                if (!(theObject is ObjectContainerBase))
                {
                    tabControlMain.TabPages.Remove(tabPageInterface);
                    
                }
                else
                {
                    cont = value as ObjectContainerBase;
                }
                if (value is CSharpSimulinkProxy)
                {
                    CSharpSimulinkProxy proxy = value as CSharpSimulinkProxy;
                    TabPage tp = new TabPage("Input");
                    tabControlMain.TabPages.Add(tp);
                    ucproxy = new UserControlProxyAlias();
                    ucproxy.Dock = DockStyle.Fill;
                    tp.Controls.Add(ucproxy);
                    ucproxy.Proxy = proxy;
                }
                UpdateAll();
            }
        }


        void Fill()
        {
            //userControlContainerDesigner.Fill(cona
        }

        void Save(string filename)
        {
            try
            {
                List<string> l = to.Text;
                StreamWriter wr = new StreamWriter(filename);
                foreach (string s in l)
                {
                    wr.WriteLine(s);
                }
                wr.Flush();
                wr.Close();
                openFileDialog.FileName = filename;
            }
            catch (Exception e)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }

        new void Load(string filename)
        {
            try
            {
                List<string> la = StaticExtensionXmlParserLibrary.TransformFile(filename) as List<string>;
                List<string> l = new List<string>();
                for (int ns = 0; ns < la.Count; ns++)
                {
                    string s = la[ns];
                    int p = 0;
                    for (int k = ns + 1; k < la.Count; k++)
                    {
                        string ss = la[k];
                        if (ss.Length == 0)
                        {
                            break;
                        }
                        if (ss[0] != '\"')
                        {
                            break;
                        }
                        s = s.Substring(0, s.Length - 1) + ss.Substring(1);
                        ++p;
                    }
                    ns += p;
                    l.Add(s);
                }
                to.Text = l;
                if (ucproxy != null)
                {
                    ucproxy.Fill();
                }
                
                Perform(() => cont.Interface.Clear());
                UpdateAll();
                saveFileDialog.FileName = filename;
            }
            catch (Exception e)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, e.Message);
            }
            
        }

        void UpdateAll()
        {
            try
            {
                UpdateText();
                UpdatePublic();
                UpdateImage();
            }
            catch (Exception)
            {
            }
        }

        void UpdatePublic()
        {
            Perform(()=>userControlContainerDesigner.Fill(cont));
        }

        void UpdateImage()
        {
            List<string> l = to.Text;
            if (l.Count > 0)
            {
                XElement doc = Simulink.Parser.Library.SimulinkXmlParser.Create(l);
                Simulink.Parser.Library.SimulinkXmlParser.TransformFunc(doc);
                SimulinkSystem system = new SimulinkSystem(doc);
                int k = 0;
                system.Subsystem.Enumerate(ref k);
                system.Subsystem.SetArrowVariables("arrow_");
                //List<Block> lb = system.AllBlocks;
                //order = Block.SetOrder(lb, new BlockCodeCreator());
                //blocks = lb.ToArray();
                userControlSimulinkSchemeAndTree.SimulinkSystem =
                    system;

            }
        }

        void UpdateText()
        {
            List<string> l = to.Text;
            richTextBoxSource.Lines = l.ToArray();
        }

        private void AcceptText()
        {
            try
            {
                List<string> l = new List<string>();
                l.AddRange(richTextBoxSource.Lines);
                to.Text = l;
                Perform(() => cont.Interface.Clear());
                UpdatePublic();
                UpdateImage();
            }
            catch (Exception e)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, e.Message);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            Load(openFileDialog.FileName);
        }

        private void buttonAcceptText_Click(object sender, EventArgs e)
        {
            AcceptText();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            Save(saveFileDialog.FileName);
        }


        private void Perform(Action act)
        {
            if (cont != null)
            {
                act();
            }
        }

    }
}
