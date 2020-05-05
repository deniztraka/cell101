using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DTWorld.Behaviours.UI.MainMenu
{
    public class WeaponSelectionCanvasBehaviour : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }
        public void Close(){
            gameObject.SetActive(false);
        }
    }
}
