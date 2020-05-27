using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DTWorld.Behaviours.UI.MainMenu
{
    public class GameFinishedCanvas : MonoBehaviour
    {
        public void Quit(){
            SceneManager.LoadScene("CreditsScene", LoadSceneMode.Single);
        }
    }
}
