using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;
using System.IO;

using BaseTypes;

using Diagram.UI;
using Diagram.UI.WCF;
using Diagram.UI.Interfaces;

namespace DataPerformer.WCF
{
    /// <summary>
    /// Static extensions
    /// </summary>
    public static class StaticExtensionDataPerformerWCF
    {
       
        /// <summary>
        /// Initialization
        /// </summary>
        public static void Init()
        {
        }

        #region Private



        static private string GetChart(string parametres)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(parametres);
            string alt = doc.DocumentElement.InnerText.GetTask();
            return alt;
        }

        static private string CreateChartXml(string parametres)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(parametres);
            IDesktop desktop = doc.GetDesktop();
            desktop.SetAliases(doc);
            string chartXml = doc.DocumentElement.GetAttribute("Chart").GetTask();
            XmlDocument input = new XmlDocument();
            input.LoadXml(chartXml);
            XmlElement ch = doc.CreateElement("ChartName");
            doc.DocumentElement.AppendChild(ch);
            ch.InnerText = (input.GetElementsByTagName("ChartName")[0] as XmlElement).InnerText;
            XmlElement par = doc.CreateElement("Parameters");
            doc.DocumentElement.AppendChild(par);
            XmlElement pari = input.GetElementsByTagName("Parameters")[0] as XmlElement;
            XmlNodeList nl = pari.ChildNodes;
            foreach (XmlElement xp in nl)
            {
                XmlElement pp = doc.CreateElement("Parameter");
                par.AppendChild(pp);
                foreach (XmlElement xpp in xp.ChildNodes)
                {
                    string npp = xpp.Name;
                    if (npp.Equals("Name"))
                    {
                        XmlElement pc = doc.CreateElement("Name");
                        pp.AppendChild(pc);
                        pc.InnerText = xpp.InnerText;
                        continue;
                    }
                    XmlElement vp = doc.CreateElement("Value");
                    vp.InnerText = xpp.InnerText;
                    pp.AppendChild(vp);
                }
            }
            string xslt = (doc.GetElementsByTagName("Xslt")[0] as XmlElement).InnerText;
            XmlNodeList nlc = input.GetElementsByTagName("Condition");
            foreach (XmlElement ecc in nlc)
            {
                string cond = ecc.InnerText;
                XmlElement conddoc = doc.CreateElement("Condition");
                doc.DocumentElement.AppendChild(conddoc);
                conddoc.InnerText = cond;
            }
            XmlDocument dr = desktop.CreateXmlDocument(doc);
            using (XmlReader reader = XmlReader.Create(new StringReader(xslt.GetTask())))
            {
                XslCompiledTransform xslTransform = new XslCompiledTransform(true);
                xslTransform.Load(reader, null, null);
                using (XmlReader rx = XmlReader.Create(new StringReader(dr.OuterXml)))
                {
                    StringWriter sw = new StringWriter();
                    using (XmlWriter wr = XmlWriter.Create(sw))
                    {
                        xslTransform.Transform(rx, wr);
                        XmlDocument od = new XmlDocument();
                        od.LoadXml(sw + "");
                        XmlDocument rd = new XmlDocument();
                        rd.LoadXml("<Root/>");
                        XmlElement rt = rd.CreateElement("Text");
                        rd.DocumentElement.AppendChild(rt);
                        XmlCDataSection cdt = rd.CreateCDataSection(od.DocumentElement.InnerXml);
                        rt.AppendChild(cdt);
                        rd.CreateErrorReport();
                        return rd.OuterXml;
                    }
                }
            }
        }


        static StaticExtensionDataPerformerWCF()
        {
            Func<string, string> f = GetChart;
            f.Add("GetChart");
            f = CreateChartXml;
            f.Add("CreateChartXml");
        }

        #endregion

        
    }
}
