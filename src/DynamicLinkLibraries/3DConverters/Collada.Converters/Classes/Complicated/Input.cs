﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;
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




        private Input(XmlElement element) : base(element, null)
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
                throw new Exception();
            }
            var semantic = element.GetAttribute("semantic");
            var source = element.GetAttribute("source").Substring(1);
            if ((semantic.Length == 0) | (source.Length == 0))
            {
                throw new Exception();
            }
            var o = GetSemantic(semantic, source);
            if (o == null)
            {
                //throw new Exception();
            }
            if (o is Source so)
            {
                Array = so.Array;
            }
            if (o is Vertices ve)
            {
                Array = ve.Array;
            }
            var offs = new OffSet(offset, o);
            dictionary = new KeyValuePair<string, OffSet>(semantic, offs);

        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Input(element);
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
                return id.Get<Source>().Array;
            }
            throw new Exception();
        }


    }
}