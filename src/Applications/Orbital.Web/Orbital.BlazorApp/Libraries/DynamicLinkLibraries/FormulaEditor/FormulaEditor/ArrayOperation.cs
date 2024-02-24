using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;


using BaseTypes;
using BaseTypes.Interfaces;


namespace FormulaEditor
{
    /// <summary>
    /// Operation with array
    /// </summary>
    public class ArrayOperation : IObjectOperation, IPowered
    {

        #region Fields

        /// <summary>
        /// Base operation
        /// </summary>
        protected IObjectOperation operation;

        /// <summary>
        /// Array
        /// </summary>
        protected object[] y;

        /// <summary>
        /// Return type
        /// </summary>
        protected ArrayReturnType returnType;

        /// <summary>
        /// Return value
        /// </summary>
        protected object returnValue;

        /// <summary>
        /// The "is array" sign
        /// </summary>
        protected bool[] isArray;

        /// <summary>
        /// Length
        /// </summary>
        protected int length = 0;

        /// <summary>
        /// Types of variables
        /// </summary>
        protected object[] types;

        /// <summary>
        /// Array of rank
        /// </summary>
        protected int[][] ranks;

        /// <summary>
        /// Array of array
        /// </summary>
        protected object[][] yy;

        /// <summary>
        /// Rank
        /// </summary>
        protected int[] rank;

        /// <summary>
        /// Array
        /// </summary>
        protected object[] yt;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="operation">Prototype operation</param>
        /// <param name="types">Types of variables</param>
        public ArrayOperation(IObjectOperation operation, object[] types)
        {
            this.operation = operation;
            this.types = types;
            yy = new object[types.Length][];
            CreateAllArrays(operation, types, out y, out yy, out rank, out ranks);
            returnValue = y;
            if (types != null)
            {
                if (types.Length > 0)
                {
                    yt = new object[types.Length];
                }
            }
            returnType = new ArrayReturnType(operation.ReturnType, rank, true);
        }

        #endregion

        /// <summary>
        /// Crates all necessary arrays
        /// </summary>
        /// <param name="op">Base operation</param>
        /// <param name="types">Types of variables</param>
        /// <param name="y">Array</param>
        /// <param name="yy">Array of arrays</param>
        /// <param name="rank">Rank</param>
        /// <param name="ranks">Array of ranks</param>
        public static void CreateAllArrays(IObjectOperation op, object[] types, out object[] y, out object[][] yy, out int[] rank, out int[][] ranks)
        {
            rank = getRank(types);
            ranks = new int[types.Length][];
            for (int i = 0; i < ranks.Length; i++)
            {
                ranks[i] = getRank(types);
            }
            y = createArray(op.ReturnType, rank);
            yy = createArrays(types, rank, rank.Length);
        }


        private static object[] createArray(object type, int[] ranks)
        {
            return createArray(type, ranks, ranks.Length);
        }

        static int[] getRank(object[] types)
        {
            int i = 0;
            ArrayReturnType t = null;
            for (; i < types.Length; i++)
            {
                if (types[i] is ArrayReturnType)
                {
                    t = types[i] as ArrayReturnType;
                    return t.Dimension;
                }
            }
            return null;
        }

        private static object[] createArray(object type, int[] ranks, int rank)
        {
            if (rank == 1)
            {
                object[] o = new object[ranks[ranks.Length - 1]];
                for (int i = 0; i < o.Length; i++)
                {
                    o[i] = type;
                }
                return o;
            }
            int m = ranks.Length - rank;
            int n = ranks[m];
            object[] ob = new object[n];
            for (int i = 0; i < ob.Length; i++)
            {
                ob[i] = createArray(type, ranks, rank - 1);
            }
            return ob;
        }

        private static object[][] createArrays(object[] types, int[] ranks, int rank)
        {
            int length = types.Length;
 //           bool b = false;
            foreach (object t in types)
            {
                if (t is ArrayReturnType)
                {
                    ArrayReturnType rt = t as ArrayReturnType;
                    length = rt.Dimension[0];
                    //b = true;
                    break;
                }
            }
            object[][] o = new object[length][];
            if (rank == 1)
            {
                for (int i = 0; i < o.Length; i++)
                {
                    object[] ob = new object[types.Length];
                    o[i] = ob;
                    for (int j = 0; j < types.Length; j++)
                    {
                        object tt = ArrayReturnType.GetBaseType(types[j]);
                        ob[j] = tt;
                    }
                }
                return o;
            }
            return null;
        }



        #region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] IObjectOperation.InputTypes
        {
            get
            {
                return types;
            }
        }

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public virtual object this[object[] x]
        {
            get
            {
                PerformOperation(operation, returnValue as object[], x, yy, rank.Length, ranks, rank, yt);
                return returnValue;
            }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
        {
            get
            {
                return returnType;
            }
        }

        /// <summary>
        /// The "is powered" sign
        /// </summary>
        public virtual bool IsPowered
        {
            get
            {
                return operation.IsPowered();
            }
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Prototype operation of single object of array
        /// </summary>
        public IObjectOperation SingleOperation
        {
            get
            {
                return operation;
            }
        }

        /// <summary>
        /// Types of objects
        /// </summary>
        public object[] Types
        {
            get
            {
                return types;
            }
        }

        /// <summary>
        /// Performs operation
        /// </summary>
        /// <param name="operation">Operation</param>
        /// <param name="o">Auxiliary variable</param>
        /// <param name="y">Auxiliary variable</param>
        /// <param name="yy">Auxiliary variable</param>
        /// <param name="rank">Rank</param>
        /// <param name="ranks">Array of ranks</param>
        /// <param name="mainRank">Main rank</param>
        /// <param name="yt">Auxiliary variable</param>
        public static void PerformOperation(IObjectOperation operation, object[] o, object[] y, object[][] yy, int rank, int[][] ranks, int[] mainRank, object[] yt)
        {
            int n = operation.InputTypes.Length;
            for (int i = 0; i < mainRank[rank - 1]; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    object yo = y[j];
                    if (yo is Array)
                    {
                        Array oby = yo as Array;
                        yt[j] = oby.GetValue(i);
                    }
                    else
                    {
                        yt[j] = yo;
                    }
                }
                o[i] = operation[yt];
            }
        }

        #endregion

    }
}
