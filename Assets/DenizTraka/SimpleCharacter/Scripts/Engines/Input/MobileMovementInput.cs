using System.Collections;
using System.Collections.Generic;
using DTWorld.Engines.AI;
using DTWorld.Interfaces;
using UnityEngine;
namespace DTWorld.Engines.Input
{
    public abstract class MobileMovementInput : IMovementInput
    {
        protected MobileAI MobileAI { get; set; }
        public MobileMovementInput(MobileAI mobileAI)
        {
            MobileAI = mobileAI;
        }
        public abstract float GetXAxis();

        public abstract float GetYAxis();
    }
}