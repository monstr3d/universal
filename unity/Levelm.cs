using System;

using UnityEngine;


using Motion6D.Interfaces;

using Scada.Interfaces;

using Vector3D;

using Unity.Standard;

namespace Assets
{
    public abstract class Levelm : AbstractLevelStringUpdate
    {

        #region Fields

        protected EulerAngles angles = new EulerAngles();

        protected ReferenceFrame frame;

        protected IAngularVelocity aVelocity;

        protected IOrientation orientation;

        protected IVelocity velocity;

        protected IEvent ev;

        protected IScadaInterface scada;

        protected Func<double> fx;

        protected Func<double> fy;

        protected Func<double> fz;

        protected Action<double> ax;

        protected Action<double> ay;

        protected Action<double> az;

        protected Action<double> mx;

        protected Action<double> my;

        protected Action<double> mz;

        protected static Levelm levelm;

        protected string[] controls;

        #endregion

        protected Levelm()
        {
            levelm = this;
            Level0.Get(out scada, out ev, out frame);
            aVelocity = frame as IAngularVelocity;
            velocity = frame as IVelocity;
            orientation = frame as IOrientation;
            fx = scada.GetDoubleOutput("Force.Fz");
            fy = scada.GetDoubleOutput("Force.Fy");
            fz = scada.GetDoubleOutput("Force.Fx");
            ax = scada.GetDoubleInput("Force.Fz");
            ay = scada.GetDoubleInput("Force.Fy");
            az = scada.GetDoubleInput("Force.Fx");
            mx = scada.GetDoubleInput("Force.Mz");
            my = scada.GetDoubleInput("Force.My");
            mz = scada.GetDoubleInput("Force.Mx");
            controls = new string[] { Level0.LongXK, Level0.ShortXK,
             Level0.LongXC, Level0.ShortXC, Level0.LimitedXC, Level0.YControl, Level0.OzK1,
             Level0.ZControl, Level0.OxControl, Level0.OyControl, Level0.OzControl1, Level0.OzControl};
            ev.Event += () =>
            {
                ForcesIndicator.indicator.Torch();

            };

        }
 
        protected void StopAll()
        {
            foreach (var s in controls)
            {
                (Level0.RigidBodyStation + "." + s).EnableDisable(false);
            }
            mx(0);
            my(0);
            mz(0);
            ax(0);
            ay(0);
            az(0);
        }

        static public void Collision(Tuple<GameObject, Component, IScadaInterface, ICollisionAction> stop)
        {
            levelm.StopAll();
            Level0.Collision(stop);
        }
       
    }
}
