using Motion6D.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector3D;

namespace Motion6D.Uniform6D
{
    /// <summary>
    /// Linear 6D motion
    /// </summary>
    public class Uniform6DMotion
    {
        #region Fields

        protected Vector3DProcessor vp = new();

        double aMax;

        double aMin;

        double[] begin = new double[3];

        double[] end = new double[3];

        double[] quaternionBegin = new double[4];

        double[] quaternionEnd = new double[4];

        double[] rotationAxis;

        double[] auxVectorFrame = new double[3];

        double[] auxQuarterInter = new double[4];

        double[] auxQuaterFrame = new double[4];

        double[] auxVectorInternal = new double[3];

        double[] interruptQuaternion = new double[4];

        double[] interruptQuaternionFinal = new double[4];

        double[] interruptQuaternionCompare = new double[4];
      
        double[] auxQuaterInternal = new double[4];

        double[] interruptVector = new double[3];


        double[] interruptVectorFinal = new double[3];
       
        /// <summary>
        /// Reference frame
        /// </summary>
        ReferenceFrame frame;

        /// <summary>
        /// Velocity object
        /// </summary>
        IVelocity velocity;

        /// <summary>
        /// Angular velocity object
        /// </summary>
        IAngularVelocity angularVelocity;

        double startTime;

        double forecastTime;

        double[] changeFrameTime;

        double lastTime;

        double time;

        bool next = true;

        double coordError;

        double angleError;

        object loc = new object();

        private Action change = () => { };
  
        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="frame">Refernce frame</param>
        /// <param name="rotationAxis">Rotation axis</param>
        /// <param name="changeFrameTime">Time of frame change</param>
        /// <param name="forecastTime">Time of forecast</param>
        /// <param name="coordError">Error of coordinate</param>
        /// <param name="angleError">Error of angle</param>
        public Uniform6DMotion(ReferenceFrame frame, double[] rotationAxis, double[] changeFrameTime, 
            double forecastTime, double coordError, double angleError)
        {
            this.frame = frame;
            this.rotationAxis = rotationAxis;
            this.changeFrameTime = changeFrameTime;
            this.forecastTime = forecastTime;
            this.coordError = coordError;
            this.angleError = angleError;
        }

        #endregion

        #region Members
        
        #region Public

        /// <summary>
        /// Initialize itself
        /// </summary>
        /// <param name="coord">Coordinates</param>
        /// <param name="quaternion">Quaternion</param>
        public void Init(double[] coord, double[] quaternion)
        {
            Array.Copy(coord, begin, 3);
            Array.Copy(quaternion, quaternionBegin, 4);
        }

        /// <summary>
        /// Sets time
        /// </summary>
        /// <param name="time">Time</param>
        /// <param name="angle">Angle</param>
        /// <param name="x">X - coordinate</param>
        /// <param name="y">Y - coordinate</param>
        /// <param name="z">Z - coordinate</param>
        public void SetTime(double time, out double angle, out double x, out double y, out double z)
        {
          //  lock (loc)
           // {
                this.time = time;
                double p1 = 1 - time;
                angle = p1 * aMin + time * aMax;
                x = begin[0] * p1 + end[0] * time;
                y = begin[1] * p1 + end[1] * time;
                z = begin[2] * p1 + end[2] * time;
           // }
        }
   
        /// <summary>
        /// Next
        /// </summary>
        /// <param name="currentTime">Current time</param>
        public void Next(double currentTime)
        {
            if (next)
            {
                LinearPrediction(currentTime);
                SetNew(auxVectorFrame, auxQuaterFrame);
                return;
            }
            double da = aMax - aMin;
            aMin += da;
            aMax += da;
            for (int i = 0; i < 3; i++)
            {
                da = end[i] - begin[i];
                begin[i] += da;
                end[i] += da;
            }
        }

        /// <summary>
        /// Initialization of prediction
        /// </summary>
        public void InitializePrediction(double forecastTime)
        {
            if (!(frame is IVelocity))
            {
                throw new Exception("Frame does not support velocity");
            }
            if (!(frame is IAngularVelocity))
            {
                throw new Exception("Frame does not support angular velocity");
            }
            velocity = frame as IVelocity;
            angularVelocity = frame as IAngularVelocity;
        }
 
        /// <summary>
        /// Copy of itself
        /// </summary>
        /// <returns>A copy</returns>
        public Uniform6DMotion Copy()
        {
            Uniform6DMotion l = 
                new Uniform6DMotion(frame, rotationAxis, changeFrameTime, forecastTime,
                    coordError, angleError);
            l.begin = begin;
            l.end = end;
            l.quaternionBegin = quaternionBegin;
            l.quaternionEnd = quaternionEnd;
            l.Set(begin, quaternionBegin, end, quaternionEnd);
            return l;
        }

