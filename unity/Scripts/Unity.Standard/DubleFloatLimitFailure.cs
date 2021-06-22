using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard.Interfaces;

namespace Unity.Standard
{
    public class DubleFloatLimitFailure : IFailureMessage
    {
        #region Fields

        Func<double> f;

        float[] limits;

        float scale;

        string name;

        #endregion

        public DubleFloatLimitFailure(Func<double> f, float[] limits, float scale, string name)
        {
            this.f = f;
            this.limits = limits;
            this.scale = Math.Abs(scale);
            this.name = name;
            StaticExtensionUnity.FailureMessages.Add(this);
        }

        string IFailureMessage.Message => GetMessage();

        string GetMessage()
        {
            float a = (float)f() * scale;
            if ((a > limits[0]) & (a < limits[1]))
            {
                return null;
            }
            return "";
        }
    }
}
