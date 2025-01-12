using CompilerBridge;
using ExtendedFormulaEditor;
using FormulaEditor;
using FormulaEditor.Compiler;
using System.Xml;

namespace TestProjectFormulaEditor
{
    public class Tests
    {

        #region Fields


        static bool loaded = false;

        MathFormula[] formulae;

        static int[] sizes = new int[4];




        #endregion


        static Tests()
        {

            /*    if (loaded)
                {
                    return;
                }*/
            StaticExtensionComplerBridge.Init(null);
            StaticExtensionFormulaEditorCompiler.Init(null);
            loadFormulaResources();
  
        }


        [SetUp]
        public void Setup()
        {
        }

 /*
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
*/
        /// <summary>
        /// Test of bool binary
        /// </summary>
        [Test]
        public void TestMethodBinaryBool()
        {
            bool type = false;
            Dictionary<string, object> d = new Dictionary<string, object>()
            {
                {"a", type},
                {"b", type}
            };
            FormulaEditor.VariableDetectors.ExtendedDictionaryVariableDetector det =
                new FormulaEditor.VariableDetectors.ExtendedDictionaryVariableDetector(d);
            FormulaEditor.Interfaces.IFormulaObjectCreator cr = det.GetCreator();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.BinaryLogical);
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            XmlNodeList nl = doc.DocumentElement.ChildNodes;
            foreach (XmlElement e in nl)
            {
                MathFormula f = MathFormula.FromString(sizes, e.OuterXml);
                ObjectFormulaTree tree = ObjectFormulaTree.CreateTree(f.FullTransform(null), cr);
                l.Add(tree);
            }
            l = l.Simplify(new FormulaEditor.Comparers.ObjectFormulaTreeEqualityComparer(new FormulaEditor.Comparers.ElementaryOperationComparer()));
            Dictionary<Func<bool, bool, bool>, object[]> dic = new Dictionary<Func<bool, bool, bool>, object[]>()
            {
                {(bool x, bool y) => { return x & y;} , new object[]{new object[] {"AND",  l[0]}}},
                {(bool x, bool y) => { return x | y;} , new object[]{new object[] {"OR",  l[1]}}},
                {(bool x, bool y) => { return !x | y;} , new object[]{new object[] {"=>",  l[2]}}},
            };
            FormulaEditor.Interfaces.ITreeCollectionProxy proxy = l.ToArray().CreateProxy();
            bool[] bar = new bool[] { true, false };

