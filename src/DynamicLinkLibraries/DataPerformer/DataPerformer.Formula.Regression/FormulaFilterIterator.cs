using CategoryTheory;

using Diagram.UI;

using FormulaEditor.Interfaces;
using FormulaEditor;

using Regression.Portable;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using BaseTypes.Interfaces;
using FormulaEditor.Symbols;
using Diagram.UI.Interfaces;
using Diagram.UI.Aliases;

namespace DataPerformer.Formula.Regression

{
    /// <summary>
    /// Formula iterator for filter
    /// </summary>
    public class FormulaFilterIterator : FilterIterator, ICategoryObject, IPostSetArrow, 
        IVariableDetector, IAlias
    {
        #region Fields

        event Action<IAlias, string> onChange;

        /// <summary>
        /// Associated object
        /// </summary>
        protected object? obj = null;

        ObjectFormulaTree tree;

        protected Dictionary<string, string> variables = new Dictionary<string, string>();

        protected Dictionary<string, object> constants = new Dictionary<string, object>();

        Dictionary<char, IMeasurement> measurements = new Dictionary<char, IMeasurement>();

        /// <summary>
        /// Formula arguments
        /// </summary>
        private ElementaryObjectArgument arg = new ElementaryObjectArgument();

        /// <summary>
        /// Dictionary of acceptors
        /// </summary>
        private Dictionary<string, IOperationAcceptor> acceptors = new Dictionary<string, IOperationAcceptor>();

        protected string formula = "";

        IAlias alias;

        IFormulaObjectCreator creator;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FormulaFilterIterator()
        {
            alias = this;
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
            PostAlias();
        }

        #endregion

        #region IVariableDetector Members

        IOperationAcceptor IVariableDetector.Detect(MathSymbol symbol)
        {
            string key = symbol.String;
            if (key.Length > 1)
            {
                return null;
            }
            if (!(symbol is SimpleSymbol))
            {
                return null;
            }
            SimpleSymbol ss = symbol as SimpleSymbol;
            if (!ss.Italic)
            {
                return null;
            }
            if (acceptors.ContainsKey(key))
            {
                return acceptors[key];
            }
            return VariableDetector.Detect(symbol, acceptors);
        }

        #endregion

        #region IAlias Members

        object IAlias.this[string name] { get => constants[name]; set => constants[name] = value; }

        IList<string> IAlias.AliasNames => constants.Keys.ToList();

        event Action<IAlias, string> IAlias.OnChange
        {
            add
            {
               onChange += value;
            }

            remove
            {
                onChange -= value;
            }
        }

        object IAlias.GetType(string name)
        {
            return AliasTypeDetector.Detector.DetectType(alias[name]);
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
                foreach (char c in measurements.Keys)
                {
                    arg[c] = measurements[c].Parameter();
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
                foreach (var s in constants.Keys)
                {
                    onChange?.Invoke(this, s);
                }
            }
        }

        #region Private Members

        void Set(Dictionary<string, string> variables)
        {
            MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, formula);
            measurements.Clear();
         /*   TABLE DELETE
          *   Dictionary<char, object> table = new Dictionary<char, object>();
            foreach (string key in variables.Keys)
            {
                IMeasurement m = this.FindMeasurement(variables[key], false);
                measurements[key[0]] = m;
                table[key[0]] = m.Type;
            }
         */ 
            IFormulaObjectCreator creator = VariableDetector.GetCreator(this);
            f = f.FullTransform(null);
            tree = ObjectFormulaTree.CreateTree(f, creator);
            arg = new ElementaryObjectArgument();
            arg.Add(tree);
            this.variables = variables;
        }

        void PostAlias()
        {
            string argStr = AllVariables;
            foreach (string key in constants.Keys)
            {
                if (!acceptors.ContainsKey(key))
                {
                    acceptors[key] = new AliasNameVariable(key, this, key);
                }
            }

        }

        

        #endregion

        #endregion

    }
}