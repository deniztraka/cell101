using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.AI;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.EventSystems;

public class DoorBehaviour : MonoBehaviour
{
    public Transform DoorPosition;
    public GameObject WeaponSelectionCanvas;
    public GameObject GameFinishedCanvas;
    private bool isOpen;
    private CharacterScreenMovementBehaviour characterMovement;
    private bool isPlayerClose;
    private bool bookIsOpen;

    public Text SpeechText;

    private bool isClosedExternally;

    private bool isFinished;

    internal void SetIsOpen(bool v)
    {
        bookIsOpen = v;
        isClosedExternally = !v;
    }
    //private MenuCharacterBehaviour characterBehaviour;       
    // Start is called before the first frame update
    void Start()
    {
        characterMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterScreenMovementBehaviour>();
        SetOpenStatus(false);
        var currentFightIndex = PlayerPrefs.GetInt("CurrentFightIndex", 0);
        var numberOfLevels = 20;

        var alradyFinishedAllLevels = currentFightIndex + 1 >= numberOfLevels;
        if (alradyFinishedAllLevels)
        {
            isFinished = true;
            SpeechText.text = "You are free";
        }
    }

    private void SetOpenStatus(bool val)
    {
        isOpen = val;
    }

    public void FixedUpdate()
    {
        isPlayerClose = Math.Abs(DoorPosition.position.x - characterMovement.transform.position.x) < 0.1;

        if (isPlayerClose && !bookIsOpen && !isClosedExternally)
        {
            if (!isFinished)
            {
                WeaponSelectionCanvasStatus(true);
            }
            else
            {
                GameFinishedCanvas.SetActive(true);
            }
        }
        else if (!isPlayerClose && bookIsOpen)
        {
            WeaponSelectionCanvasStatus(false);
        }
    }

    void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (isPlayerClose)
            {
                if (!isFinished)
                {
                    WeaponSelectionCanvasStatus(true);
                }
                else
                {
                    //Debug.Log("todo: go to world scene");
                }
            }
            else
            {
                characterMovement.MoveTo(DoorPosition);
                isClosedExternally = false;
            }
        }
    }

    private void WeaponSelectionCanvasStatus(bool val)
    {
        WeaponSelectionCanvas.SetActive(val);
        bookIsOpen = val;
    }
}
