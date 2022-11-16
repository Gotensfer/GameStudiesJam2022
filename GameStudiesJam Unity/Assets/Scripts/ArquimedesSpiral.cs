using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Functions1 {
    public class ArquimedesSpiral : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField] private float speed;
        [SerializeField] private float thicknessGain;

        private Vector2 polarCoords = Vector2.zero;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {//Teta -> variable independiente 
            polarCoords.y += Time.deltaTime;
            //Radio -> Variable Dependiente 
            polarCoords.x = polarCoords.y * speed;
            transform.localPosition = polarCoords.PolarToCartesian();
        }
    }
}

