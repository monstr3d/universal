using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml.Linq;
using System.IO;

using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;
using ErrorHandler;

namespace FormulaEditor
{
    /// <summary>
    /// Math formula
    /// </summary>
    public class MathFormula : Interfaces.ICloneable
    {

        #region Fields
        /// <summary>
        /// Epsilon to round numbers
        /// </summary>
        private const double ROUND_EPS = 0.0000000001;


        /// <summary>
        /// Separator
        /// </summary>
        static private readonly char[] byteSep = ";".ToCharArray();


        /// <summary>
        /// The vector of formula symbols
        /// </summary>
        protected List<MathSymbol> symbols = new List<MathSymbol>();


        /// <summary>
        /// Temporary list of math symbol for serialization
        /// </summary>
        protected List<MathSymbol> temp = null;

        /// <summary>
        /// The sizes of symbols
        /// </summary>
        protected int[] sizes;

        /// <summary>
        /// The formula level. Main formula has level = 0. 
        /// Its pow has level 1, etc.
        /// </summary>
        protected byte level;

        /// <summary>
        /// Auxiliary variable
        /// </summary>
        protected MathFormula form;

        /// <summary>
        /// Auxiliary variables
        /// </summary>
        private MathSymbol s, s1;


        /// <summary>
        /// Formula resources
        /// </summary>
        protected static Dictionary<string, string> resources;

        /// <summary>
        /// Formula resources
        /// </summary>
        protected static Dictionary<string, string> errorResources;

