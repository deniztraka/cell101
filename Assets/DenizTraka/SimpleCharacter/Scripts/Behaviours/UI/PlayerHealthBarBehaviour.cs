using System;
using DTWorld.Behaviours.Interfacelike;
using UnityEngine;
using UnityEngine.UI;

namespace DTWorld.Behaviours.UI
{
    public class PlayerHealthBarBehaviour : MonoBehaviour
    {
        private HealthBehaviour playerHealth;
        private Slider SliderLeft;
        private Image SliderFillLeft;
        private Slider SliderRight;
        private Image SliderFillRight;


        public Text HealthText;
        public Gradient Gradient;

        public Animator Animator;

        void Start()
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBehaviour>();
            playerHealth.OnDamageTakenEvent += new HealthBehaviour.OnDamageTakenEventHandler(OnDamageTakenEvent);
            SliderLeft = transform.Find("SliderLeft").GetComponent<Slider>();
            SliderFillLeft = SliderLeft.transform.Find("FillLeft").GetComponent<Image>();
            SliderRight = transform.Find("SliderRight").GetComponent<Slider>();
            SliderFillRight = SliderRight.transform.Find("FillRight").GetComponent<Image>();
            Init();
        }

        public void OnDamageTakenEvent(float damage, float currentHealth, float maxHealth)
        {
            UpdateSliders(currentHealth);
            if (HealthText != null)
            {
                HealthText.text = currentHealth <= 0 ? "0" : String.Format("{0:0.0}", currentHealth);
            }

            if (Animator != null)
            {
                Animator.Play("Hearth");
            }
        }

        private void Init()
        {
            SliderLeft.maxValue = playerHealth.MaxHealth;
            SliderLeft.value = playerHealth.Health;
            SliderFillLeft.color = Gradient.Evaluate(1f);

            SliderRight.maxValue = playerHealth.MaxHealth;
            SliderRight.value = playerHealth.Health;
            SliderFillRight.color = Gradient.Evaluate(1f);
            HealthText.text = playerHealth.Health <= 0 ? "0" : String.Format("{0:0.0}", playerHealth.Health);
        }

        private void UpdateSliders(float val)
        {
            SliderLeft.value = val;
            SliderFillLeft.color = Gradient.Evaluate(SliderRight.normalizedValue);
            SliderRight.value = val;
            SliderFillRight.color = Gradient.Evaluate(SliderRight.normalizedValue);
        }
    }
}