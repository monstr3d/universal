using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Unity.Standard;

namespace Assets
{
    public class AngularIndicator : IIndicator
    {
        Action IIndicator.Update => throw new NotImplementedException();

        string IIndicator.Parameter => throw new NotImplementedException();

        object IIndicator.Value { set => throw new NotImplementedException(); }

        object IIndicator.Type => throw new NotImplementedException();

        bool IIndicator.IsActive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
