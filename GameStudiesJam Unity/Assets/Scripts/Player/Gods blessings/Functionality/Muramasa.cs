using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muramasa : GodBlessing
{
    public override int Level { get => level; }
    int level;

    public override BlessingType Blessing { get => blessing; }
    BlessingType blessing = BlessingType.Muramasa;

    public override void LevelUp()
    {
        level++;
    }

    protected override void AttemptNormalAttack()
    {
        throw new System.NotImplementedException();
    }

    protected override void PerformNormalAttack()
    {
        throw new System.NotImplementedException();
    }

    protected override void PerformUltimateAttack()
    {
        throw new System.NotImplementedException();
    }
}