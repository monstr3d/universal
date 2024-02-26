using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Linq;

using FormulaEditor;
using FormulaEditor.Interfaces;

namespace FormulaEditor.Symbols
{
    /// <summary>
    /// The symbol of formula
    /// </summary>
    public abstract class MathSymbol : Interfaces.ICloneable
    {
        #region Fields
        /// <summary>
        /// The decimal separator
        /// </summary>
        static public readonly string DecimalSep =
            System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;


        /// <summary>
        /// Hex symbols
        /// </summary>
        private const string hex = "0123456789ABCDEF";

        /// <summary>
        /// Symbols of elementary functions
        /// </summary>
        public const string FUNCTIONS = "scletqabjkfg";

        /// <summary>
        /// The char of the symbol
        /// </summary>
        protected char symbol;

        /// <summary>
        /// The index of the symbol
        /// </summary>
        protected int index;

        /// <summary>
        /// The level of the symbol
        /// </summary>
        protected byte level = 0;

        /// <summary>
        /// The type of the symbol
        /// </summary>
        protected byte type;

        /// <summary>
        /// Clild formulas
        /// </summary>
        protected List<MathFormula> children = new List<MathFormula>();

        /// <summary>
        /// The value of the symbol
        /// </summary>
        protected double doubleValue;

        /// <summary>
        /// The ulong value of the symbol
        /// </summary>
        protected ulong ulongValue;

        /// <summary>
        /// Boolean value
        /// </summary>
        protected bool boolValue = false;

        /// <summary>
        /// Sizes of formula sybmols
        /// </summary>
        protected int[] sizes;

        /// <summary>
        /// String representation of symbol
        /// </summary>
        protected string s;


        /// <summary>
        /// The parent formula
        /// </summary>
        protected MathFormula parent = null;


        /// <summary>
        /// auxiliary variables
        /// </summary>
        private MathSymbol sym, sym1;

        #endregion

        #region ICloneabe Members

        /// <summary>
        /// The Interfaces.ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public abstract object Clone();


        #endregion
 
        #region Members


        /// <summary>
        /// Creates attributes for Xml element
        /// </summary>
        /// <param name="doc">The element document</param>
        /// <param name="e">The element</param>
        public virtual void CreateAttributes(XElement e)
        {
            e.SetAttributeValue("type", this.GetType().FullName);
            e.SetAttributeValue("symbol", symbol + "");
            e.SetAttributeValue("S", s);
            e.SetAttributeValue("Type", (int)type + "");
            e.SetAttributeValue("Index", index + "");
            e.SetAttributeValue("Level", (int)level + "");
            string c = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string d = doubleValue + "";
            e.SetAttributeValue("DoubleValue", d + "");
            e.SetAttributeValue("UlongValue", ulongValue + "");
            e.SetAttributeValue("type", this.GetType().FullName);
            e.SetAttributeValue("type", this.GetType().FullName);
            /*
           XmlAttribute attr = doc.CreateAttribute("type");
           attr.Value = GetType().FullName;
  "         e.Attributes.Append(attr);
           attr = doc.CreateAttribute("symbol");
           attr.Value = symbol + "";
           e.Attributes.Append(attr);
           attr = doc.CreateAttribute("S");
           attr.Value = s;
           e.Attributes.Append(attr);
           attr = doc.CreateAttribute("Type");
           attr.Value = (int)type + "";
           e.Attributes.Append(attr);
           attr = doc.CreateAttribute("Index");
           attr.Value = index + "";
           e.Attributes.Append(attr);
           attr = doc.CreateAttribute("Level");
           attr.Value = (int)level + "";
           e.Attributes.Append(attr);
           string c = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
           string d = doubleValue + "";
           d = d.Replace(c, ".");
           attr = doc.CreateAttribute("DoubleValue");
           attr.Value = level + "";
           e.Attributes.Append(attr);
           attr = doc.CreateAttribute("UlongValue");
           attr.Value = ulongValue + "";
           e.Attributes.Append(attr);*/
            e.SetAttributeValue("BoolValue", boolValue + "");
        }


