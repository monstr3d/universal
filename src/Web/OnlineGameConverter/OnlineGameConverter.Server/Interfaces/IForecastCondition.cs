using OnlineGameConverter.Server.Classes;

namespace OnlineGameConverter.Server.Interfaces
{
    public interface IForecastCondition
    {
        OrbitalForecastCondition ForecastCondition { get; set; }
    }

    public interface IForecastConditionSingleton : IForecastCondition
    {

    }


}
