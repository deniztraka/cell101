using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Engines.AI.States
{
    public class MobileWanderState : MobileIdleState
    {
        float minDecisionFrequency;
        float maxDecisionFrequency;
        float nextDecisionTime;

        bool isMoving;

        Vector2 movement;

        public MobileWanderState(float minDecisionFrequency, float maxDecisionFrequency, bool isAggressive, float chaseDistance) : base(isAggressive, chaseDistance)
        {
            this.maxDecisionFrequency = maxDecisionFrequency;
            this.minDecisionFrequency = minDecisionFrequency;
            this.nextDecisionTime = Random.Range(minDecisionFrequency, maxDecisionFrequency);
            this.isMoving = false;
            this.movement = Vector2.zero;
        }

        public MobileWanderState(float minDecisionFrequency, float maxDecisionFrequency) : base()
        {
            this.maxDecisionFrequency = maxDecisionFrequency;
            this.minDecisionFrequency = minDecisionFrequency;
            this.nextDecisionTime = Random.Range(minDecisionFrequency, maxDecisionFrequency);
            this.isMoving = false;
            this.movement = Vector2.zero;
        }

        public override float GetXAxis()
        {
            return movement.x;
        }

        public override float GetYAxis()
        {
            return movement.y;
        }

        public override BaseMobileState OnStateUpdate()
        {
            var baseResult = base.OnStateUpdate();
            if (baseResult != null)
            {
                return baseResult;
            }

            if (Time.time > nextDecisionTime)
            {
                if (Random.Range(0, 10) > 5)
                {
                    RandomizeMovement();
                }
                else
                {
                    StopMovement();
                    //return IdleState();
                }

                nextDecisionTime = Time.time + Random.Range(minDecisionFrequency, maxDecisionFrequency);
            }

            return null;
        }

        private void RandomizeMovement()
        {
            movement.x = Random.Range(-1, 2);
            movement.y = Random.Range(-1, 2);
        }

        private void StopMovement()
        {
            movement = Vector2.zero;
        }

        private BaseMobileState IdleState()
        {
            var mobileIdleState = new MobileIdleState(IsAggressive, ChaseDistance);
            mobileIdleState.SetMobile(MobileBehaviour);

            return mobileIdleState;
        }
    }
}