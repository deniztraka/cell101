using System;
using System.Collections;
using DTWorld.Behaviours.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace DTWorld.Behaviours.UI.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        public GameObject Door;
        private AudioManager audioManager;
        public void Start()
        {
            audioManager = GetComponent<AudioManager>();
            Door.SetActive(false);

            if (audioManager != null)
            {
                audioManager.Play("Menu");
            }

            StartCoroutine(ExecuteAfterSeconds(Random.Range(2, 5), () =>
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
            if (audioManager != null)
            {
                audioManager.Play("GetReady");
            }
            Door.SetActive(true);
        }

    }
}