using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Mobiles;
using UnityEngine;
namespace DTWorld.Core.Items.Shields
{
    public class RoundShield : BaseShield
    {
        public RoundShield(string name) : base(name)
        {
            this.SwingSpeed = 1f;
        }
        public RoundShield(string name, float defendRate, float swingSpeed) : base(name, defendRate, swingSpeed)
        {
        }
        public RoundShield(string name, float defendRate, float swingSpeed, BaseMobile mobile) : base(name, defendRate, swingSpeed, mobile)
        {
        }
    }
}