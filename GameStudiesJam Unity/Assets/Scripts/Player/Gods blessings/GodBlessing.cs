using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlessingType
{
    HerculesGauntlet = 0,
    Mjolnir = 1,
    HalfmoonBlade = 2,
    TotsukaSword = 3,
    Muramasa = 4,
    Ascalon = 5
}

public abstract class GodBlessing : MonoBehaviour
{
    public abstract int Level { get; }

    protected abstract void AttemptNormalAttack();
    protected abstract void PerformNormalAttack();
    protected abstract void PerformUltimateAttack();
    public abstract void LevelUp();
}