        /// <summary>
        /// Sets inself
        /// </summary>
        /// <param name="coord">Coordinates</param>
        /// <param name="quater">Quaternin</param>
        /// <returns>Angle</returns>
        public  double Set(double[] coord, double[] quater)
        {
            return Set(begin, quaternionBegin, coord, quater);
        }

        /// <summary>
        /// Sets itself
        /// </summary>
        /// <param name="coord">Coordinates</param>
        /// <param name="quater">Quaternion</param>
        /// <returns>Angle</returns>
        public double SetNew(double[] coord, double[] quater)
        {
            return Set(end, quaternionEnd, coord, quater);
        }

        /// <summary>
        /// Begin
        /// </summary>
        public double[] Begin
        {
            get
            {
                return begin;
            }
        }

        /// <summary>
        /// Change event
        /// </summary>
        public event Action Change
        {
            add { change += value; }
            remove { change -= value; }
        }
 
        /// <summary>
        /// Begin quaternion
        /// </summary>
        public double[] QuaternionBegin
        {
            get
            {
                return quaternionBegin;
            }
        }

        /// <summary>
        /// Interruption
        /// </summary>
        /// <param name="currentTime">Time</param>
        public void Interrupt(double currentTime)
        {
            lock (loc)
            {
                LinearPrediction(currentTime + forecastTime, quaternionEnd, end, interruptQuaternionCompare);
                LinearPrediction(currentTime, quaternionBegin, begin, interruptQuaternionCompare);
                Set(begin, quaternionBegin, end, quaternionEnd);
                change();
            }
        }

        /// <summary>
        /// Realtime step
        /// </summary>
        /// <param name="time">Step</param>
        public void StepRealtime(double time)
        {
            lastTime = changeFrameTime[0];
            Array.Copy(end, begin, 3);
            Array.Copy(quaternionEnd, quaternionBegin, 4);
            double delta = time + forecastTime;
            LinearPrediction(delta, quaternionEnd, end, auxQuaterInternal);
            Set(begin, quaternionBegin, end, quaternionEnd);
        }

