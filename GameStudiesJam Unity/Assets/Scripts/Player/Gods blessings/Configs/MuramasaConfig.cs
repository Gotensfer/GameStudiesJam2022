using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MuramasaConfig", menuName = "BlessingsConfig/MuramasaConfig")]
public class MuramasaConfig : ScriptableObject
{
    [Header("Config values")]
    public int[] damagesAtLevel;
    public float[] cdAtLevel;
    public float[] aoeAtLevel;
}
