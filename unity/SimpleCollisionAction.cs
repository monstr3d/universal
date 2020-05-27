using Motion6D.Interfaces;
using Scada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Standard;
using UnityEngine;
using UnityEngine.UI;
using Vector3D;

namespace Assets
{
    public class SimpleCollisionAction : AbstractCollisionAction
    {
        public SimpleCollisionAction()
        {
            constants = new float[12];
        }

        public override void Set(GameObject gameObject, Component collisionIndicator, IScadaInterface scada)
        {
            base.Set(gameObject, collisionIndicator, scada);
        }

        public override Action<Collision> Action => Update;

        void Update(Collision collision)
        {
            if (collisionIndicator is ResultIndicator)
            {
                ResultIndicator ri = collisionIndicator as ResultIndicator;
                ri.Indicate();
            }
            scada.IsEnabled = false;
            Dictionary<string, List<Text>> d = gameObject.GetGameObjectComponents<Text>();
            Text message = d["Message_Txt"][0];
            message.text = "GOOD!!";
            ReferenceFrame frame = scada.GetOutput("Relative to station.Frame")() as ReferenceFrame;
            double time = (double)scada.GetOutput("Station motion.Formula_13")();
            if (time > (double)constants[6])
            {

            }
            IVelocity v = frame as IVelocity;
            double[] vd = v.Velocity;

            string ve = "Velocty ";
            EulerAngles angles = new EulerAngles();
            angles.Set(frame.Quaternion);
        }
    }
}
