using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTWorld.Behaviours.AI.States
{
    public class MobileChaseState : BaseMobileAIStateBehaviour
    {
        private Vector2 deltaVector;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            deltaVector = MobileBehaviour.transform.position - PlayerBehaviour.transform.position;
            MobileBehaviour.Speed = MobileBehaviour.Speed * 2f;
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);

            CheckIdleTransition(animator, stateInfo, layerIndex);

            ProcessState(animator, stateInfo, layerIndex);
        }

        private void ProcessState(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            deltaVector = MobileBehaviour.transform.position - PlayerBehaviour.transform.position;

            if (CurrentDistanceFromPlayer <= MobileBehaviour.WeaponBehaviour.AttackDistance)
            {
                CurrentMovement = Vector2.zero;
            }
            else
            {
                CurrentMovement = new Vector2(GetXAxis(), GetYAxis());
            }
        }

        private void CheckIdleTransition(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (CurrentDistanceFromPlayer > MobileBehaviour.ChaseDistance)
            {
                animator.SetTrigger("Idle");
            }
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            MobileBehaviour.Speed = MobileBehaviour.Speed / 2f;
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
    }
}