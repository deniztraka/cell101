using DTWorld.Interfaces;
using UnityEngine;

namespace DTWorld.Engines.SkillSystem.Skills
{
    public class Melee : BaseSkill
    {
        public Melee() : base()
        {

        }

        public override void Gain(float val)
        {
            base.Gain(val);
            PlayerPrefs.SetFloat("Melee", CurrentValue);
        }
    }
}

