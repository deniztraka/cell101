using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Behaviours.Interfacelike
{

    public class HealthBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float health;
        public float Health
        {
            get { return health; }
            set
            {
                health = value;
            }
        }

        public float MaxHealth;

        public delegate void OnDamageTakenEventHandler(float damage, float health, float maxHealth);
        public delegate void OnHealthBelowZeroEventHandler();
        public event OnDamageTakenEventHandler OnDamageTakenEvent;
        public event OnHealthBelowZeroEventHandler OnHealthBelowZeroEvent;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;

            if (OnDamageTakenEvent != null)
            {
                OnDamageTakenEvent.Invoke(damage, Health, MaxHealth);
            }

            if (Health <= 0 && OnHealthBelowZeroEvent != null)
            {
                OnHealthBelowZeroEvent.Invoke();
            }
        }
    }
}