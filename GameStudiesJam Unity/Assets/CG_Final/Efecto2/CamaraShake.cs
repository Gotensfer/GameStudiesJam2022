using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraShake : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Material earthQuake;
    bool eq_ON;
    void Start()
    {
        bool teq_ON = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (eq_ON == true)
        {
            earthQuake.SetFloat("_Bool", 1);
        }

        else
         {
            earthQuake.SetFloat("_Bool", 0);
        }
    }

    void EarquakeOn()
    {
        eq_ON = true;
    }

    void EarquakeOff()
    {
        eq_ON= false;
    }
}
