using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Runtime.Serialization;

using Diagram.UI;
using FormulaEditor;

namespace DataPerformer
{
    /// <summary>
    /// Solver of ordinary differential equations system
    /// </summary>
    [Serializable()]
    public class DifferentialEquationSolver : Formula.DifferentialEquationSolver,  ISerializable
    {


        #region Fields

        Hashtable varsH = new Hashtable();
        Hashtable parsH = new Hashtable();
        Hashtable aliasesH = new Hashtable();
        ArrayList argsH = new ArrayList();
        Hashtable aliasNamesH = new Hashtable();

        #endregion

        #region Constructors

        /// <summary>
        /// Consructor
        /// </summary>
        public DifferentialEquationSolver()
        {
        
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public DifferentialEquationSolver(SerializationInfo info, StreamingContext context)
            :
            base()
        {
            try
            {
                isSerialized = true;
                varsH = (Hashtable)info.GetValue("Vars", typeof(object));
                parsH = (Hashtable)info.GetValue("Pars", typeof(object));
                aliasesH = (Hashtable)info.GetValue("Aliases", typeof(object));
                argsH = (ArrayList)info.GetValue("Arguments", typeof(object));
                aliasNamesH = (Hashtable)info.GetValue("AliasNames", typeof(object));
                comments = (byte[])info.GetValue("Comments", typeof(byte[]));
            }
            catch (Exception ex)
            {
                comments = new byte[0];
            }
            try
            {
                deriOrder = (int)info.GetValue("DerivationOrder", typeof(int));
                deriOrders = info.GetValue("DerivationOrders", typeof(Dictionary<string, int>))
                    as Dictionary<string, int>;
            }
            catch (Exception exc)
            {
                exc.ShowError(10);
            }
        }

        #endregion

        #region ISerializable Implementation

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Convert();
            info.AddValue("Vars", varsH);
            info.AddValue("Pars", parsH);
            info.AddValue("Aliases", aliasesH);
   /*         argsH = new ArrayList();
            foreach (string s in arguments)
            {
                argsH.Add(s);
            }*/
            info.AddValue("Arguments", argsH);
            info.AddValue("AliasNames", aliasNamesH);
            if (comments == null)
            {
                comments = new byte[0];
            }
            info.AddValue("Comments", comments);
            info.AddValue("DerivationOrder", deriOrder);
            info.AddValue("DerivationOrders", deriOrders, typeof(Dictionary<string, int>));

        }

        #endregion

        #region Public members

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

        #endregion

        #region Protected Members

        /// <summary>
        /// Performs operations after deserialization
        /// </summary>
        protected override void postDeserialize()
        {
            ConvertInvert();
            base.postDeserialize();
        }

        #endregion

        #region Private Conversion
        static void Copy(Hashtable t, Dictionary<object, object> d)
        {
            if (t.Count == 0)
            {
                return;
            }
            d.Clear();
            foreach (object o in t.Keys)
            {
                d[o] = t[o];
            }
        }

        static void Copy(Dictionary<object, object> d, Hashtable t)
        {
            if (d.Count == 0)
            {
                return;
            }
            t.Clear();
            foreach (object o in d.Keys)
            {
                t[o] = d[o];
            }
        }

        void Copy(List<string> d, ArrayList t)
        {
            if (d.Count == 0)
            {
                return;
            }
            t.Clear();
            foreach (object o in d)
            {
                t.Add(o);
            }
        }

        void Copy(ArrayList d, List<string> t)
        {
            if (d.Count == 0)
            {
                return;
            }
            t.Clear();
            foreach (object o in d)
            {
                t.Add(o as string);
            }
        }

        void Convert()
        {
            foreach (char c in vars.Keys)
            {
                object[] o = vars[c] as object[];
                string st = o[0] as string;
                MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, st);
                o[0] = f.FormulaString;
            }
            Copy(vars, varsH);
            Copy(pars, parsH);
            Copy(aliases, aliasesH);
            Copy(arguments, argsH);
            Copy(aliasNames, aliasNamesH);
        }

        void ConvertInvert()
        {
            Copy(varsH, vars);
            Copy(parsH, pars);
            Copy(aliasesH, aliases);
            Copy(argsH, arguments);
            Copy(aliasNamesH, aliasNames);
        }

        #endregion
    }
}