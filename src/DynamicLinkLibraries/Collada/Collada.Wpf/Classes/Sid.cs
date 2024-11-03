
using Collada;
using System.Collections.Generic;
using System.Xml;
using System;

public abstract class Sid : XmlHolder
{
    static Dictionary<string, Sid> dictionary = new();

    static List<string> xml = new();
    public Sid(XmlElement element) : base(element)
    {
        var p = (element.ParentNode as XmlElement);
        var sid = p.GetAttribute("sid");
        if (dictionary.ContainsKey(sid))
        {
            if (!xml.Contains(p.OuterXml))
            {
                return;
            }
            throw new Exception();
        }
        dictionary[sid] = this;
        xml.Add(p.OuterXml);
        Process(element);
    }

    protected abstract void Process(XmlElement element);

    public static Sid Get(string s)
    {
        if (dictionary.ContainsKey(s))
        {
            return dictionary[s];
        }
        throw new Exception();
    }

    public static Sid Get(XmlElement element)
    {
        var p = (element.ParentNode as XmlElement);
        var sid = p.GetAttribute("sid");
        if (dictionary.ContainsKey(sid))
        {
            if (xml.Contains(p.OuterXml))
            {
                return dictionary[sid];
            }
        }
        return null;
    }



    internal static void Clear()
    {
        dictionary.Clear();
        xml.Clear();
    }
}

