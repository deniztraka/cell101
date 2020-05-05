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

        private bool isClosedExternally;

        internal void SetIsOpen(bool v)
        {
            bookIsOpen = v;
            isClosedExternally = !v ;
        }

        public GameObject CharacterBookCanvas;
        private CharacterScreenMovementBehaviour characterMovement;
        private bool isPlayerClose;

        private bool bookIsOpen;
        void Start()
        {
            characterMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterScreenMovementBehaviour>();
            SetHasNews(true);
        }

        public void SetHasNews(bool hasNews)
        {
            ActiveLight.SetActive(hasNews);
        }

        public void FixedUpdate()
        {
            isPlayerClose = Math.Abs(CharacterBookPosition.position.x - characterMovement.transform.position.x) < 0.1;

            if (isPlayerClose && !bookIsOpen && !isClosedExternally)
            {
                CharacterBookCanvasStatus(true);

            }
            else if (!isPlayerClose && bookIsOpen)
            {
                CharacterBookCanvasStatus(false);
            }
        }

        void OnMouseDown()
        {
            if (isPlayerClose && !bookIsOpen)
            {
                CharacterBookCanvasStatus(true);
            }
            else
            {
                characterMovement.MoveTo(CharacterBookPosition);
                isClosedExternally = false;
            }
        }
        private void CharacterBookCanvasStatus(bool val)
        {
            CharacterBookCanvas.SetActive(val);
            bookIsOpen = val;
        }
    }
}