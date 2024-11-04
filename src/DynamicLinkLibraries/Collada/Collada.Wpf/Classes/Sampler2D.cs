using Collada.Wpf.Classes;
using System.Windows.Media;
using System.Xml;
using System;
using Collada;

public class Sampler2D : Sid, IImageSource
{
    static public readonly string Tag = "sampler2D";

    public Surface Surface { get; private set; }

    public ImageSource ImageSource { get; private set; }

    public Sampler2D(XmlElement element) : base(element)
    {
    }

    protected override void Process(XmlElement element)
    {
        var f = element.FirstElement();
        Surface = Sid.Get(f.InnerText) as Surface;
        if (Surface == null)
        {
            throw new Exception();
        }
        ImageSource = Surface.ImageSource;
    }

    public static object Get(XmlElement element)
    {
        var s = Sid.Get(element);
        if (s != null)
        {
            return s;
        }
        return new Sampler2D(element);

    }


}
