using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StandarEnemy : MonoBehaviour
{
    Transform hero;
    //Ememy attributes 
    [Header("Enemy attributes")]
    public float enemyLife, enemySpeed, enemyDamage;
    private Rigidbody rb;
    private Vector3 movement;
    Vector3 heroPosition;

    int health;

    public UnityEvent enemyDieEvent;
    public Transform parentForDrops;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        enemyDieEvent.AddListener(Death);
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
        rb.MovePosition(transform.position + (enemySpeed * Time.deltaTime * direction));
    }

    public void SetTarget(Transform player)
    {
        hero = player;
    }

    public void SetDropHierarchyParent(Transform parent)
    {
        parentForDrops = parent;
    }

    public void Damage(int amount)
    {
        health -= amount;

        if (health <= 0) enemyDieEvent.Invoke();
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
