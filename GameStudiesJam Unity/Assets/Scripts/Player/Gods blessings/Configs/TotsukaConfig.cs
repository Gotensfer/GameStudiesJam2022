using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TotsukaConfig", menuName = "BlessingsConfig/TotsukaConfig")]
public class TotsukaConfig : ScriptableObject
{
    [Header("Config values")]
    public int[] damagesAtLevel;
    public float[] cdAtLevel;
}
