using Diagram.UI;

using SoundService.UI.Factory;

namespace SoundService.UI
{ /// <summary>
  /// Static extensions
  /// </summary>
    public static class StaticExtensionSoundServiceUI
    {


        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionSoundServiceUI()
        {
            var s = SoundUIFactory.Singleton;
        }

        /// <summary>
        /// Buttons
        /// </summary>
        public static ButtonWrapper[] ObjectButtons =
 [
                      new ButtonWrapper(typeof(Serializable.SoundCollection),
                    "", "Sounds", Properties.Resources.audio, null, false, false),
                            new ButtonWrapper(typeof(Serializable.MultiSound),
                    "", "Multiple Sound", Properties.Resources.pcdrsound, null, true, false),
                            new ButtonWrapper(typeof(Serializable.Object2SoundName),
                    "", "Sound name converter", Properties.Resources.pcdrsounddigit, null, true, false)

    ];


    }
}
