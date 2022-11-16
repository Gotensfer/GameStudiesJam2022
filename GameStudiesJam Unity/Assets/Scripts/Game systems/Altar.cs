using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altar : MonoBehaviour
{
    [SerializeField] BlessingType blessing;

    LevelUpManager levelUpManager;

    private void Awake()
    {
        levelUpManager = GameObject.FindObjectOfType<LevelUpManager>();       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GodBlessing godBlessing in levelUpManager.ownedBlessings)
            {
                if (godBlessing.Blessing == blessing)
                {
                    godBlessing.LevelUp();
                    Destroy(gameObject);
                }
            }            
        }
    }
}