            foreach (Func<bool, bool, bool> func in dic.Keys)
            {
                object[] o = dic[func];
                foreach (object[] ob in o)
                {
                    ObjectFormulaTree tree = ob[1] as ObjectFormulaTree;
                    string fs = ob[0] + "";
                    Func<object> g = proxy[tree];
                    foreach (bool x in bar)
                    {
                        det["a"] = x;
                        foreach (bool y in bar)
                        {
                            det["b"] = y;
                            bool a = func(x, y);
                            object b = tree.Result;
                            Assert.That(a.Equals(b));
                            proxy.Update();
                            object c = g();
                            Assert.That(a.Equals(c));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Test of double binary
        /// </summary>
        [Test]
        public void TestMethodBinaryDouble()
        {
            double type = 0;
            Dictionary<string, object> d = new Dictionary<string, object>()
            {
                {"x", type},
                {"y", type}
            };
            FormulaEditor.VariableDetectors.ExtendedDictionaryVariableDetector det =
                new FormulaEditor.VariableDetectors.ExtendedDictionaryVariableDetector(d);
            FormulaEditor.Interfaces.IFormulaObjectCreator cr = det.GetCreator();
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(Properties.Resources.BinaryDouble);             // Reading of formulae from XML file
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            XmlNodeList nl = doc.DocumentElement.ChildNodes;
            foreach (XmlElement e in nl)
            {
                MathFormula f = MathFormula.FromString(sizes, e.OuterXml);   // Creation of formula objects
                ObjectFormulaTree tree = ObjectFormulaTree.CreateTree(f.FullTransform(null), cr);
                l.Add(tree);
            }
            Dictionary<Func<double, double, double>, object[]> dic = new Dictionary<Func<double, double, double>, object[]>()   // Dictionary of tested
            {                                                                                                                   // binary functions
                {(double x, double y) => { return x + y;} , new object[]{new object[] {"plus",  l[0]}}},
                {(double x, double y) => { return x - y;} , new object[]{new object[] {"minus",  l[1]}}},
                {(double x, double y) => { return x * y;} , new object[]{new object[] {"mult1",  l[2]}, new object[] {"mult2",  l[3]}}},
                {(double x, double y) => { return x / y;} , new object[]{new object[] {"frac",  l[4]}}},
                {Math.Pow , new object[]{new object[] {"pow",  l[5]}}},
                {Math.Atan2 , new object[]{new object[] {"atan2",  l[6]}}},
            };
            FormulaEditor.Interfaces.ITreeCollectionProxy proxy = l.ToArray().CreateProxy();                        // Creation of proxy code
            foreach (Func<double, double, double> func in dic.Keys)
            {
                object[] o = dic[func];
                foreach (object[] ob in o)
                {
                    ObjectFormulaTree tree = ob[1] as ObjectFormulaTree;
                    string fs = ob[0] + "";
                    Func<object> g = proxy[tree];                                       // Proxy functions
                    for (int i = 0; i < 10; i++)
                    {
                        double x = 0.007 + 0.07 * i;
                        det["x"] = x;
                        for (int j = 0; j < 10; j++)
                        {
                            double y = 0.34 + 0.031 * j;
                            det["y"] = y;
                            double a = func(x, y);                                      // Calculation of functions
                            object b = tree.Result;                                     // Calculation of tree
                            Assert.That(a.Equals(b));
                            proxy.Update();
                            object c = g();
                            Assert.That(a.Equals(c));
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Test of ternary operations
        /// </summary>
        [Test]
        public void TestMethodTernaryDouble()
        {
            double type = 0;
            Dictionary<string, object> d = new Dictionary<string, object>()
            {
                {"x", type},
                {"y", type},
                {"z", type}
            };
            FormulaEditor.VariableDetectors.ExtendedDictionaryVariableDetector det =
                new FormulaEditor.VariableDetectors.ExtendedDictionaryVariableDetector(d);
            FormulaEditor.Interfaces.IFormulaObjectCreator cr = det.GetCreator();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.TernaryDouble);
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            XmlNodeList nl = doc.DocumentElement.ChildNodes;
            foreach (XmlElement e in nl)
            {
                MathFormula f = MathFormula.FromString(sizes, e.OuterXml);
                ObjectFormulaTree tree = ObjectFormulaTree.CreateTree(f.FullTransform(null), cr);
                l.Add(tree);
            }
            l = l.Simplify(new FormulaEditor.Comparers.ObjectFormulaTreeEqualityComparer(new FormulaEditor.Comparers.ElementaryOperationComparer()));
            Dictionary<Func<double, double, double, double>, object[]> dic = new Dictionary<Func<double, double, double, double>, object[]>()
            {
             {(double x, double y, double z) => { return ((x > y) & (y < z)) | z > 9 ? x * y * z : Math.Pow(Math.Sin(x), 2) * Math.Pow(Math.Cos(y), 3) * Math.Atan(z);;} , new object[]{"1",  l[0]}},
             {(double x, double y, double z) => { return (x * y) > z ? Math.Pow(x, 6) * y * z:  5 * x * Math.Pow(Math.Cos(y), 3) * Math.Pow(z, 2) ;} , new object[]{"2",  l[1]}},
             {(double x, double y, double z) => { return y < z ? Math.Pow(z, 5) : Math.Pow(y, 3) * Math.Pow(x, 8) * Math.Pow(Math.E, -Math.PI * Math.Pow(x, 2)) ;} , new object[]{"2",  l[2]}},
             {(double x, double y, double z) => { return x > y & x < z ? x * y * z : Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2);} , new object[]{"4",  l[3]}}
            };
            FormulaEditor.Interfaces.ITreeCollectionProxy proxy = l.ToArray().CreateProxy();
            foreach (Func<double, double, double, double> func in dic.Keys)
            {
                object[] o = dic[func];
                ObjectFormulaTree tree = o[1] as ObjectFormulaTree;
                string fs = o[0] + "";
                Func<object> g = proxy[tree];
                for (int i = 0; i < 10; i++)
                {
                    double x = -5 + 0.5 * i;
                    det["x"] = x;
                    for (int j = 0; j < 10; j++)
                    {
                        double y = -5 + 0.5 * j;
                        det["y"] = y;
                        for (int k = 0; k < 10; k++)
                        {
                            double z = -5 + 0.5 * k;
                            det["z"] = z;
                            double a = func(x, y, z);
                            object b = tree.Result;
                            Assert.That(a.Equals(b));
                            proxy.Update();
                            object c = g();
                            Assert.That(a.Equals(c));
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Test of double binary
        /// </summary>
        [Test]
        public void TestMethodDerivations()
        {
            double type = 0;
            Dictionary<string, object> d = new Dictionary<string, object>()
            {
                {"x", type},
                {"y", type},
                {"t", type}
            };
            FormulaEditor.VariableDetectors.ExtendedDictionaryVariableDetector det =
                new FormulaEditor.VariableDetectors.ExtendedDictionaryVariableDetector(d);
            FormulaEditor.Interfaces.IFormulaObjectCreator cr = det.GetCreator(
                new FormulaEditor.Interfaces.IOperationDetector[] { new DerivationDetector("d/dt", "d/dt") }, 
                new FormulaEditor.Interfaces.IBinaryDetector[] { });
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.DerivationsCalc);
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            XmlNodeList nl = doc.DocumentElement.ChildNodes;
            foreach (XmlElement e in nl)
            {
                MathFormula f = MathFormula.FromString(sizes, e.OuterXml);
                ObjectFormulaTree tree = ObjectFormulaTree.CreateTree(f.FullTransform(null), cr);
                l.Add(tree);
            }
            Dictionary<Func<double, double, double, double>, object[]> dic = new Dictionary<Func<double, double, double, double>, object[]>()
            {
            /* {(double t, double x, double y) => 
             
             
    { return Math.Pow(t, 2) * (Math.Sin(x * t) * Math.Pow(Math.Cos(t), Math.Sin(x * t) - 1) - Math.Sin(t) +
        Math.Log(Math.Cos(t)) * Math.Pow(Math.Cos(t), Math.Sin(x * t)) * Math.Cos(x * t) * x)
        + Math.Pow(Math.Cos(t), Math.Sin(x * t)) * 2 * t * t;} , new object[]{"1",  l[0]}},
            };*/
         /*     {(double t, double x, double y) => 
             
             
    { return (Math.Sin(x * t) * Math.Pow(Math.Cos(t), Math.Sin(x * t) - 1) * (-Math.Sin(t)) +
        Math.Log(Math.Cos(t)) * Math.Pow(Math.Cos(t), Math.Sin(x * t)) * Math.Cos(x * t) * x);
       }//*/{ F , new object[]{"1",  l[0]}},
            };
            l = l.Simplify(new FormulaEditor.Comparers.ObjectFormulaTreeEqualityComparer(new FormulaEditor.Comparers.ElementaryOperationComparer()));
            FormulaEditor.Interfaces.ITreeCollectionProxy proxy = l.ToArray().CreateProxy();
            foreach (Func<double, double, double, double> func in dic.Keys)
            {
                object[] o = dic[func];
                ObjectFormulaTree tree = o[1] as ObjectFormulaTree;
                string fs = o[0] + "";
                Func<object> g = proxy[tree];
                for (int i = 0; i < 10; i++)
                {
                    double t = 5 + 0.5 * i;
                    det["t"] = t;
                    for (int j = 0; j < 10; j++)
                    {
                        double x = 5 + 0.5 * j;
                        det["x"] = x;
                        for (int k = 0; k < 10; k++)
                        {
                            double y = 5 + 0.5 * k;
                            det["y"] = y;
                            double a = func(t, x, y);
                            double b = (double)tree.Result;
                            Assert.AreEqual(a, b, 1e-15);
                            proxy.Update();
                            object c = g();
                            Assert.AreEqual(b, c);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// Test of formula
        /// </summary>
        [Test]
        public void TestMethodFirst()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.Formulas);
            List<MathFormula> l = new List<MathFormula>();
            XmlNodeList nl = doc.DocumentElement.ChildNodes;
            foreach (XmlElement e in nl)
            {
                MathFormula f = MathFormula.FromString(sizes, e.OuterXml);
                l.Add(f.FullTransform(null));
            }
            formulae = l.ToArray();

            double type = 0;
            Dictionary<string, object> d = new Dictionary<string, object>()
            {
                {"a", type},
                {"b", type}
            };
            FormulaEditor.VariableDetectors.ExtendedDictionaryVariableDetector det =
                new FormulaEditor.VariableDetectors.ExtendedDictionaryVariableDetector(d);
            FormulaEditor.Interfaces.IFormulaObjectCreator cr = det.GetCreator();
            ObjectFormulaTree tree = ObjectFormulaTree.CreateTree(formulae[0], cr);
            FormulaEditor.Interfaces.ITreeCollectionProxy proxy = (new ObjectFormulaTree[] { tree }).CreateProxy();
            Func<object> g = proxy[tree];
            for (int i = 0; i < 10; i++)
            {
                double a = 0.5 + 2.7 * i;
                for (int j = 0; j < 20; j++)
                {
                    double b = 0.7 + 5.4 * j;
                    det["a"] = a;
                    det["b"] = b;
                    object x = (double)tree.Result;
                    double y = Formula_1(a, b);
                    proxy.Update();
                    object z = g();
                    Assert.That(x.Equals(y));
                    Assert.That(y.Equals(z));
                 }
            }
        }

        /// <summary>
        /// Test of double unary
        /// </summary>
        [Test]
        public void TestMethodUnaryDouble()
        {
            double type = 0;
            Dictionary<string, object> d = new Dictionary<string, object>()
            {
                {"x", type}
            };
            FormulaEditor.VariableDetectors.ExtendedDictionaryVariableDetector det =
                new FormulaEditor.VariableDetectors.ExtendedDictionaryVariableDetector(d);
            FormulaEditor.Interfaces.IFormulaObjectCreator cr = det.GetCreator();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.UnaryDouble);
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            XmlNodeList nl = doc.DocumentElement.ChildNodes;
            foreach (XmlElement e in nl)
            {
                MathFormula f = MathFormula.FromString(sizes, e.OuterXml);
                ObjectFormulaTree tree = ObjectFormulaTree.CreateTree(f.FullTransform(null), cr);
                l.Add(tree);
            }
            Dictionary<Func<double, double>, object[]> dic = new Dictionary<Func<double, double>, object[]>()
            {
                {Math.Sin , new object[]{new object[] {"sin1",  l[0]}, new object[] {"sin2",  l[1]}, new object[] {"sin3",  l[2]}}},
                {Math.Cos , new object[]{new object[] {"cos1",  l[3]}, new object[] {"cos2",  l[4]}, new object[] {"cos3",  l[5]}}},
                {Math.Log , new object[]{new object[] {"ln1",  l[6]}, new object[] {"ln2",  l[7]}, new object[] {"ln3",  l[8]}}},
                {Math.Exp , new object[]{new object[] {"exp1",  l[9]}, new object[] {"exp2",  l[10]}, new object[] {"exp3",  l[11]}}},
                {(double x) => { return Math.Pow(Math.E, x);}, new object[]{new object[] {"e^x",  l[12]}}},
                {Math.Tan , new object[]{new object[] {"tg1",  l[13]}, new object[] {"tg2",  l[14]}, new object[] {"tg3",  l[15]}}},
                {(double x) => { return Math.Tan( Math.PI / 2 - x);} , new object[]{new object[] {"ctg1",  l[16]}, new object[] {"ctg2",  l[17]}, new object[] {"ctg3",  l[18]}}},
                {Math.Atan , new object[]{new object[] {"atan1",  l[19]}, new object[] {"atan2",  l[20]}, new object[] {"atan3",  l[21]}}},
                {(double x) => { return Math.PI / 2 - Math.Atan(x);}, new object[]{new object[] {"acot1",  l[22]}, new object[] {"acot2",  l[23]}, new object[] {"acot3",  l[24]}}},
                {(double x) => { return 1 / Math.Cos(x);} , new object[]{new object[] {"sec1",  l[25]}, new object[] {"sec2",  l[26]}, new object[] {"sec3",  l[27]}}},
                {(double x) => { return 1 / Math.Sin(x);} , new object[]{new object[] {"cosec1",  l[28]}, new object[] {"cosec2",  l[29]}, new object[] {"cosec3",  l[30]}}},
                {Math.Asin , new object[]{new object[] {"asin1",  l[31]}, new object[] {"asin2",  l[32]}, new object[] {"asin3",  l[33]}}},
                {Math.Acos, new object[]{new object[] {"acos1",  l[34]}, new object[] {"acos2",  l[35]}, new object[] {"acos3",  l[36]}}},
               {(double x) => {return -x;}, new object[]{new object[] {"unary minus",  l[37]}}}
            };
            FormulaEditor.Interfaces.ITreeCollectionProxy proxy = l.ToArray().CreateProxy();
            foreach (Func<double, double> func in dic.Keys)
            {
                object[] o = dic[func];
                foreach (object[] ob in o)
                {
                    ObjectFormulaTree tree = ob[1] as ObjectFormulaTree;
                    string fs = ob[0] + "";
                    Func<object>  g = proxy[tree];
                    for (int i = 0; i < 10; i++)
                    {
                        double x = 0.007 + 0.07 * i;
                        det["x"] = x;
                        double a = func(x);
                        object b = tree.Result;
                        Assert.That(a.Equals(b));
                        proxy.Update();
                        object c = g();
                        Assert.That(a.Equals(c));
                    }
                }
            }
        }

        /// <summary>
        /// Test of double binary
        /// </summary>
        [Test]
        public void TestMethodNullaryDouble()
        {
            Dictionary<string, object> d = new Dictionary<string, object>()
            {
            };
            FormulaEditor.VariableDetectors.ExtendedDictionaryVariableDetector det =
                new FormulaEditor.VariableDetectors.ExtendedDictionaryVariableDetector(d);
            FormulaEditor.Interfaces.IFormulaObjectCreator cr = det.GetCreator();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.NullaryDouble);
            List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
            XmlNodeList nl = doc.DocumentElement.ChildNodes;
            foreach (XmlElement e in nl)
            {
                MathFormula f = MathFormula.FromString(sizes, e.OuterXml);
                ObjectFormulaTree tree = ObjectFormulaTree.CreateTree(f.FullTransform(null), cr);
                l.Add(tree);
            }
            double[] x = { 0, 1, 10.5, Math.PI, Math.E };
            FormulaEditor.Interfaces.ITreeCollectionProxy proxy = l.ToArray().CreateProxy();
            for (int i = 0; i < x.Length; i++)
            {
                ObjectFormulaTree tree = l[i] as ObjectFormulaTree;
                Func<object> g = proxy[tree];
                double a = x[i];
                object b = tree.Result;
                Assert.That(a.Equals(b));
                proxy.Update();
                object c = g();
                Assert.That(a.Equals(c));
            }
        }

        #region Private members

        private static void loadFormulaResources()
        {
      /*      if (loaded)
            {
                return;
            }*/
            loaded = true;
            MathFormula.Saver = StandardXmlFormulaSaver.Object;
            FormulaEditor.CSharp.CSharpTreeCollectionProxyFactory.CodeCreator =
                    FormulaEditor.CSharp.CSharpCodeCreator.CodeCreator;

            MathSymbolFactory.Sizes = sizes;
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
                {"o", "OADate"},
                {"atan2", "atan2"},
                {"'", "d/dt"},

                { ".", "" + System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator },
                { "×", "×" },
                { "+", "+" },
                { "-", "-" },
                { "*", "\u2219" },

                                                      {"\u2260", "\u2260"},	//NE
                                                      {"\u2264", "\u2264"}, //LE
                                                      {"\u2265", "\u2265"}, //GE
                                                      {"\u2217", "OR"}, //Dis
                                                      {"\u2216", "AND"}, //Con
                                                      {"\u8835", "=>"}, //Implication
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
            ObjectFormulaTree.Creator = new FormulaArrayObjectCreator(ElementaryFunctionsCreator.Object);
            ElementaryFunctionOperation.InitDeri();
            ElementaryIntegerOperation.Prepare();
        }



        private double F(double t, double x, double y)
        {
            double xt = x * t;
            double sinxt = Math.Sin(xt);
            double cost = Math.Cos(t);
            double deg = sinxt - 1;
            double pow = Math.Pow(cost, deg);
            double var_9 = sinxt * pow;
            double log = Math.Log(cost);
            double pow1 = Math.Pow(cost, sinxt);
            double sint = -Math.Sin(t);
            double var_14 = var_9 * sint;
            double var_17 = log * pow1;
            double var_19 = var_17 * Math.Cos(x * t);
            double var_20 = var_19 * x;
            return var_14 + var_20;


            //           return (- Math.Sin(x * t) * Math.Pow(Math.Cos(t), Math.Sin(x * t) - 1) * Math.Sin(t)+   Math.Log(Math.Cos(t)) * Math.Pow(Math.Cos(t), Math.Sin(x * t)) * Math.Cos(x * t) * x);
        }

        #endregion


        private double Formula_1(double a, double b)
        {
            return Math.Pow(a * Math.Sin(b), 2);
        }
    }

}
