using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Diagram.UI.Interfaces;
using Diagram.UI;


using BaseTypes;


using DataPerformer.Interfaces;

namespace DataPerformer.Helpers
{
    /// <summary>
    /// Finite derivation from Object transformer
    /// </summary>
    public class FiniteMatrixDerivationTransformer : IFiniteDerivationMatrix
    {
        #region Fields

        IObjectTransformer transformer;

        double[] difference;

        const Double a = 0;

        int[] dim = new int[2];

        double[,] matrix;

        double[] state;

        double[] output;

        object[][] inout = new object[][] { new object[1], new object[1] };

        #endregion

        #region Ctor

        /// <summary>
        /// Construtor from objet transformer
        /// </summary>
        /// <param name="transformer">Object transformer</param>
        public FiniteMatrixDerivationTransformer(IObjectTransformer transformer)
        {
            dim = IsAccessible(transformer);
            if (dim == null)
            {
                throw new Exception("Finite matrix is not accessible");
            }
            matrix = new double[dim[1], dim[0]];
            difference = new double[dim[0]];
            state = new double[dim[0]];
            output = new double[dim[1]];
            this.transformer = transformer;
        }

        #endregion

        #region IFiniteDerivationMatrix Members


        double[] IFiniteDerivationMatrix.FiniteDifference
        {
            get
            {
                return difference;
            }
            set
            {
                Array.Copy(value, difference, difference.Length);
            }
        }



        double[] IFiniteDerivationMatrix.State
        {
            get
            {
                return state;
            }
            set
            {
                Array.Copy(value, state, state.Length);
            }
        }

        /// <summary>
        /// Output
        /// </summary>
        double[] IFiniteDerivationMatrix.Output
        {
            get
            {
                return output;
            }
        }


        /// <summary>
        /// Object transformer
        /// </summary>
        IObjectTransformer IFiniteDerivationMatrix.Transformer
        {
            get
            {
                return transformer;
            }
        }

 

        #endregion

        #region IMatrix Members

        Func<double[,]> IMatrix.Matrix
        {
            get 
            {
                return GetMatrix;
            }
        }

        int[] IMatrix.Dimension
        {
            get
            {
                return dim;
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Is accessible
        /// </summary>
        /// <param name="transformer">Transformer</param>
        /// <returns>Dimension</returns>
        public static int[] IsAccessible(IObjectTransformer transformer)
        {
            if (transformer.Input.Length != 1)
            {
                return null;
            }
            if (transformer.Output.Length != 1)
            {
                return null;
            }
             
            
            object[] t = new object[] { transformer.GetInputType(0), transformer.GetOutputType(0) };

            int[] dim = new int[2];

            for (int i = 0; i < t.Length; i++)
            {
                object type = t[i];
                if (!(type is ArrayReturnType))
                {
                    return null;
                }
                ArrayReturnType art = type as ArrayReturnType;
                if ((double)art.ElementType != a)
                {
                    return null;
                }
                int[] k = art.Dimension;
                if (k.Length != 1)
                {
                    return null;
                }
                dim[i] = k[0];
            }
            return dim;
        }

        /// <summary>
        /// Gets names of appropriate objects
        /// </summary>
        /// <param name="collection">Component collection</param>
        /// <returns>Names</returns>
        public static List<string> GetNames(IComponentCollection collection)
        {
            List<string> l = new List<string>();
            collection.ForEach<IObjectTransformer>((IObjectTransformer t) => 
            {if (IsAccessible(t) != null) { l.Add(t.GetName(collection));}});
            return l;
        }

        double[,] GetMatrix()
        {
            inout[0][0] = state;
            transformer.Calculate(inout[0], inout[1]);
            double[] y = inout[1][0] as double[];
            Array.Copy(y, output, output.Length);
            for (int i = 0; i < dim[0]; i++)
            {
                state[i] += difference[i];
                transformer.Calculate(inout[0], inout[1]);
                y = inout[1][0] as double[];
                for (int j = 0; j < dim[1]; j++)
                {
                    matrix[j, i] = (y[j] - output[j]) / difference[i];
                }
                state[i] -= difference[i];
            }
            return matrix;
        }

       

        #endregion

    }
}
