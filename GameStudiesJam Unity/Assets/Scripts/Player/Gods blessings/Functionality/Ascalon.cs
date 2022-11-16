using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;

public class Ascalon : GodBlessing
{
    public override int Level { get => level; }
    int level;

    public override BlessingType Blessing { get => blessing; }
    BlessingType blessing = BlessingType.Ascalon;

    [Tooltip("The prefab for the Hercules' gauntlet pellet proyectile")]
    [SerializeField] GameObject pellet;

    [Header("Stats")]
    [Tooltip("The attack cooldown time between each attack")]
    [SerializeField] float attackCD;
    [Tooltip("The damage that this attack inflicts")]
    [SerializeField] int damage;
    [Tooltip("The velocity of the fired proyectile")]
    [SerializeField] float proyectileVelocity;
    [Tooltip("The detection range for aquiring a target")]
    [SerializeField] float attackDetectionRange;

    [Header("Remaining cooldown")]
    [SerializeField] float CD;

    [SerializeField] AscalonConfig config;

    private KeywordRecognizer keywordRecognizer;

    public Dictionary<string, Action> wordToAction;

    private void Awake()
    {
        transform.parent.GetComponent<BlessingsSystem>().blessingTick.AddListener(AttemptNormalAttack);
        CD = attackCD;

        wordToAction = new Dictionary<string, Action>();
        wordToAction.Add("Dragón", PerformUltimateAttack);
        keywordRecognizer = new KeywordRecognizer(wordToAction.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += WordRecognized;
        keywordRecognizer.Start();
    }

    private void WordRecognized(PhraseRecognizedEventArgs word)
    {
        print(word.text);
        wordToAction[word.text].Invoke();
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

        if (CDulti >= 0)
        {
            CDulti -= Time.deltaTime;
        }
    }

    GameObject pellet_instance;
    Transform targetEnemy;
    Collider[] possibleTargets;

    protected override void PerformNormalAttack()
    {
        CD = attackCD;
        FMOD.Studio.EventInstance ascalonBasicSFX;
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

        if (targetEnemy == null) return;

        Vector3 attackDirection = GameUtils.DirectionToTarget(transform, targetEnemy);

        pellet_instance = Instantiate(pellet, transform.position, Quaternion.identity);
        pellet_instance.GetComponent<AscalonPellet>().InitializePellet(attackDirection, proyectileVelocity, damage);

        targetEnemy = null;
        
        ascalonBasicSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/AscalonBasic");
        ascalonBasicSFX.start();
    }

    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float CDForUlti;
    [SerializeField] float CDulti;

    protected override void PerformUltimateAttack()
    {
        print("Attempted");

        if (level >= 6 && CDulti <= 0)
        {
            FMOD.Studio.EventInstance ascalonUltiSFX; //Dejelo aquí arriba por si algo

            //Tu codigo destructivo aquí B)

            CDulti = CDForUlti;

            possibleTargets = Physics.OverlapSphere(transform.position, 5, enemyLayer);

            for (int i = 0; i < possibleTargets.Length; i++)
            {
                possibleTargets[i].GetComponent<StandarEnemy>().Damage(damage);
            }

            print("Success");

            // no me gusta esto

            ascalonUltiSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/AscalonUlti");
            ascalonUltiSFX.start();
        }        
    }

    void ScaleBlessingWithLevel()
    {
        damage = config.damagesAtLevel[level];
        attackCD = config.cdAtLevel[level];
    }
}