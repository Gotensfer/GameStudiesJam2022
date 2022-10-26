using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerPellet : MonoBehaviour
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
            Destroy(gameObject);
        }
    }

    public void InitializePellet(Vector3 targetPosition, float velocity, int damage)
    {
        this.damage = damage;
        rb = GetComponent<Rigidbody>();
        print((targetPosition - transform.position).normalized * velocity);
        rb.AddForce((targetPosition - transform.position).normalized * velocity, ForceMode.Impulse);
    }
}
