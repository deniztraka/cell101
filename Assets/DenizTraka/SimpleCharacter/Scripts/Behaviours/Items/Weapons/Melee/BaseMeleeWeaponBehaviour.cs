using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Interfacelike;
using UnityEngine;

namespace DTWorld.Behaviours.Items.Weapons.Melee
{

    public abstract class BaseMeleeWeaponBehaviour : BaseWeaponBehaviour
    {
        public override void Start()
        {
            base.Start();
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

            Hit(otherEntityHealth);

            // if (OwnerMobileBehaviour != null)
            // {
            //     //pereventing hitting multiple times from each swing
            //     OwnerMobileBehaviour.Mobile.IsAttacking = false;
            // }
        }

        private void Hit(HealthBehaviour otherEntityHealth)
        {
            otherEntityHealth.TakeDamage(Item.Damage);
            AudioManager.Play("Hit");
        }
    }
}