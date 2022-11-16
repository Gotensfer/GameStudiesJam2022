using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscalonPellet : MonoBehaviour
{
    public int damage;
    Rigidbody rb;
    [SerializeField] GameObject vfxObject;


    private void Awake()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<StandarEnemy>().Damage(damage);
            Destroy(Instantiate(vfxObject, transform.position, Quaternion.identity), 5f);
        }
    }

    public void InitializePellet(Vector3 direction, float velocity, int damage)
    {
        this.damage = damage;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * velocity, ForceMode.Impulse);
    }
}
