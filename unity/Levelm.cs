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

        protected IAngularVelocity av;

        protected IEvent ev;

        protected IScadaInterface scada;

        protected Func<double> fx;

        protected Func<double> fy;

        protected Func<double> fz;

        protected Action<double> ax;

        protected Action<double> ay;

        protected Action<double> az;



        #endregion

        public Levelm()
        {
            Level0.Get(out scada, out ev, out frame);
            av = frame as IAngularVelocity;
            fx = scada.GetDoubleOutput("Force.Fz");
            fy = scada.GetDoubleOutput("Force.Fy");
            fz = scada.GetDoubleOutput("Force.Fx");
            ax = scada.GetDoubleInput("Force.Fz");
            ay = scada.GetDoubleInput("Force.Fy");
            az = scada.GetDoubleInput("Force.Fx");
        }

    }
}
