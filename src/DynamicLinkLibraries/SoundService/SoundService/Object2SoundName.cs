﻿using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;


using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;
using DataPerformer.Interfaces;
using NamedTree;

namespace SoundService
{
    /// <summary>
    /// Converter of digit to sound
    /// </summary>
    public class Object2SoundName : CategoryObject, 
        IDataConsumer, IMeasurements, IPostSetArrow
    {
        #region Fields

    
        protected string[] inputs = new string[0];

 
        IMeasurement[] outMea;

        List<IMeasurements> measurements = new List<IMeasurements>();

        bool isUpdated = false;

        private event Action onChangeInput;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Object2SoundName()
        {

        }
 
        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Post();
        }

        #endregion

        #region IDataConsumer Members

        void IChildren<IMeasurements>.AddChild(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
            onChangeInput?.Invoke();
        }

        void IChildren<IMeasurements>.RemoveChild(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
            onChangeInput?.Invoke();
        }

        void IDataConsumer.UpdateChildrenData()
        {
            measurements.UpdateChildrenData();
        }

        int IDataConsumer.Count
        {
            get { return measurements.Count; }
        }

        IMeasurements IDataConsumer.this[int number]
        {
            get { return measurements[number]; }
        }

        void IDataConsumer.Reset()
        {
            this.FullReset();
        }

        event Action IDataConsumer.OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return outMea.Length; }
        }

        IMeasurement IMeasurements.this[int number]
        {
            get { return outMea[number]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            this.UpdateChildrenData();
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return isUpdated;
            }
            set
            {
                isUpdated = value;
            }
        }

        #endregion

        #region Own Members

        #region Public Members

        /// <summary>
        /// Inputs
        /// </summary>
        public string[] Inputs
        {
            get
            {
                return inputs;
            }
            set
            {
                inputs = value;
                Post();
            }
        }

        IEnumerable<IMeasurements> IChildren<IMeasurements>.Children => measurements;

        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => outMea;

        /// <summary>
        /// On Change input
        /// </summary>
        public event Action OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurements> IChildren<IMeasurements>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }


        #endregion

        #region Private Members

        void Post()
        {
            int n = inputs.Length;
            outMea = new IMeasurement[n];
            for (int i = 0; i < n; i++)
            {
                Func<object, string> func = ConvertDouble;
                var m = this.FindMeasurement(inputs[i], false);
                var k = i;
                Func<object> f = () =>
                 {
                     try
                     {
                         var finp = m.Parameter;
                         object p = finp();
                         if (p == null)
                         {
                             return null;
                         }
                         var o = (object)func(p);
                         return o;
                       
                     }
                     catch (Exception ex)
                     {
                     }
                     return "";
                 };
                outMea[i] = new Measurement("", f, "Sound_" + (i + 1), this);
            }
        }

        /// <summary>
        /// Coversion of object to sound file
        /// </summary>
        /// <param name="o">Coverted object</param>
        /// <returns>Sound filename(s)</returns>
        string ConvertDouble(object o)
        {
            StringBuilder sb = new StringBuilder();
            double d = (double)o;
            if (d < 0)
            {
                sb.Append("minus.wav_");
                d = -d;
            }
            uint h = (uint)d;
            if (h < 100)
            {
                TwoDigit(h, sb);
            }
            else if (h < 1000)
            {
                uint x = h % 100;
                uint y = (h - x) / 100;
                sb.Append(y);
                sb.Append(".wav_");
                sb.Append("hundred.wav");
                if (x > 0)
                {
                    sb.Append("_");
                    TwoDigit(x, sb);
                }
            }
            else
            {
                uint x = h % 100;
                uint y = (h - x) / 100;
                TwoDigit(y, sb);
                sb.Append("_");
                TwoDigit(x, sb);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Convers two didit integer to string
        /// </summary>
        /// <param name="m">Two digit integer</param>
        /// <param name="sb">String builder</param>
        void TwoDigit(uint m, StringBuilder sb)
        {
            if (m < 20)
            {
                sb.Append(m);
                sb.Append(".wav");
                return;
            }
            uint x = m % 10;
            uint y = (m - x) / 10;
            if (y > 1)
            {
                sb.Append(y);
                sb.Append("0.wav");
                if (x > 0)
                {
                    sb.Append("_");
                    sb.Append(x);
                    sb.Append(".wav");
                }
            }
            else
            {
                sb.Append(x);
                sb.Append(".wav");
            }
        }

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
        }

        #endregion

        #endregion


    }
}
