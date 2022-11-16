using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DragonAdjustments : MonoBehaviour
{
    public static DragonAdjustments Instance;

    [SerializeField] Material dragonTexture_;
    [SerializeField] Material trailMaterial_;
    [SerializeField] Material material_3;
    [SerializeField] Material material_4;
    [SerializeField] Material material_5;
    [SerializeField] Material material_6;

    [SerializeField] Slider colorSlider_;
    [SerializeField] Slider intensitySlider_;

    
    public float lightHue,lightIntensity;
  
    //[SerializeField] Material material_PorSiLas;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        ColorSwitcher(0.536f);
        colorSlider_.value = 0.536f;
        intensitySlider_.value = 0;
        IntensitySwitcher(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorSwitcher(float color)
    {
        //float h, s, v;

        dragonTexture_.SetColor("_borderColor", Color.HSVToRGB(color, 1, 1));

        trailMaterial_.SetColor("_Color_1", Color.HSVToRGB(color, 1, 1));
        trailMaterial_.SetColor("_Color2", Color.HSVToRGB(color, 1, 1));
        trailMaterial_.SetColor("_BorderColor", Color.HSVToRGB(color, 1, 1));


        material_3.SetColor("_EmissionColor", Color.HSVToRGB(color, 1, 1));
        material_3.color=  Color.HSVToRGB(color, 1, 1);
        material_4.color = Color.HSVToRGB(color, 1, 1);
        material_5.color = Color.HSVToRGB(color, 1, 1);
        material_5.SetColor("_EmissionColor", Color.HSVToRGB(color, 1, 1));

        material_6.color = Color.HSVToRGB(color, 1, 1);

        lightHue = color;


    }

    public void IntensitySwitcher(float intensity)
    {
        lightIntensity = intensity;
    }
}
