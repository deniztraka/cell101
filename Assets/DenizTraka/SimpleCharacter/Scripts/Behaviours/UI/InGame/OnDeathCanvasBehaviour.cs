using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DTWorld.Behaviours.UI.InGame
{
    public class OnDeathCanvasBehaviour : MonoBehaviour
    {
        public void OnTryAgainButtonClicked()
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }

        public void QuitButtonClicked()
        {
            SceneManager.LoadScene("CharacterScene", LoadSceneMode.Single);
        }
    }
}