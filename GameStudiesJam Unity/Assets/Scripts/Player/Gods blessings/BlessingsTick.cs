using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlessingsTick : MonoBehaviour
{
    public UnityEvent blessingTick;

    void Update()
    {
        blessingTick.Invoke();
    }
}