using System;
using System.Collections.Generic;
using System.Text;

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
