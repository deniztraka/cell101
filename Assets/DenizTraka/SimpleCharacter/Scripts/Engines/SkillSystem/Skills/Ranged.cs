using System.Collections.Generic;
using DTWorld.Behaviours.Utils;
using DTWorld.Engines.SkillSystem.Abillities;
using DTWorld.Interfaces;
using UnityEngine;

namespace DTWorld.Engines.SkillSystem.Skills
{
    public class Ranged : BaseSkill
    {
        public Ranged() : base()
        {
            GainFactor = 0.75f;



        }

        public override void Gain(float val)
        {
            base.Gain(val);
            PlayerPrefs.SetFloat("Ranged", CurrentValue);
        }

        public override void PrepeareAbillities()
        {
            //Abillities.Add(DBAbillities.Instance.Abillities.Find(a => a.Name.Equals("Double Damage")));
        }
    }
}

