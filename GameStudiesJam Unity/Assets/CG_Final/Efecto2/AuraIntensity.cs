using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraIntensity : MonoBehaviour
{
    [SerializeField] Material aura;
    [SerializeField] float intensity=0;
    [SerializeField] float timer = 0;
    [SerializeField] float speed;
    bool On;
    bool started;
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        On = false;

    }

    // Update is called once per frame
    void Update()
    {
        aura.SetFloat("_disolve", intensity);


        if (started == true)
        {
            timer += Time.deltaTime * speed;
            if (On == true)
            {
                aura.SetFloat("_disolve", Mathf.Lerp(0, 0.9f, timer));
            }
            else
            {
                aura.SetFloat("_disolve", Mathf.Lerp(0.9f, 0, timer));
            }
        }

        if (timer > 1)
        {
            timer = 0;
            if(On==false) started = false;
        }

        /* timer += Time.deltaTime;


         if (On == true)
         {
             Debug.Log("On");
             intensity = timer;

             Debug.Log(intensity);




         }

         else
         {
             intensity -= timer;
             if (intensity < 0)
             {
                 intensity = 0;
             }
             Debug.Log("Off");
         }
        */





    }


    void auraLerpOn()
    {
        started = true;
        On = true;
        
        timer = 0;

        Debug.Log("LlamadoOn");
    }
     void auraLerpOff()
    {
        On = false;
        timer = 0;
        Debug.Log("LlamadoOFF");
    }
}
