using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.AI;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;

public class HangRopeBehaviour : MonoBehaviour, IPointerClickHandler
{
    public GameObject Canvas;
    public Transform Position;
    public Animator Animator;

    private CharacterScreenMovementBehaviour characterMovement;
    private bool isPlayerClose;
    private bool isOpen;
    private bool willOpen;
    private bool isClosedExternally;

    void Start()
    {
        characterMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterScreenMovementBehaviour>();
    }

    internal void SetIsOpen(bool v)
    {
        isOpen = v;
        isClosedExternally = !v;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (isPlayerClose && !isOpen)
        {
            Canvas.SetActive(true);
            willOpen = false;
        }
        else
        {
            willOpen = true;
            characterMovement.MoveTo(Position);
            isClosedExternally = false;
        }
    }

    public void ResetGame()
    {
        PlayerPrefs.SetInt("Strength", 0);
        PlayerPrefs.SetInt("Dexterity", 0);
        PlayerPrefs.SetInt("TotalAvaliableAttributePoints", 0);
        PlayerPrefs.SetInt("CurrentLevel", 0);
        PlayerPrefs.SetInt("TotalExperienceGained", 0);
        PlayerPrefs.SetFloat("Melee", 0);
        PlayerPrefs.SetFloat("Ranged", 0);
        PlayerPrefs.SetInt("CurrentFightIndex", 0);

        Animator.Play("HangLights");
        StartCoroutine(ExecuteAfterTime(3, () =>
         {
             SceneManager.LoadScene("CharacterScene", LoadSceneMode.Single);
         }));
    }

    private IEnumerator ExecuteAfterTime(float time, Action task)
    {
        yield return new WaitForSeconds(time);

        if (task != null)
        {
            task();
        }
    }

    public void FixedUpdate()
    {
        isPlayerClose = Math.Abs(Position.position.x - characterMovement.transform.position.x) < 0.1;

        if (isPlayerClose && !isOpen && !isClosedExternally && willOpen)
        {
            Canvas.SetActive(true);
            isOpen = true;
            willOpen = false;
        }
        else if (!isPlayerClose && isOpen)
        {
            Canvas.SetActive(false);
        }
    }
}
