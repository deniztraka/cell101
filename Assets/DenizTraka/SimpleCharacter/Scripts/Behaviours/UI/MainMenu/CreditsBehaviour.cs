using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteAfterTime(() =>
                    {
                        Application.Quit(); 
                    }, 3));
    }

    private IEnumerator ExecuteAfterTime(Action task, float time)
    {

        yield return new WaitForSeconds(time);

        if (task != null)
        {
            task();
        }
    }
}
