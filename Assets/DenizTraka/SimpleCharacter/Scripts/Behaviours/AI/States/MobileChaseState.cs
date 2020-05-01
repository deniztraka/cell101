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

            // if (MobileBehaviour.WeaponBehaviour != null && !MobileBehaviour.WeaponBehaviour.IsRanged)
            // {
            //     CurrentMovement = GetMeleeMovement();
            // }
            // else
            // {
            //     CurrentMovement = GetRangedMovement();
            // }

             CurrentMovement = GetMovement();
        }

        private Vector2 GetRangedMovement()
        {
            var movementVector = Vector2.zero;

            if (!((DeltaVector.x >= 0 && DeltaVector.x <= 0.01f) || (DeltaVector.x <= 0 && DeltaVector.x >= -0.01f)) && DeltaVector.x != 0)
            {
                // if y axis is closer than x axis
                if (Math.Abs(DeltaVector.x) <= Math.Abs(DeltaVector.y))
                {
                    if (PlayerBehaviour.transform.position.x <= MobileBehaviour.transform.position.x)
                    {
                        movementVector.x = -1;
                    }
                    else
                    {
                        movementVector.x = 1;
                    }
                }
            }

            if (!((DeltaVector.y >= 0 && DeltaVector.y <= 0.01f) || (DeltaVector.y <= 0 && DeltaVector.y >= -0.01f)) && DeltaVector.y != 0)
            {
                // if x axis is closer than y axis
                if (Math.Abs(DeltaVector.y) <= Math.Abs(DeltaVector.x))
                {
                    if (PlayerBehaviour.transform.position.y <= MobileBehaviour.transform.position.y)
                    {
                        movementVector.y = -1;
                    }
                    else
                    {
                        movementVector.y = 1;
                    }
                }
            }

            return movementVector;
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