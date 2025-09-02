using OnlineGameConverter.Server.Interfaces;

namespace OnlineGameConverter.Server.Classes
{
    public class OrbitalCalculationResultSingleton : IOrbitalCalculationResultSingleton
    {
        List<OrbitalForecastItemDateTime> IOrbitalCalculationResult.Items { get; set; } = new List<OrbitalForecastItemDateTime>();
    }
}
