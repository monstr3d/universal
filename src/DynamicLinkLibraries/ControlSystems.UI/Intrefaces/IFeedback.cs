using System.Collections.Generic;

namespace ControlSystems.UI.Interfaces
{
    public interface IFeedback
    {
        ICollection<string> Aliases
        {
            get;
        }

        string Alias
        {
            get;
            set;
        }
            
    }
}
