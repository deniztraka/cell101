﻿using System;
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
        private float attackSpeed;
        private TrailRenderer trailRenderer;

        public new BaseWeapon Item;
        public BaseMobileBehaviour OwnerMobileBehaviour;

        private AudioManager audioManager;

        public float Damage;
        public float SwingSpeed;
        public delegate void BeforeAttackingEventHandler();
        public event BeforeAttackingEventHandler BeforeAttackingEvent;
        public delegate void AfterAttackedEventHandler();
        public event AfterAttackedEventHandler AfterAttackedEvent;
        public override void Start()
        {
            base.Start();
            audioManager = gameObject.GetComponent<AudioManager>();
            trailRenderer = gameObject.transform.GetComponentInChildren<TrailRenderer>();
            trailRenderer.enabled = false;
            this.BeforeAttackingEvent += new BeforeAttackingEventHandler(BeforeAttacking);
            this.AfterAttackedEvent += new AfterAttackedEventHandler(AfterAttacked);
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
        }

        private IEnumerator ExecuteAfterTime(Action task)
        {
            if (BeforeAttackingEvent != null)
            {
                BeforeAttackingEvent.Invoke();
            }
            if (OwnerMobileBehaviour != null)
            {
                OwnerMobileBehaviour.Mobile.IsAttacking = true;
                trailRenderer.enabled = true;
            }
            if (audioManager != null)
            {
                audioManager.Play("Swing");
            }
            
            yield return new WaitForSeconds(1 / (attackSpeed + 0.2f));

            if (task != null)
            {
                task();
            }

            if (OwnerMobileBehaviour != null)
            {
                trailRenderer.enabled = false;
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

        public void Attack()
        {
            StartCoroutine(ExecuteAfterTime(() =>
            {

                //Weapon.Attack();
            }));
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
            audioManager.Play("Hit");
        }

        public void SetAttackSpeed(float value)
        {
            attackSpeed = value;
        }
    }
}