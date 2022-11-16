using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SphereController : MonoBehaviour {

    // Use this for initialization
    const float DRAG_STOP = 250;
    private float starDrag = 0;
    private Vector3 startSpeed;

    Rigidbody rb;

	void Awake () {
        rb = GetComponent<Rigidbody>();
        starDrag = rb.drag;

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            startSpeed =rb.velocity;
            rb.drag = DRAG_STOP;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.drag = starDrag;
            rb.velocity = startSpeed;
        }
    }
}
