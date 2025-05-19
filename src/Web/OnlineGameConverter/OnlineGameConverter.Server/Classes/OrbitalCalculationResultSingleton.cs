using OnlineGameConverter.Server.Interfaces;

namespace OnlineGameConverter.Server.Classes
{
    public class OrbitalCalculationResultSingleton : IOrbitalCalculationResultSingleton
    {
        List<OrbitaForecastItem> IOrbitalCalculationResult.Items { get; set; } = new List<OrbitaForecastItem>();
    }
}
