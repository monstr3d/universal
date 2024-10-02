using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diagram.UI.Aliases
{
    /// <summary>
    /// Detector of type
    /// </summary>
    public class AliasTypeDetector
    {

        #region Fields
        /// <summary>
        /// Global detector of type
        /// </summary>
        private static AliasTypeDetector aliasDetector = new AliasTypeDetector();


        private static readonly Double d = 0;

        private static readonly Boolean b = false;


        private static readonly Int32 i = 0;

        const float f = 0;

        /// <summary>
        /// Zero time
        /// </summary>
        private static readonly DateTime DateTimeType = new DateTime((long)0, DateTimeKind.Utc);

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        protected AliasTypeDetector()
        {
        }


        /// <summary>
        /// Global detector of type
        /// </summary>
        public static AliasTypeDetector Detector
        {
            get
            {
                return aliasDetector;
            }
            set
            {
                aliasDetector = value;
            }
        }


        /// <summary>
        /// Detects type of variable
        /// </summary>
        /// <param name="variable">The variable</param>
        /// <returns>The type</returns>
        public virtual object DetectType(object variable)
        {
            Type t = variable.GetType();
            string tn = t.FullName;
            if (tn.Equals("System.Double"))
            {
                return d;
            }
            if (tn.Equals("System.Int32"))
            {
                return i;
            }
            if (tn.Equals("System.Boolean"))
            {
                return b;
            }
            if (t.Equals(typeof(string)))
            {
                return "";
            }
            if (t.Equals(typeof(DateTime)))
            {
                return DateTimeType;
            }
            if (t.Equals(typeof(float)))
            {
                return f;
            }
            return null;
        }

        /// <summary>
        /// Gets dimension of type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The dimension</returns>
        public virtual int[] GetDimension(object type)
        {
            return null;
        }


        /// <summary>
        /// Gets base type of array
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>Base type</returns>
        public virtual object GetBaseType(object type)
        {
            return type;
        }

    }
}
