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

        public delegate void OnLevelChangedEventHandler(int val);
        public event OnLevelChangedEventHandler OnLevelChangedEvent;
        public bool isNPC = true;

        void Start()
        {
            CurrentLevel = isNPC ? CurrentLevel : PlayerPrefs.GetInt("CurrentLevel");
            TotalExperienceGained = isNPC ? TotalExperienceGained : PlayerPrefs.GetInt("TotalExperienceGained");
        }

        public float GetRequiredExpAmountForNextLevel()
        {
            return 3 * Mathf.Pow(CurrentLevel + 1,2);
        }

        public void GainExperience(int exp)
        {
            TotalExperienceGained += exp;
            PlayerPrefs.SetInt("TotalExperienceGained", TotalExperienceGained);

            if (TotalExperienceGained >= GetRequiredExpAmountForNextLevel())
            {
                CurrentLevel++;
                PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
                
                if (OnLevelChangedEvent != null)
                {
                    OnLevelChangedEvent(attributePointsForEachLevel);
                }
            }
        }
    }
}