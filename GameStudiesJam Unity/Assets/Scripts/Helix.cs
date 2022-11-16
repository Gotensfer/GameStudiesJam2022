using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helix : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 Moveposition;
    Vector3 startPo = Vector3.zero;
    [SerializeField] float time;
    [SerializeField] float a;
    [SerializeField] float b;
    


    void Start()
    {
    }
    void Update()
    {
        Moveposition.x = startPo.x + Mathf.Cos(time * Time.timeSinceLevelLoad)*a;
        Moveposition.y = startPo.y + Mathf.Sin(time * Time.timeSinceLevelLoad)* a;
        Moveposition.z = startPo.z + b * time * Time.timeSinceLevelLoad;
        transform.localPosition = new Vector3(Moveposition.x, Moveposition.y, Moveposition.z);
    }
}
