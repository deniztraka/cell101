﻿using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Audio;
using DTWorld.Behaviours.Interfacelike;
using DTWorld.Behaviours.Mobiles;
using DTWorld.Behaviours.UI.InGame;
using DTWorld.Behaviours.Utils;
using UnityEngine;
namespace DTWorld.Behaviours.LevelSystem
{
    public class LevelManager : MonoBehaviour
    {
        public LevelList Levels;
        public GameObject LevelFinishedCanvas;
        public GameObject FightCanvas;

        private int CurrentFightIndex;

        private bool finishFlag;

        private AudioManager audioManager;

        public Level CurrentLevel;

        // Start is called before the first frame update
        void Start()
        {
            SetCurrentLevel();
            //currentLevel.OnLevelFinishedEvent += new Level.OnLevelFinishedEventHandler(LevelFinished);
            FightCanvas.SetActive(true);

            audioManager = GetComponent<AudioManager>();

            if (audioManager != null)
            {
                audioManager.Play("InGameFight");
            }
        }

        void Update()
        {
            if (CurrentLevel.IsFinished && !finishFlag)
            {
                finishFlag = true;
                LevelFinished();
            }
        }

        public Level GetCurrentLevel()
        {
            return CurrentLevel;
        }

        public void SetCurrentLevel()
        {
            CurrentFightIndex = PlayerPrefs.GetInt("CurrentFightIndex");
            CurrentLevel = Levels.List[CurrentFightIndex];
        }
        public void LevelFinished()
        {
            StartCoroutine(ShowWinCanvas(2));
        }

        private IEnumerator ShowWinCanvas(float seconds)
        {
            yield return new WaitForSeconds(seconds);

            var playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                var playerBehaviour = playerObj.GetComponent<PlayerBehaviour>();
                if (playerBehaviour.Mobile.Health > 0)
                {
                    var playerLevel = playerObj.GetComponent<MobileLevel>();
                    playerLevel.GainExperience((int)CurrentLevel.XPGain);
                    CurrentFightIndex++;
                    PlayerPrefs.SetInt("CurrentFightIndex", CurrentFightIndex);

                    if (LevelFinishedCanvas == null)
                    {
                        //LevelFinishedCanvas = GameObject.Find("FightIsWonCanvas");
                        var LevelFinishedCanvasSearchGroup = Resources.FindObjectsOfTypeAll<FightIsWonCanvasBehaviour>();
                        if (LevelFinishedCanvasSearchGroup.Length > 0)
                        {
                            LevelFinishedCanvas = LevelFinishedCanvasSearchGroup[0].gameObject;
                        }
                    }

                    LevelFinishedCanvas.SetActive(true);
                };
            }
        }
    }
}