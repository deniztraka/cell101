using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using DTWorld.Core.Mobiles;
using DTWorld.Engines.AI.States;
using DTWorld.Engines.Movement;
using UnityEngine;

namespace DTWorld.Engines.AI
{
    public class MobileAI
    {
        protected BaseMobileBehaviour MobileBehaviour;
        private BaseMobileState currentState;
        public BaseMobileState CurrentState
        {
            get { return currentState; }
            set
            {
                if (value == null)
                {
                    return;
                }
                if (currentState == value)
                {
                    return;
                }
                if (currentState != null)
                {
                    currentState.OnStateExit();
                }
                value.OnStateEnter();
                currentState = value;


            }
        }
        public MobileAI(BaseMobileState baseMobileState)
        {
            CurrentState = baseMobileState;
        }

        public void SetMobile(BaseMobileBehaviour mobile)
        {
            this.MobileBehaviour = mobile;
            this.CurrentState.SetMobile(mobile);
        }

        public void Update()
        {
            CurrentState = CurrentState.OnStateUpdate();
        }

        public void FixedUpdate()
        {
            CurrentState.OnStateFixedUpdate();
        }

        internal virtual float GetXAxis()
        {
            return CurrentState.GetXAxis();
        }

        internal virtual float GetYAxis()
        {
            return CurrentState.GetYAxis();
        }
    }
}
