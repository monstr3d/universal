using TradingDatabase;

namespace WinTradingResearch
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StaticExtensionResearch.Init();

            // "AAPL".DeleteBySymbol();
           // "AAPL".SaveHistoryToDatabase();
            ApplicationConfiguration.Initialize();
            var form = new FormMain();
            form.WindowState = FormWindowState.Maximized;
            Application.Run(form);
        }
    }
}