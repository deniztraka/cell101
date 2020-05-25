using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Items.Weapons;
using DTWorld.Behaviours.Mobiles;
using DTWorld.Interfaces;
using UnityEngine;
using UnityEngine.UIElements;

namespace DTWorld.Engines.SkillSystem.Abillities
{
    public abstract class BaseAbillity : ScriptableObject, IAbillity
    {
        public bool IsActive;
        public string Name;
        public string Description;
        public Image Icon;

        public GameObject ParticleEffect;

        private GameObject instantiatedParticleEffect;

        public float Duration;

        public List<BaseAbillityEffect> Effects;

        public void Disable(BaseMobileBehaviour mobileBehaviour)
        {
            IsActive = false;


            List<Component> effects = new List<Component>();

            mobileBehaviour.gameObject.GetComponents(typeof(BaseAbillityEffect), effects);

            foreach (BaseAbillityEffect effect in effects)
            {
                effect.OnBeforeDestroy();
                Destroy(effect);
            }

            if (instantiatedParticleEffect != null)
            {
                Destroy(instantiatedParticleEffect);
            }
            //Debug.Log("finished " + Name);
        }

        public virtual void Init(BaseAbillity abillity)
        {
            Name = abillity.name;
            Description = abillity.Description;
            Icon = abillity.Icon;
            IsActive = false;
            Effects = abillity.Effects;
            Duration = abillity.Duration;
            ParticleEffect = abillity.ParticleEffect;
        }

        public BaseAbillity Use(BaseMobileBehaviour mobileBehaviour)
        {
            if (!IsActive)
            {
                IsActive = true;
                //Debug.Log("active " + Name);

                foreach (var effect in Effects)
                {
                    mobileBehaviour.gameObject.AddComponent(effect.GetType());
                }

                if (ParticleEffect != null)
                {
                    instantiatedParticleEffect = Instantiate(ParticleEffect, Vector3.zero, Quaternion.identity);
                    instantiatedParticleEffect.transform.SetParent(mobileBehaviour.WeaponBehaviour.transform);
                    instantiatedParticleEffect.transform.position = Vector3.zero;
                    instantiatedParticleEffect.transform.localPosition = Vector3.zero;
                }
                return this;
            }

            return null;
        }
    }
}