        private static IFormulaSaver saver = StandardSaverSeparate.Saver;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="level">the level of formula</param>
        public MathFormula(byte level)
        {
            this.level = level;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="level">the level of formula</param>
        /// <param name="sizes">the symbols sizes</param>
        public MathFormula(byte level, int[] sizes)
            : this(level)
        {
            this.sizes = sizes;
        }

        /// <summary>
        /// Constructor that creates formula from string vector
        /// </summary>
        /// <param name="level"> the level of formula</param>
        /// <param name="sizes">the symbols sizes</param>
        /// <param name="v">the string vector</param>
        /// <param name="b">the formula string begin</param>
        /// <param name="e">the formula string end</param>
        public MathFormula(byte level, int[] sizes, List<byte[]> v, int b, int e)
            :
            this(level, sizes)
        {
            if (b >= e)
            {
                return;
            }
            for (int i = b; i < e; )
            {
                int j = MathSymbolFactory.Next(v, i);
                int k = (j == -1) ? e - 1 : j - 1;
                MathSymbol sym = MathSymbolFactory.CreateSymbol(this, v, i, k);
                if (j == -1)
                {
                    return;
                }
                i = j;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="level">Level of formula</param>
        /// <param name="sizes">Sizes</param>
        /// <param name="str">String representation of formula</param>
        /// <param name="b">Begin</param>
        /// <param name="e">End</param>
        /// <param name="converter">Converter</param>
        public MathFormula(byte level, int[] sizes, string str, int b, int e,
            MathFormulaStringConverter converter)
            :
            this(level, sizes)
        {
            if (b >= e)
            {
                return;
            }
            for (int i = b; i < e; )
            {
                int j = converter.Next(str, i);
                int k = (j == -1) ? e - 2 : j - 1;
                if (i == k)
                {
                    return;
                }
                MathSymbol sym = converter.CreateSymbol(this, str, i, k);
                if (j == -1)
                {
                    return;
                }
                i = j;
            }
        }

        /// <summary>
        /// Constructor from prototype
        /// </summary>
        /// <param name="formula">Prototype</param>
        /// <param name="converter">Symbol converter</param>
        public MathFormula(MathFormula formula, IMathSymbolConverter converter)
            : this(formula.Level, formula.Sizes)
        {
            for (int i = 0; i < formula.Count; i++)
            {
                MathSymbol s = formula[i];
                MathSymbol sym = converter.Convert(s);
                sym.Append(this);
                sym = Last;
                for (int j = 0; j < s.Count; j++)
                {
                    if (s[j] != null)
                    {
                        sym[j] = new MathFormula(s[j], converter);
                    }
                }
            }
        }

        /// <summary>
        /// Constructor from prototype
        /// </summary>
        /// <param name="formula">Prototype</param>
        public MathFormula(MathFormula formula) :
            this(formula, Converter.Singleton)
        {

        }




        #endregion

        #region Members

        /// <summary>
        /// Saver of formula
        /// </summary>
        static public IFormulaSaver Saver
        {
            get
            {
                return saver;
            }
            set
            {
                saver = value;
            }
        }


        /// <summary>
        /// Post serialization method
        /// </summary>
        public virtual void Post()
        {
            foreach (MathSymbol symbol in temp)
            {
                symbol.Post();
                symbol.AppendWithChildren(this);
            }
            temp = null;
        }


        /// <summary>
        /// Formula resources
        /// </summary>
        public static Dictionary<string, string> Resources
        {
            get
            {
                return resources;
            }
            set
            {
                resources = value;
            }
        }


        /// <summary>
        /// Formula error resources
        /// </summary>
        public static Dictionary<string, string> ErrorResources
        {
            get
            {
                return errorResources;
            }
            set
            {
                errorResources = value;
            }
        }

        /// <summary>
        /// Throws exception with message
        /// </summary>
        /// <param name="s">The message</param>
        public static void ThrowErrorException(string s)
        {
            string str = s;
            /*
			if (errorResources != null)
			{
                str = errorResources.GetString(str);
                if (errorURLResources != null)
                {
                    //string hs = errorURLResources.GetString(s);
                    Exce        ption e = new Except               ion(str);
                    //e.HelpLink = hs;
                    throw e;
                }
            }*/
            string h = null;
            try
            {
                h = errorResources[str] as string;
            }
            catch (Exception)
            {
            }
            //throw new FormulaException(str, h);
        }




        /// <summary>
        /// Creates formula from string
        /// </summary>
        /// <param name="sizes">The sizes</param>
        /// <param name="str">The string</param>
        /// <returns>The formula</returns>
        public static MathFormula FromString(int[] sizes, string str)
        {
            MathFormula f = saver.Load(str);
            f.Sizes = sizes;
            return f;
            
  /*          try
            {
                //string[] s = str.Split(byteSep);
                byte[] b = new byte[str.Length];
                for (int i = 0; i < b.Length; i++)
                {
                    b[i] = (byte)(str[i]);
                }
                System.IO.MemoryStream stream = new System.IO.MemoryStream(b);
                MathFormula form = formatter.Deserialize(stream) as MathFormula;
                form.Post();
                form.Sizes = sizes;
                return form;
            }
            catch (Exception eee)
            {
                string sm = eee.StackTrace;
                sm = null;
            }
            try
            {
                f = new MathFormula(0, sizes, str, 0, str.Length,
                    ElementaryFormulaStringConverter.Object);
                new ObjectFormulaTree(f.FullTransform(null));
                return f;
            }
            catch (Exception)
            {
               /* ArrayList list = new ArrayList();
                for (int i = 0; i < str.Length; i++)
                {
                    char c = str[i];
                    byte[] b = new byte[] { (byte)c };
                    list.Add(b);
                }
                try
                {
                    MathFormula fo = new MathFormula(0, sizes, list, 0, str.Length);
                    //new ObjectFormulaTree(fo.FullTransform);
                    return fo;
                }
                catch (Exception)
                {
                }
            }
            return f;
   */
        }

        /// <summary>
        /// Constructor of subformula 
        /// </summary>
        /// <param name="form">the initial formula</param>
        /// <param name="n1">the index of start symbol</param>
        /// <param name="n2">the index of finish symbol</param>
        public MathFormula(MathFormula form, int n1, int n2)
            : this(form.level, form.sizes)
        {
            for (int i = n1; i <= n2; i++)
            {
                Add(form[i]);
            }
        }

        /// <summary>
        /// sizes of formula symbols
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
        /// Saves intself to stream
        /// </summary>
        /// <param name="stream">The Steam</param>
        public void Save(System.IO.Stream stream)
        {
            string s = saver.Save(this);
            StreamWriter wr = new StreamWriter(stream);
            wr.Write(s);
            wr.Flush();
        }

        /// <summary>
        /// Saves itself to stream
        /// </summary>
        /// <param name="filename"></param>
    /*    public void Save(string filename)
        {
            System.IO.Stream stream = System.IO.File.Open(filename, System.IO.FileMode.Create);
            Save(stream);
            stream.Close();
        }*/


        /// <summary>
        /// Transforms formula string to bytes
        /// </summary>
        /// <param name="str">The formula string</param>
        /// <returns>The bytes</returns>
        public static byte[] GetBytes(string str)
        {
            byte[] b = new byte[str.Length];
            for (int i = 0; i < b.Length; i++)
            {
                b[i] = (byte)str[i];
            }
            return b;
        }

        /// <summary>
        /// Thansforms bytes to formula string
        /// </summary>
        /// <param name="bytes">The bytes</param>
        /// <returns>The string</returns>
        public static string GetString(byte[] bytes)
        {
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str += (char)bytes[i];
            }
            return str;
        }


        /// <summary>
        /// The string representation of the formula
        /// </summary>
        public string FormulaString
        {
            get
            {
                string s = saver.Save(this);
                return s;
 /*               try
                {
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    formatter.Serialize(stream, this);
                    byte[] bytes = stream.GetBuffer();
                    string s = "";
                    foreach (byte b in bytes)
                    {
                        s += (char)b;
                    }
                    return s;
                }
                catch (Exception eee)
                {
                    string s = eee.StackTrace;
                    s = "";
                }
                try
                {
                    return ElementaryFormulaStringConverter.Object.Convert(this);
                }
                catch (Exception)
                {
                    ArrayList list = ToArray();
                    string s = "";
                    for (int i = 0; i < list.Count; i++)
                    {
                        char c = (char)(((byte[])list[i])[0]);
                        s += c;
                    }
                    return s;
                }*/
            }
        }

        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns>The clone</returns>
        public object Clone()
        {
            return Copy();
        }

        /// <summary>
        /// Adds the symbol
        /// </summary>
        /// <param name="s">Symbol to add</param>
        public void Add(MathSymbol s)
        {
            symbols.Add(s);
        }

        /// <summary>
        /// Count of symbols
        /// </summary>
        public int Count
        {
            get
            {
                return symbols.Count;
            }
        }

        /// <summary>
        /// The n th symbol
        /// </summary>
        public MathSymbol this[int n]
        {
            get
            {
                return symbols[n];
            }
        }

        /// <summary>
        /// Sets level of formula
        /// </summary>
        /// <param name="level">The level</param>
        public void SetLevel(byte level)
        {
            this.level = level;
            foreach (MathSymbol s in symbols)
            {
                s.SetLevel(level);
            }
        }

        /// <summary>
        /// Index of symbol
        /// </summary>
        /// <param name="s">The symbol</param>
        /// <returns>The index</returns>
        public int IndexOf(MathSymbol s)
        {
            for (int i = 0; i < symbols.Count; i++)
            {
                if (symbols[i] == s)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Deletes brackets
        /// </summary>
        /// <returns>this formula with deleted brackets</returns>
        public MathFormula DeleteBrackets()
        {
            if (Count == 0)
            {
                throw new OwnException();
            }
            MathSymbol b = this[0];
            MathSymbol e = this[Count - 1];
            if (b == null)
            {
                return this;
            }
            if ((b.Symbol != '(') | (e.Symbol != ')'))
            {
                return this;
            }
            if (e.HasChildren)
            {
                return this;
            }
            int m = 0;
            for (int i = 0; i < Count - 1; i++)
            {
                MathSymbol x = this[i];
                char c = x.Symbol;
                if (c == '(')
                {
                    m++;
                }
                if (c == ')')
                {
                    m--;
                    if (m == 0)
                    {
                        return this;
                    }
                }
            }
            return (new MathFormula(this, 1, Count - 2)).DeleteBrackets();
        }

        /// <summary>
        /// the formula level
        /// </summary>
        public byte Level
        {
            get
            {
                return level;
            }
        }





        /// <summary>
        /// Convetrs the formula to byte array vector
        /// </summary>
        /// <returns>The vector</returns>
        public List<byte[]> ToArray()
        {
            List<byte[]> vec = new List<byte[]>();
            for (int i = 0; i < Count; i++)
            {
                List<byte[]> v = this[i].ToArray();
                for (int j = 0; j < v.Count; j++)
                {
                    vec.Add(v[j]);
                }
            }
            return vec;
        }






        /// <summary>
        /// Simplifyes the formula
        /// </summary>
        public void Simplify()
        {
            DelZero();
            DelMult();
            ReverseNumber();
        }

        /// <summary>
        /// Contructor of formula that corresponds the double value
        /// </summary>
        /// <param name="level">the level</param>
        /// <param name="sizes">the array of different level symbols' sizes</param>
        /// <param name="a">the value</param>
        public MathFormula(byte level, int[] sizes, double a)
            : this(level, sizes)
        {
            MathSymbol s = new SimpleSymbol('?', (byte)FormulaConstants.Number, false);
            s.Append(this);
            First.DoubleValue = a;
        }



        /// <summary>
        /// Contructor of formula that corresponds the double value
        /// </summary>
        /// <param name="level">the level</param>
        /// <param name="sizes">the array of different level symbols' sizes</param>
        /// <param name="a">the value</param>
        public MathFormula(byte level, int[] sizes, bool a)
            : this(level, sizes)
        {
            MathSymbol s = new SimpleSymbol('?', (byte)FormulaConstants.Number, false);
            s.Append(this);
            First.BoolValue = a;
        }


        /// <summary>
        /// Adds the formula to this formula
        /// </summary>
        /// <param name="formula">the formula to add</param>
        public void Add(MathFormula formula)
        {
            int n = formula.Count;
            for (int i = 0; i < n; i++)
            {
                if (formula[i].Children == null)
                {
                    formula[i].Append(this);
                }
                else
                {
                    symbols.Add(formula[i]);
                    formula[i].Parent = this;
                }
            }
        }

        /// <summary>
        /// Inserts symbol before n th symbol
        /// </summary>
        /// <param name="n">The n</param>
        /// <param name="s">The symbol</param>
        public void Insert(int n, MathSymbol s)
        {
            symbols.Insert(n, s);
        }

        /// <summary>
        /// Inserts object
        /// </summary>
        /// <param name="symbol">Symbol to insert</param>
        /// <returns>Inserted object</returns>
        public MathFormula InsertObject(MathSymbol symbol)
        {
            symbol.Append(this);
            MathSymbol s = this[Count - 1];
            if ((s is BracketsSymbol) | (s is AbsSymbol))
            {
                return s[0];
            }
            return this;
        }


        /// <summary>
        /// The "is empty" indicator
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return Count == 0;
            }
        }

        /// <summary>
        /// Copies this formula
        /// </summary>
        /// <returns>the copy</returns>
        public virtual MathFormula Copy()
        {
            form = new MathFormula(level, sizes);
            for (int i = 0; i < Count; i++)
            {
                MathSymbol s = this[i].Copy();
                s.Parent = form;
                form.Add(s);
            }
            return form;
        }

        /// <summary>
        /// Removes a symbol from formula
        /// </summary>
        /// <param name="s">The symbol to remove</param>
        public void Remove(MathSymbol s)
        {
            symbols.Remove(s);
        }

        /// <summary>
        /// Full transformation
        /// </summary>
        public MathFormula FullTransform(string prohibited)
        {
                MathFormula f = Copy();
                Zero();
                f.TranNumber();
                f.WrapFunctions();
                f.Wrap(prohibited);
                f.InsertMult(prohibited);
                StringDetector sDetector = new StringDetector(0x0, false, false);
                f = sDetector.Convert(f);
                return f;
        }

        /// <summary>
        /// Transforms numbers of the formula
        /// </summary>
        public void TranNumber()
        {
            s = First;
            if (s == null)
            {
                return;
            }
            do
            {
                if (s.Count > 0)
                {
                    for (int i = 0; i < s.Count; i++)
                    {
                        s[i].TranNumber();
                    }
                }
                s = s.TranNumber();
            }
            while (s != null);
        }

        /// <summary>
        /// Wrapping
        /// </summary>
        public void Wrap(string prohibited)
        {
            s = First;
            if (s == null)
            {
                return;
            }
            do
            {
                if (prohibited != null)
                {
                    if (prohibited.IndexOf(s.Symbol) >= 0)
                    {
                        s = s.Next;
                        continue;
                    }
                }
                s = s.Wrap(prohibited);
            }
            while (s != null);
        }

        /// <summary>
        /// Inserts multiplications
        /// </summary>
        public void InsertMult(string prohibited)
        {
            s = First;
            if (s == null)
            {
                return;
            }
            s1 = s.Next;
            while (s1 != null)
            {
                bool bo = ((s.Symbol == ')' | s is BracketsSymbol) &
                    ((s1.Symbol == '(' | s1 is BracketsSymbol) |
                    (s1.SymbolType == (byte)FormulaConstants.Unary | s1.SymbolType == (byte)FormulaConstants.Series) 
                    & s1.Symbol != ')'));
                if (prohibited != null)
                {
                    if (prohibited.IndexOf(s1.Symbol) >= 0)
                    {
                        bo = false;
                    }
                }
                if (bo)
                {
                    s.Append(new BinarySymbol('*'));
                }
                s = s1;
                s1 = s.Next;
            }
            s = First;
            do
            {
                if (s.HasChildren)
                {
                    for (int i = 0; i < s.Count; i++)
                    {
                        s[i].InsertMult(prohibited);
                    }
                }
                s = s.Next;
            }
            while (s != null);
        }

        /// <summary>
        /// Wraps elementary functions by brackets for further processing
        /// </summary>
        void WrapFunctions()
        {
            s = First;
            while (s != null)
            {
                if (s.HasChildren)
                {
                    for (int i = 0; i < s.Count; i++)
                    {
                        s[i].WrapFunctions();
                    }
                }
                if (s.SymbolType == (byte)FormulaConstants.Unary | s.SymbolType == (byte)FormulaConstants.Series)
                {
                    s1 = s.Next;
                    if (s1 == null)
                    {
                        return;
                    }
                    if (!s1.ShouldWrapped | s1 is BracketsSymbol)
                    {
                        s = s1;
                        continue;
                    }
                    s.Append(MathSymbol.Bra);
                    s1 = s.Next;
                    while (s1 != null)
                    {
                        bool b = false;
                        MathSymbol ss = s1.Next;
                        if (ss == null)
                        {
                            b = true;
                        }
                        else if (!ss.ShouldWrapped | s1 is BracketsSymbol)
                        {
                            b = true;
                        }
                        if (b)
                        {
                            s1.Append(MathSymbol.Ket);
                            s = s1.Next;
                            break;
                        }
                        MathSymbol s2 = s1;
                        s1 = s1.Next;
                        if (s1 == null)
                        {
                            s2.Append(MathSymbol.Ket);
                            break;
                        }
                    }
                }
                s = s.Next;
            }
        }

        /// <summary>
        /// Finds first symbol of the formula
        /// </summary>
        public MathSymbol First
        {
            get
            {
                if (Count == 0)
                {
                    return null;
                }
                return this[0];
            }
        }

        /// <summary>
        /// Finds last symbol of the formula
        /// </summary>
        public MathSymbol Last
        {
            get
            {
                if (Count == 0)
                {
                    return null;
                }
                return this[Count - 1];
            }

        }

        /// <summary>
        /// Checks whether the formula contains the symbol
        /// </summary>
        /// <param name="sym">sym the symbol</param>
        /// <returns>true if contains and false otherwise</returns>
        public bool Contains(MathSymbol sym)
        {
            if (symbols.Contains(sym))
            {
                return true;
            }
            s = First;
            while (s != null)
            {
                if (s.Contains(sym))
                {
                    s = null;
                    return true;
                }
                s = s.Next;
            }
            s = null;
            return false;
        }

        /// <summary>
        /// Creates element from formula
        /// </summary>
        /// <param name="formula">Formula</param>
        /// <param name="document">Document</param>
        /// <param name="creator">Creator</param>
        /// <returns>Element</returns>
        public static XElement CreateElement(MathFormula formula,
            IXmlSymbolCreator creator)
        {
            XElement e = formula.CreateXElement("F");
            for (int i = 0; i < formula.Count; i++)
            {
                XElement el = MathSymbol.CreateElement(formula[i], creator);
                e.Add(el);
            }
            return e;
        }

        /// <summary>
        /// Creates formula from Xml element
        /// </summary>
        /// <param name="e">Element</param>
        /// <param name="creator">Creator of symbols</param>
        /// <returns>Formula</returns>
        public static MathFormula CreateFormula(XElement e, IXmlSymbolCreator creator)
        {
            MathFormula f = new MathFormula((byte)0);
            IEnumerable<XElement> l = e.GetElementsByTagName("S");
            foreach (XElement el in l)
            {
                if (el.Parent != e)
                {
                    continue;
                }
                MathSymbol s = MathSymbol.CreateSymbol(el, creator);
                s.AppendWithChildren(f);
            }
            return f;
        }

        /// <summary>
        /// Resets auxiliary variables
        /// </summary>
        private void Zero()
        {
            s = First;
            while (s != null)
            {
                if (s.HasChildren)
                {
                    for (int i = 0; i < s.Count; i++)
                    {
                        s[i].Zero();
                    }
                }
                s = s.Next;
            }
            s = null;
            s1 = null;
            form = null;
        }


        /// <summary>
        /// Deletes zeros
        /// </summary>
        private void DelZero()
        {
            MathSymbol s = First;
            if (s != null)
            {
                MathSymbol s1 = s.Next;
                if (s1 != null)
                {
                    if (s.SymbolType == (int)FormulaConstants.Number & s.DoubleValue == 0 & s.Symbol == '?' & s1.Symbol == '-')
                    {
                        s.Remove();
                    }
                }
            }
            s = First;
            while (s != null)
            {
                if (s.HasChildren)
                {
                    for (int i = 0; i < s.Count; i++)
                    {
                        s[i].DelZero();
                    }
                }
                s = s.Next;
            }
        }


        /// <summary>
        /// Deletes unnecessary multiplication symbols
        /// </summary>
        private void DelMult()
        {
            MathSymbol s = First;
            if (s != null)
            {
                MathSymbol s1 = s.Next;
                while (s1 != null)
                {
                    if (s1.SymbolType == (int)FormulaConstants.Binary & s1.Symbol == '*')
                    {
                        if (s.SymbolType != (int)FormulaConstants.Number | s1.Next.SymbolType != (int)FormulaConstants.Number)
                        {
                            s1.Remove();
                            s = s.Next;
                            if (s == null)
                            {
                                break;
                            }
                            s1 = s.Next;
                            continue;
                        }
                    }
                    s = s1;
                    s1 = s.Next;
                }
            }
            s = First;
            while (s != null)
            {
                if (s.HasChildren)
                {
                    for (int i = 0; i < s.Count; i++)
                    {
                        s[i].DelMult();
                    }
                }
                s = s.Next;
            }
        }

        /// <summary>
        /// Reverses digital to symbolic represrntation
        /// </summary>
        private void ReverseNumber()
        {
            MathSymbol s = First;
            while (s != null)
            {
                if (s.SymbolType == (int)FormulaConstants.Number)
                {
                    if (s.Symbol == '?')
                    {
                        List<MathFormula> f = s.Children;
                        double a = s.DoubleValue;
                        if (a == Math.E | a == Math.PI)
                        {
                            s.Append(new SimpleSymbol((a == Math.E) ? 'e' : 'p'));
                            MathSymbol s1 = s.Next;
                            s.Remove();
                            s1.Children = f;
                            s = s1.Next;
                            continue;
                        }
                        int b = 0;
                        bool intv = false;
                        if (Math.Abs(a - Math.Ceiling(a)) < ROUND_EPS)
                        {
                            b = (int)Math.Ceiling(a);
                            intv = true;
                        }
                        else if (Math.Abs(a - Math.Floor(a)) < ROUND_EPS)
                        {
                            b = (int)Math.Floor(a);
                            intv = true;
                        }
                        string str = "";
                        if (intv)
                        {
                            str = b + "";
                        }
                        else
                        {
                            str = a + "";
                        }
                        MathSymbol sOne = s;
                        for (int i = 0; i < str.Length; i++)
                        {
                            MathSymbol symb = (str[i] == MathSymbol.DecimalSep[0]) ?
                                new BinarySymbol('.') :
                                new SimpleSymbol(str[i], false, (int)FormulaConstants.Number);
                            sOne.Append(symb);
                            sOne = sOne.Next;
                        }
                        s.Remove();
                        sOne.Children = f;
                        s = sOne.Next;
                    }
                }
                else
                {
                    s = s.Next;
                }
            }
            s = First;
            while (s != null)
            {
                if (s.HasChildren)
                {
                    List<MathFormula> f = s.Children;
                    if (f != null)
                    {
                        for (int i = 0; i < f.Count; i++)
                        {
                            MathFormula form = f[i] as MathFormula;
                            if (form.Count > 0)
                            {
                                form.ReverseNumber();
                            }
                        }
                    }
                }
                s = s.Next;
            }
        }

        #endregion

        #region Coverter

        class Converter : IMathSymbolConverter
        {
            static internal IMathSymbolConverter Singleton = new Converter();
            private Converter()
            {

            }

            static Dictionary<string, Type> types = new Dictionary<string, Type>();

            static  Converter()
            {

               Type[] t =  typeof(Converter).Assembly.GetTypes();
                foreach (Type type in t)
                {
                   if (!isBase(type))
                    {
                        continue;
                    }
                    types[type.Name] = type;
                }
            }

            static bool isBase(Type typeInfo)
            {
                if (typeInfo == null)
                {
                    return false;
                }
                if (typeInfo == typeof(MathSymbol))
                {
                    return true;
                }
                return isBase(typeInfo.BaseType);
                
            }

            public MathSymbol Convert(MathSymbol symbol)
            {
                Type t = symbol.GetType();
                string type = t.ToString();
                Type ty = null;
                foreach (string key in types.Keys)
                {
                    if (type.Contains(key))
                    {
                        ty = types[key];
                        break;
                    }
                }
                System.Reflection.ConstructorInfo c = ty.GetConstructor(new Type[] { ty });
                MathSymbol sym = c.Invoke(new object[] { symbol }) as MathSymbol;
                return sym;
            }
        }

        #endregion

    }
}
