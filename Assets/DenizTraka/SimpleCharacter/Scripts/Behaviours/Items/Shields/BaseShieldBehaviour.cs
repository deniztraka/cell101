using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Audio;
using DTWorld.Behaviours.Mobiles;
using DTWorld.Core.Items.Shields;
using UnityEngine;
namespace DTWorld.Behaviours.Items.Shields
{
    public abstract class BaseShieldBehaviour : BaseItemBehaviour
    {
        public float SwingSpeed;
        public float DefendRate;
        public new BaseShield Item;
        public BaseMobileBehaviour OwnerMobileBehaviour;
        private AudioManager audioManager;

        private ParticleSystem defendParticles;

        public delegate void BeforeDefendingEventHandler();
        public event BeforeDefendingEventHandler BeforeDefendingEvent;
        public delegate void AfterDefendEventHandler();
        public event AfterDefendEventHandler AfterDefendEvent;

        public override void Start()
        {
            base.Start();
            audioManager = gameObject.GetComponent<AudioManager>();
            var hitParticleEffect = transform.Find("HitParticleEffect");
            if (hitParticleEffect != null)
            {
                defendParticles = hitParticleEffect.GetComponent<ParticleSystem>();
            }
            this.BeforeDefendingEvent += new BeforeDefendingEventHandler(BeforeDefending);
            this.AfterDefendEvent += new AfterDefendEventHandler(AfterDefend);
        }

        public override void Update()
        {
            base.Update();
        }

        private IEnumerator ExecuteAfterTime(Action task)
        {
            if (BeforeDefendingEvent != null)
            {
                BeforeDefendingEvent.Invoke();
            }
            if (OwnerMobileBehaviour != null)
            {
                OwnerMobileBehaviour.Mobile.IsDefending = true;
            }
            if (audioManager != null)
            {
                audioManager.Play("Swing");
            }

            yield return new WaitForSeconds(1/SwingSpeed);

            if (task != null)
            {
                task();
            }

            if (OwnerMobileBehaviour != null)
            {
                OwnerMobileBehaviour.Mobile.IsDefending = false;
            }

            if (AfterDefendEvent != null)
            {
                AfterDefendEvent.Invoke();
            }
        }

        internal bool TryParry(float damage)
        {
            var isParrySuccess = UnityEngine.Random.Range(0f, 1f) < Item.DefendRate;

            if (isParrySuccess)
            {
                defendParticles.Play();
                if (audioManager != null)
                {
                    audioManager.Play("ShieldHit");
                }
                TakeDurability(damage);

            }

            return isParrySuccess;
        }

        private void TakeDurability(float damage)
        {
            Durability -= damage;
            if (Durability <= 0)
            {
                if (audioManager != null)
                {                    
                    audioManager.Play("Destroyed");
                }
                Destroy(gameObject, 0.5f);
            }
        }

        protected virtual void AfterDefend()
        {
            //Debug.Log(OwnerMobileBehaviour.Mobile.IsDefending);
        }

        protected virtual void BeforeDefending()
        {
            //Debug.Log(OwnerMobileBehaviour.Mobile.IsDefending);
        }

        public void SetSwingSpeed(float value)
        {
            SwingSpeed = value;
        }

        internal void Defend()
        {
            StartCoroutine(ExecuteAfterTime(() =>
            {
                //Debug.Log("task");
            }));
        }
    }
}