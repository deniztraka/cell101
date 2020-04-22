using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Engines.AI.States
{

    public class MobileIdleState : BaseMobileState
    {
        float chaseDistance;
        public MobileIdleState(float chaseDistance)
        {
            this.chaseDistance = chaseDistance;
        }
        public override void OnStateExit()
        {
            Debug.Log("OnIdleStateExit");
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            Debug.Log("OnIdleStateEnter");
        }

        public override BaseMobileState OnStateUpdate()
        {
            if (PlayerBehaviour == null || MobileBehaviour)
            {
                float distance = Vector2.Distance(PlayerBehaviour.transform.position, MobileBehaviour.transform.position);
                if (distance <= this.chaseDistance)
                {
                    var mobileChaseState = new MobileChaseState(PlayerBehaviour);
                    mobileChaseState.SetMobile(MobileBehaviour);
                    return mobileChaseState;
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
    }
}