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
        private AppManager appManager;

        HealthBehaviour playerHealth;
        public GameObject OnDeathCanvas;
        // Start is called before the first frame update

        void Awake()
        {
            appManager = GameObject.FindGameObjectWithTag("AppManager").GetComponent<AppManager>();
            InitGame();
        }

        void InitGame()
        {
            if (appManager.IsRanged())
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

        void Start()
        {
            
        }

        private IEnumerator StartGame()
        {
            yield return new WaitForSeconds(1);
        }

        private void OnDeath()
        {
            OnDeathCanvas.SetActive(true);
        }
    }
}