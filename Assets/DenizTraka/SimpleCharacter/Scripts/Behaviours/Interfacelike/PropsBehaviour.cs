using System.Collections.Generic;
using DTWorld.Engines.SkillSystem;
using DTWorld.Engines.SkillSystem.Attributes;
using DTWorld.Engines.SkillSystem.Skills;
using UnityEngine;

namespace DTWorld.Behaviours.Interfacelike
{
    public class PropsBehaviour : MonoBehaviour
    {
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

        public void Awake()
        {
            Skills = new Dictionary<string, BaseSkill>();
            Attributes = new Dictionary<string, BaseAttribute>();
            Skills.Add("Ranged", new Ranged());
            Skills.Add("Melee", new Melee());
            Attributes.Add("Dexterity", new Dexterity());
            Attributes.Add("Strength", new Strength());

            Skills["Ranged"].CurrentValue = PlayerPrefs.GetFloat("Ranged");
            Skills["Melee"].CurrentValue = PlayerPrefs.GetFloat("Melee");
            Attributes["Dexterity"].CurrentValue = PlayerPrefs.GetInt("Dexterity");
            Attributes["Strength"].CurrentValue = PlayerPrefs.GetInt("Strength");
        }
    }
}