using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Audio;
using UnityEngine;
namespace DTWorld.Behaviours.Audio
{

    public class AudioManager : MonoBehaviour
    {
        private Sound lastSound;
        public Sound[] Sounds;

        public void Awake()
        {
            foreach (var sound in Sounds)
            {
                sound.Source = gameObject.AddComponent<AudioSource>();
                sound.Source.clip = sound.Clip;
                sound.Source.volume = sound.Volume;
                sound.Source.pitch = sound.Pitch;
                sound.Source.loop = sound.Loop;
            }
        }

        public void Play(string name)
        {
            if (lastSound != null)
            {
                //Debug.Log(name + ":" + lastSound.Name);
            }

            //dont try to play walking sound everytime
            if (name == "Walking" && lastSound != null && lastSound.Name == "Walking" && lastSound.Source.isPlaying)
            {
                return;
            }

            var sound = Array.Find(Sounds, s => s.Name.Equals(name));
            if (sound != null)
            {
                sound.Source.Play();
                lastSound = sound;
            }
        }

        public void Stop(string name)
        {
            //dont try to play walking sound everytime
            if (lastSound != null && lastSound.Name == name && !lastSound.Source.isPlaying)
            {
                return;
            }

            var sound = Array.Find(Sounds, s => s.Name.Equals(name));
            if (sound != null && sound.Source.isPlaying)
            {
                sound.Source.Stop();
            }
        }

        public void StopAll()
        {            
            var sound = Array.Find(Sounds, s => s.Name.Equals(name));
            if (sound != null && sound.Source.isPlaying)
            {
                sound.Source.Stop();
            }
        }

    }
}
