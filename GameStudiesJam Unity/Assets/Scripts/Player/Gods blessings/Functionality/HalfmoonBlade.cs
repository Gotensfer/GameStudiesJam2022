using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfmoonBlade : GodBlessing
{
    public override int Level { get => level; }
    int level;

    public override BlessingType Blessing { get => blessing; }
    BlessingType blessing = BlessingType.HalfmoonBlade;

    [Tooltip("The prefab for the Hercules' gauntlet pellet proyectile")]
    [SerializeField] GameObject pellet;

    [Header("Stats")]
    [Tooltip("The attack cooldown time between each attack")]
    [SerializeField] float attackCD;
    [Tooltip("The damage that this attack inflicts")]
    [SerializeField] int damage;
    [Tooltip("The aoe diameter that this attack inflicts")]
    [SerializeField] float aoe;
    [Tooltip("The speed multiplier that this attack inflicts")]
    [SerializeField] float speedMult;
    [Tooltip("The velocity of the fired proyectile")]
    [SerializeField] float proyectileVelocity;
    [Tooltip("The detection range for aquiring a target")]
    [SerializeField] float attackDetectionRange;

    [Header("Remaining cooldown")]
    [SerializeField] float CD;

    [SerializeField] HalfmoonConfig config;

    private void Start()
    {
        transform.parent.GetComponent<BlessingsSystem>().blessingTick.AddListener(AttemptNormalAttack);
        CD = attackCD;
    }

    public override void LevelUp()
    {
        level++;
        ScaleBlessingWithLevel();
    }

    protected override void AttemptNormalAttack()
    {
        CD -= Time.deltaTime;

        if (CD < 0)
        {
            PerformNormalAttack();
        }
    }

    GameObject pellet_instance;
    Transform targetEnemy;
    Collider[] possibleTargets;

    protected override void PerformNormalAttack()
    {
        CD = attackCD;
        FMOD.Studio.EventInstance halfMoonBasicSFX;
        
        possibleTargets = Physics.OverlapSphere(transform.position, attackDetectionRange);

        int len = possibleTargets.Length;
        float closestDistance = 1000;

        for (int i = 0; i < len; i++)
        {
            if (!possibleTargets[i].CompareTag("Enemy")) continue;

            float distance = Vector3.Distance(transform.position, possibleTargets[i].transform.position);

            if (distance < closestDistance)
            {
                targetEnemy = possibleTargets[i].transform;
                closestDistance = distance;
            }
        }

        // Si no hay enemigos, no hacer nada
        if (targetEnemy == null) return;

        Vector3 attackDirection = GameUtils.DirectionToTarget(transform, targetEnemy);

        pellet_instance = Instantiate(pellet, transform.position, Quaternion.identity);
        pellet_instance.GetComponent<HalfmoonPellet>().InitializePellet(attackDirection, proyectileVelocity, damage, speedMult);

        targetEnemy = null;
        
        halfMoonBasicSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/MedialunaBasic");
        halfMoonBasicSFX.start();
    }

    protected override void PerformUltimateAttack()
    {
        FMOD.Studio.EventInstance halfMoonUltiSFX; //Dejelo aquí arriba por si algo
        
        //Tu codigo destructivo aquí B)
        
        halfMoonUltiSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/MedialunaUlti");
        halfMoonUltiSFX.start();
    }

    void ScaleBlessingWithLevel()
    {
        damage = config.damagesAtLevel[level];
        attackCD = config.cdAtLevel[level];
        speedMult = config.speedMultiplier[level];
    }
}