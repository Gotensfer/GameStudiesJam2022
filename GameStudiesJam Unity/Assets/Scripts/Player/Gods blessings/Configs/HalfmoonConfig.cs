using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HalfmoonConfig", menuName = "BlessingsConfig/HalfmoonConfig")]
public class HalfmoonConfig : ScriptableObject
{
    [Header("Config values")]
    public int[] damagesAtLevel;
    public float[] cdAtLevel;
    public float[] speedMultiplier;
}
