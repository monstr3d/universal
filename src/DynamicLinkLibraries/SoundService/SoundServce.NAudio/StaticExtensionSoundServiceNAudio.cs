using AssemblyService.Attributes;

namespace SoundServce.NAudio
{
    [InitAssembly]
    public class StaticExtensionSoundServiceNAudio
    {
        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {



        }

        static StaticExtensionSoundServiceNAudio()
        {
            new Factory();

        }
 
    }
}
