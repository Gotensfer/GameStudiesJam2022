using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerPellet : MonoBehaviour
{
    public int damage;
    Rigidbody rb;
    [SerializeField] GameObject hitVfx;

    private void Awake()
    {
        Destroy(gameObject, 10f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<StandarEnemy>().Damage(damage);
            var vfxInstance = Instantiate(hitVfx, transform.position, Quaternion.identity);
            Destroy(vfxInstance, 1f);
            Destroy(gameObject);
        }
    }

    public void InitializePellet(Vector3 direction, float velocity, int damage)
    {
        this.damage = damage;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * velocity, ForceMode.Impulse);
    }
}
