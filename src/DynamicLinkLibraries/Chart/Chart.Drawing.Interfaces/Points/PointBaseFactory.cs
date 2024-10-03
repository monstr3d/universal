
namespace Chart.Drawing.Interfaces.Points
{
    public class PointBaseFactory : IPointFactory
    {
        object[] types;

        string[] names = { "Base" };

        public PointBaseFactory(int n) 
        { 
            double a = 0;
            types = new object[n];
            for (int i = 0; i < n; i++)
            {
                types[i] = a;
            }
        }

        IPointFactory IPointFactory.this[string name] => this;

        object[] IPointFactory.Types => types;

        string[] IPointFactory.Names => names;

        IPoint IPointFactory.CreatePoint(object[] obj)
        {
            return new PointBase((double)obj[0], (double)obj[1]);
        }
    }
}
