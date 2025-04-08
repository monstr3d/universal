using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NamedTree;


namespace Motion6D.Interfaces
{
    /// <summary>
    /// Static Extension
    /// </summary>
    public static class StaticExtensionMotion6DInterfaces
    {

        #region Public Fields

        static Performer performer = new Performer();

        /// <summary>
        /// Default frame
        /// </summary>
        static public readonly IReferenceFrame DefaultFrame = new DefaultFrameInternal();

        #endregion

        #region Public Members
 
        /// <summary>
        /// Sorts positions
        /// </summary>
        /// <param name="positions">Positions</param>
        static public void SortPositions(this List<IPosition> positions)
        {
            positions.Sort(Comparers.PositionComparer.Singleton);
        }

        /// <summary>
        /// Gets frame of position
        /// </summary>
        /// <param name="position">The position</param>
        /// <returns>The frame of the position</returns>
        static public ReferenceFrame GetFrame(this IPosition position)
        {
            if (position is IReferenceFrame)
            {
                IReferenceFrame f = position as IReferenceFrame;
                return f.Own;
            }
            return position.GetParentFrame();
        }


        /// <summary>
        /// Parent frame
        /// </summary>
        /// <param name="position">Position</param>
        /// <returns>Parent frame</returns>
        static public ReferenceFrame GetParentFrame(this IPosition position)
        {
            if (position.Parent == null)
            {
                return Motion6DFrame.Base;
            }
            return performer.GetParentOwn(position);
        }

        /// <summary>
        /// Gets frame of position object
        /// </summary>
        /// <param name="positionObject"></param>
        /// <returns></returns>
        static public ReferenceFrame GetFrame(this IPositionObject positionObject)
        {
            return positionObject.Position.GetFrame();
        }

        /// <summary>
        /// Gets path of positions
        /// </summary>
        /// <param name="position">The position</param>
        /// <returns>The path</returns>
        static public List<IPosition> GetPath(this IPosition position)
        {
            List<IPosition> path = new List<IPosition>();
            IPosition p = position;
            while (p != null)
            {
                path.Add(p);
                p = p.Parent.Value;
            }
            return path;
        }

        #endregion

        #region Default Frame class

        class DefaultFrameInternal  : IReferenceFrame
        {

            List<IPosition> children = new List<IPosition>();

            double[] position = new double[] { 0, 0, 0 };

            IReferenceFrame IPosition.Parent
            {
                get
                {
                    return null;
                }
                set
                {
                    throw new Exception("Prohibited operation");
                }
            }




            ReferenceFrame IReferenceFrame.Own
            {
                get { return Motion6DFrame.Base; }
            }


            double[] IPosition.Position
            {
                get { return position; }
            }

            INode<IPosition> INode<IPosition>.Parent 
            { 
                get => throw  new Exception("Prohibited operation"); 
                set => throw new Exception("Prohibited operation"); 
            }

            object IPosition.Parameters
            {
                get
                {
                    throw new Exception("Prohibited operation");
                }
                set
                {
                    throw new Exception("Prohibited operation");
                }
            }

            IEnumerable<INode<IPosition>> INode<IPosition>.Nodes { get => children; set => throw new Exception("Prohibited operation"); }

            IPosition INode<IPosition>.Value => this;

            event Action<IPosition> INode<IPosition>.OnAdd
            {
                add
                {
                    throw new NotImplementedException();
                }

                remove
                {
                    throw new NotImplementedException();
                }
            }

            event Action<IPosition> INode<IPosition>.OnRemove
            {
                add
                {
                    throw new NotImplementedException();
                }

                remove
                {
                    throw new NotImplementedException();
                }
            }

            void INode<IPosition>.Add(INode<IPosition> node)
            {
            }

            void INode<IPosition>.Remove(INode<IPosition> node)
            {
                throw new NotImplementedException();
            }

            void IPosition.Update()
            {
            }

        }

        #endregion
    }
}
