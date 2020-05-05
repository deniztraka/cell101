using DTWorld.Interfaces;
using UnityEngine;

namespace DTWorld.Engines.SkillSystem.Skills
{
    public class Ranged : BaseSkill
    {
        public Ranged() : base()
        {
            GainFactor = 0.1f;
        }

        public override void Gain(float val)
        {
            base.Gain(val);
            PlayerPrefs.SetFloat("Ranged", CurrentValue);
        }
    }
}

