using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.AI;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DTWorld.Behaviours.UI.CharacterSelectionMenu
{
    public class HangYourselfCanvasBehaviour : MonoBehaviour
    {
        public HangRopeBehaviour HangRopeBehaviour;

        public void Kill()
        {            
            HangRopeBehaviour.ResetGame();
            this.gameObject.SetActive(false);
        }
        public void Later()
        {
            this.gameObject.SetActive(false);
            HangRopeBehaviour.SetIsOpen(false);
        }
    }
}