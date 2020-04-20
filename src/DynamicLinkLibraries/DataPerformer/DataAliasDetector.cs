using System;
using System.Collections.Generic;
using System.Text;


using Diagram.UI;
using Diagram.UI.Aliases;

using BaseTypes;

using FormulaEditor;

namespace DataPerformer
{
    /// <summary>
    /// Alias detector based on data
    /// </summary>
    public class DataAliasDetector : AliasTypeDetector
    {
        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly DataAliasDetector Singleton = new DataAliasDetector();

        private static readonly Int32 ii = 0;
        private static readonly Double dd = 0;
        private static readonly Boolean bb = false;
        private static readonly Single ff = 0;

        /// <summary>
        /// Default constructor
        /// </summary>
        protected DataAliasDetector()
        {
        }

        /// <summary>
        /// Detects type of variable
        /// </summary>
        /// <param name="variable">Variable</param>
        /// <returns>Type</returns>
        public override object DetectType(object variable)
        {
            Type t = variable.GetType();
            if (t.IsArray)
            {
                Array arr = variable as Array;
                int n = arr.Rank;
                bool ot = t.FullName.Contains("Object");
                int[] k = new int[n];
                int[] m = new int[n];
                for (int i = 0; i < k.Length; i++)
                {
                    k[i] = arr.GetLength(i);
                    m[i] = 0;
                }
                object et = arr.GetValue(m);
                string tn = et.GetType().FullName;
                if (tn.Contains("Boolean"))
                {
                    et = bb;
                }
                if (tn.Contains("Double"))
                {
                    et = dd;
                }
                if (tn.Contains("Int32"))
                {
                    et = ii;
                }
                if (tn.Contains("Single"))
                {
                    et = ff;
                }
                return new ArrayReturnType(et, k, ot);
                
            }
            return base.DetectType(variable);
        }

        /// <summary>
        /// Get type of array element
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override object GetBaseType(object type)
        {
            if (type is ArrayReturnType)
            {
                ArrayReturnType at = type as ArrayReturnType;
                return at.ElementType;
            }
            return base.GetBaseType(type);
        }

        /// <summary>
        /// Gets dimension of type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The dimension</returns>
        public override int[] GetDimension(object type)
        {
            if (type is ArrayReturnType)
            {
                ArrayReturnType at = type as ArrayReturnType;
                return at.Dimension;
            }
            return base.GetDimension(type);
        }

    }
}
