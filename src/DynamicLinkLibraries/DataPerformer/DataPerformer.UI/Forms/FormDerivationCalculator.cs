using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using FormulaEditor;
using FormulaEditor.UI;
using FormulaEditor.Drawing;

namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// Form for calculation of derivatioins
    /// </summary>
    public partial class FormDerivationCalculator : Form
    {
        private MathFormulaDrawable derivFormula;
        private Rectangle derivRect;
        private Image derivImage;
        private Point pointDeriv;
        private bool accepted = false;
        private Pen rectPen = new Pen(Color.Black);
        private Brush fillBrush = new SolidBrush(Color.FromArgb(216, 203, 187));
        private FormulaEditorPanel panel;
        private Panel panelBase;


        /// <summary>
        /// Default constructor
        /// </summary>
        public FormDerivationCalculator()
        {
            InitializeComponent();
            panelBase = panelDesktopCenter;
            panel = new FormulaEditorPanel();
            panel.Left = 0;
            panel.Top = 0;
            panel.Width = 1200;
            panel.Height = 300;
            panelBase.Controls.Add(panel);
            panel.Prepare();
            openFileDialogEditor.InitialDirectory =
                ResourceService.Resources.CurrentDirectory + "\\Functions";
            saveFileDialogEditor.InitialDirectory = openFileDialogEditor.InitialDirectory;

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="s">String representation of derivation</param>
        public FormDerivationCalculator(string s)
        {

            InitializeComponent();
            panelBase = panelDesktopCenter;

            this.LoadResources();
            panel = new FormulaEditorPanel();
            panel.Left = 0;
            panel.Top = 0;
            panel.Width = 1200;

            panel.Height = 300;

            panelDeriv.Top = panel.Top + panel.Height + 20;
            panelDeriv.Left = panel.Left;
            panelDeriv.Width = panel.Width;
            panelDeriv.Height = 300;//nel.Height;
            derivRect = new Rectangle(80, 20, 1100, panelDeriv.Height - 40);
            pointDeriv = new Point(derivRect.Left + 20, derivRect.Top + derivRect.Height / 2);
            derivImage = new Bitmap(panelDeriv.Width, panelDeriv.Height);
            Graphics g = Graphics.FromImage(derivImage);
            g.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, derivImage.Width, derivImage.Height);
            g.DrawRectangle(new Pen(Color.Black), 0, 0, derivImage.Width - 1, derivImage.Height - 1);
            Font f = new Font("Serif", MathSymbolFactory.Sizes[0], FontStyle.Bold | FontStyle.Italic);
            int delta = 15;
            Brush bBrush = new SolidBrush(Color.Black);
            g.DrawString("f' = ", f, bBrush, 10, pointDeriv.Y + delta);
            g.Dispose();
            textBoxDerivType.Left = 20;
            textBoxDerivType.Top = pointDeriv.Y + 35;
            panelBase.Controls.Add(panel);
            string[] symbols = new string[] { "abcdefghijklmnopqrstuvwxyz" };
            panel.Prepare(s, 4, null, null);
            openFileDialogEditor.InitialDirectory =
                ResourceService.Resources.CurrentDirectory + "\\Functions";
            saveFileDialogEditor.InitialDirectory = openFileDialogEditor.InitialDirectory;
        }

        /// <summary>
        /// Formula for derivation
        /// </summary>
        public string Formula
        {
            get
            {
                return panel.Performer.Formula.FormulaString;
            }
            set
            {
                panel.Performer.Formula =
                    new MathFormulaDrawable(MathFormula.FromString(MathSymbolFactory.Sizes, value), DrawableConverter.Object);
                panel.Performer.DrawFormula();//.Prepare(s);
            }
        }

        /// <summary>
        /// The "accepted" sign
        /// </summary>
        public bool Accepted
        {
            get
            {
                return accepted;
            }
        }

        private void Open()
        {
            if (openFileDialogEditor.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }
            LoadFromFile(openFileDialogEditor.FileName);
        }

        private void LoadFromFile(string filename)
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Load(filename);
                //XmlElement el = doc.GetElementsByTagName("Function")[0] as XmlElement;
                Formula = doc.OuterXml;
                /*doc.Load(filename);
                XmlCDataSection s = doc.DocumentElement.FirstChild as XmlCDataSection;*/
                /*System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
                    formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                Stream stream = File.OpenRead(filename);
                MathFormula f = formatter.Deserialize(stream) as MathFormula;
                stream.Close();
                f.Post();
                Formula = f.FormulaString;*/
            }
            catch (Exception ex)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, ex.Message);
            }
        }

        private void save(string filename)
        {
            /*	XmlDocument doc = new XmlDocument();
                doc.LoadXml("<?xml version=\"1.0\"?>" + "<Root>" + "</Root>");
                XmlCDataSection section = doc.CreateCDataSection("Data");
                section.InnerText = Formula;
                doc.DocumentElement.AppendChild(section);
                doc.Save(filename);
                /*XmlElement element = doc.CreateElement("Function");
                XmlAttribute f = doc.CreateAttribute("Formula");
                f.Value = Formula;
                element.Attributes.Append(f);
                XmlNode nl = doc.DocumentElement;
                nl.AppendChild(element);
                if (doc != null)
                {
                    XmlWriter writer = new XmlTextWriter(filename, new System.Text.UTF8Encoding());
                    doc.WriteContentTo(writer);
                    writer.Flush();
                    writer.Close();
                }*/
            //doc.WriteTo(.WriteContentTo(.WriteTo(.WriteContentTo(

            BinaryFormatter formatter = new BinaryFormatter();
            string s = Formula;
            byte[] b = new byte[s.Length];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = (byte)s[i];
            }

            Stream stream = File.OpenWrite(filename);
            stream.Write(b, 0, b.Length);
            stream.Close();
        }

        #region Open Save event handlers

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Open();
        }

        #endregion


        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                MathFormula formula = panel.Performer.Formula;
                MathFormula f = formula.FullTransform(null);
                //new FormulaTree(f);
            }
            catch (System.Exception ex)
            {
                string err = ResourceService.Resources.GetControlResource("Error", DataPerformer.UI.Utils.ControlUtilites.Resources);
                /*
                if (resources != null)
                {
                    string rErr = resources.GetString("Error");
                    if (rErr != null)
                    {
                        err = rErr;
                    }
                }*/
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, ex.Message, err, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            accepted = true;
            Dispose();
        }

        private void paintDeriv()
        {
            Graphics g = Graphics.FromImage(derivImage);
            g.FillRectangle(fillBrush, derivRect.Left, derivRect.Top, derivRect.Width, derivRect.Height);
            if (derivFormula != null)
            {
                derivFormula.Draw(g);
            }
            g.DrawRectangle(rectPen, derivRect.Left, derivRect.Top, derivRect.Width - 1, derivRect.Height - 1);
        }


        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
           // try
           // {
            MathFormula f = new MathFormula(panel.Performer.Formula, UndrawableConverter.Object);
