using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf
{
    partial class Function
    {
        Dictionary<string, XmlElement> parametersNew;


        Dictionary<string, Func<XmlElement, object>> functions;

        Dictionary<string, Func<XmlElement, Visual3D>> visualDic;

        Dictionary<string, Func<XmlElement, object>> sourceDic;

        Dictionary<Type, Func<XmlElement, object, object>> combined; Dictionary<XmlElement, Material> materials;






        private Dictionary<string, Type> materialTypes;

        private Dictionary<string, Func<XmlElement, Material>> materialCalc;



        Dictionary<string, List<XmlElement>> elementList;

        Dictionary<XmlElement, XmlElement> sourceParam = new Dictionary<XmlElement, XmlElement>();
        Dictionary<XmlElement, XmlElement> paramSource = new Dictionary<XmlElement, XmlElement>();



    }
}
