using Diagram.UI.CodeCreators.Interfaces;
using System.Collections.Generic;

namespace Diagram.Interfaces
{
    public interface IPropertiesCodeCreator1
    {
        List<string> CreateProperties(string prefix, object obj, string volume);

        List<string> SetProperties(string prefix, object obj, string volume);
        
        IDesktopCodeCreator DesktopCodeCreator { get; set; }

    }
}
