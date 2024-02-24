using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;
using Motion6D.Interfaces;

namespace Motion6D.Portable
{
    /// <summary>
    /// Standard position
    /// </summary>
    public class Position : IPosition, IChildrenObject
    {

        #region Fields

        /// <summary>
        /// Parent frame
        /// </summary>
        protected IReferenceFrame parent;

        /// <summary>
        /// Own position
        /// </summary>
        protected double[] own = new double[] { 0, 0, 0 };

        /// <summary>
        /// Relatyive position
        /// </summary>
        protected double[] position = new double[3];

        /// <summary>
        /// Parameters
        /// </summary>
        protected object parameters;

        /// <summary>
        /// Children objects
        /// </summary>
        protected IAssociatedObject[] ch = new IAssociatedObject[1];

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected Position()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="position">Position coordinates</param>
        public Position(double[] position)
        {
            for (int i = 0; i < own.Length; i++)
            {
                own[i] = position[i];
            }
        }

        #endregion

        #region IPosition Members

        double[] IPosition.Position
        {
            get { return position; }
        }

        /// <summary>
        /// Parent frame
        /// </summary>
        public virtual IReferenceFrame Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        /// <summary>
        /// Position parameters
        /// </summary>
        public virtual object Parameters
        {
            get
            {
                return parameters;
            }
            set
            {
                parameters = value;
                if (value is IAssociatedObject)
                {
                    IAssociatedObject ao = value as IAssociatedObject;
                    ch[0] = ao;
                }
            }
        }

        /// <summary>
        /// Updates itself
        /// </summary>
        public virtual void Update()
        {
            Update(BaseFrame);
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Updates itself
        /// </summary>
        /// <param name="frame">Base frame</param>
        protected virtual void Update(ReferenceFrame frame)
        {
            double[,] m = frame.Matrix;
            double[] p = frame.Position;
            for (int i = 0; i < p.Length; i++)
            {
                position[i] = p[i];
                for (int j = 0; j < own.Length; j++)
                {
                    position[i] += m[i, j] * own[j];
                }
            }
        }

        /// <summary>
        /// Base frame
        /// </summary>
        protected virtual ReferenceFrame BaseFrame
        {
            get
            {
                if (parent == null)
                {
                    return Motion6D.Motion6DFrame.Base;
                }
                return parent.Own;
            }
        }

        #endregion

        #region IChildrenObject Members

        IAssociatedObject[] IChildrenObject.Children
        {
            get { return ch; }
        }

        #endregion


    }
}
