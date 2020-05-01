using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Behaviours.AI.States
{
    public class MobileIdleState : BaseMobileAIStateBehaviour
    {
        private float nextDecisionTime;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            nextDecisionTime = 0;
            MobileBehaviour.SetMovement(Vector2.zero);
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);
            
            var randomDecisionDelay = Random.Range(MinDecisionDelay, MaxDecisionDelay);
            if (Time.time > nextDecisionTime)
            {
                //Debug.Log("TimeToMakeDecision");
                //Time to make decision
                if (Random.value < WanderChance)
                {
                    animator.SetTrigger("Wander");
                }

                nextDecisionTime = Time.time + randomDecisionDelay;
            }            
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
        }

    }
}