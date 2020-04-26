﻿using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Audio;
using DTWorld.Behaviours.Interfacelike;
using DTWorld.Behaviours.Items.Weapons;
using DTWorld.Core.Mobiles;
using DTWorld.Engines.Animation;
using UnityEngine;
using static DTWorld.Behaviours.Interfacelike.HealthBehaviour;
using static DTWorld.Behaviours.Items.Weapons.BaseWeaponBehaviour;

namespace DTWorld.Behaviours.Mobiles
{

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(HealthBehaviour))]
    public class BaseMobileBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        private bool isParalyzed;
        private AnimationHandler animationHandler;
        private AudioManager audioManager;
        private float actionFrequency = 0.5f;
        private float nextActionTime = 0;
        private int lastDirectionIndex;

        public BaseMobile Mobile;
        public bool IsAggressive;
        public float ChaseDistance;
        public float FleeBelowHealth;

        public ParticleSystem DamageTakenEffect;

        public float Speed
        {
            get { return speed; }
            set
            {
                Mobile.SetSpeed(value);
                speed = value;
            }
        }
        public Rigidbody2D Rigidbody2D { get; set; }
        public BaseWeaponBehaviour WeaponBehaviour { get; set; }

        public GameObject RightHandle;
        public GameObject LeftHandle;

        public virtual void Awake()
        {
            lastDirectionIndex = 0;
        }

        public virtual void Start()
        {
            this.Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            audioManager = gameObject.GetComponent<AudioManager>();
            var damageTakenEffectTransform = transform.Find("DamageTakenEffect");
            if (damageTakenEffectTransform != null)
            {
                DamageTakenEffect = damageTakenEffectTransform.gameObject.GetComponent<ParticleSystem>();
            }

            // add weapon object in the handle
            if (RightHandle != null)
            {
                var weaponBehaviour = RightHandle.GetComponentInChildren<BaseWeaponBehaviour>();
                if (weaponBehaviour != null)
                {
                    AddWeapon(weaponBehaviour);
                }
            }

            //set animation system
            var animationRig = gameObject.transform.Find("Rig");
            if (animationRig != null)
            {
                var animator = animationRig.gameObject.GetComponent<Animator>();
                if (animator != null)
                {
                    if (RightHandle != null && LeftHandle != null)
                    {
                        animationHandler = new SimpleDirectionsAnimationHandler(animator, RightHandle, LeftHandle);
                    }
                    else
                    {
                        animationHandler = new SimpleDirectionsAnimationHandler(animator);
                    }
                }
            }

            var healthBehaviourComponent = gameObject.GetComponent<HealthBehaviour>();
            healthBehaviourComponent.OnDamageTakenEvent += new OnDamageTakenEventHandler(OnDamageTaken);
            healthBehaviourComponent.OnHealthBelowZeroEvent += new OnHealthBelowZeroEventHandler(OnDead);
        }

        IEnumerator SetParalyzed(float time)
        {
            if (isParalyzed)
            {
                yield return new WaitForSeconds(time);
            }
            else
            {
                isParalyzed = true;
                yield return new WaitForSeconds(time);
            }

            isParalyzed = false;
        }

        private void OnDamageTaken(float damage, float currentHealth, float maxHealth)
        {
            Mobile.TakeDamage(damage);
            if (DamageTakenEffect != null && !DamageTakenEffect.isPlaying)
            {
                DamageTakenEffect.Play();
            }

            //no movement for 0.25 seconds after damage taken
            StartCoroutine(SetParalyzed(0.25f));

            if (audioManager != null)
            {
                if (Random.Range(0, 10) > 8)
                {
                    audioManager.Play("Hurt");
                }
            }
        }

        private void OnDead()
        {
            if (audioManager != null)
            {
                audioManager.Stop("Walking");
                audioManager.Play("Dead");
            }
            Destroy(gameObject, 1.5f);
        }

        public virtual void Update()
        {

        }

        public virtual void FixedUpdate()
        {
            var movement = Vector2.zero;
            if (Mobile.Health > 0 && !isParalyzed)
            {
                movement = Mobile.Move();
                if (movement.magnitude > 0)
                {
                    audioManager.Play("Walking");
                }
                else if (movement.magnitude == 0)
                {
                    audioManager.Stop("Walking");
                }
            }

            if (animationHandler != null)
            {
                lastDirectionIndex = animationHandler.SetCurrentAnimation(movement, Mobile);
            }

        }

        void OnValidate()
        {
            if (Mobile != null)
            {
                Mobile.SetSpeed(speed);
            }
        }

        public float GetAttackRate()
        {
            //Attack rate only depends on weapon speed for now
            return 1 / WeaponBehaviour.Item.SwingSpeed;
        }

        protected bool CanAttack()
        {
            if (Mobile.Health <= 0)
            {
                return false;
            }

            if (WeaponBehaviour == null)
            {
                return false;
            }

            if (Time.time > nextActionTime)
            {
                var calculatedAttackRate = GetAttackRate();
                if (calculatedAttackRate <= Mobile.AttackRate)
                {
                    nextActionTime = Time.time + actionFrequency;
                    return Mobile.CanAttack();

                }
                else
                {
                    nextActionTime = Time.time + actionFrequency;
                    return Mobile.CanAttack(calculatedAttackRate);
                }
            }
            return false;
        }

        public void AddWeapon(BaseWeaponBehaviour weaponBehaviour)
        {
            if (RightHandle != null)
            {
                WeaponBehaviour = weaponBehaviour;
                WeaponBehaviour.OwnerMobileBehaviour = this;
                WeaponBehaviour.BeforeAttackingEvent += new BeforeAttackingEventHandler(SetAttackSpeedBefore);
                WeaponBehaviour.AfterAttackedEvent += new AfterAttackedEventHandler(SetAttackSpeedAfter);
            }
        }

        private void SetAttackSpeedBefore()
        {
            var attackRate = GetAttackRate();
            animationHandler.SetCurrentAnimationSpeedMultiplier(attackRate);
            WeaponBehaviour.SetAttackSpeed(attackRate);
        }

        private void SetAttackSpeedAfter()
        {
            animationHandler.SetCurrentAnimationSpeedMultiplier(1f);
            WeaponBehaviour.SetAttackSpeed(1f);
        }

        public void Attack()
        {
            //attack with weapon if mobile has any weapon 
            if (CanAttack() && RightHandle != null && RightHandle.transform.childCount > 0)
            {
                if (WeaponBehaviour == null)
                {
                    WeaponBehaviour = RightHandle.GetComponentInChildren<BaseWeaponBehaviour>();
                    if (WeaponBehaviour != null)
                    {
                        WeaponBehaviour.Attack();
                    }
                }
                else
                {
                    WeaponBehaviour.Attack();
                }
            }
        }
    }
}