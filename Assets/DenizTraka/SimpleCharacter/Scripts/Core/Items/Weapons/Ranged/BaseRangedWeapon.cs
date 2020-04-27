using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Mobiles;
using UnityEngine;
namespace DTWorld.Core.Items.Weapons.Ranged
{
    public class BaseRangedWeapon : BaseWeapon
    {
        public BaseRangedWeapon(string name) : base(name)
        {
            this.SwingSpeed = 1f;
        }
        public BaseRangedWeapon(string name, float damage, float swingSpeed) : base(name, damage, swingSpeed)
        {
        }
        public BaseRangedWeapon(string name, float damage, float swingSpeed, BaseMobile mobile) : base(name, damage, swingSpeed, mobile)
        {
        }
    }
}