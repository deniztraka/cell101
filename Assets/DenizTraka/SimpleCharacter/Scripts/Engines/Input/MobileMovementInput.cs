using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.AI;
using DTWorld.Engines.AI;
using DTWorld.Interfaces;
using UnityEngine;
namespace DTWorld.Engines.Input
{
    public abstract class MobileMovementInput : IMovementInput
    {
        protected AIMovementBehaviour MobileAI { get; set; }
        public MobileMovementInput(AIMovementBehaviour mobileAI)
        {
            MobileAI = mobileAI;
        }
        public abstract float GetXAxis();

        public abstract float GetYAxis();        
    }
}