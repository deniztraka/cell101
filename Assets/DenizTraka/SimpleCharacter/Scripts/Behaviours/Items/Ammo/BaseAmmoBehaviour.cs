using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Audio;
using DTWorld.Behaviours.Interfacelike;
using DTWorld.Behaviours.Items.Weapons;
using DTWorld.Behaviours.Mobiles;
using DTWorld.Core.Items.Ammo;
using UnityEngine;
namespace DTWorld.Behaviours.Items.Ammo
{
    public class BaseAmmoBehaviour : BaseItemBehaviour
    {
        public BaseWeaponBehaviour OwnerWeaponBehaviour;
        protected Collider2D Coll;
        private AudioManager audioManager;
        public new BaseAmmo Item;

        public override void Start()
        {
            base.Start();
            Coll = gameObject.GetComponent<Collider2D>();
            audioManager = gameObject.GetComponent<AudioManager>();
        }

        public override void Update()
        {
            base.Update();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            //Debug.Log(other.name);
            //preventing from getting damage from owner
            if (OwnerWeaponBehaviour.OwnerMobileBehaviour != null && other.gameObject.GetInstanceID() == OwnerWeaponBehaviour.OwnerMobileBehaviour.gameObject.GetInstanceID())
            {
                return;
            }

            //enemy should not hit other enemies
            if (OwnerWeaponBehaviour.OwnerMobileBehaviour.tag == "Enemy" && other.tag == "Enemy")
            {
                return;
            }

            Coll.enabled = false;

            var hitSucceed = Hit(other.GetComponent<HealthBehaviour>());

            if (hitSucceed)
            {
                TrySkillGain();

            }

            StartCoroutine(DeactivateAfter(0.1f));
        }

        public void TrySkillGain()
        {
            //Player skill gain
            if (OwnerWeaponBehaviour.OwnerMobileBehaviour.tag == "Player")
            {
                var props = OwnerWeaponBehaviour.OwnerMobileBehaviour.GetComponent<PropsBehaviour>();
                props.Ranged.Gain(0.1f);
            }
        }

        private float CalculateTotalDamage()
        {
            var ownerRangedSkill = OwnerWeaponBehaviour.OwnerMobileProps.Ranged.CurrentValue;
            var ownerDexterity = OwnerWeaponBehaviour.OwnerMobileProps.Dexterity.CurrentValue;
            var ownerStrength = OwnerWeaponBehaviour.OwnerMobileProps.Strength.CurrentValue;
            var weaponDamage = OwnerWeaponBehaviour.Damage;

            var temp = (Item.Damage + (ownerRangedSkill / 10)); //ranged skill factor + 
            temp = ((temp * ownerDexterity) / 10) + temp; // dexterity factor +
            temp = ((ownerStrength * weaponDamage) / 10) + temp; // weapoin damage factor + 
            return temp;
        }

        private bool Hit(HealthBehaviour otherEntityHealth)
        {
            if (otherEntityHealth != null)
            {
                if (otherEntityHealth.Health > 0)
                {
                    otherEntityHealth.TakeDamage(OwnerWeaponBehaviour.Damage + Item.Damage + (OwnerWeaponBehaviour.OwnerMobileProps.Ranged.CurrentValue / 10));
                    return true;
                }
            }

            if (audioManager != null)
            {
                audioManager.Play("Hit");
            }



            return false;
        }

        private IEnumerator DeactivateAfter(float seconds)
        {

            yield return new WaitForSeconds(seconds);
            gameObject.SetActive(false);
        }
    }
}