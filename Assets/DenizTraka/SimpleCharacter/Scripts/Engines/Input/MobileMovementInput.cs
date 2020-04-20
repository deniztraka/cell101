using System.Collections;
using System.Collections.Generic;
using DTWorld.Engines.AI.Mobiles;
using DTWorld.Interfaces;
using UnityEngine;
namespace DTWorld.Engines.Input
{
    public abstract class MobileMovementInput : IMovementInput
    {
        protected BaseMobileAI MobileAI { get; set; }
        public MobileMovementInput(BaseMobileAI mobileAI)
        {
            MobileAI = mobileAI;
        }
        public abstract float GetXAxis();

        public abstract float GetYAxis();
    }
}