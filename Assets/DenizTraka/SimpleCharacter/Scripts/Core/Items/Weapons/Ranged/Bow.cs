﻿using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Mobiles;
using UnityEngine;
namespace DTWorld.Core.Items.Weapons.Ranged
{
    public class Bow : BaseRangedWeapon
    {
        public Bow(string name) : base(name)
        {
            this.SwingSpeed = 1f;
        }
        public Bow(string name, float damage, float swingSpeed) : base(name, damage, swingSpeed)
        {
        }
        public Bow(string name, float damage, float swingSpeed, BaseMobile mobile) : base(name, damage, swingSpeed, mobile)
        {
        }
    }
}