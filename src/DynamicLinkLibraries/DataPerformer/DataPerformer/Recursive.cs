using System;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;

using Diagram.UI;

using FormulaEditor;

namespace DataPerformer
{
	/// <summary>
	/// Recurrent object
	/// </summary>
	[Serializable()]
	public class Recursive : Formula.Recursive, ISerializable
	{

		#region Fields

		/// <summary>
		/// Internal variables
		/// </summary>
		private Hashtable variablesH = new Hashtable();


		/// <summary>
		/// Aliases
		/// </summary>
		private Hashtable aliasesH = new Hashtable();

		/// <summary>
		/// String representation of internal variables
		/// </summary>
		private Hashtable varsH = new Hashtable();

		/// <summary>
		/// String representation of external parameters
		/// </summary>
		private Hashtable parsH = new Hashtable();

		/// <summary>
		/// String represntation of external aliases
		/// </summary>
		private Hashtable externalAlsH = new Hashtable();

		/// <summary>
		/// External aliases
		/// </summary>
		private Hashtable externalAliasesH = new Hashtable();


		/// <summary>
		/// Comments
		/// </summary>
		private byte[] comments;


		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		public Recursive()
		{
		
		}

		/// <summary>
		/// Deserialization constructor
		/// </summary>
		/// <param name="info">Serialization info</param>
		/// <param name="context">Streaming context</param>
		protected Recursive(SerializationInfo info, StreamingContext context)
			: this()
		{
			try
			{
				varsH = (Hashtable)info.GetValue("Variables", typeof(Hashtable));
				parsH = (Hashtable)info.GetValue("Parameters", typeof(Hashtable));
				aliasesH = (Hashtable)info.GetValue("Aliases", typeof(Hashtable));
				externalAlsH = (Hashtable)info.GetValue("ExternalAliases", typeof(Hashtable));
				try
				{
					comments = (byte[])info.GetValue("Comments", typeof(byte[]));
				}
				catch (Exception eee)
				{
					eee.ShowError(-1);
				}
			}
			catch (Exception ex)
			{
				int level = 10;
				if (ex.Message.Contains("Comments"))
				{
					level = -1;
				}
				ex.ShowError(level);
			}
		}

		#endregion

		#region ISerializable Members

		/// <summary>
		/// ISerializable interface implementation
		/// </summary>
		/// <param name="info">Serialization info</param>
		/// <param name="context">Streaming context</param>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			Convert();
			info.AddValue("Variables", varsH);
			info.AddValue("Parameters", parsH);
			info.AddValue("Aliases", aliasesH);
			info.AddValue("ExternalAliases", externalAlsH);
			if (comments == null)
			{
				comments = new byte[0];
			}
			info.AddValue("Comments", comments);
		}

		#endregion

		/// <summary>
		/// Comments
		/// </summary>
		public ArrayList Comments
		{
			get
			{
				return PureDesktopPeer.Deserialize(comments) as ArrayList;
			}
			set
			{
				comments = PureDesktopPeer.Serialize(value);
			}
		}

		/// <summary>
		/// The operation that performs after arrows setting
		/// </summary>
		public override void PostSetArrow()
		{
			ConvertInvert();
			base.PostSetArrow();
		}

		#region Private members

		void Convert()
		{
            foreach (char c in varc)
            {
                object[] o = vars[c] as object[];
                string st = o[1] as string;
                MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, st);
                o[1] = f.FormulaString;
            }
			if (varc.Count > 0)
			{
				Copy(vars, varsH);
			}
			if (pars.Count > 0)
			{
				Copy(pars, parsH);
			}
			if (aliases.Count > 0)
			{
				Copy(aliases, aliasesH);
			}
			if (externalAls.Count > 0)
			{
				Copy(externalAls, externalAlsH);
			}
		}

		void ConvertInvert()
		{
			Copy(varsH, vars);
			Copy(parsH, pars);
			Copy(aliasesH, aliases);
			Copy(externalAlsH, externalAls);
			Order();
		}


		static void Copy(Hashtable t, Dictionary<object, object> d)
		{
			d.Clear();
			foreach (object o in t.Keys)
			{
				d[o] = t[o];
			}
		}

		static void Copy(Dictionary<object, object> d, Hashtable t)
		{
			t.Clear();
			foreach (object o in d.Keys)
			{
				t[o] = d[o];
			}
		}

		void Copy(List<string> d, ArrayList t)
		{
			t.Clear();
			foreach (object o in d)
			{
				t.Add(o);
			}
		}



		#endregion


	}

}
