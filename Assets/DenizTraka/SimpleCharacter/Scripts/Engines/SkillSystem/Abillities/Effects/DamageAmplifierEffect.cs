using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Engines.SkillSystem.Abillities
{
    public class DamageAmplifierEffect : BaseAbillityEffect
    {
        BaseMobileBehaviour mobileBehaviour;

        public float AmplifyValue = 2;

        internal override void OnBeforeDestroy()
        {
            //Debug.Log("unset damage amplifier");
            mobileBehaviour.WeaponBehaviour.Damage = mobileBehaviour.WeaponBehaviour.Damage / AmplifyValue;
        }

        void Start(){
            //Debug.Log("set damage amplifier");
            mobileBehaviour = GetComponent<BaseMobileBehaviour>();
            mobileBehaviour.WeaponBehaviour.Damage = mobileBehaviour.WeaponBehaviour.Damage * AmplifyValue;
        }
    }
}