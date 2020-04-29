using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Behaviours.AI.States
{
    public class MobileRangedFleeState : BaseMobileAIStateBehaviour
    {
        private float rangedChaseDistance = 0;
        private Vector2 deltaVector;
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            MobileBehaviour.Speed = MobileBehaviour.Speed * 2f;
            rangedChaseDistance = MobileBehaviour.WeaponBehaviour.AttackDistance + MobileBehaviour.ChaseDistance;
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            // CurrentDistanceFromPlayer = GetDistanceFrom(PlayerBehaviour.transform.position);
            // AIBehaviour.SetMovement(CurrentMovement);
            // animator.SetFloat("Health", MobileHealth.Health);
            // CurrentMovement = new Vector2(GetXAxis(), GetYAxis());

            // CheckIdleTransition(animator, stateInfo, layerIndex);

            // ProcessState(animator, stateInfo, layerIndex);

        }

        private void ProcessState(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            deltaVector = MobileBehaviour.transform.position - PlayerBehaviour.transform.position;

            CurrentMovement = new Vector2(GetXAxis() * -1, GetYAxis() * -1);

        }

        private void CheckIdleTransition(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (CurrentDistanceFromPlayer > rangedChaseDistance)
            {
                animator.SetTrigger("Idle");
            }
        }

        private float GetXAxis()
        {
            if ((deltaVector.x >= 0 && deltaVector.x <= 0.01f) || (deltaVector.x <= 0 && deltaVector.x >= -0.01f))
            {
                return 0;
            }

            if (deltaVector.x == 0)
            {
                return 0;
            }

            return deltaVector.x > 0 ? -1 : 1;
        }


        private float GetYAxis()
        {
            if ((deltaVector.y >= 0 && deltaVector.y <= 0.01f) || (deltaVector.y <= 0 && deltaVector.y >= -0.01f))
            {
                return 0;
            }

            if (deltaVector.y == 0)
            {
                return 0;
            }

            return deltaVector.y > 0 ? -1 : 1;
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            MobileBehaviour.Speed = MobileBehaviour.Speed / 2f;
        }
    }
}