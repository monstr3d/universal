using CategoryTheory;
using DataPerformer.Portable;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Event.Interfaces;
using Event.Portable;
using Event.Portable.Interfaces;
using Motion6D.Interfaces;
using Motion6D.Portable.Interfaces;
using Motion6D.Portable.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Motion6D.Portable
{
    /// <summary>
    /// Static Extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionMotion6DPortable
    {
        #region Fields

        #endregion

        #region Public Members

        /// <summary>
        /// Inits itself
        /// </summary>
        public static void Init()
        {

        }


        /// <summary>
        /// Animation
        /// </summary>
        public static IProcess Animation
        { get; set; }

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

        #region Constructor

        static StaticExtensionMotion6DPortable()
        {
            new CoreCreators.CSCodeCreator();
            DataRuntimeFactory.Singleton.SetBase();
            DataRuntimeFactory.Singleton.SetBaseAction();
        }

        #endregion
    }
}