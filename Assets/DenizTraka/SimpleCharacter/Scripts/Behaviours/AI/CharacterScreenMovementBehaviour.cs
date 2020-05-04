using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Interfaces;
using UnityEngine;
namespace DTWorld.Behaviours.AI
{
    public class CharacterScreenMovementBehaviour : MonoBehaviour, IMovementInput
    {
        private Vector3 currentPosition;

        public Transform IdlePosition;
        private Vector2 currentMovement;
        private Vector2 deltaVector;
        public virtual void Start()
        {
            currentPosition = IdlePosition.transform.position;
            currentMovement = Vector2.zero;
        }

        public void Update()
        {
            deltaVector = transform.position - currentPosition;
        }

        public float GetXAxis()
        {
            if ((deltaVector.x >= 0 && deltaVector.x <= 0.05f) || (deltaVector.x <= 0 && deltaVector.x >= -0.05f))
            {
                return 0;
            }

            return transform.position.x < currentPosition.x ? 1 : -1;
        }

        public float GetYAxis()
        {
            return 0;
        }

        public void MoveTo(Transform transform)
        {
            currentPosition = transform.position;
        }
    }
}