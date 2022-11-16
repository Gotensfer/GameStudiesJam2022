using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MjolnirConfig", menuName = "BlessingsConfig/MjolnirConfig")]
public class MjolnirConfig : ScriptableObject
{
    [Header("Config values")]
    public int[] damagesAtLevel;
    public float[] cdAtLevel;
    public float[] aoeAtLevel;
}
