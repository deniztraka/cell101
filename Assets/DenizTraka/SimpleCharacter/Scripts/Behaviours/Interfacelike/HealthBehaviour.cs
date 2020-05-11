using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Behaviours.Interfacelike
{

    public class HealthBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float health;

        private BaseMobileBehaviour mobileBehaviour;
        public float Health
        {
            get { return health; }
            set
            {
                health = value;
            }
        }

        private PropsBehaviour props;

        public float MaxHealth;

        public GameObject FloatingDamagesPrefab;

        public delegate void OnDamageTakenEventHandler(float damage, float health, float maxHealth);
        public delegate void OnHealthBelowZeroEventHandler(BaseMobileBehaviour mobile);
        public event OnDamageTakenEventHandler OnDamageTakenEvent;
        public event OnHealthBelowZeroEventHandler OnHealthBelowZeroEvent;

        // Start is called before the first frame update
        void Start()
        {
            mobileBehaviour = gameObject.GetComponent<BaseMobileBehaviour>();
            props = gameObject.GetComponent<PropsBehaviour>();
            MaxHealth = props.Strength.CurrentValue == 0 ? 7.5f : props.Strength.CurrentValue * 10;
            Health = MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            if(Health <= 0){
                return;
            }
            
            if (mobileBehaviour.ShieldBehaviour != null && mobileBehaviour.Mobile.IsDefending)
            {
                if (mobileBehaviour.ShieldBehaviour.TryParry(damage))
                {
                    return;
                }
            }

            Health -= damage;

            if (OnDamageTakenEvent != null)
            {
                OnDamageTakenEvent.Invoke(damage, Health, MaxHealth);
            }

            if (FloatingDamagesPrefab != null)
            {
                PopUpFloatingDamages(damage);
            }

            if (Health <= 0 && OnHealthBelowZeroEvent != null)
            {
                OnHealthBelowZeroEvent.Invoke(mobileBehaviour);
            }
        }

        private void PopUpFloatingDamages(float damage)
        {
            var floatingDamage = Instantiate(FloatingDamagesPrefab, transform.position, Quaternion.identity, transform);
            var textMesh = floatingDamage.GetComponent<TextMesh>();
            textMesh.text =  String.Format("{0:0.0}", damage);
        }
    }
}