using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandoraPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StandarEnemy[] enemies = EnemiesContainer.container.GetComponentsInChildren<StandarEnemy>();

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].enemyDieEvent.Invoke();
            }


            Destroy(gameObject);
        }
    }
}
