using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Audio;
using DTWorld.Behaviours.Interfacelike;
using DTWorld.Behaviours.Mobiles;
using DTWorld.Core.Items.Weapons;
using DTWorld.Interfaces;
using UnityEngine;
namespace DTWorld.Behaviours.Items.Weapons
{
    public abstract class BaseWeaponBehaviour : BaseItemBehaviour
    {
        private TrailRenderer trailRenderer;

        public new BaseWeapon Item;
        public BaseMobileBehaviour OwnerMobileBehaviour;

        protected AudioManager AudioManager;


        public bool IsRanged;

        public float AttackDistance = 0.5f;
        public float Damage;
        public float SwingSpeed;
        public delegate void BeforeAttackingEventHandler();
        public event BeforeAttackingEventHandler BeforeAttackingEvent;
        public delegate void AfterAttackedEventHandler();
        public event AfterAttackedEventHandler AfterAttackedEvent;
        public override void Start()
        {
            base.Start();            
            AudioManager = gameObject.GetComponent<AudioManager>();
            trailRenderer = gameObject.transform.GetComponentInChildren<TrailRenderer>();
            IsRanged = false;
            if (trailRenderer != null)
            {
                trailRenderer.enabled = false;
            }
            this.BeforeAttackingEvent += new BeforeAttackingEventHandler(BeforeAttacking);
            this.AfterAttackedEvent += new AfterAttackedEventHandler(AfterAttacked);
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
        }

        protected IEnumerator ExecuteAfterTime(Action task)
        {
            if (BeforeAttackingEvent != null)
            {
                BeforeAttackingEvent.Invoke();
            }
            if (OwnerMobileBehaviour != null)
            {
                OwnerMobileBehaviour.Mobile.IsAttacking = true;
                if (trailRenderer != null)
                {
                    trailRenderer.enabled = true;
                }
            }
            if (AudioManager != null)
            {
                AudioManager.Play("Swing");
            }

            var lastTime = Time.time;
            yield return new WaitForSeconds(1 / SwingSpeed);

            //Debug.Log(Time.time - lastTime);


            if (task != null)
            {
                task();
            }

            if (OwnerMobileBehaviour != null)
            {
                if (trailRenderer != null)
                {
                    trailRenderer.enabled = false;
                }
                OwnerMobileBehaviour.Mobile.IsAttacking = false;
            }

            if (AfterAttackedEvent != null)
            {
                AfterAttackedEvent.Invoke();
            }
        }

        protected IEnumerator ExecuteBeforeTime(Action task)
        {
            if (BeforeAttackingEvent != null)
            {
                BeforeAttackingEvent.Invoke();
            }
            if (OwnerMobileBehaviour != null)
            {
                OwnerMobileBehaviour.Mobile.IsAttacking = true;
                if (trailRenderer != null)
                {
                    trailRenderer.enabled = true;
                }
            }
            if (AudioManager != null)
            {
                AudioManager.Play("Swing");
            }

            if (task != null)
            {
                task();
            }

            var lastTime = Time.time;

            yield return new WaitForSeconds(1 / SwingSpeed);

            //Debug.Log(Time.time - lastTime);

            if (OwnerMobileBehaviour != null)
            {
                if (trailRenderer != null)
                {
                    trailRenderer.enabled = false;
                }
                OwnerMobileBehaviour.Mobile.IsAttacking = false;
            }

            if (AfterAttackedEvent != null)
            {
                AfterAttackedEvent.Invoke();
            }
        }

        public virtual void BeforeAttacking()
        {
            //Debug.Log("before attacking base weapon");
            //timeBeforeHit = Time.time;
            //Debug.Log(timeBeforeHit);
        }

        public virtual void AfterAttacked()
        {
            //Debug.Log("after attacking base weapon");            
        }

        public virtual void Attack()
        {
            StartCoroutine(ExecuteAfterTime(() =>
            {

                //Weapon.Attack();
            }));
        }



        public void SetSwingSpeed(float value)
        {
            SwingSpeed = value;
        }
    }
}