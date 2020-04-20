using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Engines.Movement;
using UnityEngine;

namespace DTWorld.Engines.AI.Mobiles
{
    public abstract class BaseMobileAI
    {
        public BaseMobileAI()
        {
        }

        internal abstract float GetXAxis();

        internal abstract float GetYAxis();
    }
}
