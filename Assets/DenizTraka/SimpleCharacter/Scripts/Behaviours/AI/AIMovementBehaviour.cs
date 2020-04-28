using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Mobiles;
using DTWorld.Interfaces;
using UnityEngine;

namespace DTWorld.Behaviours.AI
{
    public class AIMovementBehaviour : MonoBehaviour, IMovementInput
    {
        private Vector2 currentMovement;
        public virtual void Start(){
            currentMovement = Vector2.zero;
        }

        public float GetXAxis()
        {
            return currentMovement.x;
        }

        public float GetYAxis()
        {
            return currentMovement.y;
        }

        internal void SetMovement(Vector2 currentMovement)
        {
            //Debug.Log(currentMovement);
            this.currentMovement = currentMovement;
        }
    }
}