using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Interfaces
{
    /// <summary>
    /// Asynchronous calculation
    /// </summary>
    public interface IAsynchronousCalculation
    {
        /// <summary>
        /// Starts itself
        /// </summary>
        /// <param name="time"></param>
        void Start(double time);
        
        /// <summary>
        /// Step
        /// </summary>
        Action<double> Step
        {
            get;
        }

        /// <summary>
        /// Stops itself
        /// </summary>
        void Interrupt();

        /// <summary>
        /// Suspends itself
        /// </summary>
        void Suspend();

        /// <summary>
        /// The "is running" sign
        /// </summary>
        bool IsRunning
        {
            get;
        }

        /// <summary>
        /// Suspend event
        /// </summary>
        event Action OnSuspend;

        /// <summary>
        /// Finish event
        /// </summary>
        event Action Finish;

        /// <summary>
        /// Interrupt
        /// </summary>
        event Action OnInterrupt;
 
    }
}
