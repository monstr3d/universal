using System;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;


namespace FormulaEditor.Symbols
{
	/// <summary>
	/// The simple symbol of math formula 
	/// </summary>
    public class IndexedSymbol : SimpleSymbol, INullArityOperation, IPowered
	{

		/// <summary>
		/// The associated object
		/// </summary>
		protected object obj;


		/// <summary>
		/// Type of object
		/// </summary>
		protected object objType;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="c">the symbol</param>
		public IndexedSymbol(char c) : this(c, (byte)FormulaConstants.Indexed, true)
		{
			s = "" + c;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="c">the symbol</param>
		/// <param name="type">the type</param>
		/// <param name="italic">the italic flag</param>
		public IndexedSymbol(char c, byte type, bool italic) : base(c, type, italic)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="c">the symbol</param>
		/// <param name="type">the type</param>
		/// <param name="italic">the italic flag</param>
		/// <param name="s">string representation</param>
		public IndexedSymbol(char c, byte type, bool italic, String s) : base(c, type, italic, s)
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="c">the symbol</param>
		/// <param name="italic">the italic flag</param>
		/// <param name="type">the type</param>
		public IndexedSymbol(char c,  bool italic, byte type) : base(c, italic, type)
		{
		}


        /// <summary>
        /// Sets this symbol to formula
        /// </summary>
        /// <param name="formula">The formula to set</param>
        public override void SetToFormula(MathFormula formula)
		{
			base.SetToFormula(formula);
			if (!this.GetType().Equals(typeof(IndexedSymbol)))
			{
				return;
			}
			children.Clear();
			if (level < (sizes.Length - 1))
			{
				MathFormula child = new MathFormula((byte)(level + 1), sizes);
				children.Add(child);
				return;
			}
			children = null;
		}

        /// <summary>
        /// The Interfaces.ICloneable interface implementation
        /// </summary>
        /// <returns>A clone of itself</returns>
        public override object Clone()
		{
			return new IndexedSymbol(symbol, type, italic, s);
		}

		/// <summary>
		/// The associated object
		/// </summary>
		public object Object
		{
			get
			{
				return obj;
			}
			set
			{
				obj = value;
			}
		}

        /// <summary>
        /// Subscript
        /// </summary>
		public virtual int SubscriptIndex
		{
			get
			{
				MathFormula f = this[0];
				string s = "";
				for (int i = 0; i < f.Count; i++)
				{
					s += f[i].Symbol;
				}
				return Int32.Parse(s);
			}
		}

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
		{
			get
			{
                return new object[0];
			}
		}

		/// <summary>
		/// Return type
		/// </summary>
		public object ReturnType
		{
			get
			{
				return obj;
			}
		}

		/// <summary>
		/// The "is powered" sign
		/// </summary>
		public virtual bool IsPowered
		{
			get
			{
				return false;
			}
		}



		/// <summary>
		/// Calculates result of this operation
		/// </summary>
		public object this[object[] o]
		{
			get
			{
				return obj;
			}
		}

	}
}
