using System;
using System.Collections;
using DTWorld.Core.Mobiles;
using DTWorld.Interfaces;
using UnityEngine;

namespace DTWorld.Core.Items.Shields
{
    public abstract class BaseShield : BaseItem, IShield
    {
        private BaseMobile mobile;
        private float defendRate;
        private float swingSpeed;
        public float SwingSpeed
        {
            get { return swingSpeed; }
            set { swingSpeed = value; }
        }
        public float DefendRate
        {
            get { return defendRate; }
            set { defendRate = value; }
        }

        public BaseMobile Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        public BaseShield(string name) : base(name)
        {
        }

        public BaseShield(string name, float defendRate, float swingSpeed) : base(name)
        {
            this.defendRate = defendRate;
            this.swingSpeed = swingSpeed;
        }

        public BaseShield(string name, float defendRate, float swingSpeed, BaseMobile mobile) : base(name)
        {
            this.defendRate = defendRate;
            this.mobile = mobile;
            this.swingSpeed = swingSpeed;
        }

        public virtual void Defend(BaseMobile mobile)
        {
            //Mobile.TakeDamage(damage);
            //Debug.Log("defended from baseShield");
        }
    }
}
