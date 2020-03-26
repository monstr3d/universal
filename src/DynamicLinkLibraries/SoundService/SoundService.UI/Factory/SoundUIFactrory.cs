using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CategoryTheory;

using Diagram.UI.Factory;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Diagram.UI;


namespace SoundService.UI.Factory
{
    /// <summary>
    /// Factory of sound ojects
    /// </summary>
    public class SoundUIFactrory : EmptyUIFactory
    {
        #region Fields

        public static readonly SoundUIFactrory Singleton =
            new SoundUIFactrory();

        public static readonly ButtonWrapper[] ObjectButtons =
        new ButtonWrapper[] 
                {
                            new ButtonWrapper(typeof(SoundCollection),
                    "", "Sounds", ResourceImage.audio, null, false, false),
                            new ButtonWrapper(typeof(MultiSound),
                    "", "Multiple Sound", ResourceImage.pcdrsound, null, true, false),
                            new ButtonWrapper(typeof(Object2SoundName),
                    "", "Sound name converter", ResourceImage.pcdrsounddigit, null, true, false)
   
                };

        private static bool hasTests = false;


        #endregion

        #region Ctor

        private SoundUIFactrory()
        {
        }

        #endregion

        #region Overriden

        public override IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            Type type = button.ReflectionType;
            if (type.Equals(typeof(SoundCollection)))
            {
                return typeof(SoundService.UI.Labels.SoundCollectionLabel).CreateLabelUI(false);
            }
            if (type.Equals(typeof(MultiSound)))
            {
                return typeof(SoundService.UI.Labels.MultiSoundLabel).CreateLabelUI(true);
            }
            if (type.Equals(typeof(Object2SoundName)))
            {
                return typeof(SoundService.UI.Labels.Object2SoundNameLabel).CreateLabelUI(true);
            }
            return null;
        }

        #endregion

        #region Own Members

        /// <summary>
        /// Has tests
        /// </summary>
        static public bool HasTests
        {
            get
            {
                return hasTests;
            }
            set
            {
                hasTests = value;
            }
        }
        #endregion
    }
}
