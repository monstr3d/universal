using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Chart.Drawing.Interfaces;
using Chart.Drawing.Interfaces.Points;
using Chart.Drawing.Drawable;
using Chart.Drawing.Painters;

namespace Chart.Drawing.Factory
{
    /// <summary>
    /// Factorty which writers circles
    /// </summary>
    public class CirclePointFactory : IPointFactoryExtended
    {
        public static readonly string[] names = { "Colored circles" };

        public static readonly CirclePointFactory Object = new CirclePointFactory();

        protected CirclePointFactory()
        {
        }

        public virtual IPoint CreatePoint(object[] obj)
        {
            IPoint p = new PointBase((double)obj[0], (double)obj[1]);
            int[] col = new int[3];
            for (int i = 0; i < col.Length; i++)
            {
                double c = (double)obj[i + 2];
                int x = (int)(c * 255);
                if (x < 0)
                {
                    x = 0;
                }
                if (x > 255)
                {
                    x = 255;
                }
                col[i] = x;
            }
            Color color = Color.FromArgb(255, col[0], col[1], col[2]);
            double s = (double)obj[5];
            ColoredCircle circle = new ColoredCircle((int)s, color);
            p.Properties = circle;
            return p;
        }

        public virtual IPointFactory this[string name]
        {
            get
            {
                if (name.Equals(names[0]))
                {
                    return Object;
                }
                return null;
            }
        }

        public virtual string[] Names
        {
            get { return names; }
        }

        public virtual object[] Types
        {
            get
            {
                Double a = 0;
                return new object[] { a, a, a, a, a, a };
            }
        }


        public virtual ISeriesPainter GetPainter(ChartPerformer performer)
        {
            ISeriesPainter p = new FiguresSeriesPainter();
            p.Performer = performer;
            return p;
        }

        public static void Set()
        {
           StaticExtensionChartInterfaces.PointFactory = Object;
        }
    }
}