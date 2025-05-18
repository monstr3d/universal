using OnlineGameConverter.Server.Interfaces;

namespace OnlineGameConverter.Server.Classes
{
    /// <summary>
    /// Condition of forecast
    /// </summary>
    /*
                    var cond = new ForecastCondition(DateTime.Now, DateTime.Now, -5448.34815324,
                    -4463.93698421, 0, -0.985394777432, 1.21681893834, 7.45047785592);

     */
    public record class ForecastCondition
    {
        public ForecastCondition(DateTime begin, DateTime end, double x, 
            double y, double z, double Vx, double Vy, double Vz )
        {
            Begin = begin;
            End = end;
            X = x;
            Y = y;     
            Z = z;  
            this.Vx = Vx;
            this.Vy = Vy;
            this.Vz = Vz;
        }
        public DateTime Begin { get; private set; }

        public DateTime End { get; private set; }

        public double X { get; private set; }

        public double Y { get; private set; }
        public double Z { get; private set; }

        public double Vx { get; private set; }

        public double Vy { get; private set; }

        public double Vz { get; private set; }


    }

    public class ForecastConditionSingleton : IForecastConditionSingleton
    {
        ForecastCondition IForecastCondition.ForecastCondition { get; set; }
    }


}
