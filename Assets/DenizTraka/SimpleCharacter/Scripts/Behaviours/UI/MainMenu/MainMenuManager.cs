using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DTWorld.Behaviours.UI.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        // Start is called before the first frame update
        public void StartGame()
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }

        // Update is called once per frame
        public void QuitGame()
        {
            Application.Quit();
        }
    }
}