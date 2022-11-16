using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickUp : MonoBehaviour
{
    [SerializeField] int experienceAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerVitals>().experienceSystem.AddExperience(experienceAmount);
            Destroy(gameObject);
        }
    }
}
