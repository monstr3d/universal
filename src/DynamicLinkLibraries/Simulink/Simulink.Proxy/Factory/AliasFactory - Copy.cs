using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.XmlObjectFactory;



namespace Simulink.Proxy.Factory
{
    class AliasFactory : AliasXmlObjectFactory
    {

        #region Fields

        public static Dictionary<string, Dictionary<string, string>> 
            aliases = new Dictionary<string,Dictionary<string,string>>();

        private static XElement doc;

        const Double dt = 0;

        internal static readonly AliasFactory Object = new AliasFactory();
 
        #endregion


        #region Ctor

        protected AliasFactory()
            : base(null)
        {
            fillDictionary += Fill;
        }

        #endregion


        #region Members

        void Fill(XElement element, IDictionary<string, object> dict,
    ICategoryObject categoryObject)
        {
            if (!(categoryObject is IAlias))
            {
                return;
            }
            IAlias a = categoryObject as IAlias;
            string type = element.GetAttributeLocal(Simulink.Parser.Library.SimulinkXmlParser.BlockType);
            if (!aliases.ContainsKey(type))
            {
                return;
            }
            Dictionary<string, string> d = aliases[type];
            IList<string> an = a.AliasNames;
            foreach (string key in d.Keys)
            {
                string val = d[key];
                if (!an.Contains(val))
                {
                    continue;
                }
                string attr = element.GetAttributeLocal(key);
                if (attr.Length == 0)
                {
                    continue;
                }
                object ty = a.GetType(val);
                dict[val] = GetObject(ty, attr);

            }
        }

        object GetObject(object type, string s)
        {
            return Double.Parse(s);
        }

        static internal XElement Document
        {
            get
            {
                return doc;
            }
        }



        static AliasFactory()
        {
            
            doc = XElement.Parse(ResourceDesktop.Mapping);
           IEnumerable<XElement> nl = doc.GetElementsByTagNameLocal(
               Simulink.Parser.Library.SimulinkXmlParser.Block);
           foreach (XElement e in nl)
           {
               string bt = e.GetAttributeLocal(Simulink.Parser.Library.SimulinkXmlParser.BlockType);
               ProcessAliases(e, bt);
           }
        }

        static void ProcessAliases(XElement e, string bt)
        {
            IEnumerable<XElement> na = e.GetFirstLocal("Aliases").GetElementsByTagNameLocal("Alias");
            Dictionary<string, string> d = new Dictionary<string, string>();
            aliases[bt] = d;
            foreach (XElement el in na)
            {
                d[el.GetAttributeLocal("Name")] = el.GetAttributeLocal("alias");
            }
        }

        #endregion


    }
}
