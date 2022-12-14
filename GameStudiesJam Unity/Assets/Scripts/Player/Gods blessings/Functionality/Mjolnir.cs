using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class Mjolnir : GodBlessing
{
    public override int Level { get => level; }
    int level;

    public override BlessingType Blessing { get => blessing; }
    BlessingType blessing = BlessingType.Mjolnir;

    [Tooltip("The prefab for the Mjolnir pellet proyectile")]
    [SerializeField] GameObject pellet;

    [Header("Stats")]
    [Tooltip("The attack cooldown time between each attack")]
    [SerializeField] float attackCD;
    [Tooltip("The damage that this attack inflicts")]
    [SerializeField] int damage;
    [Tooltip("The aoe diameter that this attack inflicts")]
    [SerializeField] float aoe;
    [Tooltip("The velocity of the fired proyectile")]
    [SerializeField] float proyectileVelocity;
    [Tooltip("The detection range for aquiring a target")]
    [SerializeField] float attackDetectionRange;

    [Header("Remaining cooldown")]
    [SerializeField] float CD;

    [SerializeField] MjolnirConfig config;

    private KeywordRecognizer keywordRecognizer;

    public Dictionary<string, Action> wordToAction;

    private void Start()
    {
        transform.parent.GetComponent<BlessingsSystem>().blessingTick.AddListener(AttemptNormalAttack);
        CD = attackCD;

        wordToAction = new Dictionary<string, Action>();
        wordToAction.Add("Thor", PerformUltimateAttack);
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

    [SerializeField] LayerMask enemyLayer;

    protected override void PerformNormalAttack()
    {
        CD = attackCD;
        FMOD.Studio.EventInstance mjolnirBasicSFX; //Dejelo aqu?? arriba por si algo
        possibleTargets = Physics.OverlapSphere(transform.position, attackDetectionRange, enemyLayer);

        try
        {
            System.Random rnd = new System.Random();
            targetEnemy = possibleTargets.OrderBy(x => rnd.Next()).Take(1).ElementAt(0).transform;
        }
        catch (Exception)
        {
            print("|Mjolnir| Sin objetivos en este intento de ataque");
            targetEnemy = null;
        }

        // Si no hay enemigos, no hacer nada
        if (targetEnemy == null) return;

        pellet_instance = Instantiate(pellet, targetEnemy.position, Quaternion.identity);
        pellet_instance.GetComponent<MjolnirPellet>().InitializePellet(damage, aoe);

        targetEnemy = null;
        
        mjolnirBasicSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/MjolnirBase");
        mjolnirBasicSFX.start();
    }

    [SerializeField] float CDForUlti;
    [SerializeField] float CDulti;

    protected override void PerformUltimateAttack()
    {
        if (level >= 6 && CDulti <= 0)
        {
            FMOD.Studio.EventInstance mjolnirUltiSFX; //Dejelo aqu?? arriba por si algo

            //Tu codigo destructivo aqu?? B)
            CDulti = CDForUlti;

            pellet_instance = Instantiate(pellet, transform.position, Quaternion.identity);
            pellet_instance.GetComponent<MjolnirPellet>().InitializePellet(damage, aoe);
            pellet_instance.GetComponent<MjolnirPellet>().Detonate();

            mjolnirUltiSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/MjolnirUlti");
            mjolnirUltiSFX.start();
        }      
    }

    void ScaleBlessingWithLevel()
    {
        damage = config.damagesAtLevel[level];
        aoe = config.aoeAtLevel[level];
        attackCD = config.cdAtLevel[level];
    }
}