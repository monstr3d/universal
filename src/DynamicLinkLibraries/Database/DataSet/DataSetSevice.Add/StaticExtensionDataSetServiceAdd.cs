using AssemblyService.Attributes;

using DataSetService.Pure;

using DataSetService.Pure.Interfaces;

namespace DataSetSevice.Add
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDataSetServiceAdd
    {
        static public readonly string cs = "Data Source=IVANKOV;Initial Catalog=??????;Integrated Security=True;Encrypt=False";

        static public readonly string ic = "initial catalog=";

        /// <summary>
        /// Initialize itself
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
                var s = value.ToLower();
                int n = s.IndexOf(ic);
                s = value.Substring(n + ic.Length);
                n = s.IndexOf(";");
                s = s.Substring(0, n);
                return cs.Replace("??????", s); ;
            }
        }
    }
}