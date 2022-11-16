using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class EarthQuakeAdjustments : MonoBehaviour
{

    [SerializeField] Material Stone_;
    [SerializeField] Material material_2;
    [SerializeField] Material material_3;
    [SerializeField] Material material_4;
    [SerializeField] Material material_5;
    [SerializeField] Material material_6;

    [SerializeField] Material material_7;


    [SerializeField] Material material_8;

    [SerializeField] Material shake_;



    [SerializeField] Slider colorSlider_;
    [SerializeField] Slider ShakeAmountSlider_;
    [SerializeField] Slider ShakSpeedSlider_;

    //[SerializeField] Slider intensitySlider_;



    void Awake()
    {
        ColorSwitcher(0.05f);
        colorSlider_.value = 0.05f;
        // intensitySlider_.value = 0;
        // IntensitySwitcher(10);

        EQ_Force(1);
        ShakeAmountSlider_.value = 1f;

        EQ_Speed(30);
        ShakSpeedSlider_.value = 30f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorSwitcher(float color)
    {
        //float h, s, v;

        Stone_.SetColor("_LigthColor", Color.HSVToRGB(color, 1, 1));


        material_2.color = Color.HSVToRGB(color, 1, 1);
        material_3.SetColor("_EmissionColor", Color.HSVToRGB(color, 1, 1));
        material_3.color = Color.HSVToRGB(color, 1, 1);
        material_4.color = Color.HSVToRGB(color, 1, 1);
        material_5.color = Color.HSVToRGB(color, 1, 1);
        material_6.color = Color.HSVToRGB(color, 1, 1);

        material_7.SetColor("_EmissionColor", Color.HSVToRGB(color, 1, 1));
        material_7.color = Color.HSVToRGB(color, 1, 1);
        material_8.SetColor("_disolvercolor", Color.HSVToRGB(color, 1, 1));




    }

    public void EQ_Force(float force)
    {

        shake_.SetFloat("_RotationAmount", force);


    }

    public void EQ_Speed(float speed)
    {

        shake_.SetFloat("_RotationSpeed", speed);


    }
}
