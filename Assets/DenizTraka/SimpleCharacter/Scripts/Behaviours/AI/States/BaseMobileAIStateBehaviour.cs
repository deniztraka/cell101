using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using DTWorld.Interfaces;
using UnityEngine;

namespace DTWorld.Behaviours.AI.States
{
    public abstract class BaseMobileAIStateBehaviour : StateMachineBehaviour
    {
        protected BaseMobileBehaviour MobileBehaviour;
        protected PlayerBehaviour PlayerBehaviour;
        protected AIMovementBehaviour AIBehaviour;
        protected Vector2 CurrentMovement;        
        protected float CurrentDistanceFromPlayer = 0f;

        public float MinDecisionDelay = 1f;
        public float MaxDecisionDelay = 5f;
        public float WanderChance = 0.5f;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            AIBehaviour = animator.GetComponent<AIMovementBehaviour>();
            MobileBehaviour = animator.GetComponent<BaseMobileBehaviour>();
            PlayerBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CurrentDistanceFromPlayer = GetDistanceFrom(PlayerBehaviour.transform.position);
            AIBehaviour.SetMovement(CurrentMovement);

            //Debug.Log("ChaseDistance:" + MobileBehaviour.ChaseDistance + " DistanceFromPlayer:" + CurrentDistanceFromPlayer);
            //Check chasing if mobile is aggressive
            if (!stateInfo.IsName("Chase") && MobileBehaviour.IsAggressive && CurrentDistanceFromPlayer <= MobileBehaviour.ChaseDistance)
            {
                animator.SetTrigger("Chase");
            }
        }

        public float GetDistanceFrom(Vector2 position)
        {
            return Vector2.Distance(position, MobileBehaviour.transform.position);
        }
    }
}