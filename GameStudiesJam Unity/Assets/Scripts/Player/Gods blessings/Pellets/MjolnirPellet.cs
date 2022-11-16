using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MjolnirPellet : MonoBehaviour
{
    int damage;
    float aoe;

    [SerializeField] GameObject vfxThunder;

    private void Awake()
    {
        Destroy(gameObject, 0.05f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Collider[] targets = Physics.OverlapSphere(transform.position, aoe / 2f);

            Destroy(Instantiate(vfxThunder, transform.position, Quaternion.identity), 5f);

            int len = targets.Length;
            for (int i = 0; i < len; i++)
            {
                if (targets[i].CompareTag("Enemy"))
                {
                    targets[i].GetComponent<StandarEnemy>().Damage(damage);
                }
            }

            // VFX de la explosión aquí

            // --

            Destroy(gameObject);
        }
    }

    public void InitializePellet(int damage, float aoe)
    {
        this.damage = damage;
        this.aoe = aoe;
    }

    public void Detonate()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, aoe / 2f);

        Destroy(Instantiate(vfxThunder, transform.position, Quaternion.identity), 5f);

        int len = targets.Length;
        for (int i = 0; i < len; i++)
        {
            if (targets[i].CompareTag("Enemy"))
            {
                targets[i].GetComponent<StandarEnemy>().Damage(damage);
            }
        }

        Destroy(gameObject);
    }
}
