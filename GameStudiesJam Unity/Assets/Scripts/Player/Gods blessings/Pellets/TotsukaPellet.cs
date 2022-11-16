using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotsukaPellet : MonoBehaviour
{
    public int damage;
    Rigidbody rb;


    private void Awake()
    {
        Destroy(gameObject, 10f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<StandarEnemy>().Damage(damage);
        }
    }

    public void InitializePellet(Vector3 direction, float velocity, int damage)
    {
        this.damage = damage;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * velocity, ForceMode.Impulse);
    }
}
