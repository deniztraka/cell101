using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Interfaces;
using UnityEngine;

namespace DTWorld.Core.Mobiles
{
    public abstract class BaseMobile : IHealth
    {
        private float actionRate;
        private float nextActionTime;
        private bool isAttacking;
        // private IWeapon weapon;

        private float health;
        public float Health
        {
            get { return health; }
            set { health = value; }
        }

        // public IWeapon Weapon
        // {
        //     get { return weapon; }
        //     set { weapon = value; }
        // }
        public bool IsAttacking
        {
            get { return isAttacking; }
            set { isAttacking = value; }
        }

        // internal void AddWeapon(IWeapon weapon)
        // {
        //     this.weapon = weapon;
        // }

        protected float Speed;
        public IMovementType MovementType;
        public float ActionRate
        {
            get { return actionRate; }
            set { actionRate = value; }
        }

        public bool IsDefending { get; internal set; }

        public BaseMobile(float health, float Speed, IMovementType movementType)
        {
            this.Speed = Speed;
            this.MovementType = movementType;
            this.actionRate = 0.5f;
            this.nextActionTime = 0;
            this.Health = health;
            this.IsDefending = false;
        }

        public BaseMobile(float Speed, IMovementType movementType)
        {
            this.Speed = Speed;
            this.MovementType = movementType;
            this.actionRate = 0.5f;
            this.nextActionTime = 0;
            this.Health = 100;
            this.IsDefending = false;
        }

        public BaseMobile(float Speed)
        {
            this.Speed = Speed;
            this.actionRate = 0.5f;
            this.nextActionTime = 0;
            this.Health = 100;
            this.IsDefending = false;
        }

        public void SetSpeed(float speed)
        {
            this.Speed = speed;
        }

        public virtual Vector2 Move()
        {
            if (!isAttacking && !IsDefending && this.MovementType != null)
            {
                return this.MovementType.Move(Speed);
            }
            return Vector2.zero;
        }

        internal bool CanDefend()
        {
            var canDefend = false;
            if (Time.time >= nextActionTime)
            {
                canDefend = true;
                nextActionTime = Time.time + actionRate;
            }

            return canDefend;
        }

        public void SetNextActionTime(float time){
            nextActionTime = time;
        }

        internal bool CanDefend(float newActionRate)
        {
            var canAttack = false;
            if (Time.time >= nextActionTime)
            {
                canAttack = true;
                nextActionTime = Time.time + newActionRate;
            }

            return canAttack;
        }

        internal bool CanAttack()
        {
            var canAttack = false;
            if (Time.time >= nextActionTime)
            {
                canAttack = true;
                nextActionTime = Time.time + actionRate;
            }

            return canAttack;
        }

        internal bool CanAttack(float newAttackRate)
        {
            var canAttack = false;
            if (Time.time >= nextActionTime)
            {
                canAttack = true;
                nextActionTime = Time.time + newAttackRate;
            }

            return canAttack;
        }


        public void TakeDamage(float damage)
        {
            Debug.Log("Health before damage: " + this.health);
            this.health -= damage;
            //Debug.Log("Damage taken: " + damage);
            //Debug.Log("Health after damage: " + this.health);
        }

        public void SetHealth(float health)
        {
            this.health = health;
        }
    }
}

