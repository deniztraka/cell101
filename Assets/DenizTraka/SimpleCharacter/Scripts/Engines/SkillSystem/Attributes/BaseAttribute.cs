using System.Collections;
using System.Collections.Generic;
using DTWorld.Interfaces;
using UnityEngine;
namespace DTWorld.Engines.SkillSystem.Attributes
{
    public abstract class BaseAttribute : IAttribute
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int currentVal;
        public int CurrentValue
        {
            get { return currentVal; }
            set { currentVal = value; }
        }
        public delegate void OnAttributeChangedEventHandler();
        public event OnAttributeChangedEventHandler OnAttributeChangedEvent;

        public virtual void Gain(int val)
        {
            currentVal += val;
            if (OnAttributeChangedEvent != null)
            {
                OnAttributeChangedEvent();
            }
        }
    }
}