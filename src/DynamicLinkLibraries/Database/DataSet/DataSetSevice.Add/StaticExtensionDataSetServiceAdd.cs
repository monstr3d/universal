using AssemblyService.Attributes;

using DataSetService;

using DataSetService.Interfaces;

namespace DataSetSevice.Add
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDataSetServiceAdd
    {

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        static StaticExtensionDataSetServiceAdd()
        {
            var c = Converter.Instance;
        }

        class Converter : IConnectionStringConverter
        {
            static internal readonly Converter Instance = new Converter();
            private Converter()
            {
                this.Set();
            }

            string IConnectionStringConverter.Convert(string value)
            {
                var s = value.Replace("SSPI", "True").Replace("user id=sa;", "");
                return s;
            }
        }
    }
}