using System.Collections;
using System.Collections.Generic;
using DTWorld.Engines.AI;
using UnityEngine;
namespace DTWorld.Engines.Input
{
    public class HumanMovementInput : MobileMovementInput
    {
        public HumanMovementInput(MobileAI mobileAI) : base(mobileAI)
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