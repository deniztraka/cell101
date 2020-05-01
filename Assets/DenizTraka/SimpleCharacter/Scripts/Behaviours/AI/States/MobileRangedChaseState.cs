// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// namespace DTWorld.Behaviours.AI.States
// {
//     public class MobileRangedChaseState : BaseMobileAIStateBehaviour
//     {

//         override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//         {
//             base.OnStateEnter(animator, stateInfo, layerIndex);
//             MobileBehaviour.Speed = MobileBehaviour.Speed * 2f;
//         }

//         override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//         {
//             base.OnStateUpdate(animator, stateInfo, layerIndex);

//             //CheckIdleTransition(animator, stateInfo, layerIndex);

//             ProcessState(animator, stateInfo, layerIndex);
//         }

//         private void ProcessState(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//         {
//             //Debug.Log(Math.Abs(DeltaVector.x) + "-" + Math.Abs(DeltaVector.y));
//             // if (CurrentDistanceFromPlayer <= MobileBehaviour.WeaponBehaviour.AttackDistance)
//             // {
//             //     animator.SetTrigger("Attack");
//             // }
//             // else
//             // {
            
//             //}

//             CurrentMovement = new Vector2(GetXAxis(), GetYAxis());
//             if(CurrentMovement == Vector2.zero){
//                 animator.SetTrigger("Attack");
//             }
//         }

//         private void CheckIdleTransition(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//         {
//             if (CurrentDistanceFromPlayer > ChaseDistance)
//             {
//                 animator.SetTrigger("Idle");
//             }
//         }

//         override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
//         {
//             MobileBehaviour.Speed = MobileBehaviour.Speed / 2f;
//         }

//         private float GetXAxis()
//         {
            

//             if (DeltaVector.x == 0 || (DeltaVector.x >= 0 && DeltaVector.x <= 0.01f) || (DeltaVector.x <= 0 && DeltaVector.x >= -0.01f))
//             {
//                 return 0;
//             }

//             if (Math.Abs(DeltaVector.x) <= Math.Abs(DeltaVector.y))
//             {
//                 if (PlayerBehaviour.transform.position.x < MobileBehaviour.transform.position.x)
//                 {
//                     return -1;
//                 }
//                 else
//                 {
//                     return 1;
//                 }
//             }

//             return 0;

//             //return MobileBehaviour.transform.position.x < PlayerBehaviour.transform.position.x ? 1 : -1;

//         }

//         private float GetYAxis()
//         {
//             if (DeltaVector.y == 0 || (DeltaVector.y >= 0 && DeltaVector.y <= 0.01f) || (DeltaVector.y <= 0 && DeltaVector.y >= -0.01f))
//             {
//                 return 0;
//             }

//             if (Math.Abs(DeltaVector.y) <= Math.Abs(DeltaVector.x))
//             {
//                 if (PlayerBehaviour.transform.position.y < MobileBehaviour.transform.position.y)
//                 {
//                     return -1;
//                 }
//                 else
//                 {
//                     return 1;
//                 }
//             }

//             return 0;
//             //return MobileBehaviour.transform.position.y < PlayerBehaviour.transform.position.y ? 1 : -1;
//         }
//     }
// }