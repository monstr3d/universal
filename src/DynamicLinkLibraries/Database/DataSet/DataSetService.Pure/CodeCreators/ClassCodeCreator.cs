using BaseTypes.Attributes;
using DataSetService.Pure.Interfaces;
using Diagram.UI;
using Diagram.UI.CodeCreators.Interfaces;
using Diagram.UI.Interfaces;
using System.Data;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Xml;
namespace DataSetService.Pure.CodeCreators
{
    [Language("C#")]
    class ClassCodeCreator : IClassCodeCreator
    {

        static NamedTree.Performer performer = new();

        static readonly Dictionary<Func<object, bool>, Func<string, object, List<string>>> dictionary =
            new Dictionary<Func<object, bool>, Func<string, object, List<string>>>()
            {
                    { (o) => { return o is SavedDataProvider; } , CreateSavedDataProvider },
             };

        
        internal ClassCodeCreator()
        {
            this.AddClassCodeCreator();
        }


        List<string> IClassCodeCreator.CreateCode(string prefix, object obj, string volume)
        {
            foreach (Func<object, bool> key in dictionary.Keys)
            {
                if (key(obj))
                {
                    return dictionary[key](prefix, obj);
                }
            }
            return null;
        }

        protected virtual IDesktopCodeCreator DesktopCodeCreator { get; set; }

        IDesktopCodeCreator IClassCodeCreator.DesktopCodeCreator { get => DesktopCodeCreator; set => DesktopCodeCreator = value; }

        static List<string> CreateSavedDataProvider(string preffix, object obj)
        {
            List<string> l = new List<string>();
            string pr = preffix;
            if (pr[pr.Length - 1] != '.')
            {
                pr = pr + ".";
            }
            SavedDataProvider sv = obj as SavedDataProvider;
            l.Add("DataSetService.Pure.SavedDataProvider");
            l.Add("{");
            l.Add("");
            l.Add("\tinternal CategoryObject()");
            l.Add("\t{");
            IDataSetProvider prov = sv;
            var dataSet = prov.DataSet;
            var s = JsonSerializer.Serialize(dataSet);
            using var stream = new StringWriter();
    
    //        dataSet.WriteXml(stream, XmlWriteMode.WriteSchema); 
            

            var ll = performer.GenerateLong("s", s, 50);

            performer.Add(l, ll, 2);

            l.Add("\t\tvar doc = new System.Xml.XmlDocument();");
            l.Add("\t\tdoc.LoadXml(s);");
            l.Add("\t\tvar ds = new DataSet();");
            l.Add("\t\tvar reader = new StringReader(s);");
            l.Add("\t\tds.ReadXml(reader);");
            l.Add("\t\tDataSetProvider prov = this;");
            l.Add("\t\tprov.DataSet = ds;");

            l.Add("\t}");

            l.Add("}");
            return l;
        }

    }
}

