using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandarEnemy : MonoBehaviour
{
    GameObject hero;            
    //Ememy attributes 
    [SerializeField] float enemyLife, enemySpeed, enemyDamage;
    private Rigidbody rb;
    private Vector3 movement;
    Vector3 heroPosition;

    void Start()
    {
        rb= this.GetComponent<Rigidbody>();

        hero = GameObject.FindWithTag("Hero");

    }

    // Update is called once per frame
    void Update()
    {
        heroPosition = hero.transform.position;
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
        rb.MovePosition((Vector3)transform.position + (direction * enemySpeed * Time.deltaTime));
    }
}
