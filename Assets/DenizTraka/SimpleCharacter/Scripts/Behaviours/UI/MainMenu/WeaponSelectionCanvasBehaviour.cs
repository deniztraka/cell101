using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DTWorld.Behaviours.UI.MainMenu
{
    public class WeaponSelectionCanvasBehaviour : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        public void StartGame()
        {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }

        public void RangedSelected()
        {
            AppManager.Instance.IsRanged = true;
            StartGame();
        }

        public void MeleeSelected()
        {
            AppManager.Instance.IsRanged = false;
            StartGame();
        }
        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
