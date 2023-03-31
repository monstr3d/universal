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
        static public void Init()
        {

        }

        static StaticExtensionDataSetServiceAdd()
        {
            new Converter();
        }

        class Converter : IConnectionStringConverter
        {
            internal Converter()
            {
                this.Set();
            }

            string IConnectionStringConverter.Convert(string value)
            {
                return value.Replace("SQLEXPRESS", "SQLEXPESS").Replace("SSPI", "True").Replace("user id=sa;", "");
            }
        }
    }
}