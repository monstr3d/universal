using System;
using System.Collections.Generic;


using CategoryTheory;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using Motion6D.Interfaces;
using System.Linq;
using NamedTree;

namespace Motion6D.Portable
{
    /// <summary>
    /// Link of relative frame
    /// </summary>
    public class ReferenceFrameArrow : CategoryArrow, IDisposable
    {
        #region Fields

        IPosition source;

        IReferenceFrame target;

        static Diagram.UI.Performer performer = new ();

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReferenceFrameArrow()
        {

        }


        #endregion

        #region ICategoryArrow Members

        /// <summary>
        /// The source of this arrow
        /// </summary>
        public override ICategoryObject Source
        {
            get
            {
                return source as ICategoryObject;
            }
            set
            {
                IPosition position = value.GetSource<IPosition>();
                if (position.Parent != null)
                {
                    throw new CategoryException("Root", this);
                }
                source = position;
            }
        }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        public override ICategoryObject Target
        {
            get
            {
                return target as ICategoryObject;
            }
            set
            {
                IReferenceFrame rf = value.GetTarget<IReferenceFrame>();
                IAssociatedObject sa = source as IAssociatedObject;
                IAssociatedObject ta = value as IAssociatedObject;
                INamedComponent ns = sa.Object as INamedComponent;
                INamedComponent nt = ta.Object as INamedComponent;
                /*if (nt != null & ns != null)
                {
                    if (PureDesktopPeer.GetDifference(nt, ns) >= 0)
                    {
                        throw new OwnException("Illegal order");
                    }
                }*/
                target = rf;
                performer.AddChildNode(target, source);
        //        source.Parent = target;
        //        target.Add(source);
            }
        }

        /// <summary>
        /// TargetFrame
        /// </summary>
        public IReferenceFrame TargetFrame
        {
            get => target;
        }


        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            if (source != null)
            {
                source.Parent = null;
                if (target != null)
                {
                    target.Remove(source);
                }
            }
            source = null;
            target = null;
        }


        #endregion

        #region Specific Members

        /// <summary>
        /// Preparation operation
        /// </summary>
        /// <param name="collection">Desktop</param>
        /// <returns>List of position objects</returns>
        static public List<IPosition> Prepare(IComponentCollection collection)
        {
            List<IPosition> frames = new List<IPosition>();
            if (collection == null)
            {
                return frames;
            }
            IEnumerable<object> c = collection.AllComponents;
            foreach (object o in c)
            {
                if (!(o is IObjectLabel))
                {
                    continue;
                }
                IObjectLabel lab = o as IObjectLabel;
                ICategoryObject co = lab.Object;
                if (!(co is IReferenceFrame))
                {
                    if (co is IPosition)
                    {
                        IPosition p = co as IPosition;
                        if (p.Parent == null)
                        {
                            frames.Add(p);
                        }
                    }
                    continue;
                }
                IReferenceFrame f = co as IReferenceFrame;
                if (f.Parent != null)
                {
                    continue;
                }
                prepare(f, frames);
            }
            return frames;
        }



        private static void prepare(IReferenceFrame frame, List<IPosition> frames)
        {
            List<IPosition> children = performer.GetChildren<IPosition>(frame).ToList();
            frames.Add(frame);
            foreach (IPosition p in children)
            {
                if (frames.Contains(p))
                {
                    continue;
                }
                if (p is IReferenceFrame)
                {
                    IReferenceFrame f = p as IReferenceFrame;
                    prepare(f, frames);
                }
                else
                {
                    frames.Add(p);
                }
            }
        }

        #endregion

        /*!!!FICTION
        void Fiction()
        {
            IPosition position = null;
            IReferenceFrame frame = null;
            ReferenceFrameArrow link = new ReferenceFrameArrow();
            link.Source = position as ICategoryObject;
            link.Target = position as ICategoryObject;


            position.Parent = frame;
            frame.Children.Add(position);
        }*/
    }
}
