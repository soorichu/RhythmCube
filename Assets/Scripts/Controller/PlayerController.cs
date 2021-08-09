using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    TimeManager theTimeManager;

    void Start()
    {
        theTimeManager = FindObjectOfType<TimeManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            theTimeManager.CheckTiming();
        }
    }
}
