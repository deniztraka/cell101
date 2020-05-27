using System.Collections.Generic;
using DTWorld.Behaviours.Utils;
using DTWorld.Engines.SkillSystem.Abillities;
using DTWorld.Interfaces;
using UnityEngine;

namespace DTWorld.Engines.SkillSystem.Skills
{
    public class Melee : BaseSkill
    {


        public Melee() : base()
        {
            GainFactor = 0.75f;
        }

        public override void PrepeareAbillities()
        {
            if (DBAbillities.Instance != null)
            {
                var doubleDamage = DBAbillities.Instance.Abillities.Find(a => a.Name.Equals("Double Damage"));
                var doubleDamageInstance = ScriptableObject.CreateInstance("DoubleDamageAbillity") as DoubleDamageAbillity;
                doubleDamageInstance.Init(doubleDamage);
                Abillities.Add(doubleDamageInstance);
            }
        }

        public List<BaseAbillity> GetAbillities()
        {
            return Abillities;
        }

        public override void Gain(float val)
        {
            base.Gain(val);
            PlayerPrefs.SetFloat("Melee", CurrentValue);
        }
    }
}

