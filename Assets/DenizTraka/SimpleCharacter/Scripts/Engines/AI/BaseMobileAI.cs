using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Core.Mobiles;
using DTWorld.Engines.Movement;
using UnityEngine;

namespace DTWorld.Engines.AI.Mobiles
{
    public abstract class BaseMobileAI
    {
        protected BaseMobile Mobile;

        public BaseMobileAI()
        {
        }

        public BaseMobileAI(BaseMobile mobile)
        {
            this.Mobile = mobile;
        }

        internal abstract float GetXAxis();

        internal abstract float GetYAxis();
    }
}
