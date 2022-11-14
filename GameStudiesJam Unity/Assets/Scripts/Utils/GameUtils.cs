using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameUtils
{
    public static Vector3 DirectionToTarget(Transform self, Transform target)
    {
        return (target.position - self.position).normalized;
    }
}