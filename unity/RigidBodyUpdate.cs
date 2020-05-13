using Scada.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class RigidBodyUpdate : IUpdate
    {
        Action<double> fx;

        Action<double> fy;

        Action<double> fz;

        Action<double> mx;

        Action<double> my;

        Action<double> mz;


        Func<double> x;
        Func<double> y;
        Func<double> d;
        Func<double> ox;

        MonoBehaviour mono;


        public RigidBodyUpdate()
        {

        }

        void IUpdate.Set(MonoBehaviorWrapper wrapper, MonoBehaviour mono)
        {
            this.mono = mono;
            IScadaInterface scada = wrapper.Scada;
            fx = scada.GetDoubleInput("Force.Fx");
            fy = scada.GetDoubleInput("Force.Fy");
            fz = scada.GetDoubleInput("Force.Fz");
            mx = scada.GetDoubleInput("Force.Mx");
            my = scada.GetDoubleInput("Force.My");
            mz = scada.GetDoubleInput("Force.Mz");
            x = scada.GetDoubleOutput("Rigid Body.X");
            y = scada.GetDoubleOutput("Rigid Body.Y");
            d = scada.GetDoubleOutput("Measurements.Distance");
            ox = scada.GetDoubleOutput("Rigid Body.OMGx");

        }


        void IUpdate.Update()
        {
            PrintRigid();
        }

        void PrintRigid()
        {
            if (Input.GetKey(KeyCode.A))
            {
                fx(0.1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                fx(-0.1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                mx(0.01);
            }
            if (Input.GetKey(KeyCode.F))
            {
                mx(-0.01);
            }
            Debug.Log(x() + " " + ox());
        }


    }
}
