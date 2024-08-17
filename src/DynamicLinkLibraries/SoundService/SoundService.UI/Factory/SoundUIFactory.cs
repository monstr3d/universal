using Diagram.UI.Factory;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI;


namespace SoundService.UI.Factory
{
    /// <summary>
    /// Factory of sound ojects
    /// </summary>
    public class SoundUIFactory : EmptyUIFactory
    {
        #region Fields

        public static readonly SoundUIFactory Singleton =
            new SoundUIFactory();

        public static ButtonWrapper[] ObjectButtons = 
       [
                            new ButtonWrapper(typeof(Serializable.SoundCollection),
                    "", "Sounds", Properties.Resources.audio, null, false, false),
                            new ButtonWrapper(typeof(MultiSound),
                    "", "Multiple Sound", Properties.Resources.pcdrsound, null, true, false),
                            new ButtonWrapper(typeof(Object2SoundName),
                    "", "Sound name converter", Properties.Resources.pcdrsounddigit, null, true, false)

          ];

        private static bool hasTests = false;


        #endregion

        #region Ctor

 /*       static SoundUIFactory()
        {
            try
            {

                ObjectButtons = [
                                    new ButtonWrapper(typeof(Serializable.SoundCollection),
                            "", "Sounds", Properties.Resources.audio, null, false, false),
                            new ButtonWrapper(typeof(MultiSound),
                    "", "Multiple Sound", Properties.Resources.pcdrsound, null, true, false),
                            new ButtonWrapper(typeof(Object2SoundName),
                    "", "Sound name converter", Properties.Resources.pcdrsounddigit, null, true, false)
                            

          ];
            }
            catch (Exception ex)
            {

            }

        }*/

        private SoundUIFactory()
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
