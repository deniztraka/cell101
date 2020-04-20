using System.Collections;
using System.Collections.Generic;
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
        private AnimationHandler animationHandler;

        public BaseMobile Mobile;

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

        public virtual void Awake(){
            
        }

        public virtual void Start()
        {
            this.Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

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
        }

        private void OnDamageTaken(float damage)
        {
            Mobile.TakeDamage(damage);
        }

        public virtual void FixedUpdate()
        {

            var movement = Mobile.Move();
            if (animationHandler != null)
            {
                animationHandler.SetCurrentAnimation(movement, Mobile.IsAttacking);
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

        protected bool CanAttack(){
            var calculatedAttackRate = GetAttackRate();
            if(calculatedAttackRate <= Mobile.AttackRate){
                return Mobile.CanAttack();
            } else {
                return Mobile.CanAttack(calculatedAttackRate);
            }
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
    }
}