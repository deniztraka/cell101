using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Behaviours.Interfacelike
{
    public class MobileLevel : MonoBehaviour
    {
        public int CurrentLevel;
        public int TotalExperienceGained;

        private int attributePointsForEachLevel = 1;

        public delegate void OnLevelChangedEventHandler(int val, int currentLevel);
        public event OnLevelChangedEventHandler OnLevelChangedEvent;

        public delegate void OnExperienceGainedEventHandler(int val, int currentLevel);
        public event OnExperienceGainedEventHandler OnExperienceGainedEvent;
        public bool isNPC = true;

        void Start()
        {
            CurrentLevel = isNPC ? CurrentLevel : PlayerPrefs.GetInt("CurrentLevel");
            TotalExperienceGained = isNPC ? TotalExperienceGained : PlayerPrefs.GetInt("TotalExperienceGained");
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

                if (OnLevelChangedEvent != null)
                {
                    OnLevelChangedEvent(attributePointsForEachLevel, CurrentLevel);
                }
            }
        }
    }
}