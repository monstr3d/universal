using System;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;


using Diagram.UI;

using BaseTypes.Interfaces;

using SerializationInterface;
using FormulaEditor;
using System.Linq;

namespace DataPerformer
{
    /// <summary>
    /// Vector formula data transformer
    /// </summary>
    [Serializable()]
    public class VectorFormulaConsumer : 
        Formula.VectorFormulaConsumer,
        ISerializable

    {

        #region Fields


 
        /// <summary>
        /// Dictionary of acceptors
        /// </summary>
        private Dictionary<string, IOperationAcceptor> acc = new Dictionary<string, IOperationAcceptor>();

   
        private ArrayList args = new ArrayList();

        private Hashtable pars = new Hashtable();

        private Hashtable opNames = new Hashtable();


        #endregion

        #region Ctor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public VectorFormulaConsumer()
        {
        } 

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public VectorFormulaConsumer(SerializationInfo info, StreamingContext context)
        {
            try
            {
                formulaString = (string[])info.GetValue("Formulas", typeof(string[]));
                isSerialized = true;
                args = (ArrayList)info.GetValue("Arguments", typeof(ArrayList));
                pars = (Hashtable)info.GetValue("Parameters", typeof(Hashtable));
                opNames = (Hashtable)info.GetValue("Unaries", typeof(Hashtable));
                calculateDerivation = (bool)info.GetValue("CalculateDerivation", typeof(bool));
                if (calculateDerivation)
                {
                    deriOrder = 1;
                }
                try
                {
                    comments = (byte[])info.GetValue("Comments", typeof(byte[]));
                }
                catch (Exception ex)
                {
                    ex.ShowError(-1);
                }
                deriOrder = (int)info.GetValue("DerivationOrder", typeof(int));
                try
                {
                    feedback = info.Deserialize<Dictionary<int, string>>("Feedback");
                }
                catch (Exception exc)
                {
                    exc.ShowError(100); ;
                }
                try
                {
                    shouldRuntimeUpdate = info.GetBoolean("ShouldRuntimeUpdate");
                }
                catch (Exception exc)
                {
                    exc.ShowError(100); ;
                }
                try
                {
                    forwardAliases = info.Deserialize<Dictionary<int, string> >("ForwardAliases");
                }
                catch (Exception exc)
                {
                    exc.ShowError(100); ;
                }

            }
            catch (Exception ex)
            {
                ex.ShowError(1);
            }
            Init();
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            if (parameters.Count > 0)
            {
                pars.Clear();
                foreach (string key in parameters.Keys)
                {
                    pars[key] = parameters[key];
                }
            }
            if (arguments.Count > 0)
            {
                args.Clear();
                foreach (object o in arguments)
                {
                    args.Add(o);
                }
            }
            if (operationNames.Count > 0)
            {
                opNames.Clear();
                foreach (int key in operationNames.Keys)
                {
                    opNames[key] = operationNames[key];
                }

            }
            if (formulae != null)
            {
                formulaString = formulae.ToStringEnumerable().ToArray();
            }
            info.AddValue("Formulas", formulaString);
            info.AddValue("Arguments", args);
            info.AddValue("Parameters", pars);
            info.AddValue("Unaries", opNames);
            info.AddValue("CalculateDerivation", calculateDerivation);
            if (comments != null)
            {
                info.AddValue("Comments", comments);
            }
            info.AddValue("DerivationOrder", deriOrder);
            info.Serialize("Feedback", feedback);
            info.AddValue("ShouldRuntimeUpdate", shouldRuntimeUpdate);
            info.Serialize("ForwardAliases", forwardAliases);
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Post deserializatoion
        /// </summary>
        protected override void PostDeserialization()
        {
            if (args.Count > 0)
            {
                foreach (string s in args)
                {
                    arguments.Add(s);
                }
                args.Clear();
            }
            if (pars.Count > 0)
            {
                foreach (string key in pars.Keys)
                {
                    parameters[key] = pars[key];
                }
                pars.Clear();
            }
            if (opNames.Count > 0)
            {
                foreach (int i in opNames.Keys)
                {
                    operationNames[i] = opNames[i] + "";
                }
                opNames.Clear();
            }

        }

        #endregion

        #region Public Members

        /// <summary>
        /// Comments
        /// </summary>
        public ICollection Comments
        {
            get
            {
                return PureDesktopPeer.Deserialize(comments) as ICollection;
            }
            set
            {
                comments = PureDesktopPeer.Serialize(value);
            }
        }


        #endregion

    }

}
