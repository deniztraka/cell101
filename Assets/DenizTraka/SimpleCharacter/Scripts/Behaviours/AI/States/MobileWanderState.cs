using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Behaviours.AI.States
{
    public class MobileWanderState : BaseMobileAIStateBehaviour
    {
        private float nextDecisionTime;
        public float MinDecisionDelay = 1f;
        public float MaxDecisionDelay = 5f;
        public float IdleChance = 0.5f;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            nextDecisionTime = 0;
            SetNewMovement();
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateUpdate(animator, stateInfo, layerIndex);

            var randomDecisionDelay = Random.Range(MinDecisionDelay, MaxDecisionDelay);
            if (Time.time > nextDecisionTime)
            {
                if (Random.value > IdleChance)
                {
                    animator.SetTrigger("Idle");
                }
                else
                {
                    SetNewMovement();
                }

                nextDecisionTime = Time.time + randomDecisionDelay;
            }
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            base.OnStateExit(animator, stateInfo, layerIndex);
        }

        private void SetNewMovement()
        {
            CurrentMovement = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
        }
    }
}