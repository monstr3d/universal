using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Diagram.UI.Labels;

using Motion6D.Interfaces;

namespace Motion6D
{
    internal class PositionObjectFactoryCollection : PositionObjectFactory
    {

        #region Fields

        IPositionObjectFactory[] factories;

        #endregion

        #region Ctor

        internal PositionObjectFactoryCollection(IPositionObjectFactory[] factories)
        {
            this.factories = factories;
        }

        #endregion

        #region Overriden Members

        public override object CreateObject(string type)
        {
            foreach (IPositionObjectFactory factory in factories)
            {
                object o = factory.CreateObject(type);
                if (o != null)
                {
                    return o;
                }
            }
            return null;
        }

        public override Camera NewCamera()
        {
            foreach (IPositionObjectFactory factory in factories)
            {
                Camera c = factory.NewCamera();
                if (c != null)
                {
                    return c;
                }
            }
            return null;
        }

        public override object CreateForm(Camera camera)
        {
            return null;
        }

        public override object CreateForm(Interfaces.IPosition position, Interfaces.IVisible visible)
        {
            foreach (IPositionObjectFactory factory in factories)
            {
                object o = factory.CreateForm(position, visible);
                if (o != null)
                {
                    return o;
                }
            }
            return null;
        }
   
        public override Type CameraType
        {
            get 
            {
                foreach (IPositionObjectFactory factory in factories)
                {
                    Type t = factory.CameraType;
                    if (t != null)
                    {
                        return t;
                    }
                }
                return null;
            }
        }

        public override IObjectLabel CreateLabel(object obj)
        {

            foreach (IPositionObjectFactory factory in factories)
            {
                IObjectLabel l = factory.CreateLabel(obj);
                if (l != null)
                {
                    return l;
                }
            }
            return null;
        }

        public override object CreateLabel(Interfaces.IPosition position, Interfaces.IVisible visible)
        {
            foreach (IPositionObjectFactory factory in factories)
            {
                object o = factory.CreateLabel(position, visible);
                if (o != null)
                {
                    return o;
                }
            }
            return null;
        }

        /// <summary>
        /// Checks whether the factory supports a kind
        /// </summary>
        /// <param name="kind">Kind of object</param>
        /// <returns>True is supports and false otherwise</returns>
        public override bool SupportsKind(string kind)
         {
            foreach (IPositionObjectFactory factory in factories)
            {
                if (factory.SupportsKind(kind))
                {
                    return true;
                }
            }
            return false;
         }

        #endregion

    }
}
