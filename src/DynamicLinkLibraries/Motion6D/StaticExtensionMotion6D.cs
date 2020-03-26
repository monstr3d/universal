using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using Motion6D.Interfaces;


namespace Motion6D
{
    /// <summary>
    /// Static extension
    /// </summary>
    [CategoryTheory.InitAssembly]
    public static class StaticExtensionMotion6D
    {

        #region Fields

        static IProcess animation;

        #endregion

        #region Public Members

        /// <summary>
        /// Sets position
        /// </summary>
        /// <param name="position">Position</param>
        /// <param name="visible">Visible object</param>
        public static void SetPosition(this IPosition position, object visible)
        {
            if (visible is IVisible)
            {
                (visible as IVisible).Position = position;
            }
            if (position is IChildrenObject)
            {
                IAssociatedObject[] ch = (position as IChildrenObject).Children;
                foreach (object o in ch)
                {
                    position.SetPosition(o);
                }
            }
            if (visible is IChildrenObject)
            {
                IAssociatedObject[] ch = (visible as IChildrenObject).Children;
                foreach (object o in ch)
                {
                    position.SetPosition(o);
                }
            }
        }


  
        /// <summary>
        /// Gets collection of factories
        /// </summary>
        /// <param name="factories">Factories</param>
        /// <returns>Factory</returns>
        static public PositionObjectFactory ToFactory(this IPositionObjectFactory[] factories)
        {
            return new PositionObjectFactoryCollection(factories);
        }


        /// <summary>
        /// Animation
        /// </summary>
        static public IProcess Animation
        {
            get
            {
                return animation;
            }
            set
            {
                animation = value;
            }
        }

        /// <summary>
        /// First
        /// </summary>
        static bool first = true;

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {
            if (!first)
            {
                return;
            }
            first = false;
            new Binder();
        }

        /// <summary>
        /// Post load positions
        /// </summary>
        /// <param name="collection">Components</param>
        public static void PostLoadPositions(this IComponentCollection collection)
        {
            List<IPosition> l = collection.GetAll<IPosition>();
            l.SortPositions();
            foreach (IPosition position in l)
            {
                if (position is IPostLoadPosition)
                {
                    (position as IPostLoadPosition).PostLoadPosition();
                }
            }
        }

        /// <summary>
        /// Updates frames
        /// </summary>
        /// <param name="frames">Frames</param>
        public static void UpdateFrames(this IEnumerable<IPosition> frames)
        {
            foreach (IPosition frame in frames)
            {
                frame.Update();
            }
        }

        /// <summary>
        /// Gets root frames
        /// </summary>
        /// <param name="collection">Collection of objects</param>
        /// <returns>Root frames</returns>
        public static List<IPosition> GetRootFrames(this IEnumerable collection)
        {
            List<IPosition> l = new List<IPosition>();
            foreach (object o in collection)
            {
                if (o is IPosition)
                {
                    IPosition p = o as IPosition;
                    if (p.Parent == null)
                    {
                        if (!l.Contains(p))
                        {
                            l.Add(p);
                        }
                    }
                }
            }
            return l;
        }



        #endregion

        //!!!BINDER
        class Binder : System.Runtime.Serialization.SerializationBinder
        {
            internal Binder()
            {
                this.Add();
            }

            public override Type BindToType(string assemblyName, string typeName)
            {
                if (typeName.Equals("Motion6D.CameraLink"))
                {
                    return typeof(VisibleConsumerLink);
                }
                return null;
            }

        }


    }
}
