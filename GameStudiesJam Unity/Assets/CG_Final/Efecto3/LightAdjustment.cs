using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAdjustment : MonoBehaviour
{
    // Start is called before the first frame update

    Light light;
    void Start()
    {
        light = GetComponent<Light>(); 
    }

    // Update is called once per frame
    void Update()
    {
        light.color = Color.HSVToRGB(DragonAdjustments.Instance.lightHue, 1, 1); //Naci por la qcha, moriré por el awapanelus
        light.intensity = DragonAdjustments.Instance.lightIntensity;
    }
}
