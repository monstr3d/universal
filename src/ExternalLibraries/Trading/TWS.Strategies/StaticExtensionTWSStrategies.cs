using IBApi;
using System.Runtime.CompilerServices;

namespace TWS.Strategies
{
    public static class StaticExtensionTWSStrategies
    {
        static Dictionary<DataTypes, Func<Bar, double>> FuctionTypes =
            new Dictionary<DataTypes, Func<Bar, double>>()
            {
             {DataTypes.Open,  bar => bar.Open },
            {DataTypes.Close, bar => bar.Close },
             {DataTypes.High, bar => bar.High  },
             {DataTypes.Low, bar => bar.Low  },
             {DataTypes.HihgLowDiff,bar => bar.High - bar.Low}
            };
        public static Func<Bar, double> GetFunc(this DataTypes dataTypes)
        {
            return FuctionTypes[dataTypes];
        }

        

    }
}
