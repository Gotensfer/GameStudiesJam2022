using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlessingsSystem : MonoBehaviour
{
    public UnityEvent blessingTick;

    public GodBlessing[] blessings;

    void Update()
    {
        blessingTick.Invoke();
    }
}