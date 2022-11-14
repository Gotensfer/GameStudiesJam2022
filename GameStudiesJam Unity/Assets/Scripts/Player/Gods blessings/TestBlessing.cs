using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlessing : GodBlessing
{
    [Tooltip("The attack cooldown time between each attack")]
    [SerializeField] float attackCD;
    [Header("Remaining cooldown")]
    [SerializeField] float CD;

    public override int Level { get => level; }
    int level;

    private void Start()
    {
        transform.parent.GetComponent<BlessingsSystem>().blessingTick.AddListener(AttemptNormalAttack);
        CD = attackCD;
    }

    override protected void AttemptNormalAttack()
    {
        CD -= Time.deltaTime;

        if (CD < 0)
        {
            PerformNormalAttack();
        }
    }

    override protected void PerformNormalAttack()
    {
        print($"Performed test blessing of {gameObject.name}");
        CD = attackCD;
    }

    override protected void PerformUltimateAttack()
    {
        throw new System.NotImplementedException();
    }

    public override void LevelUp()
    {
        level++;
    }
}