using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New player config", menuName ="PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public int baseMaxHealth;
    public int baseDamage;
}
