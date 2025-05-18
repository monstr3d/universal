using OnlineGameConverter.Server.Classes;

namespace OnlineGameConverter.Server.Interfaces
{
    public interface IForecastCondition
    {
        ForecastCondition ForecastCondition { get; set; }
    }

    public interface IForecastConditionSingleton : IForecastCondition
    {

    }


}
