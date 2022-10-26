using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBehaviour : MonoBehaviour
{
    public UnityEvent basicAttackTick;

    void Update()
    {
        basicAttackTick.Invoke();
    }
}