        /// <summary>
        /// Loads attributes from Xml element
        /// </summary>
        /// <param name="e">The element</param>
        public virtual void LoadAttributes(XElement e)
        {
            symbol = e.GetAttribute("symbol")[0];
            s = e.GetAttribute("S");
            type = (byte)Int32.Parse(e.GetAttribute("Type"));
            index = Int32.Parse(e.GetAttribute("Index"));
            level = (byte)Int32.Parse(e.GetAttribute("Level"));
            string c = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string d = e.GetAttribute("DoubleValue");
            d = d.Replace(".", c);
            doubleValue = Double.Parse(d);
            ulongValue = UInt64.Parse(e.GetAttribute("UlongValue"));
            string str = e.GetAttribute("BoolValue");
            if (str.ToLower().Contains("true"))
            {
                boolValue = true;
            }
        }

        /// <summary>
        /// Sets level of symbol
        /// </summary>
        /// <param name="level">The level</param>
        public virtual void SetLevel(byte level)
        {
            this.level = level;
        }

        /// <summary>
        /// Sets same level to symbol
        /// </summary>
        /// <param name="level">The level</param>
        public void SetSameLevel(byte level)
        {
            this.level = level;
            foreach (MathFormula f in children)
            {
                f.SetLevel(level);
            }
        }


        /// <summary>
        /// Sets degree level
        /// </summary>
        /// <param name="level">The level</param>
        public void SetDegreeLevel(byte level)
        {
            this.level = level;
            if (Count > 0)
            {
                this[0].SetLevel((byte)(level + 1));
            }
        }


        /// <summary>
        /// Post serialization method
        /// </summary>
        public virtual void Post()
        {
            if (children == null)
            {
                return;
            }
            foreach (MathFormula f in children)
            {
                f.Post();
            }
        }

        /// <summary>
        /// Creates Element from symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="document">The doucument</param>
        /// <param name="creator">Creator</param>
        /// <returns>The element</returns>
        public static XElement CreateElement(MathSymbol symbol,
                   IXmlSymbolCreator creator)
        {
            XElement e = creator.CreateElement(symbol);
            for (int i = 0; i < symbol.Count; i++)
            {
                XElement el = MathFormula.CreateElement(symbol[i], creator);
                e.Add(el);
            }
            return e;
        }

        /// <summary>
        /// Craeates symbol from Xml element
        /// </summary>
        /// <param name="e">The element</param>
        /// <param name="creator">The creator</param>
        /// <returns>The symbol</returns>
        public static MathSymbol CreateSymbol(XElement e, IXmlSymbolCreator creator)
        {
            MathSymbol s = creator.CreateSymbol(e);
            IEnumerable<XElement> l = e.GetElementsByTagName("F");
            List<MathFormula> list = new List<MathFormula>();
            foreach (XElement el in l)
            {
                if (el.Parent != e)
                {
                    continue;
                }
                MathFormula f = MathFormula.CreateFormula(el, creator);
                list.Add(f);
            }
            s.Children = list;
            return s;
        }


        /// <summary>
        /// The bra symbol
        /// </summary>
        static public MathSymbol Bra
        {
            get
            {
                MathSymbol s = new BinarySymbol('(');
                s.type = (byte)FormulaConstants.Service;
                return s;
            }
        }

        /// <summary>
        /// The ket symbol
        /// </summary>
        static public MathSymbol Ket
        {
            get
            {
                MathSymbol s = new SimpleSymbol(')', false, (byte)FormulaConstants.Unary);
                return s;
            }
        }

        /// <summary>
        /// String representation
        /// </summary>
        public string String
        {
            get
            {
                return s;
            }
        }


        /// <summary>
        /// The index of symbol
        /// </summary>
        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }

        /// <summary>
        /// The level of symbol
        /// </summary>
        public byte Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        /// <summary>
        /// Checks whether the symbol is same
        /// </summary>
        /// <param name="sym">Symbol</param>
        /// <returns>True if same and false otherwise</returns>
        public virtual bool IsSame(MathSymbol sym)
        {
            return false;
        }

        /// <summary>
        /// The char representation of symbol
        /// </summary>
        public char Symbol
        {
            get
            {
                return symbol;
            }
            set
            {
                symbol = value;
            }
        }


        /// <summary>
        /// The n th child formula
        /// </summary>
        public MathFormula this[int n]
        {
            get
            {
                return children[n];
            }
            set
            {
                children[n] = value;
            }
        }


        /// <summary>
        /// The next symbol
        /// </summary>
        public object NextObject
        {
            get
            {
                int i = Parent.IndexOf(this);
                if (i >= (Parent.Count - 1))
                {
                    return parent;
                }
                return parent[i + 1];
            }
        }