        /// <summary>
        /// Starts realtime
        /// </summary>
        /// <param name="time">Time</param>
        public void StartRealtime(double time)
        {
            startTime = time;
            lastTime = time;
            //double delta = time - changeFrameTime[0];
            LinearPrediction(time, quaternionBegin, begin, interruptQuaternion);
            LinearPrediction(time + forecastTime, quaternionEnd, end, interruptQuaternion);
            Set(begin, quaternionBegin, end, quaternionEnd);
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Linear prediction
        /// </summary>
        /// <param name="time">Current time</param>
        private void LinearPrediction(double time)
        {
            lastTime = time;
            double delta = time - changeFrameTime[0]; // Forecast time
            double[] coord = frame.Position;          // Coordinates of frame
            double[] v = velocity.Velocity;           // Velocity vector
            for (int i = 0; i < 3; i++)
            {
                auxVectorFrame[i] = coord[i] + v[i] * delta; // Linear prediction of coordinates
            }
            double[] omega = angularVelocity.Omega; // Angular velocity vector
            double mod = omega[0] * omega[0] + omega[1] * omega[1] + omega[2] * omega[2];
            mod = Math.Sqrt(mod);
            Array.Copy(omega, 0, auxQuarterInter, 1, 3); // Calculation of "shift" quaternion
            double angle = 0.5 * mod * delta;
            double s = Math.Sin(angle);
            double c = Math.Cos(angle);
            auxQuarterInter[0] = c;
            double smod = s / mod;
            for (int i = 1; i < 3; i++)
            {
                auxQuarterInter[i] *= smod;
            }
            QuaternionMultiply(frame.Quaternion, auxQuarterInter, auxQuaterFrame); // Calculation of quaternion
        }

        void CalculateInternal()
        {
            double p1 = 1 - time;
            double angle = p1 * aMin + time * aMax;
            for (int i = 0; i < 3; i++)
            {
                auxVectorInternal[i] = begin[i] * p1 + end[i] * time;
            }
            double s = Math.Sin(angle);
            double c = Math.Cos(angle);
            auxQuaterInternal[0] = c;
            Array.Copy(rotationAxis, 0, auxQuaterInternal, 1, 3);
            for (int i = 0; i < 3; i++)
            {
                auxQuaterInternal[i] *= s;
            }
        }

       

        /// <summary>
        /// Multiplication of quaternion
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">Product</param>
        private static void QuaternionMultiply(double[] x, double[] y, double[] z)
        {
            z[0] = x[0] * y[0] - x[1] * y[1] - x[2] * y[2] - x[3] * y[3];
            z[1] = x[0] * y[1] + x[1] * y[0] + x[2] * y[3] - x[3] * y[2];
            z[2] = x[0] * y[2] + x[2] * y[0] + x[3] * y[1] - x[1] * y[3];
            z[3] = x[0] * y[3] + x[3] * y[0] + x[1] * y[2] - x[2] * y[1];
        }

        /// <summary>
        /// Invert multiplication of quaternions
        /// </summary>
        /// <param name="x">First term</param>
        /// <param name="y">Second term</param>
        /// <param name="z">Product</param>
        private  void QuaternionInvertMultiply(double[] x, double[] y, double[] z)
        {
            z[0] = x[0] * y[0] + x[1] * y[1] + x[2] * y[2] + x[3] * y[3];
            z[1] = x[0] * y[1] - x[1] * y[0] - x[2] * y[3] + x[3] * y[2];
            z[2] = x[0] * y[2] - x[2] * y[0] - x[3] * y[1] + x[1] * y[3];
            z[3] = x[0] * y[3] - x[3] * y[0] - x[1] * y[2] + x[2] * y[1];
        }


        private double Set(double[] coord1, double[] quater1, double[] coord2, double[] quater2)
        {
            Array.Copy(coord1, begin, 3);
            Array.Copy(coord2, end, 3);
            Array.Copy(quater1, quaternionBegin, 4);
            Array.Copy(quater2, quaternionEnd, 4);
            vp.QuaternionInvertMultiply(quaternionBegin, quaternionEnd, auxQuaterInternal);
            QuaternionNorm(auxQuaterInternal);
            double s = auxQuaterInternal[0];
            if (s > 0.99999999999999999999)
            {
                aMax = 0;
                aMin = 0;
                aMax = aMin;
                rotationAxis[0] = 1;
                return aMax;
            }
            aMin = 0;
            aMax = 2 * Math.Acos(Math.Sqrt(s));
            Array.Copy(auxQuaterInternal, 1, rotationAxis, 0, 3);
            double mod = rotationAxis[0] * rotationAxis[0] + rotationAxis[1] * rotationAxis[1] + rotationAxis[2] * rotationAxis[2];
            if (mod < 0.000000000001)
            {
                rotationAxis[0] = 1;
                return 0;
            }
            mod = 1 / Math.Sqrt(mod);
            for (int i = 0; i < 3; i++)
            {
                rotationAxis[i] *= mod;
            }
            return aMax;
        }

        private void LinearPrediction(double time, double[] quaterOutput, double[] coord, double[] quaternionAux)
        {
            double delta = time - changeFrameTime[0];
            double[] quaternion = frame.Quaternion;
            double[] omega = angularVelocity.Omega;
            double mod = omega[0] * omega[0] + omega[1] * omega[1] + omega[2] * omega[2];
            mod = Math.Sqrt(mod);
            if (mod < 0.00000000001)
            {
                Array.Copy(quaternion, quaterOutput, 4);
            }
            else
            {
                double angle = 0.5 * mod * delta;
                quaternionAux[0] = Math.Cos(angle);
                double s = Math.Sin(angle) / mod;
                for (int i = 0; i < 3; i++)
                {
                    quaternionAux[i + 1] = omega[i] * s;
                }
                QuaternionMultiply(frame.Quaternion, quaternionAux, quaterOutput);
            }
            double[] v = velocity.Velocity;
            double[] p = frame.Position;
            for (int i = 0; i < 3; i++)
            {
                coord[i] = p[i] + delta * v[i];
            }
        }

        private void LinearPrediction(double[] quaterOutput, double[] coord, double[] quaternionAux)
        {
            double p = 1 - time;
            double mod = Math.Sqrt(
              rotationAxis[0] * rotationAxis[0] +
              rotationAxis[1] * rotationAxis[1] +
              rotationAxis[2] * rotationAxis[2]);
            if (mod < 0.00000000001)
            {
                Array.Copy(quaternionBegin, quaterOutput, 4);
            }
            else
            {
                double angle = aMin * p + aMax * time;
                Array.Copy(rotationAxis, 0, quaternionAux, 1, 3);
                quaternionAux[0] = Math.Cos(angle);
                double s = Math.Sin(angle);
                for (int i = 0; i < 3; i++)
                {
                    quaternionAux[i + 1] *= s;
                }
                QuaternionMultiply(quaternionBegin, quaternionAux, quaterOutput);
            }
            for (int i = 0; i < 3; i++)
            {
                coord[i] = begin[i] * p + end[i] * time;
            }
        }

        private void QuaternionNorm(double[] quaternion)
        {
            double mod = quaternion[0] * quaternion[0] +
                quaternion[1] * quaternion[1] +
                quaternion[2] * quaternion[2] +
                quaternion[3] * quaternion[3];
            mod = 1 / Math.Abs(mod);
            for (int i = 0; i < 4; i++)
            {
                quaternion[i] *= mod;
            }
        }

        private double QuaterModule(double[] quaternion)
        {
            return Math.Sqrt(quaternion[1] * quaternion[1] +
                quaternion[2] * quaternion[2] +
                quaternion[3] * quaternion[3]);
        }


        #endregion

        #endregion

    }
}
