using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Core.Audio
{
    [Serializable]
    public class Sound
    {
        public string Name;
        public AudioClip Clip;
        [Range(0, 1)]
        public float Volume;
        [Range(.1f, 3f)]
        public float Pitch;
        [HideInInspector]
        public AudioSource Source;
    }
}
