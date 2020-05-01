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

             CurrentMovement = GetMovement();
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
            MobileBehaviour.Speed = MobileBehaviour.Speed / 2f;
        }

        private Vector2 GetMeleeMovement()
        {
            var movementVector = Vector2.zero;
            if (!((DeltaVector.x >= 0 && DeltaVector.x <= 0.01f) || (DeltaVector.x <= 0 && DeltaVector.x >= -0.01f)) && DeltaVector.x != 0)
            {
                movementVector.x = DeltaVector.x > 0 ? -1 : 1;
            }

            if (!((DeltaVector.y >= 0 && DeltaVector.y <= 0.01f) || (DeltaVector.y <= 0 && DeltaVector.y >= -0.01f)) && DeltaVector.y != 0)
            {
                movementVector.y = DeltaVector.y > 0 ? -1 : 1;
            }

            return movementVector;
        }

        private Vector2 GetMovement()
        {
            var movementVector = Vector2.zero;
            if (!((DeltaVector.x >= 0 && DeltaVector.x <= 0.01f) || (DeltaVector.x <= 0 && DeltaVector.x >= -0.01f)) && DeltaVector.x != 0)
            {
                movementVector.x = DeltaVector.x > 0 ? -1 : 1;
            }

            if (!((DeltaVector.y >= 0 && DeltaVector.y <= 0.01f) || (DeltaVector.y <= 0 && DeltaVector.y >= -0.01f)) && DeltaVector.y != 0)
            {
                movementVector.y = DeltaVector.y > 0 ? -1 : 1;
            }

            return movementVector;
        }
    }
}