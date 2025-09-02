using System;
using System.Collections.Generic;
using System.Text;

using Diagram.UI;
using ErrorHandler;
using Motion6D.Interfaces;
using Motion6D.Portable;

namespace Motion6D
{
    /// <summary>
    /// Factory of positions
    /// </summary>
    public class PositionFactory : IPositionFactory
    {

        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        static public readonly PositionFactory Object = new PositionFactory();

        /// <summary>
        /// The "Position" string
        /// </summary>
        static public readonly string OwnName = "Position";

        static private IPositionFactory factory = Object;

        #endregion

        #region Ctor
        /// <summary>
        /// Default constructor
        /// </summary>
        protected PositionFactory()
        {
        }
        #endregion

        #region IPositionFactory Members

        /// <summary>
        /// Creates position from object array
        /// </summary>
        /// <param name="o">The object array</param>
        /// <returns>The position</returns>
        public virtual IPosition Create(object[] o)
        {
            try
            {
                double[] d = new double[3];
                for (int i = 0; i < 3; i++)
                {
                    d[i] = (double)o[i];
                }
                return new Position(d);
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
            return null;
        }

        /// <summary>
        /// Acceess to factory by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual IPositionFactory this[string name]
        {
            get
            {
                return Object;
            }
        }

        /// <summary>
        /// Names of factories
        /// </summary>
        public virtual string[] Names
        {
            get
            {
                return new string[] { OwnName };
            }
        }

        /// <summary>
        /// Factory name
        /// </summary>
        public virtual string Name
        {
            get
            {
                return OwnName;
            }
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Global factory
        /// </summary>
        static public IPositionFactory Factory
        {
            get 
            { 
                return factory; 
            }
            set 
            { 
                factory = value; 
            }
        }

        #endregion

    }
}
