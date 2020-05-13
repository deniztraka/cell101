using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Audio;
using UnityEngine;
namespace DTWorld.Behaviours.Interfacelike
{
    public class MobileLevel : MonoBehaviour
    {
        public int CurrentLevel;
        public int TotalExperienceGained;

        public ParticleSystem LevelGainedEffect;

        private int attributePointsForEachLevel = 1;

        private AudioManager audioManager;

        public delegate void OnLevelChangedEventHandler(int val, int currentLevel);
        public event OnLevelChangedEventHandler OnLevelChangedEvent;

        public delegate void OnExperienceGainedEventHandler(int val, int currentLevel);
        public event OnExperienceGainedEventHandler OnExperienceGainedEvent;
        public bool isNPC = true;

        void Start()
        {
            CurrentLevel = isNPC ? CurrentLevel : PlayerPrefs.GetInt("CurrentLevel");
            TotalExperienceGained = isNPC ? TotalExperienceGained : PlayerPrefs.GetInt("TotalExperienceGained");

            audioManager = gameObject.GetComponent<AudioManager>();

            var healthBehaviour = gameObject.GetComponent<HealthBehaviour>();
            if (healthBehaviour != null)
            {
                healthBehaviour.MaxHealth += CurrentLevel * 2f;
                healthBehaviour.Health = healthBehaviour.MaxHealth;
            }
        }

        public float GetRequiredExpAmountForNextLevel()
        {
            return 3 * Mathf.Pow(CurrentLevel + 1, 2);
        }

        public void GainExperience(int exp)
        {
            TotalExperienceGained += exp;
            PlayerPrefs.SetInt("TotalExperienceGained", TotalExperienceGained);

            if (OnExperienceGainedEvent != null)
            {
                OnExperienceGainedEvent.Invoke(exp, CurrentLevel);
            }

            if (TotalExperienceGained >= GetRequiredExpAmountForNextLevel())
            {
                CurrentLevel++;
                PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);

                if (LevelGainedEffect != null)
                {
                    LevelGainedEffect.Play();
                    if (audioManager != null)
                    {
                        audioManager.Play("LevelUp");
                    }
                }

                if (OnLevelChangedEvent != null)
                {
                    OnLevelChangedEvent(attributePointsForEachLevel, CurrentLevel);
                }
            }
        }
    }
}