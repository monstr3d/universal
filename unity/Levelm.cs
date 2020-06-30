using System;

using Motion6D.Interfaces;

using Scada.Interfaces;

using Unity.Standard;

namespace Assets
{
    public abstract class  Levelm : AbstractLevelStringUpdate
    {

        #region Fields

        protected ReferenceFrame frame;

        protected IEvent ev;

        protected IScadaInterface scada;

        protected Func<double> fx;

        protected Func<double> fy;

        protected Func<double> fz;


        #endregion

        public Levelm()
        {
            Level0.Get(out scada, out ev, out frame);
            fx = scada.GetDoubleOutput("Force.Fz");
            fy = scada.GetDoubleOutput("Force.Fy");
            fz = scada.GetDoubleOutput("Force.Fx");
        }

    }
}
