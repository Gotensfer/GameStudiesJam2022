using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] enemies;

    [SerializeField] float timeSpawn = 1; //spawneamos  en el segundo 1
    [SerializeField] float repeatSpawnRate = 3; //cada cuánto tiempo estamos spawneando enemigos


    [SerializeField] Transform xRight;
    [SerializeField] Transform xLeft;
    [SerializeField] Transform yTop;
    [SerializeField] Transform yBottom;
    void Start()
    {
        InvokeRepeating("SpawnEnemies",timeSpawn,repeatSpawnRate); 
    }


    private void SpawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);

        spawnPosition= new Vector3(Random.Range(xRight.position.x, xLeft.position.x),1,Random.Range(yTop.position.z, yBottom.position.z)); //esta muy cursed lo de tener y pero posición en z, sin embargo como el juego es top view, espero se etienda

        GameObject enemy1 = Instantiate(enemies[0],spawnPosition,gameObject.transform.rotation, transform.parent);

    }
}
