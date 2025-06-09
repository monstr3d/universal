using OnlineGameConverter.Server.Classes;

namespace OnlineGameConverter.Server.Interfaces
{
    public interface IOrbitalCalculationResult
    {
        List<OrbitalForecastItem> Items { get; set; }
    }

    public interface IOrbitalCalculationResultSingleton : IOrbitalCalculationResult
    {

    }
}
