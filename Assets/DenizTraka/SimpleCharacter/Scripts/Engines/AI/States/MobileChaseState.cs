using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Engines.AI.States
{
    public class MobileChaseState : BaseMobileState
    {
        private BaseMobileBehaviour target;
        private Vector2 delta;
        private float currentDistance;
        private float chaseDistance;

        public MobileChaseState(BaseMobileBehaviour mobile, BaseMobileBehaviour target, float chaseDistance) : base(mobile)
        {
            this.target = target;
            this.chaseDistance = chaseDistance;
            delta = Vector2.zero;
        }

        public override float GetXAxis()
        {
            if (currentDistance <= 0.5)
            {
                return 0;
            }

            if ((delta.x >= 0 && delta.x <= 0.01f) || (delta.x <= 0 && delta.x >= -0.01f))
            {
                return 0;
            }

            return delta.x > 0 ? -1 : 1;
        }

        public override float GetYAxis()
        {
            if (currentDistance <= 0.5)
            {
                return 0;
            }

            if (delta.y == 0)
            {
                return 0;
            }

            return delta.y > 0 ? -1 : 1;
        }

        public override void OnStateExit()
        {
            if (MobileBehaviour != null)
            {
                MobileBehaviour.Speed = MobileBehaviour.Speed / 2f;
            }
        }

        public override void OnStateEnter()
        {
            //Debug.Log("Chase!");
            base.OnStateEnter();
            if (MobileBehaviour != null)
            {
                MobileBehaviour.Speed = MobileBehaviour.Speed * 2f;
            }
        }

        public override BaseMobileState OnStateUpdate()
        {
            if (MobileBehaviour == null)
            {
                return null;
            }

            delta = MobileBehaviour.transform.position - target.transform.position;

            currentDistance = Vector2.Distance(MobileBehaviour.transform.position, target.transform.position);

            if (currentDistance > chaseDistance)
            {
                return WanderState();
            }

            if(currentDistance < chaseDistance && MobileBehaviour.Mobile.Health < MobileBehaviour.FleeBelowHealth){
                return FleeState();
            }

            if (currentDistance <= 0.5)
            {
                return AttackingState();
            }

            return null;
        }

        internal override void OnStateFixedUpdate()
        {
            if (MobileBehaviour == null)
            {
                return;
            }
        }

        private BaseMobileState FleeState()
        {
            return new MobileFleeState(MobileBehaviour, PlayerBehaviour, chaseDistance);
        }

        private BaseMobileState WanderState()
        {
            return new MobileWanderState(MobileBehaviour, 1, 5, true, chaseDistance);
        }

        private BaseMobileState AttackingState()
        {
            return new MobileAttackingState(MobileBehaviour, target, true, chaseDistance);
        }
    }
}