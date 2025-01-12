using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Enumeration;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Xml;
using System.Xml.Schema;
using Wpf.Loader;
using System.Xml.Linq;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Windows.Controls;

namespace Collaada.Wpf.Test
{
    internal  static class StaticExtenrion
    {

        static internal void   CheckSchema(this string filename)
        {
            var sch = @"c:\AUsers\1MySoft\CSharp\Collada.Doc\collada_schema_1_4.xml";

            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml("<Root><Child>Test</Child></Root>");

             XmlSchemaSet schemas = new XmlSchemaSet();
            using (var reader = new StreamReader(sch))
            {
                try
                {
                           var str = reader.ReadToEnd();
                          XmlDocument doc = new XmlDocument();
                           doc.LoadXml(str);
                          var xDocument = XDocument.Load(doc.CreateNavigator().ReadSubtree());

                    var x = xDocument + "";

                    //schemas.Add("", xDocument);
                    schemas.Add("http://www.collada.org/2005/11/COLLADASchema", XmlReader.Create(new StringReader(x)));
                }
                catch (Exception ex)
                {

                }
                var l = new List<string>();
                try
                {
                    XDocument e = XDocument.Load(filename);
                    e.Validate(schemas, (o, e) =>
                    {
                        l.Add(e.Message);
                    });
                }
                catch (Exception ex)
                {

                }

            }
        }
 
       static  void Compare()
        {
            var wr1 = new XamlWrapper();
            wr1.Load(@"c:\AUsers\1MySoft\CSharp\03D\XAML\tu154b\Model\1.xaml");

            var wr2 = new XamlWrapper();

            wr2.Load(@"c:\AUsers\1MySoft\CSharp\03D\XAML\tu154b\Model\2.xaml");

            var v1 = wr1.Visual;

            var ww1 = Comparer.Get(v1 as ModelVisual3D).ToList();

            var ww2 = Comparer.Get(wr2.Visual as ModelVisual3D).ToList();

            var c = Comparer.Inatance;

            foreach (var x1 in ww1)
            {
                foreach (var x2 in ww2)
                {
                    if (c.GetHashCode(x1) == c.GetHashCode(x2))
                    {
                        c.Equals(x1, x2);
                    }
                }
            }

        }


    }
}
