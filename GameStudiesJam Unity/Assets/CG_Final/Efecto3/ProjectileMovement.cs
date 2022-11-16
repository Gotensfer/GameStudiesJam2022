using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject hitVfx;
    [SerializeField] GameObject Stuff;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {

    }

    private void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision co)
    {
        speed = 0;

        ContactPoint contact=co.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if(hitVfx != null)
        {
            var vfxInstance = Instantiate(hitVfx, pos, rot);
            Destroy(vfxInstance,1f);
        }

        Destroy(Stuff);

        Destroy(gameObject,1f);
        
    }
}
