using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simulink.Parser.Library;

namespace Simulink.CSharp.Library
{
    /// <summary>
    /// Performer of static operations
    /// </summary>
    public static class StaticPerformer
    {

        /*public static SimulinkSystem Load(IList<string> text)
        {
            return new SimulinkSystem(text);
        }*/

        /// <summary>
        /// Calculation of table value
        /// </summary>
        /// <param name="x">The X - argument</param>
        /// <param name="y">The Y - argument</param>
        /// <param name="xa">The X - argument array</param>
        /// <param name="ya">The Y - argument array</param>
        /// <param name="t">Value array</param>
        /// <returns>Calcculated value</returns>
        public static double Calculate2D(double x, double y,
            double[] xa, double[] ya, double[,] t)
        {
            int i = 0, j = 0;
            for (; i < xa.Length; i++)
            {
                if (xa[i] > x)
                {
                    break;
                }
            }
            for (; j < ya.Length; y++)
            {
                if (ya[j] > y)
                {
                    break;
                }
            }
            double x0 = xa[i];
            double dx = x - x0;
            double deltaX = dx / (xa[i] - xa[i - 1]);
            double val0 = t[i - 1, j - 1] + deltaX * (t[i, j - 1] - t[i - 1, j - 1]);
            double val1 = t[i - 1, j] + deltaX * (t[i, j] - t[i - 1, j]);
            double dy = y - ya[j];
            double deltaY = dy / (ya[j] - ya[j - 1]);
            return val0 + deltaY * (val1 - val0);
        }
    }
}