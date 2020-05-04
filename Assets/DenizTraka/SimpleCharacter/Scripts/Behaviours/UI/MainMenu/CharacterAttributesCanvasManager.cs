using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.AI;
using UnityEngine;
namespace DTWorld.Behaviours.UI.CharacterSelectionMenu
{
    public class CharacterAttributesCanvasManager : MonoBehaviour
    {

        public void CloseBook(){
            gameObject.SetActive(false);
        }
    }
}