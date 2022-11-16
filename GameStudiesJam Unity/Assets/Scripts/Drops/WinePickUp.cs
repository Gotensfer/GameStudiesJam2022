using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinePickUp : MonoBehaviour
{
    [SerializeField] int healAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerVitals>().Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
