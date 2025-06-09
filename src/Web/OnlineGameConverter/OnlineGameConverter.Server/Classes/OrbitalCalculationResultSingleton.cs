using OnlineGameConverter.Server.Interfaces;

namespace OnlineGameConverter.Server.Classes
{
    public class OrbitalCalculationResultSingleton : IOrbitalCalculationResultSingleton
    {
        List<OrbitalForecastItem> IOrbitalCalculationResult.Items { get; set; } = new List<OrbitalForecastItem>();
    }
}
