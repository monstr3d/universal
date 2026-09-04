using Diagram.UI.CodeCreators.Interfaces;
using System.Collections.Generic;

namespace Diagram.UI.Interfaces
{
    public interface IParametersCodeCreator1
    {
        List<string> CreateParameters(string prefix, object parent, object obj, string volume);

        List<string> SetParameters(string prefix, object parent, object obj, string volume);
        IDesktopCodeCreator DesktopCodeCreator { get; set; }
    }
}
