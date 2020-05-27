using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Engines.SkillSystem.Abillities;
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

        protected List<BaseAbillity> Abillities;

        public BaseSkill()
        {
            Abillities = new List<BaseAbillity>();
            PrepeareAbillities();
        }

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

        public abstract void PrepeareAbillities();

        internal BaseAbillity GetSelectedAbillity()
        {
            //Todo get it from player prefs
            return Abillities[0];
        }
    }
}