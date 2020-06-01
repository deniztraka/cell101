using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Audio;
using DTWorld.Behaviours.LevelSystem;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Behaviours.Utils
{

    public class AppManager : MonoBehaviour
    {
        public static AppManager Instance { get; private set; }
        public bool IsRanged;

        public bool HasLeveledUp;

        private AudioManager audioManager;
        void Start()
        {
            audioManager = GetComponent<AudioManager>();
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PrepareRandomFightValues()
        {

        }

        internal void StartLevel(Level currentLevel)
        {
            StartCoroutine(InitiateLevel(currentLevel));
        }

        IEnumerator InitiateLevel(Level currentLevel)
        {
            currentLevel.Initiate();

            yield return new WaitForSeconds(0.5f);
            if (audioManager != null)
            {
                audioManager.Play("Fight");
            }
            currentLevel.Spawn();

        }
    }
}