//                MathFormula f = MathFormula.FromString(panel.Performer.Formula.Sizes, fs);
                f = f.FullTransform(null);
                /*FormulaTree tree = new FormulaTree(f);
                FormulaTree der = tree.Deriv(textBoxDerivType.Text);
                der.SimplifyAll();
                derivFormula = der.GetFormula(0, FormulaEditorPanel.sizes);*/
                ObjectFormulaTree tree = ObjectFormulaTree.CreateTree(f, ElementaryFunctionsCreator.Object);
                ObjectFormulaTree der = tree.Derivation(textBoxDerivType.Text);
                //der = ElementaryFormulaSimplification.Object.Simplify(der);//der.SimplifyAll();
                MathFormula form = FormulaCreator.CreateFormula(der, (byte)0, MathSymbolFactory.Sizes);

                form.Simplify();

                derivFormula = new MathFormulaDrawable(form, DrawableConverter.Object);
                derivFormula.Position = pointDeriv;
                derivFormula.CalculateFullRelativeRectangle();
                derivFormula.CalculatePositions();
                paintDeriv();
                Refresh();
        /*    }
            catch (System.Exception ex)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, ex.Message);
            }*/

        }

        private void panelDeriv_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(derivImage, 0, 0, derivImage.Width, derivImage.Height);
        }

     }
}