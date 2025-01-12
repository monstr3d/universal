using BaseTypes;
using Chart.Drawing.Interfaces;
using Chart.Drawing.Interfaces.Points;
using DataPerformer.Interfaces;


namespace Chart.DataPerformer
{
    public class MeasurementSeries : ISeries
    {
        List<IPoint> points = new List<IPoint>();

        Func<Func<object>> x;

        IMeasurement measurement;

        int yCount = 0;


        private double[,] size = new double[2, 2];

        Action step;


        public MeasurementSeries(Func<Func<object>> x, IMeasurement measurement)
        {
            this.x = x;
            this.measurement = measurement;
            yCount = 1;
            var t = measurement.Type;
            step = SimpleStep;
            if (t is ArrayReturnType)
            {
                yCount = (t as ArrayReturnType).Dimension[0];
                step = MultiStep;
            }
        }

        public void Step()
        {
            step();
        }

        void SimpleStep()
        {
            var a = x()();
            var b = measurement.ToNullable<double>();
            if (a == null || b == null)
            {
                return;
            }
            IPoint p = new PointBase((double)a, (double)b);
            p.Properties = measurement.AttachedToPoint();
            points.Add(p);
        }

        void MultiStep()
        {
            var a = x()();
            var b = measurement.ToNullableObject<double[]>();
            if (a == null || b == null)
            {
                return;
            }
            var c = (b as double[]).Clone();
            IPoint p = new MultiPoint((double)a, c as double[]);
            p.Properties = measurement.AttachedToPoint();
            points.Add(p);
        }




        double[,] ISeries.Size => Size;

        IList<IPoint> ISeries.Points => points;

        int ISeries.YCount => yCount;

        void ISeries.Add(IPoint point)
        {
            points.Add(point);
        }

        private double[,] Size
        {
            get
            {
                this.GetSize(size); return size;
            }
        }

        
    }
}
