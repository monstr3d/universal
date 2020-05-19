using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using Diagram.UI.Interfaces;
using Diagram.UI.XmlObjectFactory;
using Diagram.UI.Labels;

using FormulaEditor;
using FormulaEditor.Symbols;

using ControlSystems.Data;





namespace Simulink.Proxy.Factory
{
    class TransferFunctionFactory : SerializableTemplateObjectFactory
    {

        #region Fields

        static Dictionary<int, string>[] formulas = new Dictionary<int, string>[2];
        RationalTransformControlSystemData transform;
        #endregion

        #region Ctor

        internal TransferFunctionFactory(IDesktop desktop) : base(desktop, 
            Simulink.Parser.Library.SimulinkXmlParser.BlockType,
            Simulink.Parser.Library.SimulinkXmlParser.Name, 
            ResourceDesktop.TransferFcn)
        {
        }


        #endregion

        #region Overriden

        protected override IDesktop Pattern
        {
            get
            {
                IDesktop d = base.Pattern;
                foreach (IObjectLabel l in d.Objects)
                {
                    transform = l.Object as RationalTransformControlSystemData;
                    break;
                }
                Process();
                return d;
            }
        }

        #endregion

        #region Members

        void Process()
        {
            int[] k = new int[3];
            int[] deg = Simulink.Parser.Library.SimulinkXmlParser.TransformFuncDegree(element);
            MathFormula f = new MathFormula(3);
            f.Add(new FractionSymbol());
            MathSymbol s = f.First;
   //         MathFormula[] children = new MathFormula[2];
            List<MathFormula> children = new List<MathFormula>();
            for (int i = 0; i < 2; i++)
            {
                Dictionary<int, string> d = formulas[i];
                string fs = d[deg[i] -1];
                children.Add(MathFormula.FromString(k, fs));
            }
            s.Children = children;
            string sf = f.FormulaString;
            transform.CreateSystem(sf);
        }

        static TransferFunctionFactory()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(ResourceDesktop.TransferFcnMapping);
            XmlNodeList nl = doc.GetElementsByTagName("Polynoms");
            foreach (XmlElement e in nl)
            {
                Dictionary<int, string> form = new Dictionary<int, string>();
                string sa = e.GetAttribute("Type");
                int k = sa.Equals("Nominators") ? 0 : 1;
                formulas[k] = form;
                XmlNodeList ff = e.GetElementsByTagName("Formula");
                foreach (XmlElement ef in ff)
                {
                    string nd = ef.GetAttribute("Degree");
                    int deg = Int32.Parse(nd);
                    form[deg] = ef.InnerXml;
                }
            }
        }

        #endregion



    }
}
