using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Interfacelike;
using DTWorld.Core.Items;
using UnityEngine;
using static DTWorld.Behaviours.Interfacelike.HealthBehaviour;

namespace DTWorld.Behaviours.Items.Damagables
{
    [RequireComponent(typeof(HealthBehaviour))]
    public abstract class DamagableItemBehaviour : BaseItemBehaviour
    {
        protected new BaseDamagableItem Item;
        private HealthBehaviour healthBehaviour;

        public override void Awake()
        {
            base.Awake();
        }
        public override void Start()
        {
            base.Start();

            var healthBehaviour = gameObject.GetComponent<HealthBehaviour>();
            healthBehaviour.OnDamageTakenEvent += new OnDamageTakenEventHandler(OnDamageTaken);
            Item.SetHealth(healthBehaviour.Health);
        }

        private void OnDamageTaken(float damage)
        {
            Item.TakeDamage(damage);
        }
    }
}