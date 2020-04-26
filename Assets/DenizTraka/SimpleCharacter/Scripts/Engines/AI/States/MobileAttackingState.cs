using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Engines.AI.States
{
    public class MobileAttackingState : MobileIdleState
    {
        BaseMobileBehaviour target;
        public MobileAttackingState(BaseMobileBehaviour mobile, BaseMobileBehaviour target, bool isAggressive, float chaseDistance) : base(mobile, isAggressive, chaseDistance)
        {
            this.target = target;
        }

        public override float GetXAxis()
        {
            return 0f;
        }

        public override float GetYAxis()
        {
            return 0f;
        }

        public override void OnStateExit()
        {

        }

        public override void OnStateEnter()
        {
            //Debug.Log("Attacking");
            base.OnStateEnter();
        }

        public override BaseMobileState OnStateUpdate()
        {
            if (target.Mobile.Health <= 0)
            {
                return WanderState();
            }

            if (MobileBehaviour.Mobile.Health < MobileBehaviour.FleeBelowHealth)
            {
                return FleeState();
            }

            MobileBehaviour.Attack();

            var baseResult = base.OnStateUpdate();
            if (baseResult != null)
            {
                return baseResult;
            }

            return null;
        }

        private BaseMobileState FleeState()
        {
            return new MobileFleeState(MobileBehaviour, target, ChaseDistance);
        }

        internal override void OnStateFixedUpdate()
        {

        }

        private BaseMobileState WanderState()
        {
            return new MobileWanderState(MobileBehaviour, 1, 5, true, ChaseDistance);
        }
    }
}