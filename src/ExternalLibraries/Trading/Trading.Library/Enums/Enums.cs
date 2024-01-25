using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trading.Library.Enums
{
    /// <summary>
    /// Current position
    /// </summary>
    public enum PositionType
    {
        None,
        Short,
        Long
    }

    /// <summary>
    /// Direction of position
    /// </summary>
    public enum PositionDirection
    {
        Opened,
        Closed
    }
}
