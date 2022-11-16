using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle_Practice : MonoBehaviour
{
    // Start is called before the first frame update

    

    [Range(0f,1f)]
    [SerializeField] float vectorSizex,vectorSizey;

    Vector2 x, y;
    float angle;


    void Start()
    {
        x = new Vector2(vectorSizex, 0);
        y = new Vector2(0, vectorSizey);
       

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
          {
            Debug.Log(x);
            Debug.Log(y);

           Vector2 result = new Vector2(vectorSizex, vectorSizey);
            Debug.Log(result);

            angle= Vector2.SignedAngle(x, result);

            Debug.Log(angle+" Angulo");


        }
    }
}
