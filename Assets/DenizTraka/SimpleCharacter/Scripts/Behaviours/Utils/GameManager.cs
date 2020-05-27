using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Interfacelike;
using DTWorld.Behaviours.LevelSystem;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
using UnityEngine.UI;
namespace DTWorld.Behaviours.Utils
{
    public class GameManager : MonoBehaviour
    {
        public GameObject ArcherCharacter;
        public GameObject MeleeCharacter;

        public Sprite MeleeImage;
        public Sprite RangedImage;

        public GameObject ActionButton;

        private BaseMobileBehaviour selectedCharacter;

        HealthBehaviour playerHealth;
        public GameObject OnDeathCanvas;

        // Start is called before the first frame update

        void Awake()
        {
            InitGame();
        }

        void InitGame()
        {

            if (AppManager.Instance == null || AppManager.Instance.IsRanged)
            {
                ArcherCharacter.SetActive(true);
                selectedCharacter = ArcherCharacter.GetComponent<BaseMobileBehaviour>();
                ActionButton.GetComponent<Image>().sprite = RangedImage;
            }
            else
            {
                MeleeCharacter.SetActive(true);
                selectedCharacter = MeleeCharacter.GetComponent<BaseMobileBehaviour>();
                ActionButton.GetComponent<Image>().sprite = MeleeImage;
            }

            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBehaviour>();
            playerHealth.OnHealthBelowZeroEvent += new HealthBehaviour.OnHealthBelowZeroEventHandler(OnDeath);
        }

        private IEnumerator StartGame()
        {
            yield return new WaitForSeconds(1);
        }

        private IEnumerator ShowDeathCanvas(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            OnDeathCanvas.SetActive(true);
        }

        private void OnDeath(BaseMobileBehaviour mobile)
        {
            var levelManager = GameObject.Find("FightManager").GetComponent<LevelManager>();
            var currentLevel = levelManager.GetCurrentLevel();
            currentLevel.ResetEnemyDeathCount();

            StartCoroutine(ShowDeathCanvas(2));

        }
    }
}