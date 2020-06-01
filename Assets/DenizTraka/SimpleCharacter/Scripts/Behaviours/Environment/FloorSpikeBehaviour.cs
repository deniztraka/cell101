using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Interfacelike;
using UnityEngine;
namespace DTWorlds.Behaviours.Environment
{
    public class FloorSpikeBehaviour : MonoBehaviour
    {
        private bool isActive;
        private Animator animator;

        private float lastTriggeredTime;
        public float TriggerFrequency = 5f;
        public float TriggerChance = 0.1f;
        public float Damage = 10f;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Random.value < TriggerChance)
            {
                if (!isActive && Time.time > lastTriggeredTime + TriggerFrequency)
                {
                    StartCoroutine(Trigger());
                    lastTriggeredTime = Time.time;
                }
            }
        }

        IEnumerator Trigger()
        {
            animator.SetTrigger("Attack");
            isActive = true;
            yield return new WaitForSeconds(TriggerFrequency / 2);
            animator.SetTrigger("Return");
            isActive = false;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            //is owner currently attacking
            if (!isActive)
            {
                return;
            }

            //check if it has health behaviour?
            var otherEntityHealth = other.GetComponent<HealthBehaviour>();
            if (otherEntityHealth == null)
            {
                return;
            }

            if (otherEntityHealth.Health <= 0)
            {
                return;
            }

            otherEntityHealth.TakeDamage(Damage);
            isActive = false;

        }
    }
}
