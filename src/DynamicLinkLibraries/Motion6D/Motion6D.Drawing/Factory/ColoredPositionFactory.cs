using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Diagram.UI;

using Motion6D.Drawing.Classes;
using Motion6D.Interfaces;
using Motion6D.Portable;
using ErrorHandler;

namespace Motion6D.Drawing.Factory
{
    public class ColoredPositionFactory : PositionFactory
    {
        /// <summary>
        /// The "Colored" string
        /// </summary>
        new static public readonly string OwnName = "Colored";
        /// <summary>
        /// Singleton
        /// </summary>
        new static public readonly ColoredPositionFactory Object = new ColoredPositionFactory();

        /// <summary>
        /// Default constructor
        /// </summary>
        protected ColoredPositionFactory()
        {

        }



        /// <summary>
        /// Factory name
        /// </summary>
        public override string Name
        {
            get
            {
                return OwnName;
            }
        }

        /// <summary>
        /// Names of factories
        /// </summary>
        public override string[] Names
        {
            get
            {
                return new string[] { PositionFactory.OwnName, OwnName };
            }
        }

        /// <summary>
        /// Accees to factory by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override IPositionFactory this[string name]
        {
            get
            {
                if (OwnName.Equals(name))
                {
                    return Object;
                }
                return base[name];

            }
        }

        /// <summary>
        /// Creates position from object array
        /// </summary>
        /// <param name="o">The object array</param>
        /// <returns>The position</returns>
        public override IPosition Create(object[] o)
        {
            try
            {
                double[] d = new double[3];
                for (int i = 0; i < d.Length; i++)
                {
                    d[i] = (double)o[i];

                }
                IPosition p = new Position(d);
                try
                {
                    int[] col = new int[3];
                    for (int i = 0; i < col.Length; i++)
                    {
                        double a = (double)o[i + d.Length];
                        if (a > 1)
                        {
                            a = 1;
                        }
                        if (a < 0)
                        {
                            a = 0;
                        }
                        col[i] = (int)(255 * a);
                    }
                    double size = (double)o[d.Length + col.Length];
                    if (size < 1)
                    {
                        size = 1;
                    }
                    Color color = Color.FromArgb(255, col[0], col[1], col[2]);
                    ColorSize cs = new ColorSize();
                    cs.Color = color;
                    cs.Size = size;
                    p.Parameters = cs;
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                }
                return p;
            }
            catch (Exception exc)
            {
                exc.ShowError(10);
            }
            return base.Create(o);
        }

    }
}