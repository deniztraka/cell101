using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Engines.AI.States
{
    public class MobileFleeState : BaseMobileState
    {
        private BaseMobileBehaviour target;
        private Vector2 delta;
        private float currentDistance;
        private float fleeDistance;

        public MobileFleeState(BaseMobileBehaviour mobile, BaseMobileBehaviour target, float fleeDistance) : base(mobile)
        {
            this.target = target;
            this.fleeDistance = fleeDistance;
            delta = Vector2.zero;
        }

        public override float GetXAxis()
        {            

            if ((delta.x >= 0 && delta.x <= 0.01f) || (delta.x <= 0 && delta.x >= -0.01f))
            {
                return 0;
            }

            return delta.x < 0 ? -1 : 1;
        }

        public override float GetYAxis()
        {            
            if (delta.y == 0)
            {
                return 0;
            }

            return delta.y < 0 ? -1 : 1;
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
            //Debug.Log("flee");
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

            if (currentDistance > fleeDistance || MobileBehaviour.Mobile.Health > MobileBehaviour.FleeBelowHealth)
            {
                return WanderState();
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

        private BaseMobileState WanderState()
        {
            return new MobileWanderState(MobileBehaviour, 1, 5, true, fleeDistance);
        }
    }
}