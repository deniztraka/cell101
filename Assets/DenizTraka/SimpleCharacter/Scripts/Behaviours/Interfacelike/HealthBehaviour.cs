﻿using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using DTWorlds.Behaviours.Environment;
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

        public float MaxHealth;

        public GameObject FloatingDamagesPrefab;

        public delegate void OnDamageTakenEventHandler(float damage, float health, float maxHealth);
        public delegate void OnHealthBelowZeroEventHandler(BaseMobileBehaviour mobile);
        public event OnDamageTakenEventHandler OnDamageTakenEvent;
        public event OnHealthBelowZeroEventHandler OnHealthBelowZeroEvent;

        void Awake()
        {

        }

        // Start is called before the first frame update
        void Start()
        {
            mobileBehaviour = gameObject.GetComponent<BaseMobileBehaviour>();
            
        }

        IEnumerator CreateBloodStainsAfterSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            BloodStainsPool.Instance.Create(transform.position);
        }

        public void TakeDamage(float damage)
        {
            if (Health <= 0)
            {
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
            if (UnityEngine.Random.value > 0.5)
            {
                StartCoroutine(CreateBloodStainsAfterSeconds(0.5f));
            }

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
            textMesh.text = String.Format("{0:0.0}", damage);
            
        }
    }
}