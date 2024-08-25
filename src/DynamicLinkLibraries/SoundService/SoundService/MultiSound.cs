using System;
using System.Collections.Generic;

using CategoryTheory;

using Diagram.UI;

using DataPerformer.Portable;
using DataPerformer.Interfaces;
using DataPerformer.Interfaces.Attributes;

using Event.Interfaces;

namespace SoundService
{
    /// <summary>
    /// Multiple sound
    /// </summary>
    [CalculationReasons(new string[] {StaticExtensionEventInterfaces.Realtime, "Testing" })]
    public class MultiSound  : CategoryObject, 
        IDataConsumer, IPostSetArrow, ITimeMeasurementConsumer, IRealtimeUpdate, 
        IStopped, IStarted
    {
        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        static private readonly char[] token = "_".ToCharArray();

        List<IMeasurements> measurements = new List<IMeasurements>();

        IMeasurement condition;

        IMeasurement sound;

        List<long> pause =  new List<long>();

        protected string conditionName;

        protected string soundName;
    
        IMeasurement timeMeasure;

        volatile bool running = false;

        double start;

        Func<bool> test;
 
        #endregion

        #region Ctor


        /// <summary>
        /// Default constructor
        /// </summary>
        public MultiSound()
        {
        }

  
        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
            onChangeInput();
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
            onChangeInput();
        }

        void IDataConsumer.UpdateChildrenData()
        {
            measurements.UpdateChildrenData();
        }

        int IDataConsumer.Count
        {
            get { return measurements.Count; }
        }
        
        IMeasurements IDataConsumer.this[int n]
        {
            get { return measurements[n]; }
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

        #region IPostSetArrow Members


        void IPostSetArrow.PostSetArrow()
        {
            Post();
        }

        #endregion

        #region ITimeMeasureConsumer Members

        IMeasurement ITimeMeasurementConsumer.Time
        {
            get
            {
                return timeMeasure;
            }
            set
            {
                timeMeasure = value;
            }
        }

        #endregion

        #region IRealtimeUpdate Members

        Action IRealtimeUpdate.Update
        {
            get
            {
                return RealtimeUpdate;
            }
        }

    
        event Action IRealtimeUpdate.OnUpdate
        {
            add { }
            remove { }
        }

        #endregion

        #region IStopped Members

        void IStopped.Stop()
        {
            running = false;
            test = () => { return false; };
        }

        #endregion

        #region IStarted Members

        void IStarted.Start(double time)
        {
            running = true;
            start = time;
            test = () =>
                {
                    if (!running)
                    {
                        return false;
                    }
                    if (start == Time)
                    {
                        return false;
                    }
                    test = () =>
                    {
                        return true;
                    };
                    return true;
                };
        }

        #endregion

        #region Own Members

        #region Public

        /// <summary>
        /// Condition
        /// </summary>
        public string Condition
        {
            get
            {
                return conditionName;
            }
            set
            {
                conditionName = value;
                Post();
            }
        }

        /// <summary>
        /// Sound
        /// </summary>
        public string Sound
        {
            get
            {
                return soundName;
            }
            set
            {
                soundName = value;
                Post();
            }
        }



        #endregion

        #region Private

        void RealtimeUpdate()
        {
            if (!test())
            {
                return;
            }
            bool soundCondition = (bool)condition.Parameter();      // Sound condition
            if (soundCondition)
            {
                string currentSound = sound.Parameter() as string;  // Sound file
                Play(currentSound);
            }                                                       // Plays sound
        }


        double Time
        {
            get
            {
                if (timeMeasure == null)
                {
                    return double.MinValue;
                }
                return (double)timeMeasure.Parameter();
            }
        }

        void Post()
        {
            try
            {
                condition = this.FindMeasurement(conditionName, true);
                sound = this.FindMeasurement(soundName, true);
            }
            catch (Exception ex)
            {
                ex.ShowError(1);
            }
        }

        /// <summary>
        /// Plays sound
        /// </summary>
        /// <param name="s">String with sound files</param>
        void Play(string s)
        {
            string[] sounds = s.Split(token); // Sounds
            Action play = () =>   // Play action
            {
                for (int i = 0; i < sounds.Length; i++)
                {
                    if (!running)
                    {
                        return;
                    }
                    string fn = sounds[i];
                    try
                    {
                        var pl = StaticExtensionSoundService.SoundFactory.SoundPlayer;
                        pl.SoundLocation = fn;
                        pl.PlaySync();
                    }
                    catch (Exception ex)
                    {
                        ex.ShowError(10);
                    }
                }
            };
            // Plays sounds in thread
            System.Threading.ThreadStart ts = new System.Threading.ThreadStart(play);
            System.Threading.Thread t = new System.Threading.Thread(ts);
            t.Start();
        }

        void PlaySounds(object soundsObj)
        {
            string[] sounds = soundsObj as string[];
            for (int i = 0; i < sounds.Length; i++)
            {
                try
                {
                    var pl = StaticExtensionSoundService.SoundFactory.SoundPlayer;
                    pl.SoundLocation = sounds[i];
                    pl.PlaySync();
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                }
            }
        }



        #endregion

        #endregion

    }
}
