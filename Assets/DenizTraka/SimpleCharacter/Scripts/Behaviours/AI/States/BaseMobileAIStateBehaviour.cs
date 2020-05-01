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
        protected Vector2 DeltaVector;



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
            animator.SetFloat("ChaseDistance", MobileBehaviour.ChaseDistance);
            animator.SetFloat("AttackDistance", MobileBehaviour.WeaponBehaviour.AttackDistance);
            animator.SetFloat("FleeBelowHealth", MobileBehaviour.FleeBelowHealth);
            animator.SetFloat("FleeDistance", MobileBehaviour.FleeDistance);
            DeltaVector = MobileBehaviour.transform.position - PlayerBehaviour.transform.position;
        }

        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            CurrentDistanceFromPlayer = GetDistanceFrom(PlayerBehaviour.transform.position);
            animator.SetFloat("CurrentDistanceFromPlayer", CurrentDistanceFromPlayer);
            animator.SetBool("InChaseRange", CurrentDistanceFromPlayer <= MobileBehaviour.ChaseDistance);
            animator.SetBool("InFleeRange", CurrentDistanceFromPlayer < MobileBehaviour.FleeDistance);
            animator.SetBool("InAttackRange", CurrentDistanceFromPlayer <= MobileBehaviour.WeaponBehaviour.AttackDistance);
            animator.SetFloat("Health", MobileHealth.Health);
            animator.SetBool("IsHealthBelowFleeHealth", MobileHealth.Health < MobileBehaviour.FleeBelowHealth);
            AIBehaviour.SetMovement(CurrentMovement);
            DeltaVector = MobileBehaviour.transform.position - PlayerBehaviour.transform.position;            
        }

        public float GetDistanceFrom(Vector2 position)
        {
            return Vector2.Distance(position, MobileBehaviour.transform.position);
        }
    }
}