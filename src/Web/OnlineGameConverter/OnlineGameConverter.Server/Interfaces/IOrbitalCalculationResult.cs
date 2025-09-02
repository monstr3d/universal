using OnlineGameConverter.Server.Classes;

namespace OnlineGameConverter.Server.Interfaces
{
    public interface IOrbitalCalculationResult
    {
        List<OrbitalForecastItemDateTime> Items { get; set; }
    }

    public interface IOrbitalCalculationResultSingleton : IOrbitalCalculationResult
    {

    }
}
