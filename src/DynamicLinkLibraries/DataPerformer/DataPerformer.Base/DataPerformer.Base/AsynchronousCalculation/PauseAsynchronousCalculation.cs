using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DataPerformer.Interfaces;

namespace DataPerformer.AsynchronousCalculation
{
    /// <summary>
    /// Pause asynchronous calculation
    /// </summary>
    public class PauseAsynchronousCalculation : IAsynchronousCalculation
    {
        #region Fields

        private Action<double> pause;

        private bool isRunning = false;

        object loc = new object();

        Action onInterrupt = () => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pauseSpan">Pause time span</param>
        public PauseAsynchronousCalculation(TimeSpan pauseSpan)
        {
            pause = (double time) =>
            {
                lock (loc)
                {
                    if (isRunning)
                    {
                        return;
                    }
                    isRunning = true;
                }
                Thread.Sleep(pauseSpan);
                lock (loc)
                {
                    isRunning = false;
                }
            };
        }

        #endregion

        #region IAsynchronousCalculation

        void IAsynchronousCalculation.Start(double time)
        {

        }

        Action<double> IAsynchronousCalculation.Step
        {
            get { return Pause; }
        }

        void IAsynchronousCalculation.Interrupt()
        {
            lock (loc)
            {
                isRunning = false;
                pause = (double time) => { };
            }
        }

        void IAsynchronousCalculation.Suspend()
        {

        }

        bool IAsynchronousCalculation.IsRunning
        {
            get { return isRunning; }
        }

        event Action IAsynchronousCalculation.OnSuspend
        {
            add { }
            remove { }
        }

        event Action IAsynchronousCalculation.Finish
        {
            add { }
            remove { }
        }

        event Action IAsynchronousCalculation.OnInterrupt
        {
            add { onInterrupt += value; }
            remove { onInterrupt -= value; }
        }

        #endregion

        #region Private Members

        private void Pause(double time)
        {
            pause(time);
        }

        #endregion

    }
}