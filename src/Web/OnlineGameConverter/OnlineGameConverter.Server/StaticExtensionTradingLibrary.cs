using FormulaEditor;
using Trading.Library.Objects;

namespace OnlineGameConverter.Server
{
    public static class StaticExtensionTradingLibrary
    {

        static  Dictionary<string, object> symbols;

        static Dictionary<string, string> stringSymbols;

        public static async Task<DataQuery> GetDataQueryAsync(CancellationToken cancellationToken)
        {
            return await DataQuery.Create(cancellationToken);
        }

        public static async Task<Dictionary<string, object>> GetTradingHistoricalSymbols(CancellationToken cancellationToken)
        {
            if (symbols == null)
            {
                var x = await DataQuery.Create(cancellationToken);
                symbols = x.Symbols;
            }
            return symbols;
        }

        public static async Task<Dictionary<string, string>> GetTradingHistorucalSrtingSymbols(CancellationToken cancellationToken)
        {
            if (stringSymbols == null)
            {
                var x = await GetTradingHistoricalSymbols(cancellationToken);
                stringSymbols = new Dictionary<string, string>();
                foreach (var i in x)
                {
                   stringSymbols.Add(i.Key, i.Value.ToString());
                }
            }
            return stringSymbols;
        }

        public static async Task<string[][]> GetTradingHistorucalSrtingSymbolsArray(CancellationToken cancellationToken)
        {
            var t = await GetTradingHistorucalSrtingSymbols(cancellationToken);
            var l = from s in t select  new string[] { s.Key, s.Value };
            return l.ToArray();

        }

    }
}
