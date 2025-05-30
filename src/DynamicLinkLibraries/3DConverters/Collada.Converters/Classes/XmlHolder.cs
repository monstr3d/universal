﻿using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;

using Collada.Converters.MeshCreators;
using ErrorHandler;

namespace Collada.Converters.Classes
{
    public class XmlHolder : Collada.XmlHolder
    {

        protected Service s = new();

        protected IMeshCreator meshCreator;

        protected ColladaMeshCreator MeshCreator { get; private set; }

        protected XmlHolder(XmlElement element, IMeshCreator meshCreator) : base(element)
        {
            this.meshCreator = meshCreator;
            MeshCreator = meshCreator as ColladaMeshCreator;
            if (element.IsElementary())
            {
                return;
            }
            var nl = element.GetAllElementsByTagName("source").Where(e => e != element).ToArray();
            if (nl.Length > 0)
            {
                throw new OwnException("XmlHolder");
            }
            return;
        }

        protected virtual object Get()
        {
            return this;
        }
    }
}