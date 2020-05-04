using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.AI;
using UnityEngine;
namespace DTWorld.Behaviours.UI.CharacterSelectionMenu
{
    public class MealBehaviour : MonoBehaviour
    {
        public Transform MealPosition;
        private CharacterScreenMovementBehaviour characterMovement;
        // Start is called before the first frame update
        void Start()
        {
            characterMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterScreenMovementBehaviour>();
        }

        void OnMouseDown()
        {            
            characterMovement.MoveTo(MealPosition);
        }

    }
}