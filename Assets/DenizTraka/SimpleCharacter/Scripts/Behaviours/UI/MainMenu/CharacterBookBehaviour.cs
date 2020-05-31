using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.AI;
using DTWorld.Behaviours.Interfacelike;
using DTWorld.Behaviours.Mobiles;
using DTWorld.Behaviours.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
namespace DTWorld.Behaviours.UI.CharacterSelectionMenu
{
    public class CharacterBookBehaviour : MonoBehaviour, IPointerClickHandler
    {
        public Transform CharacterBookPosition;
        public GameObject ActiveLight;
        public GameObject ExclamationMark;

        private bool isClosedExternally;

        internal void SetIsOpen(bool v)
        {
            bookIsOpen = v;
            isClosedExternally = !v;
        }

        public GameObject CharacterBookCanvas;
        private CharacterScreenMovementBehaviour characterMovement;
        private bool isPlayerClose;

        private bool bookIsOpen;
        void Start()
        {
            characterMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterScreenMovementBehaviour>();

            SetHasNews(AppManager.Instance.HasLeveledUp);
        }

        public void SetHasNews(bool hasNews)
        {
            ActiveLight.SetActive(hasNews);
            ExclamationMark.SetActive(hasNews);
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

            SetHasNews(AppManager.Instance.HasLeveledUp);
        }

        public void OnPointerClick(PointerEventData pointerEventData)
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