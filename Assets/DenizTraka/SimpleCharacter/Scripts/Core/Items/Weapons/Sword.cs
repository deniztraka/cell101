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
            this.Damage = 10;
            this.SwingSpeed = 0.5f;
        }
        public Sword(string name, BaseMobile mobile) : base(name, mobile)
        {
            this.Damage = 10;
            this.SwingSpeed = 0.5f;
        }
    }
}