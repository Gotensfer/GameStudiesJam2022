using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBehaviour))]
public class BA_Pellet : MonoBehaviour
{
    [SerializeField] float attackCD;
    [SerializeField] float CD;

    [SerializeField] GameObject pellet;
    [SerializeField] int damage;
    [SerializeField] float velocity;

    [SerializeField] float detectionRadius;

    [SerializeField] Voice voice;

    private void Start()
    {
        GetComponent<PlayerBehaviour>().basicAttackTick.AddListener(AttempBasicAttack);
        CD = attackCD;

        StartCoroutine(initLate());

        GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    IEnumerator initLate()
    {
        yield return null;

        voice.wordToAction.Add("Rojo", RedAtq);
        voice.wordToAction.Add("Azul", BlueAtq);
        voice.wordToAction.Add("Verde", GreenAtq);
    }

    void AttempBasicAttack()
    {
        CD -= Time.deltaTime;

        if (CD < 0)
        {
            PerformBasicAttack();
            CD = attackCD;
        }
    }

    GameObject pellet_instance;
    Transform targetEnemy;
    Collider[] possibleTargets;


    void PerformBasicAttack()
    {
        possibleTargets = Physics.OverlapSphere(transform.position, detectionRadius);

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

        pellet_instance = Instantiate(pellet, transform.position, Quaternion.identity);

        Vector3 dir;


        if (targetEnemy != null) dir = targetEnemy.position;
        else dir = transform.forward;

        pellet_instance.GetComponent<PlayerPellet>().InitializePellet(dir, velocity, damage);

        targetEnemy = null;
    }


    

    void RedAtq()
    {
        GameObject pellet_instance;
        GameObject pellet_instance2;
        GameObject pellet_instance3;
        Transform targetEnemy = null;
        Collider[] possibleTargets;

        possibleTargets = Physics.OverlapSphere(transform.position, detectionRadius);

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

        pellet_instance = Instantiate(pellet, transform.position, Quaternion.identity);
        pellet_instance2 = Instantiate(pellet, transform.position, Quaternion.identity);
        pellet_instance3 = Instantiate(pellet, transform.position, Quaternion.identity);

        Vector3 dir;


        if (targetEnemy != null) dir = targetEnemy.position;
        else dir = transform.forward;

        Vector3 dir2 = dir + Vector3.left * 2;
        Vector3 dir3 = dir + Vector3.right * 2;

        pellet_instance.GetComponent<PlayerPellet>().InitializePellet(dir, velocity, damage);
        pellet_instance2.GetComponent<PlayerPellet>().InitializePellet(dir2, velocity, damage);
        pellet_instance3.GetComponent<PlayerPellet>().InitializePellet(dir3, velocity, damage);

        targetEnemy = null;

        GetComponent<MeshRenderer>().material.color = Color.red;
    }



    void BlueAtq()
    {
        Collider[] possibleTargets;

        possibleTargets = Physics.OverlapSphere(transform.position, detectionRadius);

        int len = possibleTargets.Length;

        for (int i = 0; i < len; i++)
        {
            if (possibleTargets[i].CompareTag("Enemy"))
            {
                PlayerController.kills++;
                Destroy(possibleTargets[i].gameObject);
            }
        }

        GetComponent<MeshRenderer>().material.color = Color.blue;
    }

    [SerializeField] PlayerVitals vitals;
    [SerializeField] int healAmount;

    void GreenAtq()
    {
        vitals.Heal(healAmount);

        GetComponent<MeshRenderer>().material.color = Color.green;
    }
}
