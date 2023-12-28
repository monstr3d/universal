using Chart.Drawing.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart.Drawing.Painters
{
    public class CandleSeriesPainter : SimpleSeriesPainter
    {
        ChartPerformer performer;

        Color up;

        Color down;

        public CandleSeriesPainter(Color up, Color down) : base([up, down])
        {
            this.up = up;
            this.down = down;
        }

        public override object Clone()
        {
            return new CandleSeriesPainter(up, down);
        }


    
        public override void Draw(ISeries series, Graphics g)
        {
          
        }
    }
}
