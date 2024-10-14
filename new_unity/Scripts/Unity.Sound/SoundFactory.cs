using AssemblyService.Attributes;
using SoundService;
using SoundService.Interfaces;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Unity.Sound
{
    public class SoundFactory : ISoundFactory
    {
        Dictionary<string, AudioSource> audios = new();

        ReferenceFrameBehavior reference;
        string extension = "";

        protected SoundFactory(ReferenceFrameBehavior reference, IEnumerable<AudioSource> aud, string extension):
            this(aud, extension)
        {
            this.reference = reference;
        }
            

        protected SoundFactory(IEnumerable<AudioSource> aud, string extension) :
        
          this(extension)
        {
            foreach (var audio in aud)
            {
                audio.enabled = false;
                var s = audio.clip + "";
                s = s.Replace(" (UnityEngine.AudioClip)", "") + extension;
                audios[s] = audio;
            }
        }

        public  SoundFactory(ReferenceFrameBehavior reference, GameObject gameObject, string extension) :
            this(reference, gameObject.GetComponentsInChildren<AudioSource>(),
                extension)
        {

        }

        protected SoundFactory(string extension)
        {
           this.extension = extension;
        }

        ISoundPlayer ISoundFactory.SoundPlayer => new SoundPlayer(reference, audios);

        public string Directory { get => ""; set { } }

    
        internal class SoundPlayer : ISoundPlayer
        {
            Dictionary<string, AudioSource> audios;

            ReferenceFrameBehavior reference;
            internal SoundPlayer(ReferenceFrameBehavior reference, Dictionary<string, AudioSource> audios)
            {
                this.audios = audios;
                this.reference = reference;
            }

            string location = "";

            string ISoundPlayer.SoundLocation { get => location; set => location = value; }

            void ISoundPlayer.Play()
            {
                try
                {

                }
                catch (Exception ex)
                {

                }
            }

            void ISoundPlayer.PlaySync()
            {
                try
                {
                    var audio = audios[location];
                    reference.AudioSource = audio;
                }
                catch (Exception ex)
                {

                }

            }
        }

    }
}
