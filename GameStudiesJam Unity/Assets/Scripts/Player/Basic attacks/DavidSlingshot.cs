using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBehaviour))]
public class DavidSlingshot : MonoBehaviour
{
    [Tooltip("The prefab for the David's slingshot pellet proyectile")]
    [SerializeField] GameObject pellet;

    [Header("Stats")]
    [Tooltip("The attack cooldown time between each attack")]
    [SerializeField] float attackCD;
    [Tooltip("The base damage that this attack inflicts")]
    [SerializeField] int baseDamage;
    [Tooltip("The velocity of the fired proyectile")]
    [SerializeField] float proyectileVelocity;
    [Tooltip("The detection range for aquiring a target")]
    [SerializeField] float attackDetectionRange;

    [Header("Remaining cooldown")]
    [SerializeField] float CD;

    private void Start()
    {
        GetComponent<PlayerBehaviour>().basicAttackTick.AddListener(Attempt_DavidSlingshotAttack);
        CD = attackCD;
    }

    void Attempt_DavidSlingshotAttack()
    {
        CD -= Time.deltaTime;

        if (CD < 0)
        {
            PerformBasicAttack();
            
        }
    }

    GameObject pellet_instance;
    Transform targetEnemy;
    Collider[] possibleTargets;


    void PerformBasicAttack()
    {
        CD = attackCD;
        FMOD.Studio.EventInstance BasicSFX; //Dejelo aquí arriba por si algo
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
        pellet_instance.GetComponent<PlayerPellet>().InitializePellet(attackDirection, proyectileVelocity, baseDamage);

        targetEnemy = null;  
        
        BasicSFX = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Basic");
        BasicSFX.start();
    }
}