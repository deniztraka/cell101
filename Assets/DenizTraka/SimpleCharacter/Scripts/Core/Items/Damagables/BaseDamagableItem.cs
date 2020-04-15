using DTWorld.Interfaces;
using UnityEngine;

namespace DTWorld.Core.Items
{
    public abstract class BaseDamagableItem : BaseItem, IHealth
    {
        private float health;
        public float Health
        {
            get { return health; }
            set { health = value; }
        }

        public BaseDamagableItem(string name) : base(name)
        {

        }

        public virtual void SetHealth(float health)
        {
            Health = health;
        }
        public virtual void TakeDamage(float damage)
        {
            //Debug.Log("Health before damage: " + this.health);
            this.health -= damage;
            //Debug.Log("Damage taken: " + damage);
            //Debug.Log("Health after damage: " + this.health);
        }
    }
}
