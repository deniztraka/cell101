using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.AI;
using UnityEngine;
namespace DTWorld.Behaviours.UI.CharacterSelectionMenu
{
    public class CharacterBookBehaviour : MonoBehaviour
    {
        public Transform CharacterBookPosition;
        public GameObject ActiveLight;
        public GameObject OpenText;
        public GameObject CharacterBookCanvas;
        private CharacterScreenMovementBehaviour characterMovement;
        private bool isPlayerClose;
        //private MenuCharacterBehaviour characterBehaviour;       
        // Start is called before the first frame update
        void Start()
        {
            characterMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterScreenMovementBehaviour>();
            SetHasNews(true);
        }

        public void SetHasNews(bool hasNews){
            ActiveLight.SetActive(hasNews);
        }

        public void FixedUpdate(){
            isPlayerClose = Math.Abs(CharacterBookPosition.position.x - characterMovement.transform.position.x) < 0.1;
            
            if(isPlayerClose){
                OpenText.SetActive(true);
            } else {
                 OpenText.SetActive(false);
            }
        }

        void OnMouseDown()
        {            
            if (isPlayerClose)
            {
                OpenCharacterBookCanvas();
            }
            else
            {
                characterMovement.MoveTo(CharacterBookPosition);
            }
        }

        private void OpenCharacterBookCanvas(){
            CharacterBookCanvas.SetActive(true);
        }
    }
}