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
        private float distance;

        public MobileChaseState(BaseMobileBehaviour target)
        {
            this.target = target;
            delta = Vector2.zero;
        }

        public override float GetXAxis()
        {
            if (distance <= 0.5)
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
            if (distance <= 0.5)
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
            Debug.Log("OnChaseStateExit");
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            Debug.Log("OnChaseStateEnter");
        }

        public override BaseMobileState OnStateUpdate()
        {
            if (MobileBehaviour == null)
            {
                return null;
            }

            delta = MobileBehaviour.transform.position - target.transform.position;

            distance = Vector2.Distance(MobileBehaviour.transform.position, target.transform.position);

            return null;
        }

        internal override void OnStateFixedUpdate()
        {
            if (MobileBehaviour == null)
            {
                return;
            }
        }
    }
}