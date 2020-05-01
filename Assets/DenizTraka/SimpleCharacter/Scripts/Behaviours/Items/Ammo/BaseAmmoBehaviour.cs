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

            Hit(other.GetComponent<HealthBehaviour>());
            Coll.enabled = false;
        }

        private void Hit(HealthBehaviour otherEntityHealth)
        {
            if (otherEntityHealth != null)
            {
                if (otherEntityHealth.Health > 0)
                {
                    otherEntityHealth.TakeDamage(OwnerWeaponBehaviour.Damage + Item.Damage);
                }
            }

            if (audioManager != null)
            {
                //Debug.Log("Hit");
                audioManager.Play("Hit");
            }

            StartCoroutine(DeactivateAfter(0.1f));
        }

        private IEnumerator DeactivateAfter(float seconds)
        {

            yield return new WaitForSeconds(seconds);
            gameObject.SetActive(false);
        }
    }
}