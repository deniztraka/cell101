using System;
using System.Collections;
using System.Collections.Generic;
using DTWorld.Behaviours.Interfacelike;
using DTWorld.Behaviours.Mobiles;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    HealthBehaviour playerHealth;
    public GameObject OnDeathCanvas;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBehaviour>();
        playerHealth.OnHealthBelowZeroEvent += new HealthBehaviour.OnHealthBelowZeroEventHandler(OnDeath);
        //Application.targetFrameRate = 30;
    }

    private void OnDeath()
    {
        OnDeathCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
