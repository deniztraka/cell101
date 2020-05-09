using System.Collections.Generic;
using DTWorld.Engines.SkillSystem;
using DTWorld.Engines.SkillSystem.Attributes;
using DTWorld.Engines.SkillSystem.Skills;
using UnityEngine;

namespace DTWorld.Behaviours.Interfacelike
{
    public class PropsBehaviour : MonoBehaviour
    {
        public float baseAttributePointsGainFactor = 0.05f;
        public float RangedSkill;
        public float MeleeSkill;
        public int StrengthAttribute;
        public int DexterityAttribute;

        public int TotalAvaliableAttributePoints;

        public bool isNPC = true;

        public Dictionary<string, BaseSkill> Skills;
        public Dictionary<string, BaseAttribute> Attributes;

        public BaseSkill Ranged
        {
            get { return Skills["Ranged"]; }
        }
        public BaseSkill Melee
        {
            get { return Skills["Melee"]; }
        }
        public BaseAttribute Strength
        {
            get { return Attributes["Strength"]; }
        }
        public BaseAttribute Dexterity
        {
            get { return Attributes["Dexterity"]; }
        }

        public delegate void OnAttributePointsGainedEventHandler();
        public event OnAttributePointsGainedEventHandler OnAttributePointsGainedEvent;

        public void Awake()
        {
            Skills = new Dictionary<string, BaseSkill>();
            Attributes = new Dictionary<string, BaseAttribute>();
            Skills.Add("Ranged", new Ranged());
            Skills.Add("Melee", new Melee());
            Attributes.Add("Dexterity", new Dexterity());
            Attributes.Add("Strength", new Strength());

            RangedSkill = Skills["Ranged"].CurrentValue = isNPC ? RangedSkill : PlayerPrefs.GetFloat("Ranged");
            MeleeSkill = Skills["Melee"].CurrentValue = isNPC ? MeleeSkill : PlayerPrefs.GetFloat("Melee");
            DexterityAttribute = Attributes["Dexterity"].CurrentValue = isNPC ? DexterityAttribute : PlayerPrefs.GetInt("Dexterity");
            StrengthAttribute = Attributes["Strength"].CurrentValue = isNPC ? StrengthAttribute : PlayerPrefs.GetInt("Strength");

            TotalAvaliableAttributePoints = PlayerPrefs.GetInt("TotalAvaliableAttributePoints");
            // Ranged.OnSkillChangedEvent += new BaseSkill.OnSkillChangedEventHandler(TryGainBaseAttribute);
            // Melee.OnSkillChangedEvent += new BaseSkill.OnSkillChangedEventHandler(TryGainBaseAttribute);


        }

        void Start(){
            var mobileLevel = GetComponent<MobileLevel>();
            mobileLevel.OnLevelChangedEvent += new MobileLevel.OnLevelChangedEventHandler(AddBaseAttributePoints);
        }

        public void TryGainBaseAttribute(float val)
        {
            if (UnityEngine.Random.value < baseAttributePointsGainFactor)
            {
                TotalAvaliableAttributePoints++;
                PlayerPrefs.SetInt("TotalAvaliableAttributePoints", TotalAvaliableAttributePoints);
                if (OnAttributePointsGainedEvent != null)
                {
                    OnAttributePointsGainedEvent();
                }
            }
        }

        public void AddBaseAttributePoints(int val)
        {
            TotalAvaliableAttributePoints += val;
            PlayerPrefs.SetInt("TotalAvaliableAttributePoints", TotalAvaliableAttributePoints);
            if (OnAttributePointsGainedEvent != null)
            {
                OnAttributePointsGainedEvent();
            }
        }
    }
}