        /// <summary>
        /// Inserts symbol
        /// </summary>
        /// <param name="formula">The formula to insert</param>
        /// <param name="previosSymbol">The previos symbol</param>
        /// <returns>Inserted object</returns>
        public object InsertBefore(MathFormula formula, MathSymbol previosSymbol)
        {
            try
            {
                MathSymbol symbol = (MathSymbol)Clone();
                symbol.SetToFormula(formula);
                int n = formula.IndexOf(previosSymbol);
                formula.Insert(n, symbol);
                symbol.parent = formula;
                if (symbol is BracketsSymbol)
                {
                    return symbol[0];
                }
                return symbol.NextObject;
            }
            finally
            {
            }
        }

        /// <summary>
        /// Appends the symbol to formula
        /// </summary>
        /// <param name="formula">Formula the formula to append</param>
        /// <returns>Next inserted object</returns>
        public MathFormula Append(MathFormula formula)
        {
            try
            {
                MathSymbol symbol = (MathSymbol)Clone();
                symbol.SetToFormula(formula);
                formula.Add(symbol);
                symbol.parent = formula;
            }
            finally
            {
            }
            return formula;
        }

        /// <summary>
        /// Sizes of symbols
        /// </summary>
        public int[] Sizes
        {
            get
            {
                return sizes;
            }
            set
            {
                sizes = value;
            }
        }

        /// <summary>
        /// Appends this symbol with children
        /// </summary>
        /// <param name="formula">Formula to append</param>
        public void AppendWithChildren(MathFormula formula)
        {
            formula.Add(this);
            parent = formula;
        }



        /// <summary>
        /// Count of children
        /// </summary>
        public int Count
        {
            get
            {
                if (children == null)
                {
                    return 0;
                }
                return children.Count;
            }
        }

        /// <summary>
        /// Appends new symbol to this object
        /// </summary>
        /// <param name="symbol">the symbol to append</param>
        public void Append(MathSymbol symbol)
        {
            MathSymbol s = Next;
            if (s != null)
            {
                s.Insert(symbol);
                return;
            }
            parent.InsertObject(symbol);
        }

        /// <summary>
        /// Inserts symbol before this object
        /// </summary>
        /// <param name="symbol">the symbol to insert</param>
        public void Insert(MathSymbol symbol)
        {
            InsertObject(this, symbol);
        }

        /// <summary>
        /// Wraps this symbol by brackets
        /// </summary>
        /// <returns>Next symbol</returns>
        public MathSymbol Wrap(string prohibited)
        {
            sym = Next;
            if (ShouldWrapped)
            {
                Insert(Bra);
                Append(Ket);
            }
            if (HasChildren)
            {
                for (int i = 0; i < Count; i++)
                {
                    this[i].Wrap(prohibited);
                }
            }
            return sym;
        }


        /// <summary>
        /// Finds the next symbol in the formula
        /// </summary>
        public MathSymbol Next
        {
            get
            {
                int i = parent.IndexOf(this);
                if (i < parent.Count - 1)
                {
                    return parent[i + 1];
                }
                return null;
            }
        }


        /// <summary>
        /// Replaces this symbol
        /// </summary>
        /// <param name="s">the symbol to replace</param>
        public void Replace(MathSymbol s)
        {
            Append(s);
            Remove();
        }






        /// <summary>
        /// Converts this symbol to array
        /// </summary>
        /// <returns>The array</returns>
        public List<byte[]> ToArray()
        {
            List<byte[]> v = new List<byte[]>();
            if (type == (int)FormulaConstants.Series)
            {
                string s = Index + "";
                v.Add(new byte[] { (byte)s[0] });
            }
            else
            {
                v.Add(new byte[] { (byte)symbol });
            }
            Int32 t = type;
            byte b = (byte)(t.ToString()[0]);
            v.Add(new byte[] { b });
            if (Count > 0)
            {
                for (int i = 0; i < Count; i++)
                {
                    List<byte[]> vec = this[i].ToArray();
                    MathSymbolFactory.AddByte(v, MathSymbolFactory.BEGIN_SEPARATOR);
                    for (int j = 0; j < vec.Count; j++)
                    {
                        v.Add(vec[j]);
                    }
                    MathSymbolFactory.AddByte(v, MathSymbolFactory.END_SEPARATOR);
                }
            }
            return v;
        }

