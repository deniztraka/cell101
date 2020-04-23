using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Audio;
using UnityEngine;
namespace DTWorld.Behaviours.Audio
{

    public class AudioManager : MonoBehaviour
    {
        public Sound[] Sounds;

        public void Awake()
        {
            foreach (var sound in Sounds)
            {
                sound.Source = gameObject.AddComponent<AudioSource>();
                sound.Source.clip = sound.Clip;
                sound.Source.volume = sound.Volume;
                sound.Source.pitch = sound.Pitch;
            }
        }

        public void Play(string name)
        {
            var sound = Array.Find(Sounds, s => s.Name.Equals(name));
            if(sound != null){
                sound.Source.Play();
            }
        }

    }
}
