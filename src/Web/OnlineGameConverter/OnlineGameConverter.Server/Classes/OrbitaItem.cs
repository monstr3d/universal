namespace OnlineGameConverter.Server.Classes
{
    public record class OrbitaForecastItem
    {
        public OrbitaForecastItem(DateTime datetime, double x,
            double y, double z, double Vx, double vY, double vZ)
        {
            DateTime = datetime;
            X = x;
            Y = y;
            Z = z;
            this.Vx = Vx;
            this.Vy = Vy;
            this.Vz = Vz;
        }
        public DateTime DateTime { get; set; }

        public double X { get; set; }

        public double Y { get; set; }
        public double Z { get; set; }

        public double Vx { get; set; }
        public double Vy { get; set; }
        public double Vz { get; set; }



    }
}
