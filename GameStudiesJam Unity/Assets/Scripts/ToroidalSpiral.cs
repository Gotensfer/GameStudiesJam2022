using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToroidalSpiral : MonoBehaviour
{

    Vector3 toroidal;

    [SerializeField] float _radius1;
    [SerializeField] float _radius2;
    [SerializeField] float _anglea;
    [SerializeField] float _angleb; //Esto es el periodo creo me da bastante pereza buscar conicas 


    void Start()
    {

    }
    void Update()
    {
        toroidal.x = (_radius1+_radius2*(Mathf.Cos(Time.timeSinceLevelLoad * _anglea)))*Mathf.Cos(Time.timeSinceLevelLoad * _angleb);

        toroidal.y = (_radius1 + _radius2 * (Mathf.Cos(Time.timeSinceLevelLoad * _anglea))) * Mathf.Sin(Time.timeSinceLevelLoad * _angleb);

        toroidal.z = _radius2 * Mathf.Sin(Time.timeSinceLevelLoad * _anglea);

        transform.localPosition = toroidal;
    }
}
