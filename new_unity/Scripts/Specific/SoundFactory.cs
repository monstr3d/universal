using AssemblyService.Attributes;
using SoundService;
using SoundService.Interfaces;

using UnityEngine;

namespace Assets.Scripts.Specific
{
    [InitAssembly]
    internal static class StaticSound
    {
        static StaticSound()
        {
            var s = SoundFactory.Instance;
        }

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {
            
        }
    }

    internal class SoundFactory : ISoundFactory
    {

        internal static readonly SoundFactory Instance = new SoundFactory();
        private SoundFactory()
        {
            this.Set();
        }

        ISoundPlayer ISoundFactory.SoundPlayer => new SoundPlayer(GameObject);

        public string Directory { get => ""; set { } }

        public GameObject GameObject
        {
            get; set;
        }

        internal class SoundPlayer : ISoundPlayer
        {

            internal SoundPlayer(GameObject gameObject)
            {

            }

            string location = "";

            string ISoundPlayer.SoundLocation { get => location; set => location = value; }

            void ISoundPlayer.Play()
            {
                
            }

            void ISoundPlayer.PlaySync()
            {
                
            }
        }

    }
}
