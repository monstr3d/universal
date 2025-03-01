using System.Xml;

using Abstract3DConverters.Interfaces;

using Collada.Converters.Classes.Elementary;

namespace Collada.Converters.Classes.Complicated
{
    [Tag("input")]
    public class Input : XmlHolder
    {

        public KeyValuePair<string, OffSet> Semantic => dictionary;

   
       public float[] Array { get; private set; }



        KeyValuePair<string, OffSet> dictionary;

        public static IClear Clear => StaticExtensionCollada.GetClear<Input>();




        private Input(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            var offset = -1;
            var off = element.GetAttribute("offset");

            if (off.Length > 0)
            {
                offset = int.Parse(off);
            }
            var s = element.OuterXml;
            var p = element.Get<P>();
            if (p != null)
            {
                throw new Exception("Class input exception 1");
            }
            var semantic = element.GetAttribute("semantic");
            if (!semantic.StartsWith("PO"))
            {

            }
            var source = element.GetAttribute("source").Substring(1);
            if ((semantic.Length == 0) | (source.Length == 0))
            {
                throw new Exception("Class input exception 2");
            }
            var o = GetSemantic(semantic, source);
            if (o is Source so)
            {
                Array = so.Array;
                if (Array == null)
                {

                }
            }
            if (o is Vertices ve)
            {
                Array = ve.Array;
            }
            var offs = new OffSet(offset, o);
            dictionary = new KeyValuePair<string, OffSet>(semantic, offs);
            if (o == null)
            {
                //throw new Exception();
            }
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Input(element, meshCreator);
            if (a.Array == null)
            {

            }
            return a.Get();
        }


        object GetSemantic(string semantic, string id)
        {
            if (semantic == "POSITION")
            {
                return id.Get<Source>();
            }
            if (semantic == "VERTEX")
            {
                return id.Get<Vertices>();
            }
            if (semantic == "NORMAL")
            {
                return id.Get<Source>();
            }
            if (semantic == "TEXCOORD")
            {
                return id.Get<Source>();
            }
            if (semantic == "INPUT")
            {
                return null;
            }
            if (semantic == "OUTPUT")
            {
                return null;
            }
            if (semantic == "INTERPOLATION")
            {
                return null;
            }
            throw new Exception("Class input exception 3");
        }


    }
}