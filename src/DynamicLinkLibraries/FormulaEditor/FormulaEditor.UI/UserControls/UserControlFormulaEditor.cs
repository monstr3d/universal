using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;


using FormulaEditor;
using FormulaEditor.Drawing.Interfaces;
using FormulaEditor.Drawing.Symbols;
using FormulaEditor.Drawing;
using FormulaEditor.Symbols;

using FormulaEditor.UI.Utils;

namespace FormulaEditor.UI.UserControls
{
    /// <summary>
    /// User control for formula editing
    /// </summary>
    public partial class UserControlFormulaEditor : UserControl
    {
        #region Fields

        private FormulaEditor.FormulaEditorPerformer performer = null;

        private int[] sizes;

        private int bottom;



        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlFormulaEditor()
        {
            InitializeComponent();
            this.LoadControlResources();
        }

        #endregion

 
        /// <summary>
        /// Prepares for polynom editing
        /// </summary>
        /// <param name="sizes">Sizes of symbols</param>
        /// <param name="arg">Argument of polynon</param>
        /// <param name="letters">Variable letters</param>
        public void PreparePoly(int[] sizes, char arg, string[] letters)
        {
            this.sizes = sizes;
            BeforePrepare();
            performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(arg)));
            for (int i = 0; i < letters.Length; i++)
            {
                string let = letters[i];
                for (int j = 0; j < let.Length; j++)
                {
                    performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(let[j])));
                }
            }

            string numbers = "0123456789";
            for (int i = 0; i < numbers.Length; i++)
            {
                performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(numbers[i], false, (byte)5)));
            }
            string binary = ".+-*";
            for (int i = 0; i < binary.Length; i++)
            {
                performer.Add(new BinarySymbolDrawable(new BinarySymbol(binary[i])));
            }

            performer.Add(new BracketsSymbolDrawable(new BracketsSymbol()));
            performer.Add(new AbsSymbolDrawable(new AbsSymbol()));
            performer.Add(new FractionSymbolDrawable(new FractionSymbol()));
            performer.Add(new BinarySymbolDrawable(MathSymbol.Bra as BinarySymbol));
            performer.Add(new SimpleSymbolDrawable(MathSymbol.Ket as SimpleSymbol));

            int y = 3;
            IDrawableSymbol symbol = null;
            int n = 0;
            Set(1, ref n, ref symbol, ref y);
            for (int i = 0; i < letters.Length; i++)
            {
                Set(letters[i].Length, ref n, ref symbol, ref y);
            }

            int[] np = new int[] { numbers.Length, binary.Length, 4 };
            for (int i = 0; i < np.Length; i++)
            {
                Set(np[i], ref n, ref symbol, ref y);
            }
            AfrerPrepare(y);
            Resize += OnResize;
        }

        /// <summary>
        /// Preparation
        /// </summary>
        /// <param name="sx">Variable symbols</param>
        /// <param name="n">Level</param>
        /// <param name="sSubscript">Subscripted symbols</param>
        /// <param name="symbols">Text symbols</param>
        public void Prepare(string sx, int n, string[,] sSubscript, string[] symbols)
        {
            int[] sizes = MathSymbolFactory.Sizes;
            this.sizes = sizes;
            BeforePrepare();
            string[] all = symbols;

            Hashtable table = new Hashtable();
            string[,] el = new string[,] {{"=", "="}, {"&", "AND"}, {"\u2216", "AND"}, {"\u2217", "OR"}, {"|", "OR"}, {"\u8835", "=>"}, {"l", "LIKE"}, {"p", "=>"}, 
                       {"¬", "NOT"}, {"(", "("}, {".", "."}, {":", ":"},{"?", "?"}, {"<", "<"}, {">", ">"}, {"+", "+"},
                {"-", "-"}, {"*", "*"}, {"=", "="}, {"/", "/" }, {"﹪", "%" }, {"A", "atan2"}, {"'", "d/dt"}};
            for (int i = 0; i < el.GetLength(0); i++)
            {
                table[el[i, 0]] = el[i, 1];
            }
            // MathFormula.Resources = table;


            int sub = (sSubscript == null) ? 0 : sSubscript.GetLength(0);
            //BinaryFunctionSymbolDrawable.Prepare(sizes, g);
            if (all != null)
            {
                foreach (string str in all)
                {
                    foreach (char c in str)
                    {
                        performer.Add(new SimpleSymbolDrawable(
                            new SimpleSymbol(c, 0x0, false, false)));
                    }
                }
            }

            string ss = sx;
            for (int i = 0; i < sub; i++)
            {
                performer.Add(new SubscriptedSymbolDrawable(new SubscriptedSymbol(sSubscript[i, 0], sSubscript[i, 1])));
            }
            for (int i = 0; i < ss.Length; i++)
            {
                performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(ss[i])));
            }
            string elem = "scletqabjkfgwo'\u2211\u03B4\u0442";
            for (int i = 0; i < elem.Length; i++)
            {
                performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(elem[i], false, (byte)4)));
            }
            string integerSym = "ABCDEFGHI";
            performer.Add(new BinaryFunctionSymbolDrawable(new BinaryFunctionSymbol('A', "atan2")));
            for (int i = 0; i < integerSym.Length; i++)
            {
                char c = integerSym[i];
                performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(c, (byte)4, false, ElementaryIntegerOperation.GetString(c))));
            }
            string numbers = "x0123456789ABCDEF";
            for (int i = 0; i < numbers.Length; i++)
            {
                performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(numbers[i], false, (byte)5)));
            }
            string binary = ".+-*×/﹪=><\u2264\u2265\u2260?:&|^\u2266\u2267\u2216\u2217\u8835l\u2270";
            //string[,] el = new string[,] {{"\u2216", "AND"}, {"\u2217", "OR"}};
            //string binary = ".+-*=><?:&|^\u2217l";
            for (int i = 0; i < binary.Length; i++)
            {
                performer.Add(new BinarySymbolDrawable(new BinarySymbol(binary[i])));
            }
            string unary = "¬~";
            for (int i = 0; i < unary.Length; i++)
            {
                performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(unary[i], false, (byte)4)));
            }
            performer.Add(new BracketsSymbolDrawable(new BracketsSymbol()));
            performer.Add(new AbsSymbolDrawable(new AbsSymbol()));
            performer.Add(new BinaryFunctionSymbolDrawable(new BinaryFunctionSymbol('2', "(,)")));
            performer.Add(new TernaryFunctionSymbolDrawable(new TernaryFunctionSymbol('3', "(,,)")));
            performer.Add(new RootSymbolDrawable(new RootSymbol()));
            performer.Add(new FractionSymbolDrawable(new FractionSymbol()));
            performer.Add(new BinarySymbolDrawable(MathSymbol.Bra as BinarySymbol));
            performer.Add(new SimpleSymbolDrawable(MathSymbol.Ket as SimpleSymbol));
            performer.Add(new SimpleSymbolDrawable(new SimpleSymbol('e')));
            performer.Add(new SimpleSymbolDrawable(new SimpleSymbol('%', (byte)FormulaConstants.Variable, true, "\u03c0")));
            performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(true)));
            performer.Add(new SimpleSymbolDrawable(new SimpleSymbol(false)));
            for (int i = 0; i < n; i++)
            {
                performer.Add(new SeriesSymbolDrawable(new SeriesSymbol(i)));
            }
            List<string> ls = StaticExtensionFormulaEditor.AdditionalFormulas;
            foreach (string str in ls)
            {
                performer.Add(new SimpleSymbolDrawable(new SimpleSymbol('@', 0x0, false, true, str)));
            }
            List<string> lp = StaticExtensionFormulaEditor.Properties;
            foreach (string str in lp)
            {
                performer.Add(new SimpleSymbolDrawable(new SimpleSymbol('.', 0x0, true, false, str)));
            }
            int x = 10, y = 10;
            int bottom = 0;
            IDrawableSymbol symbol = null;
            int ns = 0;
            if (all != null)
            {
                foreach (string str in all)
                {
                    foreach (char c in str)
                    {
                        symbol = performer[ns];
                        Point p = new Point(x, y);
                        MathSymbolDrawable.SetComponentPosition(symbol, p);
                        symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth, (int)(1.5 * 20));
                        x += symbol.PureDrawable.RectForShow.Width;
                        ++ns;
                    }
                    bottom = y + symbol.PureDrawable.RectForShow.Height;
                    y = bottom;
                    x = 10;
                }
            }

            if (sub != 0)
            {
                for (int i = ns; i < sub + ns; i++)
                {
                    symbol = performer[i];
                    Point p = new Point(x, y);
                    MathSymbolDrawable.SetComponentPosition(symbol, p);
                    symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth, (int)(1.5 * 20));
                    x += symbol.PureDrawable.RectForShow.Width;
                }
                bottom = y + symbol.PureDrawable.RectForShow.Height;
                y = bottom;
                x = 10;
            }
            for (int i = sub + ns; i < sub + ns + ss.Length; i++)
            {
                symbol = performer[i];
                Point p = new Point(x, y);
                MathSymbolDrawable.SetComponentPosition(symbol, p);
                symbol.PureDrawable.RectForShow = new Rectangle(x, y, 30, (int)(1.5 * 20));
                x += symbol.PureDrawable.RectForShow.Width;
            }
            bottom = y + symbol.PureDrawable.RectForShow.Height;
            y = bottom;
            x = 10;
            for (int i = ss.Length + ns + sub; i < ss.Length + elem.Length + 1 + sub + ns; i++)
            {
                symbol = performer[i];
                Point p = new Point(x, y);
                MathSymbolDrawable.SetComponentPosition(symbol, p);
                symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth + 10, (int)(1.5 * 20));
                x += symbol.PureDrawable.RectForShow.Width;
            }
            bottom = y + symbol.PureDrawable.RectForShow.Height;
            y = bottom;
            x = 10;

            for (int i = sub + ns + ss.Length + elem.Length + 1; i < sub + ns + ss.Length + elem.Length + integerSym.Length + 1; i++)
            {
                symbol = performer[i];
                Point p = new Point(x, y);
                MathSymbolDrawable.SetComponentPosition(symbol, p);
                symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth + 10, (int)(1.5 * 20));
                x += symbol.PureDrawable.RectForShow.Width;
            }

            bottom = y + symbol.PureDrawable.RectForShow.Height;
            y = bottom;
            x = 10;
            for (int i = sub + ns + ss.Length + elem.Length + integerSym.Length + 1;
                i < sub + ns + ss.Length + elem.Length + numbers.Length + integerSym.Length + 1; i++)
            {
                symbol = performer[i];
                Point p = new Point(x, y);
                MathSymbolDrawable.SetComponentPosition(symbol, p);
                symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth + 10, (int)(1.5 * 20));
                x += symbol.PureDrawable.RectForShow.Width;
            }
            bottom = y + symbol.PureDrawable.RectForShow.Height;
            y = bottom;
            x = 10;
            int k = sub + ns + ss.Length +
                elem.Length + numbers.Length + integerSym.Length + binary.Length + unary.Length + 13 + n;
            for (int i = sub + ns + ss.Length + elem.Length + integerSym.Length + numbers.Length + 1; i < k; i++)
            {
                symbol = performer[i];
                Point p = new Point(x, y);
                MathSymbolDrawable.SetComponentPosition(symbol, p);
                symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth + 10, (int)(1.5 * 20));
                x += symbol.PureDrawable.RectForShow.Width;
            }
            bottom = y + symbol.PureDrawable.RectForShow.Height;
            x = 10;
            y = bottom;
            if (ls.Count > 0)
            {
                for (int i = k; i < k + ls.Count; i++)
                {
                    symbol = performer[i];
                    Point p = new Point(x, y);
                    MathSymbolDrawable.SetComponentPosition(symbol, p);
                    symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth + 10, (int)(1.5 * 20));
                    x += symbol.PureDrawable.RectForShow.Width;
                }
                bottom = y + symbol.PureDrawable.RectForShow.Height;
            }
            k += ls.Count;
            x = 10;
            bottom = y + symbol.PureDrawable.RectForShow.Height;
            y = bottom;
            if (lp.Count > 0)
            {
                for (int i = k; i < k + lp.Count; i++)
                {
                    symbol = performer[i];
                    Point p = new Point(x, y);
                    MathSymbolDrawable.SetComponentPosition(symbol, p);
                    symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth + 10, (int)(1.5 * 20));
                    x += symbol.PureDrawable.RectForShow.Width;
                }
                bottom = y + symbol.PureDrawable.RectForShow.Height;
            }
            AfrerPrepare(bottom);
            Resize += OnResize;
        }

        /// <summary>
        /// Default preparation
        /// </summary>
        public void Prepare()
        {
            Prepare("abcdfgxyzt", 4, null, null);
        }



        private void BeforePrepare()
        {
            Control control = panelFormula;
            performer = new FormulaEditor.FormulaEditorPerformer(panelFormula, null);

            Hashtable table = new Hashtable();
            string[,] el = new string[,] {{"=", "="}, {"&", "AND"}, {"\u2216", "AND"}, {"\u2217", "OR"}, {"|", "OR"}, {"\u8835", "=>"}, {"l", "LIKE"}, {"p", "=>"}, 
                       {"¬", "NOT"}, {"(", "("}, {".", "."}, {":", ":"},{"?", "?"}, {"<", "<"}, {">", ">"}, {"+", "+"},
                {"-", "-"}, {"*", "*"}, {"=", "="}, {"/", "/" }, { "﹪", "%" }, {"A", "atan2"}, {"'", "d/dt"}};
            for (int i = 0; i < el.GetLength(0); i++)
            {
                table[el[i, 0]] = el[i, 1];
            }
            MathFormulaDrawable formula = new MathFormulaDrawable(new MathFormula((byte)0, sizes), DrawableConverter.Object);
            Color[] cols = new Color[] { Color.FromArgb(216, 203, 187), Color.Black };
            performer.SetColors(cols[0], cols[1]);
            Graphics g = Graphics.FromHwnd(control.Handle);
            SimpleSymbolDrawable.Prepare(sizes, g);
            BracketsSymbolDrawable.Prepare(sizes, g);
            AbsSymbolDrawable.Prepare(sizes, g);
        }

        private void AfrerPrepare(int bottom)
        {
            this.bottom = bottom;
            Control control = panelFormula;
            Rectangle r = new Rectangle(40, bottom + 3, control.Width - 45, control.Height - bottom - 6);
            performer.FormulaRectangle = r;
            Image back = new Bitmap(control.Width, control.Height);

            Graphics g = Graphics.FromImage(back);
            g.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, back.Width, back.Height);
            g.DrawRectangle(new Pen(Color.Black), 0, 0, back.Width - 1, back.Height - 1);
            Font f = new Font("Serif", sizes[0], FontStyle.Bold | FontStyle.Italic);
            int delta = 15;
            Brush bBrush = new SolidBrush(Color.Black);
            g.DrawString("f = ", f, bBrush, 10, r.Y + r.Height / 2 + delta);
            g.Dispose();
            performer.Prepare(back);
            MathFormulaDrawable formula = new MathFormulaDrawable(new MathFormula((byte)0, sizes), DrawableConverter.Object);
            performer.Formula = formula;
            performer.InitEventHandlers();
            performer.DrawFormula();
        }



        /// <summary>
        /// String representation of formula
        /// </summary>
        public string Formula
        {
            get
            {
                if (performer != null)
                {
                    return performer.FormulaString;
                }
                return "";
            }
            set
            {
                if (performer == null)
                {
                    return;
                }
                performer.SetFormula(value, sizes);
                performer.DrawFormula();
            }
        }

        private void loadXml(string filename)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
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
            catch (System.Exception ex)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(this, ex.Message);
            }
        }
        private void saveXml(string filename)
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

            /*  System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
              formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
              string s = Formula;
              byte[] b = new byte[s.Length];
              for (int i = 0; i < b.Length; i++)
              {
                  b[i] = (byte)s[i];
              }

              Stream stream = File.OpenWrite(filename);
              stream.Write(b, 0, b.Length);
              stream.Close();*/
            try
            {
                XmlDocument doc = new XmlDocument();
                /*doc.LoadXml("<?xml version=\"1.0\"?>" + "<Root>" + "</Root>");
                XmlElement element = doc.CreateElement("Function");
                doc.DocumentElement.AppendChild(element);
                XmlAttribute f = doc.CreateAttribute("Formula");
                f.Value = Formula;
                element.Attributes.Append(f);*/
                doc.LoadXml(Formula);
                doc.Save(filename);
            }
            catch (Exception e)
            {
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(e.Message);
            }
        }

        private void Set(int n, ref int k, ref IDrawableSymbol symbol, ref int y)
        {
            int x = 0;
            for (int i = k; i < k + n; i++)
            {
                symbol = performer[i];
                Point p = new Point(x, y);
                MathSymbolDrawable.SetComponentPosition(symbol, p);
                symbol.PureDrawable.RectForShow = new Rectangle(x, y, symbol.StandardWidth, (int)(1.5 * 20));
                x += symbol.PureDrawable.RectForShow.Width;
            }
            y += symbol.PureDrawable.RectForShow.Height;
            k += n;
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialogFormula.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            loadXml(openFileDialogFormula.FileName);
            panelFormula.Refresh();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialogFormula.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            saveXml(saveFileDialogFormula.FileName);
        }

        private void OnResize(object sender, EventArgs e)
        {
            Control control = panelFormula;
            Rectangle r = new Rectangle(40, bottom + 3, control.Width - 45, control.Height - bottom - 6);
            performer.FormulaRectangle = r;
            Image back = new Bitmap(control.Width, control.Height);

            Graphics g = Graphics.FromImage(back);
            g.FillRectangle(new SolidBrush(Color.LightGray), 0, 0, back.Width, back.Height);
            g.DrawRectangle(new Pen(Color.Black), 0, 0, back.Width - 1, back.Height - 1);
            Font f = new Font("Serif", sizes[0], FontStyle.Bold | FontStyle.Italic);
            int delta = 15;
            Brush bBrush = new SolidBrush(Color.Black);
            g.DrawString("f = ", f, bBrush, 10, r.Y + r.Height / 2 + delta);
            g.Dispose();
            performer.Prepare(back);
 
        }

    }
}
