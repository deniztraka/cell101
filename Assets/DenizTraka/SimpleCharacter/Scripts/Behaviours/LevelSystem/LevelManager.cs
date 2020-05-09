using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Utils;
using UnityEngine;
namespace DTWorld.Behaviours.LevelSystem
{
    public class LevelManager : MonoBehaviour
    {
        public List<Level> Levels;

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 0f;
        }

        public Level PickLevel()
        {
            var choosenLevelIndex = Random.Range(0, Levels.Count);
            var chosenLevel = Levels[choosenLevelIndex];
            return chosenLevel;
        }

        public void StartLevel()
        {
            GameObject.Find("FightCanvas").SetActive(false);

            var chosenLevel = PickLevel();
            chosenLevel.OnLevelFinishedEvent += new Level.OnLevelFinishedEventHandler(LevelFinished);
            chosenLevel.Spawn();
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }

        public void LevelFinished()
        {
            var gameManager = gameObject.GetComponent<GameManager>();
            gameManager.LevelFinishedCanvas.SetActive(true);
        }
    }
}