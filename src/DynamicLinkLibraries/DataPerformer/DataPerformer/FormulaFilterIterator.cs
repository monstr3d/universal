using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;


using DataPerformer.Interfaces;

using DataPerformer.Portable;

using FormulaEditor.Interfaces;
using FormulaEditor;
using DataPerformer.Formula;

namespace DataPerformer
{
    /// <summary>
    /// Formula iterator for filter
    /// </summary>
    [Serializable()]
    public class FormulaFilterIterator : FilterIterator, ISerializable, ICategoryObject, IPostSetArrow
    {
        #region Fields

        /// <summary>
        /// Associated object
        /// </summary>
        protected object obj;

        ObjectFormulaTree tree;

        Dictionary<string, string> variables = new Dictionary<string, string>();

        Dictionary<string, object> constants = new Dictionary<string, object>();

        Dictionary<char, IMeasurement> measures = new Dictionary<char,IMeasurement>();

        /// <summary>
        /// Formula arguments
        /// </summary>
        private ElementaryObjectArgument arg;


        string formula = "";

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FormulaFilterIterator()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected FormulaFilterIterator(SerializationInfo info, StreamingContext context)
        {
            variables = info.GetValue("Variables", typeof(Dictionary<string, string>)) as Dictionary<string, string>;
            constants = info.GetValue("Constants", typeof(Dictionary<string, object>)) as Dictionary<string, object>;
            formula = info.GetValue("Formula", typeof(string)) as string;
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Variables", variables, typeof(Dictionary<string, string>));
            info.AddValue("Constants", constants, typeof(Dictionary<string, object>));
            info.AddValue("Formula", formula, typeof(string));
        }

        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
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

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Set(variables);
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// The "allow next" sign
        /// </summary>
        protected override bool? AllowNext
        {
            get 
            {
                if (tree == null)
                {
                    return null;
                }
                foreach (char c in measures.Keys)
                {
                    arg[c] = measures[c].Parameter();
                }
                foreach (string s in constants.Keys)
                {
                    arg[s[0]] = constants[s];
                }
                return (bool?)tree.Result; 
            }
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// All variables of filter
        /// </summary>
        public string AllVariables
        {
            get
            {
                string s = "";
                try
                {
                    MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, formula);
                    s = ElementaryObjectDetector.GetVariables(f);
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                }
                return s;
            }
        }

        /// <summary>
        /// Formula of iterator
        /// </summary>
        public string Formula
        {
            get
            {
                return formula;
            }
            set
            {
                MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, value);
                formula = value;
            }
        }

        /// <summary>
        /// Variables
        /// </summary>
        public string Constants
        {
            get
            {
                try
                {
                    string s = "";
                    MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, formula);
                    string str = ElementaryObjectDetector.GetVariables(f);
                    foreach (char c in str)
                    {
                        if (!variables.ContainsKey("" + c) & s.IndexOf(c) < 0)
                        {
                            s += c;
                        }
                    }
                    return s;
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                }
                return "";
            }
            set
            {
                variables.Clear();
                constants.Clear();
               // string s = "";
                MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, formula);
                string str = ElementaryObjectDetector.GetVariables(f);
                double a = 0;
                foreach (char c in str)
                {
                    if (value.IndexOf(c) >= 0)
                    {
                        constants[c + ""] = a;
                    }
                    else
                    {
                        variables[c + ""] = "";
                    }
                }
            }
        }

        /// <summary>
        /// String of variables
        /// </summary>
        public string Variables
        {
            get
            {
                string s = AllVariables;
                string str = "";
                foreach (char c in s)
                {
                    if (!constants.ContainsKey(c + ""))
                    {
                        str += c;
                    }
                }
                return str;
            }
        }

        /// <summary>
        /// Dictionary of variables
        /// </summary>
        public Dictionary<string, string> VariableDictionary
        {
            get
            {
                return variables;
            }
            set
            {
                Set(value);
            }
        }

        /// <summary>
        /// Dictionary of constants
        /// </summary>
        public Dictionary<string, object> ConstDictionary
        {
            get
            {
                return constants;
            }
            set
            {
                constants = value;
            }
        }

        void Set(Dictionary<string, string> variables)
        {
            MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, formula);
            measures.Clear();
            Dictionary<char, object> table = new Dictionary<char, object>();
            foreach (string key in variables.Keys)
            {
                IMeasurement m = this.FindMeasurement(variables[key], false);
                measures[key[0]] = m;
                table[key[0]] = m.Type;
            }
            IFormulaObjectCreator creator = VariableDetector.GetCreator(table);
            f = f.FullTransform(null);
            tree = ObjectFormulaTree.CreateTree(f, creator);
            arg = new ElementaryObjectArgument();
            arg.Add(tree);
            this.variables = variables;
        }
    
        #endregion

     }
}
