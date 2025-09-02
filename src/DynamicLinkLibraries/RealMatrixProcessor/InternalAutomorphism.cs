
namespace RealMatrixProcessor
{
    /// <summary>
    /// Internal automorphism
    /// </summary>
    public class InternalAutomorphism
    {

        #region Fields

        double[,] direct;
        double[,] inverted;
        double[,] auxilary;

        RealMatrix realMatrix = new();
        
        int n;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="direct">Direct matrix</param>
        public InternalAutomorphism(double[,] direct)
        {
            this.direct = direct;
            n = direct.GetLength(0);
            inverted = realMatrix.Invert(direct);
            auxilary = new double[n, n];
        }

        #endregion

        /// <summary>
        /// Process
        /// </summary>
        /// <param name="a">Input</param>
        /// <param name="b">Result</param>
        public void Process(double[,] a, double[,] b)
        {
            realMatrix.Multiply(a, direct, auxilary);
            realMatrix.Multiply(inverted, auxilary, b);
        }

        /// <summary>
        /// Processas itself
        /// </summary>
        /// <param name="a">Input and result</param>
        public void ProsessItself(double[,] a)
        {
            Process(a, a);
        }
        
        /// <summary>
        /// Process
        /// </summary>
        /// <param name="a">Input</param>
        /// <returns>Result</returns>
        public double[,] Process(double[,] a)
        {
            var b = new double[n, n];
            Process(a, b);
            return b;
        }
    }
}
