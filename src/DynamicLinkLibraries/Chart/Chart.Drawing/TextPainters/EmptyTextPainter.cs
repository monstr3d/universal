using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chart.Drawing.Interfaces;
using ErrorHandler;

namespace Chart.Drawing.TextPainters
{
    internal class EmptyTextPainter : ICoordTextPainter
    {
        

        ChartPerformer ICoordTextPainter.Performer { get => throw new ErrorHandler.WriteProhibitedException(); 
            set => throw new ErrorHandler.WriteProhibitedException(); }
        void ICoordTextPainter.DrawTextX(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale)
        {
        }

        void ICoordTextPainter.DrawTextY(Graphics g, int[,] insets, double[,] dSize, int[] size, double[] scale)
        {
        }
    }
}
