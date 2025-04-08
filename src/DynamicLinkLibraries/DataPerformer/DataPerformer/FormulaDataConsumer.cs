using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;


using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI.Aliases;

using FormulaEditor;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;
using ErrorHandler;
using NamedTree;

namespace DataPerformer
{
    /// <summary>
    /// Formula transformer of mesurements. It is measurements consumer
    /// </summary>
    [Serializable()]
    public class FormulaDataConsumer : DataConsumer, IMeasurements, ISerializable,
        IPostSetArrow, IAlias
    {

        #region Fields

        /// <summary>
        /// Output measurement
        /// </summary>
        private IMeasurement measure;


        /// <summary>
        /// Output value
        /// </summary>
        private double result;

        /// <summary>
        /// String representation of formula
        /// </summary>
        private string formulaString = "";

        /// <summary>
        /// The object's formula
        /// </summary>
        private MathFormula formula;

        /// <summary>
        /// Tree of the formula
        /// </summary>
        private ObjectFormulaTree tree;

        /// <summary>
        /// The formula argument
        /// </summary>
        private ElementaryObjectArgument arg;

        /// <summary>
        /// Input parameter
        /// </summary>
        private DataPerformer.Portable.DynamicalParameter par;

        /// <summary>
        /// The formula arguments
        /// </summary>
        private ArrayList arguments;

        /// <summary>
        /// Derivation of output parameter
        /// </summary>
        private double derivation;

        /// <summary>
        /// Partial derivations
        /// </summary>
        private Hashtable derivations = new Hashtable();

        /// <summary>
        /// Table of parameters
        /// </summary>
        private Hashtable parameters = new Hashtable();

        /// <summary>
        /// Change alias event
        /// </summary>
        event Action<IAlias, string> onChange = (IAlias a, string name) => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        public FormulaDataConsumer()
            : base(11)
        {
            init();
            arguments = new ArrayList();
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public FormulaDataConsumer(SerializationInfo info, StreamingContext context)
            :
            base(11)
        {
            formulaString = (string)info.GetValue("Formula", typeof(string));
            if (formulaString.Length > 0)
            {
                Formula = formulaString;
            }
            arguments = (ArrayList)info.GetValue("Arguments", typeof(ArrayList));
            parameters = (Hashtable)info.GetValue("Parameters", typeof(Hashtable));
            init();
        }

        #endregion

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        new public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Formula", formulaString);
            info.AddValue("Arguments", arguments);
            info.AddValue("Parameters", parameters);
        }

        /*new public XmlElement CreateXml(XmlDocument doc)
        {
            XmlElement el = doc.CreateElement("FormulaDataConsumer");
            XmlAttribute attr = doc.CreateAttribute("Formula");
            attr.Value = Formula;
            el.Attributes.Append(attr);
            foreach (string s in arguments)
            {
                XmlElement ea = doc.CreateElement("FormulaArgument");
                XmlAttribute attrArg = doc.CreateAttribute("Argument");
                attrArg.Value = s;
                ea.Attributes.Append(attrArg);
                el.AppendChild(ea);
            }
			

            return el;
        }*/


        /// <summary>
        /// The count of measurements
        /// </summary>
        int IMeasurements.Count
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// Access to n - th measurement
        /// </summary>
        IMeasurement IMeasurements.this[int n]
        {
            get
            {
                return measure;
            }
        }

        /// <summary>
        /// Updates measurements data
        /// </summary>
        public void UpdateMeasurements()
        {
            if (IsUpdated)
            {
                return;
            }
            try
            {
                if (par == null)
                {
                    throw new Exception(DynamicalParameter.UndefinedParameters);
                }
                UpdateChildrenData();
                (par as Formula.DynamicalParameter).Set(arg);
                result = (double)tree.Result;
                derivation = 0;
                string str = arg.Variables;
                foreach (char c in str)
                {
                    string s = c + "";
                    if (parameters.ContainsKey(s))
                    {
                        continue;
                    }
                    IMeasurement m = par[c];
                    if (!(m is IDerivation))
                    {
                        derivation = 0;
                        break;
                    }
                    IDerivation p = m as IDerivation;
                    ObjectFormulaTree t = derivations[c] as ObjectFormulaTree;
                    derivation += (double)t.Result * (double)p.Derivation.Parameter();
                }
                isUpdated = true;
            }
            catch (Exception e)
            {
                e.HandleException(10);
                this.Throw(e);
            }
        }

 

        /// <summary>
        /// Accepts parameters
        /// </summary>
        /// <param name="s">String of parameters</param>
        public void AcceptParameters(string s)
        {
            parameters.Clear();
            par = null;
            arg = new ElementaryObjectArgument();
            arg.Add(tree);
            string str = arg.Variables;
            foreach (char c in s)
            {
                if (str.IndexOf(c) < 0)
                {
                    throw new Exception("Illegal formula parameter");
                }
            }
            foreach (char c in s)
            {
                double a = 0;
                parameters["" + c] = a;
                arg[c] = a;
            }
        }


        /// <summary>
        /// The operation that performs after arrows setting
        /// </summary>
        public void PostSetArrow()
        {
            if (tree == null)
            {
                return;
            }
            DynamicalParameter parameter = new DynamicalParameter();
            foreach (IMeasurements measurements in measurementsData)
            {
                /*IAssociatedObject cont = measurements as IAssociatedObject;
                INamedComponent comp = cont.Object as INamedComponent;*/
                string name = this.GetName(measurements);//comp.Name;
                for (int i = 0; i < measurements.Count; i++)
                {
                    IMeasurement measure = measurements[i];
                    string p = name + "." + measure.Name;
                    foreach (string s in arguments)
                    {
                        if (s.Substring(4).Equals(p))
                        {
                            char c = s[0];
                            parameter.Add(c, measure);
                        }
                    }
                }
            }
            foreach (string s in arguments)
            {
                if (s.Substring(4).Equals("Time"))
                {
                    parameter.Add(s[0], 
                        DataPerformer.Portable.StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasurement);
                }
            }
            Parameter = parameter;
            foreach (string s in AliasNames)
            {
                arg[s[0]] = this[s];
            }
        }


        /// <summary>
        /// The name of measurements source
        /// </summary>
        public string SourceName
        {
            get
            {
                INamedComponent comp = Object as INamedComponent;
                return comp.Name;
            }
        }

        /// <summary>
        /// String representation of formula
        /// </summary>
        public string Formula
        {
            get
            {
                return formulaString;

            }
            set
            {
                formula = MathFormula.FromString(MathSymbolFactory.Sizes, value);
                formulaString = value;
                MathFormula f = formula.FullTransform(null);
                tree = ObjectFormulaTree.CreateTree(f, ElementaryFunctionsCreator.Object);
                arg = new ElementaryObjectArgument();
                arg.Add(tree);
                string var = arg.Variables;
                derivations.Clear();
                parameters.Clear();
                foreach (char c in var)
                {
                    ObjectFormulaTree t = tree.Derivation(c + "");
                    arg.Add(t);
                    t = ElementarySimplifier.Simplify(t);
                    derivations[c] = t;
                }
            }
        }

        /// <summary>
        /// The formula arguments
        /// </summary>
        public ArrayList Arguments
        {
            get
            {
                return arguments;
            }
            set
            {
                string str = Variables;
                //bool b = false;
                foreach (char c in str)
                {
                    foreach (string s in value)
                    {
                        if (s[0] == c)
                        {
                            goto m;
                        }
                    }
                    throw new Exception(VariablesShortage);
                m:
                    continue;
                }
                arguments = value;
            }
        }

        /// <summary>
        /// Input dynamical parameter
        /// </summary>
        public DynamicalParameter Parameter
        {
            set
            {
                arg = new ElementaryObjectArgument();
                arg.Add(tree);
                par = value;
            }
        }

        /// <summary>
        /// Formula variables
        /// </summary>
        public string Variables
        {
            get
            {
                string s = "";
                ElementaryObjectArgument arg = new ElementaryObjectArgument();
                string str = arg.Variables;
                foreach (char c in str)
                {
                    if (!parameters.ContainsKey("" + c))
                    {
                        s += c;
                    }
                }
                return s;
            }
        }


        /// <summary>
        /// Names of aliases
        /// </summary>
        public IList<string> AliasNames
        {
            get
            {
                List<string> s = new List<string>();
                foreach (string str in parameters.Keys)
                {
                    s.Add(str);
                }
                return s;
            }
        }

        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => [measure];

        /// <summary>
        /// Access to alias object
        /// </summary>
        public object this[string alias]
        {
            get
            {
                return parameters[alias];
            }
            set
            {
                char c = alias[0];
                double a = (double)value;
                arg[c] = a;
                parameters[alias] = a;
            }
        }

        /// <summary>
        /// Gets object type
        /// </summary>
        /// <param name="name">Object name</param>
        /// <returns>Returns type of alias object</returns>
        public object GetType(string name)
        {
            IAlias al = this;
            return AliasTypeDetector.Detector.DetectType(al[name]);
        }


        event Action<IAlias, string> IAlias.OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }




        /// <summary>
        /// Gets alias type
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public object GetType(int n)
        {
            Double a = 0;
            return a;
        }


        /// <summary>
        /// Calculates formula result
        /// </summary>
        /// <returns>The formula result</returns>
        private object calculate()
        {
            return result;
        }

        /// <summary>
        /// Calculates derivation
        /// </summary>
        /// <returns>The derivation</returns>
        private object getDerivation()
        {
            return derivation;
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void init()
        {
            measure = new MeasurementDerivation(tree.ReturnType, new Func<object>(calculate), 
                new Measurement(getDerivation, "Der_result", this), "result", this);
        }

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
        }
    }
}
