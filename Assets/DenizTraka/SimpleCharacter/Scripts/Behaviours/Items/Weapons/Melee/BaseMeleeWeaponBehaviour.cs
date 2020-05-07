using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Interfacelike;
using UnityEngine;

namespace DTWorld.Behaviours.Items.Weapons.Melee
{

    public abstract class BaseMeleeWeaponBehaviour : BaseWeaponBehaviour
    {

        protected Collider2D Coll;
        public override void Start()
        {
            base.Start();
            Coll = gameObject.GetComponent<Collider2D>();
        }



        // Update is called once per frame
        public override void Update()
        {
            base.Update();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            //preventing from getting damage from owner
            if (OwnerMobileBehaviour != null && other.gameObject.GetInstanceID() == OwnerMobileBehaviour.gameObject.GetInstanceID())
            {
                return;
            }

            //is owner currently attacking
            if (OwnerMobileBehaviour != null && !OwnerMobileBehaviour.Mobile.IsAttacking)
            {
                return;
            }

            //enemy should not hit other enemies
            if (OwnerMobileBehaviour.tag == "Enemy" && other.tag == "Enemy")
            {
                return;
            }

            //check if it has health behaviour?
            var otherEntityHealth = other.GetComponent<HealthBehaviour>();
            if (otherEntityHealth == null)
            {
                return;
            }

            if (otherEntityHealth.Health <= 0)
            {
                return;
            }

            Coll.enabled = false;

            var hitSucceed = Hit(otherEntityHealth);

            if (hitSucceed)
            {
                TrySkillGain();
            }

        }

        private float CalculateTotalDamage()
        {
            var ownerMeleeSkill = OwnerMobileProps.Melee.CurrentValue;
            var ownerStrength = OwnerMobileProps.Strength.CurrentValue;
            var weaponDamage = Damage;

            var temp = (Item.Damage + (ownerMeleeSkill / 10)); //ranged skill factor + 
            temp = ((ownerStrength * weaponDamage) / 10) + temp; // weapoin damage factor + 
            return temp;
        }

        private bool Hit(HealthBehaviour otherEntityHealth)
        {
            if (otherEntityHealth != null)
            {
                if (otherEntityHealth.Health > 0)
                {
                    otherEntityHealth.TakeDamage(CalculateTotalDamage());
                    AudioManager.Play("Hit");
                    return true;
                }
            }

            return false;
        }

        public void TrySkillGain()
        {
            if (OwnerMobileBehaviour.tag == "Player")
            {
                var props = OwnerMobileBehaviour.GetComponent<PropsBehaviour>();
                props.Melee.Gain(0.1f);
            }
        }

        public override void BeforeAttacking()
        {
            base.BeforeAttacking();
            //Debug.Log("before attacking base weapon");
            //timeBeforeHit = Time.time;
            //Debug.Log(timeBeforeHit);
        }

        public override void AfterAttacked()
        {
            base.AfterAttacked();
            if (!Coll.enabled)
            {
                Coll.enabled = true;
            }
            //Debug.Log("before attacking base weapon");
            //timeBeforeHit = Time.time;
            //Debug.Log(timeBeforeHit);
        }
    }
}