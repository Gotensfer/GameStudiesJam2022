using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] ParticleSystem ice_;
    [SerializeField] ParticleSystem fire_;
    [SerializeField] ParticleSystem earth_;
    [SerializeField] ParticleSystem Dragon_;

    [SerializeField] float timer=0;

    [SerializeField] bool canAtk = true;
    void Start()
    {
        anim = GetComponent<Animator>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
  
            if (Input.GetKeyDown(KeyCode.Q))
            {
                anim.SetTrigger("Cast");
                fire_.Play(true);
                
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetTrigger("Cast");
                ice_.Play(true);
            }



            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("Scream");
                earth_.Play(true);

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                anim.SetTrigger("Dragon");
                Dragon_.Play(true);

            }
   
    

        

    }
}
