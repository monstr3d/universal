using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

using BaseTypes;
using BaseTypes.Interfaces;

using FormulaEditor.Collections;
using FormulaEditor.Interfaces;
using FormulaEditor.Symbols;


namespace FormulaEditor
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    public static class StaticExtensionFormulaEditor
    {

        #region Fields

        /// <summary>
        ///  checks value
        /// </summary>
        private static Func<object, bool> checkValue = (object o) =>
            {
                return o == null;
            };


        static List<string> additionalFormulas = new List<string>();

        static List<string> properties = new List<string>();

        static event Action<ITreeCollection, object> onCreateProxy = (ITreeCollection c, object ob) => { };

        static IOperationSeparator operationSeparator = new OperationSeparatorCollection();


        #endregion

        #region Ctor

        static StaticExtensionFormulaEditor()
        {
            "orderby".AddAdditionalFormula();
            "where".AddAdditionalFormula();
            "average".AddAdditionalFormula();
            "IndexOf".AddAdditionalFormula();
            MathSymbolFactory.Sizes = new int[] { 15, 11, 9, 6 };
            loadFormulaResources();
            ObjectFormulaTree.Creator = 
                new FormulaArrayObjectCreator(ElementaryFunctionsCreator.Object);
            ElementaryFunctionOperation.InitDeri();
            ElementaryIntegerOperation.Prepare();
            ParallelCount = 0;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Initialization
        /// </summary>
        static public void Init()
        {

        }


        /// <summary>
        /// String representation of formulae
        /// </summary>
        /// <param name="formulae">The formulae</param>
        /// <returns>The string representation of formulae</returns>
        public static IEnumerable<string> ToStringEnumerable(this IEnumerable<MathFormula> formulae)
        {
            foreach (var formula in formulae)
            {
                yield return formula.FormulaString;
            }
        }

        /// <summary>
        /// Transformation of array of trees
        /// </summary>
        /// <param name="trees">Trees</param>
        /// <returns>Transformation result</returns>
        static public ObjectFormulaTree[] Transform(this ObjectFormulaTree[] trees)
        {
            return ObjectFormulaTree.CreateList(trees,
                new List<ObjectFormulaTree>()).ToArray();
        }

        /// <summary>
        /// Factory of parallel calculations
        /// </summary>
        public static IParallelFactory ParallelFactory
        {
            get;
            set;
        }


        /// <summary>
        /// Count of parallel opetations
        /// </summary>
        static public int ParallelCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets unary parallel operation
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="operation">Prototype</param>
        /// <returns>The parallel operation</returns>
        static public IObjectOperation GetUnaryParallel(object type, IObjectOperation operation)
        {
            if (ParallelFactory != null)
            {
                if (ParallelCount > 0)
                {
                    return ParallelFactory.GetUnary(type, operation);
                }
            }
            return null;
        }

        /// <summary>
        /// Get dynamical binary left parallel operation
        /// </summary>
        /// <param name="typeLeft">Type of left part</param>
        /// <param name="typeRight">Type of right part</param>
        /// <param name="operation">Prototype</param>
        /// <returns>The parallel operation</returns>
        public static IObjectOperation GetDynamicalBinaryLeft(object typeLeft, 
            object typeRight, IObjectOperation operation)
        {
            if (ParallelFactory != null)
            {
                if (ParallelCount > 0)
                {
                    return ParallelFactory.GetDynamicalBinaryLeft(typeLeft, typeRight, operation);
                }
            }
            return null;
        }

        /// <summary>
        /// Get dynamical binary right parallel operation
        /// </summary>
        /// <param name="typeLeft">Type of left part</param>
        /// <param name="typeRight">Type of right part</param>
        /// <param name="operation">Prototype</param>
        /// <returns>The parallel operation</returns>
        public static IObjectOperation GetDynamicalBinaryRight(object typeLeft,
            object typeRight, IObjectOperation operation)
        {
            if (ParallelFactory != null)
            {
                if (ParallelCount > 0)
                {
                    return ParallelFactory.GetDynamicalBinaryRight(typeLeft, typeRight, operation);
                }
            }
            return null;
        }

        /// <summary>
        /// Adds a separator
        /// </summary>
        /// <param name="separator"></param>
        static public void Add(this IOperationSeparator separator)
        {
            (operationSeparator as OperationSeparatorCollection).Add(separator);
        }

        /// <summary>
        /// Gets a separator
        /// </summary>
        /// <param name="operation">An opreation</param>
        /// <returns>The separator of the operation</returns>
        public static string[] GetSepatator(this IObjectOperation operation)
        {
            return operationSeparator[operation];
        }

        /// <summary>
        /// Creates Proxy event
        /// </summary>
        static public event Action<ITreeCollection, object> OnCreateProxy
        {
            add { onCreateProxy += value; }
            remove { onCreateProxy -= value; }
        }

        /// <summary>
        /// Create proxy add
        /// </summary>
        /// <param name="collection">Collection of trees</param>
        /// <param name="obj">The object</param>
        public static void CreateProxy(this ITreeCollection collection, object obj)
        {
            onCreateProxy(collection, obj);
        }

        /// <summary>
        /// Checks whether a tree has a fiction
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>True if operation has fictoin</returns>
        static public bool HasFiction(this ObjectFormulaTree tree)
        {
            if (tree == null)
            {
                return true;
            }
            IObjectOperation op = tree.Operation;
            if (op == null)
            {
                return true;
            }
            if (StaticExtensionBaseTypes.HasAttributeBT<Attributes.FictionAttribute>(op))
            {
                return true;
            }
            for (int i = 0; i < tree.Count; i++)
            {
                if (tree[i].HasFiction())
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Checks whether a collection of trees has a fiction
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <returns>True if operation has fictoin</returns>
        public static bool HasFiction(this ITreeCollection collection)
        {
           ObjectFormulaTree[] trees = collection.Trees;
            foreach (ObjectFormulaTree tree in trees)
            {
                if (tree.HasFiction())
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Transformation of properties
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        static public MathFormula TransformPropery(this MathFormula formula)
        {
            MathFormula form = new MathFormula(formula.Level, formula.Sizes);
            int n = formula.Count;
            for (int i = 0; i < n; i++)
            {
                MathSymbol s = formula[i].Copy();
                List<MathFormula> c = s.Children;
                if (i < n + 2)
                {
                    MathSymbol p = formula[i + 1];
                    MathSymbol pn = formula[i + 2];
                    if (p.Symbol == '.')
                    {
                        s = new PropertySymbol(s.String, p.String);
                    }
                    
                }
                s.Parent = form;
                form.Add(s);
            }
            return form;

        }

        /// <summary>
        /// Adds additional formula
        /// </summary>
        /// <param name="add">Added formula</param>
        static public void AddAdditionalFormula(this string add)
        {
            if (!additionalFormulas.Contains(add))
            {
                additionalFormulas.Add(add);
            }
        }

        /// <summary>
        /// Adds additional property
        /// </summary>
        /// <param name="property">Added property</param>
        static public void AddProperty(this string property)
        {
            if (!properties.Contains(property))
            {
                properties.Add(property);
            }
        }


        /// <summary>
        /// Additional formulas
        /// </summary>
        static public List<string> AdditionalFormulas
        {
            get
            {
                return additionalFormulas;
            }
        }

        /// <summary>
        /// Proprerties
        /// </summary>
        static public List<string> Properties
        {
            get
            {
                return properties;
            }
        }

        /// <summary>
        /// Factory of proxy
        /// </summary>
        static private ITreeCollectionProxyFactory Factory
        {
            get;
            set;
        }

        /// <summary>
        /// Creator factory
        /// </summary>
        static public CreatorOfCrerator CreatorFactory
        {
            get;
            set;
        } = CreatorOfCrerator.Instance;

        static public ITreeCollectionCodeCreator TreeCollectionCodeCreator
        {
            get;
            set;
        }

        /// <summary>
        /// Checks value
        /// </summary>
        public static Func<object, bool> CheckValue
        {
            get
            {
                return checkValue;
            }
            set
            {
                checkValue = value;
            }
        }



        /// <summary>
        /// Should check value in genetated code
        /// </summary>
        public static bool ShouldCheckValueInGeneratedCode
        { get; set; }

        /// <summary>
        /// Creates proxy from tree collection
        /// </summary>
        /// <param name="collection">Tree collection</param>
        /// <returns>Proxy</returns>
        public static ITreeCollectionProxy CreateProxy(this ITreeCollection collection)
        {
            ITreeCollectionProxyFactory factory;
            if (collection is ITreeCollectionProxyFactory)
            {
                factory = collection as ITreeCollectionProxyFactory;
            }
            else
            {
                factory = Factory;
            }
            if (factory == null)
            {
                return null;
            }
            return factory.CreateProxy(collection, checkValue);
        }


        /// <summary>
        /// Creates tree collection from trees
        /// </summary>
        /// <param name="trees">Trees</param>
        /// <returns>Collection</returns>
        public static ITreeCollection CreateCollection(this ObjectFormulaTree[] trees)
        {
            return new SimpleTreeCollection(trees);
        }

        /// <summary>
        /// Creates proxy from trees
        /// </summary>
        /// <param name="trees">Trees</param>
        /// <returns>Proxy</returns>
        public static ITreeCollectionProxy CreateProxy(this ObjectFormulaTree[] trees)
        {
            return trees.CreateCollection().CreateProxy();
        }

        /// <summary>
        /// Simplification of collection of trees
        /// </summary>
        /// <param name="trees">Trees</param>
        /// <param name="comparer">Comparer</param>
        /// <returns>Trees</returns>
        public static List<ObjectFormulaTree> Simplify(this List<ObjectFormulaTree> trees, IEqualityComparer<ObjectFormulaTree> comparer)
        {
            ObjectFormulaTree.Simplify(trees, comparer);
            return trees;
        }

        /// <summary>
        /// Calculates derivation tree
        /// </summary>
        /// <param name="tree">Tree to calculate</param>
        /// <param name="variableName">Name of variable</param>
        /// <returns>Tree of derivation</returns>
        static public ObjectFormulaTree Derivation(this ObjectFormulaTree tree, string variableName)
        {
            if (tree.Operation is IDerivationOperation)
            {
                IDerivationOperation op = tree.Operation as IDerivationOperation;
                return op.Derivation(tree, variableName);
            }
            if (ElementaryBinaryOperation.IsInteger(tree.Operation.ReturnType))
            {
                ElementaryRealConstant op = new ElementaryRealConstant(0);
                return new ObjectFormulaTree(op, new List<ObjectFormulaTree>());
            }
            if (tree.Operation is OptionalOperation)
            {
                OptionalOperation op = tree.Operation as OptionalOperation;
                op = op.Clone() as OptionalOperation;
                List<ObjectFormulaTree> list = new List<ObjectFormulaTree>();
                list.Add(tree[0]);
                for (int i = 1; i < 3; i++)
                {
                    list.Add(tree[i].Derivation(variableName));
                }
                return new ObjectFormulaTree(op, list);
            }
            return null;
        }

        /// <summary>
        /// The "is dynamical array detection"
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>True if type is dynamical array</returns>
        static public bool IsDynamicalArray(this object type)
        {
            if (type is ArrayReturnType)
            {
                ArrayReturnType t = type as ArrayReturnType;
                if (t.Dimension.Length == 1)
                {
                    return t.Dimension[0] == -1;
                }
            }
            return false;
        }


        #endregion

        #region Internal Members

        static internal IObjectOperation GetObjectOperation(this object obj, string name)
        {
            IObjectOperation op = PropertyOperation.GetPropertyOperation(obj, name);
            if (op != null)
            {
                return op;
            }
            return FieldOperation.GetFieldOperation(obj, name);
        }

        static internal IEnumerable<double> ToDouble(this IEnumerable<object> o)
        {
            foreach (object ob in o)
            {
                yield return (double)ob;
            }
        }

        static internal IEnumerable<float> ToSingle(this IEnumerable<object> o)
        {
            foreach (object ob in o)
            {
                yield return (float)ob;
            }
        }


        #endregion

        #region Private Members

        static void loadFormulaResources()
        {
            string[,] contents = new string[,]{
                { "s", "sin" },
                { "c", "cos" },
                { "l", "ln" },
                { "u", "lg" },
                { "e", "exp" },
                { "t", "tg" },
                { "q", "ctg"},
                { "a", "arctg" },
                { "b", "arcctg"},
                { "j", "sec" },
                { "k", "cosec" },
                { "f", "arcsin" },
                { "g", "arccos" },
                { "v", "arctg" },
                {"w", "time"},
                {"o", "DateTimeToDay"},
                {"atan2", "atan2"},
                {"'", "d/dt"},

                { ".", "" + System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator },
                { "×", "×" },
                { "+", "+" },
                { "-", "-" },
                { "*", "\u2219" },
                { "/", "/" }, //inline division
                { "﹪", "%" }, //modulo division

                                                      {"\u2260", "\u2260"},	//NE
                                                      {"\u2264", "\u2264"}, //LE
                                                      {"\u2265", "\u2265"}, //GE
                                                      {"\u2217", "OR"}, //Dis
                                                      {"\u2216", "AND"}, //Con
                                                      {"\u8835", "=>"}, // Implication
                                                      {"\u2270", "LIKE"},
                                                      {"¬", "¬"},
                                                      {"~", "~"},
                                                      {"=", "="},
                                                      {">", ">"},
                                                      {"<", "<"},
                                                      {"?", "?"},
                                                      {":", ":"},
                                                      {"&", "&"},
                                                      {"|", "|"},
                                                      {"\u2266", "<<"},
                                                      {"\u2267", ">>"},
                                                      {"^", "^"},
                { "(", "(" },
                { ")", ")" },
                { "1", "1" },
                { "2", "2" },
                { "3", "3" },
                { "4", "4" },
                { "5", "5" },
                { "6", "6" },
                { "7", "7" },
                { "8", "8" },
                { "9", "9" },
                { "0", "0" },
                {"\u2211", "\u2211"},
                {"\u03B4", "\u03B4"},
                {"\u0442", "\u0442"}
                };
            MathFormula.Resources = new Dictionary<string, string>();
            for (int i = 0; i < contents.GetLength(0); i++)
            {
                MathFormula.Resources[contents[i, 0]] = contents[i, 1];
            }
        }

        #endregion

        #region Helper Class


        class SimpleTreeCollection : ITreeCollection
        {
            #region Fields

            private ObjectFormulaTree[] trees;


            #endregion

            #region Ctor

            internal SimpleTreeCollection(ObjectFormulaTree[] trees)
            {
                this.trees = trees;
            }

            #endregion

            ObjectFormulaTree[] ITreeCollection.Trees
            {
                get { return trees; }
            }

            bool ITreeCollection.IsValid
            {
                get
                {
                    return true;
                }
            }

        }

        #endregion

        #region Internal XML Members

        internal static string ToLongDateString(this DateTime dateTime)
        {
            return "";
        }

        internal static string ToLongTimeString(this DateTime dateTime)
        {
            return "";
        }

        /// <summary>
        /// Gets elements by tag name
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="tag">Tag</param>
        /// <returns>Elements</returns>
        internal static IEnumerable<XElement> GetElementsByTagName(this XElement element, string tag)
        {
            return element.Elements(XName.Get(tag));
        }



        /// <summary>
        /// Gets First element by tag name
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="tag">Tag</param>
        /// <returns>The first element</returns>
        internal static XElement GetFirst(this XElement element, string tag)
        {
            IEnumerable<XElement> c = element.GetElementsByTagName(tag);
            foreach (XElement e in c)
            {
                return e;
            }
            return null;
        }

        /// <summary>
        /// Gets First element by tag name
        /// </summary>
        /// <param name="element">Element</param>
        /// <returns>The first element</returns>
        internal static XElement GetFirst(this XElement element)
        {
            IEnumerable<XElement> c = element.GetChildNodes();
            foreach (XElement e in c)
            {
                return e;
            }
            return null;
        }




        /// <summary>
        /// Gets attribute
        /// </summary>
        /// <param name="element">Element</param>
        /// <param name="name">Name</param>
        /// <returns>Attribute</returns>
        internal static string GetAttribute(this System.Xml.Linq.XElement element, string name)
        {
            XAttribute attr = element.Attribute(System.Xml.Linq.XName.Get(name));
            if (attr == null)
            {
                return "";
            }
            return attr.Value;
        }

        /// <summary>
        /// Creates XElement
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <returns>The element</returns>
        internal static XElement CreateXElement(string tag)
        {
            return XElement.Parse("<" + tag + "/>");
        }

        /// <summary>
        /// Creates XElement
        /// </summary>
        /// <param name="tag">The tag</param>
        /// <param name="obj">The object</param>
        /// <returns>The element</returns>
        internal static XElement CreateXElement(this object obj, string tag)
        {
            XElement e = CreateXElement(tag);
            if (obj is XElement)
            {
                (obj as XElement).Add(e);
            }
            return e;
        }

        /// <summary>
        /// Gets child nodes
        /// </summary>
        /// <param name="element">Element</param>
        /// <returns>Child nodes</returns>
        internal static IEnumerable<XElement> GetChildNodes(this XElement element)
        {
            IEnumerable<XElement> c = element.Elements();
            return c;
        }

        static internal bool IsDBNull(this object obj)
        {
            return false;
        }


        /// <summary>
        /// Converts object to type info
        /// </summary>
        /// <param name="ob"></param>
        /// <returns>Type info</returns>
        internal static TypeInfo ToTypeInfo(this object ob)
        {
            return IntrospectionExtensions.GetTypeInfo(ob.GetType());
        }

        /// <summary>
        /// Gets attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static T GetAttribute<T>(this object obj) where T : Attribute
        {
            return CustomAttributeExtensions.GetCustomAttribute<T>(obj.ToTypeInfo());
        }

        #endregion

    }
}
