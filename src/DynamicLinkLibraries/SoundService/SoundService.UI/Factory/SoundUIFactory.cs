using Diagram.UI.Factory;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;
using Diagram.UI;


namespace SoundService.UI.Factory
{
    /// <summary>
    /// Factory of sound ojects
    /// </summary>
    internal class SoundUIFactory : EmptyUIFactory
    {
        #region Fields

        public static readonly SoundUIFactory Singleton =
            new SoundUIFactory();

  
        private static bool hasTests = false;


        #endregion

        #region Ctor

        private SoundUIFactory()
        {
            this.Add();
        }

        #endregion

        #region Overriden

        public override IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            Type type = button.ReflectionType;
            if (type.Equals(typeof(Serializable.SoundCollection)))
            {
                return typeof(Labels.SoundCollectionLabel).CreateLabelUI(false);
            }
            if (type.Equals(typeof(Serializable.MultiSound)))
            {
                return typeof(Labels.MultiSoundLabel).CreateLabelUI(true);
            }
            if (type.Equals(typeof(Serializable.Object2SoundName)))
            {
                return typeof(Labels.Object2SoundNameLabel).CreateLabelUI(true);
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
