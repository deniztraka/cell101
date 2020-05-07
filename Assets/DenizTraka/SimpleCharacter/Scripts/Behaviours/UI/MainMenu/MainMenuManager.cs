using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace DTWorld.Behaviours.UI.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        public GameObject Door;
        public void Start()
        {
            Door.SetActive(false);

            StartCoroutine(ExecuteAfterSeconds(Random.Range(2,5), () =>
             {
                 OpenDoor();
             }));

        }

        IEnumerator ExecuteAfterSeconds(float seconds, Action task)
        {
            yield return new WaitForSeconds(seconds);
            task();
        }

        public void OpenDoor()
        {
            Door.SetActive(true);
        }

    }
}