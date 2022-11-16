using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesContainer : MonoBehaviour
{
    public static Transform container;

    private void Start()
    {
        container = transform;
    }
}
