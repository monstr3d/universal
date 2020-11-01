using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicEngineering.UI.Factory.Interfaces
{
    /// <summary>
    /// Blocking interface
    /// </summary>
    public interface IActionBlocking
    {

        void Block(ActionType type, bool block);
    }
}
