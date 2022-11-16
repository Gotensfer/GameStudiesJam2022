using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StandarEnemy))]
public class Drops : MonoBehaviour
{
    [Header("Drop prefabs")]
    [SerializeField] GameObject blood;
    [SerializeField] GameObject cloggedBlood;
    [SerializeField] GameObject crystallizedBlood;
    [SerializeField] GameObject pandoraBox;
    [SerializeField] GameObject wine;

    [Header("Drop chances")]
    [SerializeField] int bloodChance;
    [SerializeField] int cloggedBloodChance;
    [SerializeField] int crystallizedBloodChance;
    [SerializeField] int pandoraBoxChance;
    [SerializeField] int wineChance;

    Transform parentForDrops;

    private void Awake()
    {   
        GetComponent<StandarEnemy>().enemyDieEvent.AddListener(Drop);
    }

    void Drop()
    {
        parentForDrops = GetComponent<StandarEnemy>().parentForDrops;

        int chance = Random.Range(1, 101);

        // Esto podría usar una especie de flyweight
        int rangeForBloodChance = bloodChance;
        int rangeForCloggedBloodChance = rangeForBloodChance + cloggedBloodChance;
        int rangeForCrystallizedBloodChance = rangeForCloggedBloodChance + crystallizedBloodChance;
        int rangeForPandoraBoxChance = rangeForCrystallizedBloodChance + pandoraBoxChance;
        int rangeForWineChance = rangeForPandoraBoxChance + wineChance;

        if (chance <= rangeForBloodChance)
        {
            Instantiate(blood, transform.position, Quaternion.identity, parentForDrops);
        }
        else if (chance <= rangeForCloggedBloodChance)
        {
            Instantiate(cloggedBlood, transform.position, Quaternion.identity, parentForDrops);
        }
        else if (chance <= rangeForCrystallizedBloodChance)
        {
            Instantiate(crystallizedBlood, transform.position, Quaternion.identity, parentForDrops);
        }
        else if (chance <= rangeForPandoraBoxChance)
        {
            Instantiate(pandoraBox, transform.position, Quaternion.identity, parentForDrops);
        }
        else if (chance <= rangeForWineChance)
        {
            Instantiate(wine, transform.position, Quaternion.identity, parentForDrops);
        }
        else
        {
            // No se droppea nada
        }
    }
}