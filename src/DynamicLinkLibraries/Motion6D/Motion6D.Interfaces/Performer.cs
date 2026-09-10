namespace Motion6D.Interfaces
{
    public class Performer
    {

        RealMatrixProcessor.RealMatrix rm = new();
        public Performer() { }

        public ReferenceFrame GetParentOwn(IPosition position)
        {
            var p = position.Parent;
            if (p is IReferenceFrame rf)
            {
                return rf.Own;
            }
            return null;
        }

        /// <summary>
        /// Fills position
        /// </summary>
        /// <param name="frame">Frame</param>
        /// <param name="p">Position</param>
        /// <param name="x">Array</param>
        public void FillPosition(ReferenceFrame frame, IPosition p, double[] x)
        {
            var m = frame.Matrix;
            rm.Multiply(m, p.Position, x);

        }

    }
}
