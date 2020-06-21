using Motion6D.Interfaces;
using Scada.Desktop;
using Scada.Interfaces;
using System;

using Unity.Standard;

namespace Assets
{
    public class Levelm2 : AbstractLevelStringUpdate
    {
        ReferenceFrame frame;

        Action update;

        public Levelm2()
        {
            update = () =>
            {
                double[] p = frame.Position;
                if (Math.Abs(p[1]) < 0.5)
                {
                    (SimpleActivation.RigidBodyStation + "." +
                        SimpleActivation.LongX).EnableDisable(true);
                    update = () => { };
                }
 
            };
            IScadaInterface scada = SimpleActivation.RigidBodyStation.ToExistedScada();
            scada["Force"].Event += Levelm2_Event;
            frame = scada.GetOutput("Relative to station.Frame")() as ReferenceFrame;
        }

        private void Levelm2_Event()
        {
            update();
        }

        protected override void Update()
        {
            
        }

        
    }
}

