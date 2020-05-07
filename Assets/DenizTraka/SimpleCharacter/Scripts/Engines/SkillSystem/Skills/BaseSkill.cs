using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Interfaces;
using UnityEngine;
namespace DTWorld.Engines.SkillSystem.Skills
{
    [Serializable]
    public abstract class BaseSkill : ISkill
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private float currentVal;
        public float CurrentValue
        {
            get { return currentVal; }
            set { currentVal = value; }
        }

        private float gainFactor;
        public float GainFactor
        {
            get { return gainFactor; }
            set { gainFactor = value; }
        }

        public delegate void OnSkillChangedEventHandler(float gainVal);
        public event OnSkillChangedEventHandler OnSkillChangedEvent;

        public virtual void Gain(float val)
        {
            if (UnityEngine.Random.value < GainFactor)
            {
                currentVal += val;
                if (OnSkillChangedEvent != null)
                {
                    OnSkillChangedEvent(val);
                }
            }
        }
    }
}