using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Interfacelike;
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

        private Level currentLevel;

        // Start is called before the first frame update
        void Start()
        {
            SetCurrentLevel();
            currentLevel.OnLevelFinishedEvent += new Level.OnLevelFinishedEventHandler(LevelFinished);
            FightCanvas.SetActive(true);
        }

        public Level GetCurrentLevel()
        {
            return currentLevel;
        }

        public void SetCurrentLevel()
        {
            CurrentFightIndex = PlayerPrefs.GetInt("CurrentFightIndex");
            currentLevel = Levels.List[CurrentFightIndex];
        }
        public void LevelFinished()
        {
            var playerLevel = GameObject.FindGameObjectWithTag("Player").GetComponent<MobileLevel>();
            playerLevel.GainExperience((int)currentLevel.XPGain);
            CurrentFightIndex++;
            PlayerPrefs.SetInt("CurrentFightIndex", CurrentFightIndex);

            LevelFinishedCanvas.SetActive(true);
        }
    }
}