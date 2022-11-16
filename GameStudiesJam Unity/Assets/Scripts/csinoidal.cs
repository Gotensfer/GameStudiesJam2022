using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csinoidal : MonoBehaviour
{
    Vector3 c_lindric;

    [SerializeField] float _radius1;
    [SerializeField] float height;
    [SerializeField] float _angleA;
    [SerializeField] float speed;
    [SerializeField] float _angleLa;


    void Start()
    {

    }
    void Update()
    {
        c_lindric.x = _radius1*Mathf.Cos(speed * Time.timeSinceLevelLoad);

        c_lindric.y = _radius1 * Mathf.Sin(speed * Time.timeSinceLevelLoad);

        c_lindric.z = height* Mathf.Cos((_angleLa * speed * Time.timeSinceLevelLoad)+_angleA);

        transform.localPosition = c_lindric;
    }
}
