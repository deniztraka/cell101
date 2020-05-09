using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DTWorld.Behaviours.UI.InGame
{
    public class LevelFinishedCanvasBehaviour : MonoBehaviour
    {
        public void QuitButtonClicked()
        {
            SceneManager.LoadScene("CharacterScene", LoadSceneMode.Single);
        }
    }
}