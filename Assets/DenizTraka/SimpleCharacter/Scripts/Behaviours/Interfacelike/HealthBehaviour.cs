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

        public delegate void OnDamageTakenEventHandler(float damage);
        public delegate void OnHealthBelowZeroEventHandler();
        public event OnDamageTakenEventHandler OnDamageTakenEvent;
        public event OnHealthBelowZeroEventHandler OnHealthBelowZeroEvent;

        // Start is called before the first frame update
        void Start()
        {
        }

        public void TakeDamage(float damage)
        {
            if (OnDamageTakenEvent != null)
            {
                OnDamageTakenEvent.Invoke(damage);
            }

            Health -= damage;
            
            if (Health <= 0 && OnHealthBelowZeroEvent != null)
            {
                OnHealthBelowZeroEvent.Invoke();
            }
        }
    }
}