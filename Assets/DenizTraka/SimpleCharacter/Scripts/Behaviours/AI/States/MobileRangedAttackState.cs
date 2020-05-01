using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Behaviours.AI.States
{
    public class MobileRangedAttackState : BaseMobileAIStateBehaviour
    {
        private Vector2 deltaVector;
        private float rangedChaseDistance = 0;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            deltaVector = MobileBehaviour.transform.position - PlayerBehaviour.transform.position;
            rangedChaseDistance = MobileBehaviour.WeaponBehaviour.AttackDistance + MobileBehaviour.ChaseDistance;
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            //base.OnStateUpdate(animator, stateInfo, layerIndex);

            CheckIdleTransition(animator, stateInfo, layerIndex);

            ProcessState(animator, stateInfo, layerIndex);
        }

        private void ProcessState(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            deltaVector = MobileBehaviour.transform.position - PlayerBehaviour.transform.position;
            CurrentDistanceFromPlayer = GetDistanceFrom(PlayerBehaviour.transform.position);
            animator.SetFloat("Health", MobileHealth.Health);

            // if (CurrentDistanceFromPlayer <= rangedChaseDistance && CurrentDistanceFromPlayer > rangedChaseDistance / 2 && MobileHealth.Health >= MobileBehaviour.FleeBelowHealth)
            // {
            //     animator.SetTrigger("Chase");
            // }
            // else
            // if (CurrentDistanceFromPlayer <= rangedChaseDistance / 4 || MobileHealth.Health < MobileBehaviour.FleeBelowHealth)
            // {
            //     animator.SetTrigger("Flee");
            // }

            MobileBehaviour.Attack();
        }

        private void CheckIdleTransition(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (CurrentDistanceFromPlayer > rangedChaseDistance)
            {
                animator.SetTrigger("Idle");
            }
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }

        // private float GetXAxis()
        // {
        //     if (deltaVector.x == 0 || (deltaVector.x >= 0 && deltaVector.x <= 0.01f) || (deltaVector.x <= 0 && deltaVector.x >= -0.01f))
        //     {
        //         return 0;
        //     }

        //     return 0;
        // }


        // private float GetYAxis()
        // {
        //     if (deltaVector.y == 0 || (deltaVector.y >= 0 && deltaVector.y <= 0.01f) || (deltaVector.y <= 0 && deltaVector.y >= -0.01f))
        //     {
        //         return 0;
        //     }

        //     return 0;
        // }
    }
}