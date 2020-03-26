using System;
using System.Collections.Generic;
using System.Text;

using Motion6D.Interfaces;

namespace Motion6D
{
    /// <summary>
    /// Collection of positions
    /// </summary>
    public class PositionCollection : Position, IPositionCollection
    {
        #region Fields

        /// <summary>
        /// List of children
        /// </summary>
        protected List<IPosition> positions = new List<IPosition>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PositionCollection()
        {
            parent = StaticExtensionMotion6DInterfaces.DefaultFrame;
        }

        #endregion

        #region IPositionCollection Members

        ICollection<IPosition> IPositionCollection.Positions
        {
            get { return positions; }
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Parent frame
        /// </summary>
        public override IReferenceFrame Parent
        {
            get
            {
                return base.Parent;
            }
            set
            {
                IReferenceFrame frame = StaticExtensionMotion6DInterfaces.DefaultFrame;
                if (value != null)
                {
                    frame = value;
                }
                base.Parent = frame;
                foreach (IPosition p in positions)
                {
                    p.Parent = frame;
                    p.Update();
                }
            }
        }

        /// <summary>
        /// Updates itself
        /// </summary>
        public override void Update()
        {
            base.Update();
            foreach (IPosition p in positions)
            {
                p.Update();
            }
        }

        #endregion
    }
}
