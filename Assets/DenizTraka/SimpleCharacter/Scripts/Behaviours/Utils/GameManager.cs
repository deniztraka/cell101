using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Interfacelike;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Behaviours.Utils
{
    public class GameManager : MonoBehaviour
    {
        public GameObject ArcherCharacter;
        public GameObject MeleeCharacter;

        private BaseMobileBehaviour selectedCharacter;

        HealthBehaviour playerHealth;
        public GameObject OnDeathCanvas;


        public GameObject LevelFinishedCanvas;
        // Start is called before the first frame update

        void Awake()
        {
            InitGame();
        }

        void InitGame()
        {

            if (AppManager.Instance.IsRanged)
            {
                ArcherCharacter.SetActive(true);
                selectedCharacter = ArcherCharacter.GetComponent<BaseMobileBehaviour>();
            }
            else
            {
                MeleeCharacter.SetActive(true);
                selectedCharacter = MeleeCharacter.GetComponent<BaseMobileBehaviour>();
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

        private void OnDeath()
        {
            StartCoroutine(ShowDeathCanvas(2));

        }
    }
}