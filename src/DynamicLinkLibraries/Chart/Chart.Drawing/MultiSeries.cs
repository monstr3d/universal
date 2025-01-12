using Chart.Drawing.Interfaces;
using Chart.Drawing.Interfaces.Points;
using System.Collections.Generic;


namespace Chart.Drawing
{
    public class MultiSeries : ISeries
    {
        private int dimension;

        ISeries inter;

  
        private double[,] size = new double[2, 2];

        private bool calculatedSize = false;

        List<IPoint> points = new List<IPoint>();

        public MultiSeries(int dimension)
        {
            inter = this;
            this.dimension = dimension;
        }

        public void AddXY(double x, double[] y)
        {
            inter.Add(new MultiPoint(x, y));
        }

        #region ISeries Members

        double[,] ISeries.Size => GetSize();

        IList<IPoint> ISeries.Points => points;

        private double[,] GetSize()
        {
            if (calculatedSize)
            {  
                return size; 
            }
            this.GetSize(size);
            calculatedSize = true;
            return size;
        }

        int ISeries.YCount => dimension;

        void ISeries.Add(IPoint point)
        {
            calculatedSize = false;
            points.Add(point);
        }

        #endregion
    }
}
