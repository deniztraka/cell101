using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Audio;
using DTWorld.Behaviours.LevelSystem;
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
            CurrentFightText.text = String.Format("Fight {0}", PlayerPrefs.GetInt("CurrentFightIndex"));
            audioManager = GetComponent<AudioManager>();
        }

        IEnumerator Fight(){
            
            currentLevel.Spawn();
            yield return new WaitForSeconds(0.5f);
            
            gameObject.SetActive(false);
            

        }

        public void StartFight()
        {
            if (audioManager != null)
            {
                audioManager.Play("Fight");
            }
            Time.timeScale = 1f;
            StartCoroutine(Fight());
        }
    }
}