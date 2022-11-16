using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateProjectile : MonoBehaviour
{ 
   [SerializeField] Transform spawnArea;
   [SerializeField] GameObject dragonHead;
    [SerializeField] float offset;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnProjectile()
    {
        Vector3 spawnDown = new Vector3(spawnArea.position.x, spawnArea.position.y + offset, spawnArea.position.z);
            Instantiate(dragonHead, spawnDown, Quaternion.identity);
        

        
    }
}
