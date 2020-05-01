using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Behaviours.AI.States
{
    public class MobileAttackState : BaseMobileAIStateBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);

            MobileBehaviour.Speed = MobileBehaviour.Speed * 2f;
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            if (MobileBehaviour.WeaponBehaviour != null && MobileBehaviour.WeaponBehaviour.IsRanged && PlayerBehaviour != null)
            {

                var isAlignedOnYAxis = Math.Abs(MobileBehaviour.transform.position.x - PlayerBehaviour.transform.position.x) < 0.1f;
                var isAlignedOnXAxis = Math.Abs(MobileBehaviour.transform.position.y - PlayerBehaviour.transform.position.y) < 0.1f;
                if (isAlignedOnYAxis || isAlignedOnXAxis)
                {
                    if (isAlignedOnXAxis)
                    {
                        if (MobileBehaviour.transform.position.x < PlayerBehaviour.transform.position.x)
                            MobileBehaviour.SetLastDirection(Vector2.right);
                        else
                        {
                            MobileBehaviour.SetLastDirection(Vector2.left);
                        }
                    }
                    else
                    {
                        if (MobileBehaviour.transform.position.y < PlayerBehaviour.transform.position.y)
                            MobileBehaviour.SetLastDirection(Vector2.up);
                        else
                        {
                            MobileBehaviour.SetLastDirection(Vector2.down);
                        }
                    }

                    MobileBehaviour.Attack();
                }
                else
                {
                    CurrentMovement = GetRangedMovement();
                }
            }
            else
            {
                MobileBehaviour.Attack();
            }

        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);

            MobileBehaviour.Speed = MobileBehaviour.Speed / 2f;
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
    }
}