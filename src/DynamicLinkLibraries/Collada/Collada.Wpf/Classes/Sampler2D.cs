using Collada.Wpf.Classes;
using System.Windows.Media;
using System.Xml;
using System;
using Collada;
using System.Collections.Generic;

[Tag("sampler2D")]
public class Sampler2D : Sid
{
    static public readonly string Tag = "sampler2D";

    static Dictionary<string, Sampler2D> samplers = new();

    static public Sampler2D Get(string s)
    {
        if (samplers.ContainsKey(s))
        {
            return samplers[s];
        }
        return null;
    }

    internal static void Clear()
    {
        samplers.Clear();
    }

    

    public Surface Surface { get; private set; }


    public Sampler2D(XmlElement element) : base(element)
    {

    }

    public override void Set(NewParam newParam)
    {
        base.Set(newParam);
        var n = newParam.Name;
        if (samplers.ContainsKey(newParam.Name))
        {
            if (samplers[n].Xml.OuterXml != Xml.OuterXml)
            {
                throw new Exception();
            }
        }
        else
        {
           samplers[n] = this;
            n = n.Replace("Sampler", "Surface");
            Surface = Surface.Get(n); 
        }
    }

    protected override void Process(XmlElement element)
    {
        var f = element.FirstElement();
    /*    Surface = Sid.Get(f.InnerText) as Surface;
        if (Surface == null)
        {
            throw new Exception();
        }
        ImageSource = Surface.ImageSource;*/
    }

    public static object Get(XmlElement element)
    {
  /*      var s = Sid.Get(element);
        if (s != null)
        {
            return s;
        }*/
        return new Sampler2D(element);

    }


}
