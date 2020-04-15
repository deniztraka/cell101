using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Interfaces;
using UnityEngine;

namespace DTWorld.Core.Mobiles
{
    public abstract class BaseMobile : IHealth
    {
        private float attackRate;
        private float nextAttackTime;
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
        protected IMovementType MovementType;
        public float AttackRate
        {
            get { return attackRate; }
            set { attackRate = value; }
        }

        public BaseMobile(float Speed, IMovementType movementType)
        {
            this.Speed = Speed;
            this.MovementType = movementType;
            this.attackRate = 0.5f;
            this.nextAttackTime = 0;
            this.Health = 100;
        }

        public void SetSpeed(float speed)
        {
            this.Speed = speed;
        }

        public virtual Vector2 Move()
        {
            if (!isAttacking)
            {
                return this.MovementType.Move(Speed);
            }
            return Vector2.zero;
        }

        internal bool CanAttack()
        {
            var canAttack = false;
            if (Time.time >= nextAttackTime)
            {
                canAttack = true;
                nextAttackTime = Time.time + attackRate;
            }

            return canAttack;
        }

        internal bool CanAttack(float newAttackRate)
        {
            var canAttack = false;
            if (Time.time >= nextAttackTime)
            {
                canAttack = true;
                nextAttackTime = Time.time + newAttackRate;
            }

            return canAttack;
        }


        public void TakeDamage(float damage)
        {
            //Debug.Log("Health before damage: " + this.health);
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

