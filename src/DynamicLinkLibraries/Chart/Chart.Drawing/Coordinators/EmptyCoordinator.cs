using BaseTypes.Attributes;
using Chart.Drawing.Interfaces;
using Chart.Drawing.TextPainters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.Drawing.Coordinators
{
    public class EmptyCoordinator : ICoordPainter
    {
        private ICoordTextPainter textPainter = new EmptyTextPainter();

        ICoordTextPainter ICoordPainter.X { get => textPainter; set => textPainter=value; }
        ICoordTextPainter ICoordPainter.Y { get => textPainter; set => textPainter=value; }
        ChartPerformer ICoordPainter.Performer { get => null; set { } }

        void ICoordPainter.ClearInsets(IControl component, int[,] insets)
        {
        }

        void ICoordPainter.DrawCoord(Graphics g, double[,] dSize, int[] size)
        {
        }

        void ICoordPainter.DrawCoord(Graphics g, int[,] insets, double[,] dSize, int[] size)
        {

        }

    }
}
