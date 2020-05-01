using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Interfacelike;
using DTWorld.Behaviours.Mobiles;
using DTWorld.Interfaces;
using UnityEngine;

namespace DTWorld.Behaviours.AI.States
{
    public abstract class BaseMobileAIStateBehaviour : StateMachineBehaviour
    {
        protected BaseMobileBehaviour MobileBehaviour;
        protected HealthBehaviour MobileHealth;
        protected PlayerBehaviour PlayerBehaviour;
        protected AIMovementBehaviour AIBehaviour;
        protected Vector2 CurrentMovement;
        protected float CurrentDistanceFromPlayer = 0f;
        protected float ChaseDistance;
        protected Vector2 DeltaVector;

        public float MinDecisionDelay = 1f;
        public float MaxDecisionDelay = 5f;
        public float WanderChance = 0.5f;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            AIBehaviour = animator.GetComponent<AIMovementBehaviour>();
            MobileBehaviour = animator.GetComponent<BaseMobileBehaviour>();
            MobileHealth = animator.GetComponent<HealthBehaviour>();
            var playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                PlayerBehaviour = playerObj.GetComponent<PlayerBehaviour>();
            }
            animator.SetBool("IsRanged", MobileBehaviour.WeaponBehaviour.IsRanged);
            animator.SetFloat("Health", MobileHealth.Health);
            ChaseDistance = MobileBehaviour.WeaponBehaviour.IsRanged ? MobileBehaviour.WeaponBehaviour.AttackDistance + MobileBehaviour.ChaseDistance / 2 : MobileBehaviour.ChaseDistance;
            DeltaVector = MobileBehaviour.transform.position - PlayerBehaviour.transform.position;
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CurrentDistanceFromPlayer = GetDistanceFrom(PlayerBehaviour.transform.position);
            animator.SetFloat("Health", MobileHealth.Health);
            AIBehaviour.SetMovement(CurrentMovement);
            DeltaVector = MobileBehaviour.transform.position - PlayerBehaviour.transform.position;

            //Debug.Log(CurrentDistanceFromPlayer);

            if (MobileBehaviour.IsAggressive &&
            CurrentDistanceFromPlayer <= MobileBehaviour.WeaponBehaviour.AttackDistance
            && MobileHealth.Health >= MobileBehaviour.FleeBelowHealth)
            {


                if (!stateInfo.IsName("Attack"))
                {
                    animator.SetTrigger("Attack");
                }

            }
            else if (MobileBehaviour.IsAggressive && CurrentDistanceFromPlayer <= ChaseDistance)
            {
                if (!(stateInfo.IsName("Chase") || stateInfo.IsName("RangedChase")) && MobileHealth.Health >= MobileBehaviour.FleeBelowHealth)
                {
                    animator.SetTrigger("Chase");
                }
                else if (!stateInfo.IsName("Flee") && MobileHealth.Health < MobileBehaviour.FleeBelowHealth)
                {
                    animator.SetTrigger("Flee");
                }
            }
        }

        public float GetDistanceFrom(Vector2 position)
        {
            return Vector2.Distance(position, MobileBehaviour.transform.position);
        }
    }
}