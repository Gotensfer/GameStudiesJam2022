using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AscalonConfig", menuName = "BlessingsConfig/AscalonConfig")]
public class AscalonConfig : ScriptableObject
{
    [Header("Config values")]
    public int[] damagesAtLevel;
    public float[] cdAtLevel;
}
