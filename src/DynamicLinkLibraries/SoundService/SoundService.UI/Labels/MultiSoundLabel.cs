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
    public class MultiSoundLabel : UserControlBaseLabel
    {
        #region Fields

        MultiSound sound;

        UserControlMultiSound userControlMultiSound;

        int stepCount;

        double step;

        double start;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MultiSoundLabel()
            : base(typeof(MultiSound), "", Properties.Resources.pcdrsound.ToBitmap())
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected MultiSoundLabel(SerializationInfo info, StreamingContext context)
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
                ex.HandleException(1);
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
                userControlMultiSound = new UserControlMultiSound();
                return userControlMultiSound;
            }
        }

        /// <summary>
        /// Object
        /// </summary>
        protected override ICategoryObject Object
        {
            get
            {
                return sound;
            }
            set
            {
                if (!(value is MultiSound))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                sound = value as MultiSound;
                if (userControlMultiSound != null)
                {
                    userControlMultiSound.Sound = sound;
                }
             }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public override void Post()
        {
            userControlMultiSound.Post();
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