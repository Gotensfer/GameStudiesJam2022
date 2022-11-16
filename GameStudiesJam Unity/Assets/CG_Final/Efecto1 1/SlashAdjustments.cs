using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlashAdjustments : MonoBehaviour
{
    public static DragonAdjustments Instance;

    [SerializeField] Material FireSlashWave_;
    [SerializeField] Material FireTrail_;
    [SerializeField] Material Weapon_;
    [SerializeField] Material material_4;
    [SerializeField] Material material_5;
    [SerializeField] Material material_6;
    [SerializeField] Material material_7;
    [SerializeField] Material material_8;
    [SerializeField] Material material_9;
    [SerializeField] Material material_10;

    [SerializeField] Slider colorSlider_;
    [SerializeField] Slider texturePickerSlider;

    [SerializeField] Texture2D[] texturas;

    [SerializeField] Texture2D actualTexture;


    public float lightHue, lightIntensity;

    //[SerializeField] Material material_PorSiLas;

    void Awake()
    {
        /*if (Instance == null) Instance = this;
        else Destroy(gameObject);*/

        ColorSwitcher(0.07f);
        colorSlider_.value = 0.07f;

        texturePicker(0);
        texturePickerSlider.value = 0;
        /*intensitySlider_.value = 0;
        IntensitySwitcher(10);*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ColorSwitcher(float color)
    {
        //float h, s, v;

        FireSlashWave_.SetColor("_Color_1", Color.HSVToRGB(color, 0.8f, 1));
        FireSlashWave_.SetColor("_Color2", Color.HSVToRGB(color, 0.8f, 1));
        FireSlashWave_.SetColor("_BorderColor", Color.HSVToRGB(color, 1, 1));

        FireTrail_.SetColor("_Color_1", Color.HSVToRGB(color, 0.8f, 1));
        FireTrail_.SetColor("_Color2", Color.HSVToRGB(color, 0.8f, 1));
        FireTrail_.SetColor("_Color2", Color.HSVToRGB(color, 1, 1));



        Weapon_.SetColor("_Color", Color.HSVToRGB(color, 1, 1));
        Weapon_.SetColor("_ligth_color", Color.HSVToRGB(color, 1, 1));
        Weapon_.SetColor("_WeaponColor", Color.HSVToRGB(color, 0.5f, 1));

        material_4.color = Color.HSVToRGB(color, 0.8f, 1);
        material_5.color = Color.HSVToRGB(color, 0.7f, 1);
        material_5.SetColor("_EmissionColor", Color.HSVToRGB(color, 1, 1));

        material_6.color = Color.HSVToRGB(color, 0.8f, 1);
        material_7.SetColor("_color", Color.HSVToRGB(color, 1f, 1));


        material_8.color = Color.HSVToRGB(color, 0.8f, 1);
        material_9.color = Color.HSVToRGB(color, 0.8f, 1);

        lightHue = color;


    }

    public void IntensitySwitcher(float intensity)
    {
        lightIntensity = intensity;
    }

    public void texturePicker(float position)
    {
        Debug.Log(position);

        int textureIndex = (int)position;

        material_7.SetTexture("_mainTexture", texturas[textureIndex]);


        
    }
}
