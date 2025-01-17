using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using SoundService.UI.UserControls;
using SoundService.UI.Factory;
using ErrorHandler;




namespace SoundService.UI.Labels
{
    [Serializable()]
    public class SoundCollectionLabel : UserControlBaseLabel
    {
        #region Fields

        SoundCollection sounds;

        UserControlSoundCollection userControlSoundCollection;

        UserControlSoundFull userControlSoundFull;

        int stepCount;

        double step;

        double start;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SoundCollectionLabel()
            : base(typeof(SoundCollection), "", Properties.Resources.audio.ToBitmap())
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SoundCollectionLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            try
            {
                stepCount = info.GetInt32("StepCount");
                step = info.GetDouble("Step");
                start = info.GetDouble("Begin");
            }
            catch (Exception ex)
            {
                ex.ShowError(1);
            }
        }

        #endregion

        #region Overriden

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("StepCount", stepCount);
            info.AddValue("Step", step);
            info.AddValue("Begin", start);

        }


        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {
                if (SoundUIFactory.HasTests)
                {
                    userControlSoundFull = new UserControlSoundFull();
                    userControlSoundFull.AcceptTest += (double x, double y, int z) =>
                        {
                            start = x;
                            step = y;
                            stepCount = z;
                        };
                    return userControlSoundFull;
                }
                userControlSoundCollection = new UserControlSoundCollection();
                return userControlSoundCollection;
            }
        }

        /// <summary>
        /// Object
        /// </summary>
        public override ICategoryObject Object
        {
            get
            {
                return sounds; ;
            }
            set
            {
                if (!(value is SoundCollection))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                sounds = value as SoundCollection;
                if (userControlSoundCollection != null)
                {
                    userControlSoundCollection.SoundCollection = sounds;
                }
                else
                {
                    userControlSoundFull.SoundCollection = sounds;
                }
            }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public override void Post()
        {
            if (userControlSoundCollection != null)
            {
                userControlSoundCollection.Post();
            }
            else
            {
                userControlSoundFull.Set(start, step, stepCount);
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Test data
        /// </summary>
        public object[] TestData
        {
            get
            {
                return new object[] { start, step, stepCount };
            }
        }

        #endregion
    }
}