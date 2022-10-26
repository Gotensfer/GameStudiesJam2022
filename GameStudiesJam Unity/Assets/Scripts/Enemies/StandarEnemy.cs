using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandarEnemy : MonoBehaviour
{
    Transform hero;
    //Ememy attributes 
    [Header("Enemy attributes")]
    [SerializeField] float enemyLife, enemySpeed, enemyDamage;
    private Rigidbody rb;
    private Vector3 movement;
    Vector3 heroPosition;

    int health;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        heroPosition = hero.position;
        Vector3 direction = heroPosition - transform.position;

        //float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg; //por si usamos sprites para que roten hacia el jugador
        //rb.rotation=angle;
        direction.Normalize();
        movement = direction;

    }

    private void FixedUpdate()
    {
        MoveEnemy(movement);
    }

    void MoveEnemy(Vector3 direction)
    {
        rb.AddForce(enemySpeed * direction);
    }

    public void SetTarget(Transform player)
    {
        hero = player;
    }

    public void Damage(int amount)
    {
        health -= amount;

        if (health <= 0) Death();
    }

    void Death()
    {
        PlayerController.kills++;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerVitals>().Damage(1);
        }
    }
}
