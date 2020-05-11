using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Audio;
using DTWorld.Behaviours.Interfacelike;
using DTWorld.Behaviours.Items.Shields;
using DTWorld.Behaviours.Items.Weapons;
using DTWorld.Core.Mobiles;
using DTWorld.Engines.Animation;
using UnityEngine;
using static DTWorld.Behaviours.Interfacelike.HealthBehaviour;
using static DTWorld.Behaviours.Items.Shields.BaseShieldBehaviour;
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
        private float nextActionTime = 0;
        private int lastDirectionIndex;


        private float tempShieldSwingSpeed;
        private float tempWeaponSwingSpeed;

        private PropsBehaviour propsBehaviour;

        public BaseMobile Mobile;
        public bool IsAggressive;
        public float ChaseDistance;
        public float FleeBelowHealth;
        public float FleeDistance;

        public HealthBehaviour HealthBehaviour;

        public float lastDefendTime = 0;
        public float lastAttackTime = 0;

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
        public BaseShieldBehaviour ShieldBehaviour { get; set; }

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

            // add shield object in the handle
            if (LeftHandle != null)
            {
                var shieldBehaviour = LeftHandle.GetComponentInChildren<BaseShieldBehaviour>();
                if (shieldBehaviour != null)
                {
                    AddShield(shieldBehaviour);
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

            HealthBehaviour = gameObject.GetComponent<HealthBehaviour>();
            HealthBehaviour.OnDamageTakenEvent += new OnDamageTakenEventHandler(OnDamageTaken);
            HealthBehaviour.OnHealthBelowZeroEvent += new OnHealthBelowZeroEventHandler(OnDead);
            if (WeaponBehaviour != null)
            {
                ChaseDistance = (WeaponBehaviour.AttackDistance / 4) + ChaseDistance;
                FleeDistance = WeaponBehaviour.IsRanged ? WeaponBehaviour.AttackDistance / 2 : 0;
            }

            propsBehaviour = gameObject.GetComponent<PropsBehaviour>();
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
                if (UnityEngine.Random.Range(0, 10) > 8)
                {
                    audioManager.Play("Hurt");
                }
            }
        }

        private void OnDead(BaseMobileBehaviour mobile)
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

        public int GetLastDirectionIndex()
        {
            return lastDirectionIndex;
        }

        public void SetLastDirection(Vector2 lastDirection)
        {
            lastDirectionIndex = animationHandler.SetCurrentAnimation(lastDirection, Mobile);
        }

        void OnValidate()
        {
            if (Mobile != null)
            {
                Mobile.SetSpeed(speed);
            }
        }

        public float GetSwingSpeed()
        {
            //Attack rate only depends on weapon speed for now
            return WeaponBehaviour.Item.SwingSpeed + (propsBehaviour.Dexterity.CurrentValue / 10);
        }

        public float GetSwingRate()
        {
            var swingSpeed = GetSwingSpeed();

            return 1 / swingSpeed;
        }

        public float GetDefendSpeed()
        {
            //Defend rate only depends on weapon speed for now
            return ShieldBehaviour.Item.SwingSpeed;
        }

        protected bool CanDefend()
        {

            if (Mobile.Health <= 0)
            {
                return false;
            }

            if (ShieldBehaviour == null)
            {
                return false;
            }


            if (Time.time > nextActionTime)
            {
                var calculatedDefendRate = GetDefendSpeed();
                //Debug.Log(calculatedDefendRate);
                if (calculatedDefendRate <= Mobile.ActionRate)
                {
                    nextActionTime = Time.time + Mobile.ActionRate;
                    return Mobile.CanDefend();

                }
                else
                {
                    nextActionTime = Time.time + Mobile.ActionRate;
                    return Mobile.CanDefend(calculatedDefendRate);
                }
            }
            return false;
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
                var calculatedAttackRate = GetSwingRate();
                if (calculatedAttackRate <= Mobile.ActionRate)
                {
                    nextActionTime = Time.time + Mobile.ActionRate;
                    return Mobile.CanAttack();

                }
                else
                {
                    nextActionTime = Time.time + Mobile.ActionRate;
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
                WeaponBehaviour.OwnerMobileProps = gameObject.GetComponent<PropsBehaviour>();
            }
        }

        private void AddShield(BaseShieldBehaviour shieldBehaviour)
        {
            if (LeftHandle != null)
            {
                ShieldBehaviour = shieldBehaviour;
                ShieldBehaviour.OwnerMobileBehaviour = this;
                ShieldBehaviour.BeforeDefendingEvent += new BeforeDefendingEventHandler(SetDefendSpeedBefore);
                ShieldBehaviour.AfterDefendEvent += new AfterDefendEventHandler(SetDefendSpeedAfter);
            }
        }

        private void SetDefendSpeedBefore()
        {
            animationHandler.SetCurrentAnimationSpeedMultiplier(1 / GetDefendSpeed());

            tempShieldSwingSpeed = ShieldBehaviour.Item.SwingSpeed;
            //ShieldBehaviour.SetSwingSpeed(1 / defendRate);
        }

        private void SetDefendSpeedAfter()
        {
            animationHandler.SetCurrentAnimationSpeedMultiplier(1f);
            //Todo set swingspeed to old value
            //ShieldBehaviour.SetSwingSpeed(tempShieldSwingSpeed);
        }

        private void SetAttackSpeedBefore()
        {
            animationHandler.SetCurrentAnimationSpeedMultiplier(1 / GetSwingRate());
            tempWeaponSwingSpeed = WeaponBehaviour.Item.SwingSpeed;
            //WeaponBehaviour.SetSwingSpeed(1 / attackRate);
        }

        private void SetAttackSpeedAfter()
        {
            animationHandler.SetCurrentAnimationSpeedMultiplier(1f);
            //Todo set swingspeed to old value
            //WeaponBehaviour.SetSwingSpeed(tempWeaponSwingSpeed);
        }

        public void Defend()
        {
            if (CanDefend() && LeftHandle != null && LeftHandle.transform.childCount > 0)
            {
                //Debug.Log(Time.time - lastDefendTime);
                lastDefendTime = Time.time;
                if (ShieldBehaviour == null)
                {
                    ShieldBehaviour = RightHandle.GetComponentInChildren<BaseShieldBehaviour>();
                    if (WeaponBehaviour != null)
                    {
                        lastAttackTime = Time.time;
                        ShieldBehaviour.Defend();
                    }
                }
                else
                {
                    lastDefendTime = Time.time;
                    ShieldBehaviour.Defend();
                }
            }
        }

        public void Attack()
        {
            //attack with weapon if mobile has any weapon 
            if (CanAttack() && RightHandle != null && RightHandle.transform.childCount > 0)
            {
                //Debug.Log(Time.time - lastAttackTime);
                lastAttackTime = Time.time;
                if (WeaponBehaviour == null)
                {
                    WeaponBehaviour = RightHandle.GetComponentInChildren<BaseWeaponBehaviour>();
                    if (WeaponBehaviour != null)
                    {
                        WeaponBehaviour.Attack(GetSwingRate());
                    }
                }
                else
                {
                    WeaponBehaviour.Attack(GetSwingRate());
                }
            }
        }

        public void SetParalyzed(bool val)
        {
            isParalyzed = val;
        }
    }
}