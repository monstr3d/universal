using IBApi;
using TradingDatabase;

namespace Trading.Web
{
    public class TradingControl
    {
        public string[] Periods { get => StaticExtensionIBApi.Barsizes; }

        public Dictionary<string, Guid> Symbols { get => StaticExtensionTradingDatabase.Symbols; }
    }
}
