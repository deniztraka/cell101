using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Audio;
using DTWorld.Behaviours.LevelSystem;
using DTWorld.Behaviours.Utils;
using UnityEngine;
using UnityEngine.UI;
namespace DTWorld.Behaviours.UI.InGame
{
    public class FightCanvasBehaviour : MonoBehaviour
    {
        private Level currentLevel;
        public Text EnemiesText;
        public Text CurrentFightText;
        public Text XPGainText;


        private AudioManager audioManager;
        void Start()
        {
            var fightManager = GameObject.Find("FightManager").GetComponent<LevelManager>();
            currentLevel = fightManager.GetCurrentLevel();
            Time.timeScale = 0f;

            EnemiesText.text = String.Format("Number Of Enemies: {0}", currentLevel.Enemies.Count);
            XPGainText.text = String.Format("XP Gain: {0}", currentLevel.XPGain);
            CurrentFightText.text = String.Format("Fight {0}", PlayerPrefs.GetInt("CurrentFightIndex") + 1);
            audioManager = GetComponent<AudioManager>();
        }

        public void StartFight()
        {
            if (audioManager != null)
            {
                audioManager.Play("Fight");
            }
            Time.timeScale = 1f;

            AppManager.Instance.StartLevel(currentLevel);
            gameObject.SetActive(false);
        }
    }
}