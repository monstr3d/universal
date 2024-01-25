using AssemblyService.Attributes;
using Diagram.UI.Factory;
using Diagram.UI;
using System.Reflection;
using Trading.Library.Forms.Factory;
using System.Linq.Expressions;

namespace Trading.Library.Forms
{
    [InitAssembly]
    public static class StaticExtensionTradingLibraryForms
    {
        static StaticExtensionTradingLibraryForms()
        {
            new UIFactory();
        }

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {
        }

        public static readonly ButtonWrapper[] ObjectsButtons = 
            [
      
            new ButtonWrapper(typeof(Serializable.Objects.DataQuery), "",
                      "Trading query", Properties.Resources.ib_data, null, true, false),
           new ButtonWrapper(typeof(Serializable.Objects.Order), "", 
                      "Order Manager", Properties.Resources.bundle, null, true, false)

            ];


    }
}
