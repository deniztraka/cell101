using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
namespace DTWorld.Engines.AI.States
{
    public abstract class BaseMobileState : IMobileState
    {
        protected BaseMobileBehaviour MobileBehaviour;
        protected PlayerBehaviour PlayerBehaviour;

        public virtual void OnStateEnter()
        {
            PlayerBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        }

        public abstract void OnStateExit();

        public abstract BaseMobileState OnStateUpdate();

        public abstract float GetXAxis();

        public abstract float GetYAxis();

        public void SetMobile(BaseMobileBehaviour mobileBehaviour)
        {
            this.MobileBehaviour = mobileBehaviour;
        }

        internal abstract void OnStateFixedUpdate();
    }
}