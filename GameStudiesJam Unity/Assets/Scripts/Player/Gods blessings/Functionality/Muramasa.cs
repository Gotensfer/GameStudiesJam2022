using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class Muramasa : GodBlessing
{
    public override int Level { get => level; }
    int level;

    public override BlessingType Blessing { get => blessing; }
    BlessingType blessing = BlessingType.Muramasa;

    [Tooltip("The prefab for the Mjolnir pellet proyectile")]
    [SerializeField] GameObject pellet;

    [Header("Stats")]
    [Tooltip("The attack cooldown time between each attack")]
    [SerializeField] float attackCD;
    [Tooltip("The damage that this attack inflicts")]
    [SerializeField] int damage;
    [Tooltip("The aoe radius that this attack inflicts")]
    [SerializeField] float aoe;
    [Tooltip("The velocity of the fired proyectile")]
    [SerializeField] float proyectileVelocity;
    [Tooltip("The detection range for aquiring a target")]
    [SerializeField] float attackDetectionRange;

    [Header("Remaining cooldown")]
    [SerializeField] float CD;

    [SerializeField] MuramasaConfig config;

    private KeywordRecognizer keywordRecognizer;

    public Dictionary<string, Action> wordToAction;

    private void Start()
    {
        transform.parent.GetComponent<BlessingsSystem>().blessingTick.AddListener(AttemptNormalAttack);
        CD = attackCD;

        playerController = FindObjectOfType<PlayerController>();

        wordToAction = new Dictionary<string, Action>();
        wordToAction.Add("Muramasa", PerformUltimateAttack);
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

    Collider[] possibleTargets;

    [SerializeField] LayerMask enemyLayer;

    [SerializeField] GameObject hitVfx;

    protected override void PerformNormalAttack()
    {
        CD = attackCD;
        FMOD.Studio.EventInstance muramasaBasicSFX; //Dejelo aqu?? arriba por si algo
        possibleTargets = Physics.OverlapSphere(transform.position, aoe, enemyLayer);

        for (int i = 0; i < possibleTargets.Length; i++)
        {
            possibleTargets[i].GetComponent<StandarEnemy>().Damage(damage);
        }
        muramasaBasicSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/MuramasaBasic");
        muramasaBasicSFX.start();

        var vfxInstance = Instantiate(hitVfx, transform.position, Quaternion.identity);
        Destroy(vfxInstance, 5f);
    }

    PlayerController playerController;

    [SerializeField] float CDForUlti;
    [SerializeField] float CDulti;

    [SerializeField] GameObject ultiVfx;

    protected override void PerformUltimateAttack()
    {
        if (level >= 6 && CDulti <= 0)
        {
            FMOD.Studio.EventInstance muramasaUltiSFX; //Dejelo aqu?? arriba por si algo

            //Tu codigo destructivo aqu?? B)
            CDulti = CDForUlti;

            playerController.velocity += 5;

            muramasaUltiSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/MuramasaUlti");
            muramasaUltiSFX.start();

            var vfxInstance = Instantiate(ultiVfx, transform.position, Quaternion.identity);
            Destroy(vfxInstance, 5f);
        }      
    }

    void ScaleBlessingWithLevel()
    {
        damage = config.damagesAtLevel[level];
        aoe = config.aoeAtLevel[level];
        attackCD = config.cdAtLevel[level];
    }
}