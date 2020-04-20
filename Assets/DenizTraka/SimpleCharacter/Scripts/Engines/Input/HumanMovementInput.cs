using System.Collections;
using System.Collections.Generic;
using DTWorld.Engines.AI.Mobiles;
using UnityEngine;
namespace DTWorld.Engines.Input
{
    public class HumanMovementInput : MobileMovementInput
    {
        public HumanMovementInput(BaseMobileAI mobileAI) : base(mobileAI)
        {
        }

        public override float GetXAxis()
        {
            return MobileAI.GetXAxis();
        }

        public override float GetYAxis()
        {
            return MobileAI.GetYAxis();
        }
    }
}