using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Interfacelike;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Behaviours.LevelSystem
{
    public enum LevelDifficulty
    {
        VeryEasy,
        Easy,
        Medium,
        Hard,
        Hell
    }

    [CreateAssetMenu(fileName = "Level", menuName = "LevelSystem/Level", order = 1)]
    public class Level : ScriptableObject
    {
        public List<GameObject> Enemies;
        public Vector3[] SpawnPoints;

        public LevelDifficulty Difficulty;

        public delegate void OnLevelFinishedEventHandler();
        public event OnLevelFinishedEventHandler OnLevelFinishedEvent;

        private int numberOfDeaths;

        void SpawnEntities()
        {
            var currIndex = 0;
            foreach (var enemy in Enemies)
            {
                PrepareEnemy(enemy, currIndex);
                currIndex++;
            }
        }

        private void OnEnemyDeath()
        {
            numberOfDeaths++;
            if (numberOfDeaths >= Enemies.Count && OnLevelFinishedEvent != null)
            {
                OnLevelFinishedEvent();
            }
        }

        private void PrepareEnemy(GameObject enemy, int spawnPointIndex)
        {
            HealthBehaviour currentEnemyObj = Instantiate(enemy, SpawnPoints[spawnPointIndex], Quaternion.identity).GetComponent<HealthBehaviour>();
            currentEnemyObj.OnHealthBelowZeroEvent += new HealthBehaviour.OnHealthBelowZeroEventHandler(OnEnemyDeath);
        }

        internal void Spawn()
        {
            SpawnEntities();
        }
    }
}