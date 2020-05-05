using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.AI;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Transform DoorPosition;
    public GameObject WeaponSelectionCanvas;
    private bool isOpen;
    private CharacterScreenMovementBehaviour characterMovement;
    private bool isPlayerClose;
    private bool bookIsOpen;

    private bool isClosedExternally;

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
    }

    // Update is called once per frame
    void Update()
    {

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
            WeaponSelectionCanvasStatus(true);

        }
        else if (!isPlayerClose && bookIsOpen)
        {
            WeaponSelectionCanvasStatus(false);
        }
    }

    void OnMouseDown()
    {
        if (isPlayerClose)
        {
            WeaponSelectionCanvasStatus(true);
        }
        else
        {
            characterMovement.MoveTo(DoorPosition);
            isClosedExternally = false;
        }
    }

    private void WeaponSelectionCanvasStatus(bool val)
    {
        WeaponSelectionCanvas.SetActive(val);
        bookIsOpen = val;
    }
}
