using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfmoonPellet : MonoBehaviour
{
    public int damage;
    public float speedMult;
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
            other.GetComponent<StandarEnemy>().enemySpeed *= speedMult;
            Destroy(gameObject);
        }
    }

    public void InitializePellet(Vector3 direction, float velocity, int damage, float speedMult)
    {
        this.damage = damage;
        this.speedMult = speedMult;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * velocity, ForceMode.Impulse);
    }
}
