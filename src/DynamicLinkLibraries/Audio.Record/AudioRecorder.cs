using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using DataPerformer.Interfaces;

using Event.Interfaces;

using Audio.Record.Interfaces;

namespace Audio.Record
{
    /// <summary>
    /// Audio recorder
    /// </summary>
    public class AudioRecorder : CategoryObject, IRealTimeStartStop, ICalculationReason
    {

        #region Fields

        protected IAudioRecorder recorder;

        string calculationReason = "";

        Queue<string> queue = new Queue<string>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AudioRecorder()
        {
            recorder = StaticExtensionAudioRecord.RecorderFactory.GetDefault(false);
        }

        /// <summary>
        /// Fiction constructor
        /// </summary>
        /// <param name="b">Fiction parameter</param>
        protected AudioRecorder(bool b)
        {

        }

        #endregion

        #region IRealTimeStartStop Members

        event Action IRealTimeStartStop.OnStart
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action IRealTimeStartStop.OnStop
        {
            add
            {
            }

            remove
            {

            }
        }

        void IRealTimeStartStop.Start()
        {
            if (calculationReason.Equals("Realtime"))
            {
                recorder.Start("");
            }
        }

        void IRealTimeStartStop.Stop()
        {
            if (calculationReason.Equals("Realtime"))
            {
                recorder.Stop();
                queue.Enqueue(recorder.Id);
            }
        }

        #endregion

        #region ICalculationReason Members

        string ICalculationReason.CalculationReason
        {
            get
            {
                return calculationReason;
            }

            set
            {
                calculationReason = value;
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Dequeue
        /// </summary>
        public string Dequeue
        {
            get
            {
                if (queue.Count == 0)
                {
                    return null;
                }
                return queue.Dequeue();
            }
        }

        /// <summary>
        /// Recorder
        /// </summary>
        public IAudioRecorder Recorder
        {
            get
            { return recorder; }
        }

        #endregion
    }
}
