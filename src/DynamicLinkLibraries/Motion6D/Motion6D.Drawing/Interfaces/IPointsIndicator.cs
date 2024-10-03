using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Motion6D.Drawing.Interfaces
{
    public interface IPointsIndicator
    {

        IPointsIndicator this[string name]
        {
            get;
        }

        string[] this[PositionCollectionIndicator collection]
        {
            get;
        }

        PositionCollectionIndicator Positions
        {
            get;
            set;
        }

        bool Blocked
        {
            get;
            set;
        }

    }
}
