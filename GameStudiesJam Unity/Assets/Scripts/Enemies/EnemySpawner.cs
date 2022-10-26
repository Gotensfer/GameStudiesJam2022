using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] enemies;

    [SerializeField] float timeSpawn = 1; //spawneamos  en el segundo 1
    [SerializeField] float repeatSpawnRate = 3; //cada cuánto tiempo estamos spawneando enemigos


    [SerializeField] Transform northWest;
    [SerializeField] Transform northEast;
    [SerializeField] Transform southWest;
    [SerializeField] Transform southEast;

    [SerializeField] Transform player;
    [SerializeField] Transform enemyContainer;

    void Start()
    {
        InvokeRepeating("SpawnEnemies",timeSpawn,repeatSpawnRate); 
    }

    /* Tener en consideración que: el norte es Z+ y el sur es  Z-
     *                             el oeste es X- y el este es X+ 
     * 
     * n.w : North west  | s.w : South west
     * n.e : North east  | s.e : South east
     * 
     *  n.w - - - n.e
     *   -  - - -  -
     *   -  - - -  -
     *   -  - - -  -
     *  s.w - - - s.e
     */

    private void SpawnEnemies()
    {

        Vector3 spawnPosition = new Vector3(Random.Range(southWest.position.x, northEast.position.x),1,Random.Range(northWest.position.z, southEast.position.z)); //esta muy cursed lo de tener y pero posición en z, sin embargo como el juego es top view, espero se etienda

        GameObject enemy1 = Instantiate(enemies[0],spawnPosition,gameObject.transform.rotation, enemyContainer);
        enemy1.GetComponent<StandarEnemy>().SetTarget(player);
    }
}
