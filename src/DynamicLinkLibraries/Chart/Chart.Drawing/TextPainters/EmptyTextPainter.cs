using Chart.Drawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.Drawing.TextPainters
{
    internal class EmptyTextPainter : ICoordTextPainter
    {
        ChartPerformer ICoordTextPainter.Performer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        void ICoordTextPainter.DrawTextX(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale)
        {
        }

        void ICoordTextPainter.DrawTextY(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale)
        {
        }
    }
}
