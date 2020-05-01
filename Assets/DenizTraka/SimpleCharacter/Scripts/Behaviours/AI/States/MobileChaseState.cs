using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DTWorld.Behaviours.AI.States
{
    public class MobileChaseState : BaseMobileAIStateBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            MobileBehaviour.Speed = MobileBehaviour.Speed * 2f;
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);

            ProcessState(animator, stateInfo, layerIndex);
        }

        private void ProcessState(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CurrentMovement = new Vector2(GetXAxis(), GetYAxis());
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            MobileBehaviour.Speed = MobileBehaviour.Speed / 2f;
        }

        private float GetXAxis()
        {
            if ((DeltaVector.x >= 0 && DeltaVector.x <= 0.01f) || (DeltaVector.x <= 0 && DeltaVector.x >= -0.01f))
            {
                return 0;
            }

            if (DeltaVector.x == 0)
            {
                return 0;
            }

            return DeltaVector.x > 0 ? -1 : 1;
        }


        private float GetYAxis()
        {
            if ((DeltaVector.y >= 0 && DeltaVector.y <= 0.01f) || (DeltaVector.y <= 0 && DeltaVector.y >= -0.01f))
            {
                return 0;
            }

            if (DeltaVector.y == 0)
            {
                return 0;
            }

            return DeltaVector.y > 0 ? -1 : 1;
        }
    }
}