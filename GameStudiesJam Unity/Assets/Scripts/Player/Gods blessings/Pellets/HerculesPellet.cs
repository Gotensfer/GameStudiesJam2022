using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerculesPellet : MonoBehaviour
{
    int damage;
    float aoe;
    Rigidbody rb;


    private void Awake()
    {
        Destroy(gameObject, 10f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {            
            Collider[] targets = Physics.OverlapSphere(transform.position, aoe / 2f);

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

    public void InitializePellet(Vector3 direction, float velocity, int damage, float aoe)
    {
        this.damage = damage;
        this.aoe = aoe;

        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * velocity, ForceMode.Impulse);
    }
}
