using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float velocity;

    float inputForward;
    float inputSideways;
    Vector3 movementVector;
    Rigidbody rb;

    public static int kills;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        inputForward = Input.GetAxisRaw("Vertical");
        inputSideways = Input.GetAxisRaw("Horizontal");

        movementVector.x = inputSideways;
        movementVector.z = inputForward;
    }

    private void FixedUpdate()
    {
        rb.AddForce(movementVector * velocity);
    }
}
