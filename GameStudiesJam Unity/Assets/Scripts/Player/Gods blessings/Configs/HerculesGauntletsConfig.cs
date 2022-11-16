using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="HerculesConfig", menuName = "BlessingsConfig/HerculesConfig")]
public class HerculesGauntletsConfig : ScriptableObject
{
    [Header("Config values")]
    public int[] damagesAtLevel;
    public float[] cdAtLevel;
    public float[] aoeAtLevel;
}
