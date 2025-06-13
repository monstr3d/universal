using OnlineGameConverter.Server.Classes;

namespace OnlineGameConverter.Server.Interfaces
{
    public interface IForecastCondition
    {
        OrbitalForecastConditionDateTime ForecastCondition { get; set; }
    }

    public interface IForecastConditionSingleton : IForecastCondition
    {
    }


}
