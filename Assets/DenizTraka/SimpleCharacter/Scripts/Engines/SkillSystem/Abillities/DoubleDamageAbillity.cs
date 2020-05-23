using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Engines.SkillSystem.Abillities
{
    [CreateAssetMenu(fileName = "DoubleDamageAbillity", menuName = "Abillities/DoubleDamage", order = 1)]
    public class DoubleDamageAbillity : BaseAbillity
    {
        public override void Init(BaseAbillity abillity){
            base.Init(abillity);

            var damageAmplifier = abillity.Effects.Find(e => e.name.Equals("DamageAmplifierEffect")) as DamageAmplifierEffect;            
            damageAmplifier.AmplifyValue = 2;
        }
    }
}