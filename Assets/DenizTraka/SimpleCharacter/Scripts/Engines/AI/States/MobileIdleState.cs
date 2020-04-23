using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Engines.AI.States
{

    public class MobileIdleState : BaseMobileState
    {
        protected float ChaseDistance;
        protected bool IsAggressive;
        public MobileIdleState()
        {
            this.IsAggressive = false;
            this.ChaseDistance = 1f;
        }

        public MobileIdleState(bool isAggressive, float chaseDistance)
        {
            this.ChaseDistance = chaseDistance;
            this.IsAggressive = isAggressive;
        }

        public MobileIdleState(BaseMobileBehaviour mobile, bool isAggressive, float chaseDistance) : base(mobile)
        {
            this.ChaseDistance = chaseDistance;
            this.IsAggressive = isAggressive;
        }
        public override void OnStateExit()
        {
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
        }

        public override BaseMobileState OnStateUpdate()
        {
            if (PlayerBehaviour == null || MobileBehaviour)
            {
                if (PlayerBehaviour.Mobile.Health > 0 && IsAggressive && CheckChaseState())
                {
                    return ChaseState();
                }
            }
            return null;
        }

        public override float GetXAxis()
        {
            return 0f;
        }

        public override float GetYAxis()
        {
            return 0f;
        }

        internal override void OnStateFixedUpdate()
        {

        }

        public bool CheckChaseState()
        {
            float distance = Vector2.Distance(PlayerBehaviour.transform.position, MobileBehaviour.transform.position);
            return distance <= this.ChaseDistance;
        }

        public BaseMobileState ChaseState()
        {
            return new MobileChaseState(MobileBehaviour, PlayerBehaviour, ChaseDistance);
        }
    }
}