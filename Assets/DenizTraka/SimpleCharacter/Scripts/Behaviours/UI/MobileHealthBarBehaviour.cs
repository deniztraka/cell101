using DTWorld.Behaviours.Interfacelike;
using UnityEngine;
using UnityEngine.UI;

namespace DTWorld.Behaviours.UI
{
    public class MobileHealthBarBehaviour : MonoBehaviour
    {
        private HealthBehaviour mobileHealth;
        private Slider slider;
        private Image fill;
        public Gradient Gradient;
        // Start is called before the first frame update
        void Start()
        {
            mobileHealth = transform.GetComponentInParent<HealthBehaviour>();
            mobileHealth.OnDamageTakenEvent += new HealthBehaviour.OnDamageTakenEventHandler(OnDamageTakenEvent);
            slider = transform.Find("Slider").GetComponent<Slider>();
            fill = slider.transform.Find("Fill").GetComponent<Image>();
            Init();
        }

        private void Init()
        {
            slider.maxValue = mobileHealth.MaxHealth;
            slider.value = mobileHealth.Health;
            fill.color = Gradient.Evaluate(1f);
        }

        public void OnDamageTakenEvent(float damage, float currentHealth, float maxHealth)
        {
            slider.value = currentHealth;
            fill.color = Gradient.Evaluate(slider.normalizedValue);
            if (currentHealth <= 0)
            {
                Destroy(gameObject, 0.5f);
            }
        }
    }
}