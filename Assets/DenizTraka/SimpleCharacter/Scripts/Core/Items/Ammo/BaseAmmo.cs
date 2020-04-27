using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Core.Items.Ammo
{

    public abstract class BaseAmmo : BaseItem
    {
        private float damage;
        public float Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        
        public BaseAmmo(string name) : base(name)
        {
            this.damage = 1;
        }

        public BaseAmmo(string name, float damage) : base(name)
        {
            this.damage = damage;
        }
    }
}
