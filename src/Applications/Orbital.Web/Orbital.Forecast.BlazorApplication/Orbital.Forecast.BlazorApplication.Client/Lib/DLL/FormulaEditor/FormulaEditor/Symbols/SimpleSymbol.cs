using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Linq;

namespace FormulaEditor.Symbols
{
	/// <summary>
	/// The simple symbol of math formula 
	/// </summary>
	public class SimpleSymbol : MathSymbol
	{

		#region Fields

		/// <summary>
		/// Auxiliary variable
		/// </summary>
		protected string sb = "";


		/// <summary>
		/// Italic flag
		/// </summary>
		protected bool italic = true;

		/// <summary>
		/// Bold flag
		/// </summary>
		protected bool bold = true;

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="c">the symbol</param>
		public SimpleSymbol(char c) : base(c, 1)
		{
			sb += c;
			type = (byte)1;
			s = sb + "";
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="c">the symbol</param>
		/// <param name="type">the type</param>
		/// <param name="italic">the italic flag</param>
		public SimpleSymbol(char c, byte type, bool italic) : base(c, 1)
		{
		    this.type = type;
			this.italic = italic;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="c">The symbol</param>
		/// <param name="type">The type</param>
		/// <param name="italic">The italic flag</param>
		/// <param name="bold">The bold flag</param>
		public SimpleSymbol(char c, byte type, bool italic, bool bold) : this(c, type, italic)
		{
			this.bold = bold;
			s = c + "";
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="c">the symbol</param>
		/// <param name="type">the type</param>
		/// <param name="italic">the italic flag</param>
		/// <param name="s">string representation</param>
		public SimpleSymbol(char c, byte type, bool italic, string s) : this(c, type, italic)
		{
			this.s = s;
			if ((s == "True") | (s == "False"))
			{
				type = (byte)FormulaConstants.Boolean;
			}
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="c">Symbol</param>
		/// <param name="type">type</param>
        /// <param name="italic">italic sign</param>
        /// <param name="bold">bold sign</param>
        /// <param name="s">String representation</param>
		public SimpleSymbol(char c, byte type, bool italic, bool bold, string s) : this(c, type, italic, s)
		{
			this.s = s;
			this.bold = bold;
		}



		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="c">the symbol</param>
		/// <param name="italic">the italic flag</param>
		/// <param name="type">the type</param>
		public SimpleSymbol(char c,  bool italic, byte type) : this(c, type, italic)
		{
			String str = "";
			str += c;
			string s = null;
			if (MathFormula.Resources != null)
			{
                if (MathFormula.Resources.ContainsKey(str))
                {
                    s = MathFormula.Resources[str];
                }
			}
			if (s == null)
			{
				this.s = str;
			}
			else if (s.Length > 0)
			{
				this.s = s;
			}
			else
			{
				this.s = str;
			}
		}

        /// <summary>
        /// Construcor
        /// </summary>
        /// <param name="value">Value</param>
        public SimpleSymbol(bool value)
        {
            symbol = 'b';
            boolValue = BoolValue;
            bold = true;
            italic = false;
            s = value + "";
            type = (byte)FormulaConstants.Boolean;
      }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="s">Prototype</param>
        public SimpleSymbol(SimpleSymbol s)
            : this(s.symbol, s.type, s.italic, s.bold, s.s)
        {
            boolValue = s.boolValue;
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Creates attributes for Xml element
        /// </summary>
        /// <param name="doc">The element document</param>
        /// <param name="e">The element</param>
        public override void CreateAttributes(XElement e)
        {
            base.CreateAttributes(e);
            SaveBool(italic, "Italic", e);
            SaveBool(bold, "Bold", e);
            e.SetAttributeValue("Sb", sb);
        }

        /// <summary>
        /// Loads attributes from Xml element
        /// </summary>
        /// <param name="e">The element</param>
        public override void LoadAttributes(XElement e)
        {
            base.LoadAttributes(e);
            sb = e.GetAttribute("Sb");
            italic = LoadBool("Italic", e);
            bold = LoadBool("Bold", e);
			var t = e.GetAttribute("S");
			if ((t == "True") || (t == "False"))
			{ 
				type = (byte)FormulaConstants.Boolean;
			}
        }

        /// <summary>
        /// Sets level of symbol
        /// </summary>
        /// <param name="level">The level</param>
        public override void SetLevel(byte level)
        {
            SetDegreeLevel(level);
        }

        /// <summary>
        /// Sets this symbol to formula
        /// </summary>
        /// <param name="formula">The formula to set</param>
        public override void SetToFormula(MathFormula formula)
		{
			base.SetToFormula(formula);
			if (italic)
			{
				//font = fontsItalic[level];
			}
			else
			{
				//font = fonts[level];
			}
			if (!this.GetType().Equals(typeof(SimpleSymbol)))
			{
				return;
			}
			if (level < (sizes.Length - 1))
			{
				MathFormula child = new MathFormula((byte)(level + 1), sizes);
				children.Add(child);
				return;
			}
			children = null;
		}

		/// <summary>
		/// Interfaces.ICloneable interface implementation
		/// </summary>
		/// <returns>Clone of itsel</returns>
		public override object Clone()
		{
			SimpleSymbol ss = new SimpleSymbol(symbol, type, italic, bold, s);
			ss.doubleValue = doubleValue;
			ss.ulongValue = ulongValue;
			return ss;
		}

		/// <summary>
		/// Checks whether the symbol is same
		/// </summary>
		/// <param name="sym">Symbol</param>
		/// <returns>True if same and false otherwise</returns>
		public override bool IsSame(MathSymbol sym)
		{
			if (!(sym is SimpleSymbol))
			{
				return false;
			}
			SimpleSymbol ss = sym as SimpleSymbol;
			return (bold == ss.bold) & (type == ss.type) & (ss.s.Equals(s));
		}


		#endregion

		#region Specific Members


		/// <summary>
		/// Italic flag
		/// </summary>
		public bool Italic
		{
			get
			{
				return italic;
			}
		}

		/// <summary>
		/// Bold flag
		/// </summary>
		public bool Bold
		{
			get
			{
				return bold;
			}
		}

        /// <summary>
        /// Saves bool value to Xml element
        /// </summary>
        /// <param name="b">Bool value</param>
        /// <param name="name">Attribute name</param>
        /// <param name="doc">Document</param>
        /// <param name="e">Element</param>
        public static void SaveBool(bool b, string name, XElement e)
        {
            e.SetAttributeValue(name, b ? "1" : "0");
        }

        /// <summary>
        /// Loads bool value from Xml element
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="e">Element</param>
        /// <returns>Bool value</returns>
        public static bool LoadBool(string name, XElement e)
        {
            return e.GetAttribute(name)[0] == '1';
        }

		#endregion

	}
}
