using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Mobiles;
using UnityEngine;
namespace DTWorld.Core.Items.Weapons
{
    public class Sword : BaseWeapon
    {
        public Sword(string name) : base(name)
        {
            this.SwingSpeed = 1f;
        }
        public Sword(string name, float damage) : base(name, damage)
        {
            this.SwingSpeed = 1f;
        }
        public Sword(string name, float damage, BaseMobile mobile) : base(name, damage, mobile)
        {
            this.SwingSpeed = 1f;
        }
    }
}