        /// <summary>
        /// Removes this symbol from formula
        /// </summary>
        public void Remove()
        {
            parent.Remove(this);
        }


        /// <summary>
        /// Checks whether this symbol has children
        /// </summary>
        public bool HasChildren
        {
            get
            {
                if (children != null)
                {
                    if (Count != 0)
                    {
                        return !this[0].IsEmpty;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// The type of the synbol
        /// </summary>
        public byte SymbolType
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// Double value of the symbol
        /// </summary>
        public double DoubleValue
        {
            get
            {
                return doubleValue;
            }
            set
            {
                doubleValue = value;
            }
        }

        /// <summary>
        /// Boolean value of the symbol
        /// </summary>
        public bool BoolValue
        {
            get
            {
                return boolValue;
            }
            set
            {
                boolValue = value;
            }
        }

        /// <summary>
        /// ULong value of symbol
        /// </summary>
        public ulong ULongValue
        {
            get
            {
                return ulongValue;
            }
        }

        /// <summary>
        /// Makes copy of the symbol
        /// </summary>
        /// <returns>the copy</returns>
        public MathSymbol Copy()
        {
            try
            {
                sym = Clone() as MathSymbol;
                if (children != null)
                {
                    sym.children = new List<MathFormula>();
                    for (int i = 0; i < Count; i++)
                    {
                        if (this[i] != null)
                        {
                            sym.children.Add(this[i].Copy());
                        }
                    }
                }
                sym.doubleValue = doubleValue;
                return sym;
            }
            finally
            {
            }
        }

        /// <summary>
        /// Sets this symbol to formula
        /// </summary>
        /// <param name="formula">The formula to set</param>
        public virtual void SetToFormula(MathFormula formula)
        {
            SetToFormulaBase(formula);
        }


        /// <summary>
        /// Base function to setting this symbol to formula
        /// </summary>
        /// <param name="formula">The formula to set</param>
        public virtual void SetToFormulaBase(MathFormula formula)
        {
            level = formula.Level;
            sizes = MathSymbolFactory.Sizes;
            parent = formula;
        }

        /// <summary>
        /// Transformation of string representation of double values
        /// </summary>
        /// <returns>the transformation result</returns>
        public MathSymbol TranNumber()
        {
            string str = "";
            sym = Next;
            if (type != (byte)FormulaConstants.Number)
            {
                if (symbol != '.' | !s.Equals("."))
                {
                    return sym;
                }
            }
            str += symbol;
            if (HasChildren)
            {
                if (str.Length > 2)
                {
                    if (str[1] == 'x')
                    {
                        ulong a = Hex(str);
                        ulong b = a >> 32;
                        if (b == 0)
                        {
                            doubleValue = a;
                            symbol = '?';
                            return sym;
                        }
                        ulongValue = a;
                        symbol = '$';
                        return sym;
                    }
                }
                if (!MathFormula.Resources.ContainsKey("."))
                {
                    str = str.Replace('.', DecimalSep[0]);
                }
                if (double.TryParse(str, out doubleValue))
                {
                    symbol = '?';
                }
                return sym;
            }
            MathFormula f = new MathFormula((byte)0);
            while (true)
            {
                try
                {
                    if (sym == null)
                    {
                        if (str.Length > 2)
                        {
                            if (str[1] == 'x')
                            {
                                ulong a = Hex(str);
                                ulong b = a >> 32;
                                if (b == 0)
                                {
                                    doubleValue = a;
                                    symbol = '?';
                                    return sym;
                                }
                                ulongValue = a;
                                symbol = '$';
                                return sym;
                            }
                        }

                        str = str.Replace('.', DecimalSep[0]);
                        if (double.TryParse(str, out doubleValue))
                        {
                            symbol = '?';
                        }
                        return sym;
                    }
                    if ((sym.type != (byte)FormulaConstants.Number) & (sym.symbol != '.'))
                    {
                        if (str.Length > 2)
                        {
                            if ((str[1] == 'x'))
                            {
                                ulong a = Hex(str);
                                ulong b = a >> 32;
                                if (b == 0)
                                {
                                    doubleValue = a;
                                    symbol = '?';
                                    return sym;
                                }
                                ulongValue = a;
                                symbol = '$';
                                return sym;
                            }
                        }
                        str = str.Replace('.', DecimalSep[0]);
                        doubleValue = Double.Parse(str);
                        symbol = '?';
                        return sym;
                    }
                    if (sym.HasChildren)
                    {
                        children[0] = sym.children[0];
                        str = str.Replace('.', DecimalSep[0]);
                        doubleValue = Double.Parse(str);
                        sym.Remove();
                        return Next;
                    }
                    else
                    {
                        str += sym.symbol;
                        if (str.Equals(".."))
                        {
                            return sym;
                        }
                        sym1 = sym.Next;
                        sym.Remove();
                        sym = sym1;
                    }
                }
                finally
                {
                    //throw new Exception(ERRORS[4] + ex.getMessage());
                }
            }
        }

        /// <summary>
        /// Hexagonal value of symbol
        /// </summary>
        /// <param name="c">The symbol</param>
        /// <returns>The hexagonal value</returns>
        public static ulong Hex(char c)
        {
            return (ulong)hex.IndexOf(c);
        }

        /// <summary>
        /// Hexagonal value of string
        /// </summary>
        /// <param name="s">The string</param>
        /// <returns>The value</returns>
        public static ulong Hex(string s)
        {
            ulong a = 0;
            for (int i = 2; i < s.Length; i++)
            {
                ulong j = Hex(s[i]);
                a = a << 4;
                a |= j;
            }
            return a;
        }

        /// <summary>
        /// Hex string representation
        /// </summary>
        /// <param name="a">The value</param>
        /// <returns>The representation</returns>
        public static string Hex(ulong a)
        {
            string s = "";
            ulong b = a;
            if (a == 0)
            {
                return "0x0";
            }
            for (int i = 0; i < 16; i++)
            {
                if (b == 0)
                {
                    break;
                }
                int c = (int)(b & 0xF);
                s = hex[c] + s;
                b = b >> 4;
            }
            return "0x" + s;
        }

        /// <summary>
        /// Translates byte to hex
        /// </summary>
        /// <param name="b">The byte</param>
        /// <returns>Hex representation</returns>
        public static string Hex(byte b)
        {
            int c1 = (int)(b & 0xF);
            int c2 = (int)((b >> 4) & 0xF);
            return "" + hex[c2] + hex[c1];
        }

        /// <summary>
        /// Insetrs symbol before this symbol
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="inserted">Inserted symbol</param>
        /// <returns>The inserted object</returns>
        public static object InsertObject(MathSymbol symbol, MathSymbol inserted)
        {
            return inserted.InsertBefore(symbol.Parent, symbol);
        }


        /// <summary>
        /// Checks whether symbol should by wrapped by brackets
        /// </summary>
        public bool ShouldWrapped
        {
            get
            {
                if ((type == (byte)FormulaConstants.Number | type == (byte)FormulaConstants.Special
                     | type == (byte)FormulaConstants.Variable) & (symbol != '('
                    & symbol != '('))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Resets auxiliary variables
        /// </summary>
        public void Zero()
        {
            sym = null;
            sym1 = null;
        }

        /// <summary>
        /// Checks whether children contains the symbol
        /// </summary>
        /// <param name="s">the symbol</param>
        /// <returns>the result of checking</returns>
        public bool Contains(MathSymbol s)
        {
            if (s == this)
            {
                return true;
            }
            if (HasChildren)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (this[i].Contains(s))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Checks whether children contains the formula
        /// </summary>
        /// <param name="f">the formula</param>
        /// <returns>the result of checking</returns>
        public bool Contains(MathFormula f)
        {
            if (!f.IsEmpty)
            {
                return Contains(f.First);
            }
            return false;
        }

        /// <summary>
        /// Checks whether children contains the inserted object
        /// </summary>
        /// <param name="o">the inserted object</param>
        /// <returns>the result of checking</returns>
        public bool Contains(object o)
        {
            if (o == null)
            {
                return false;
            }
            if (o is MathSymbol)
            {
                return Contains((MathSymbol)o);
            }
            else
            {
                return Contains((MathFormula)o);
            }
        }

        /// <summary>
        /// Child formulas
        /// </summary>
        public List<MathFormula> Children
        {
            set
            {
                children = value;
            }
            get
            {
                return children;
            }
        }

        /// <summary>
        /// The parent formula
        /// </summary>
        public MathFormula Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol">the symbol char</param>
        /// <param name="index">the symbol index</param>
        protected MathSymbol(char symbol, int index)
        {
            this.symbol = symbol;
            this.index = index;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected MathSymbol()
        {
        }

        #endregion


    }
}
