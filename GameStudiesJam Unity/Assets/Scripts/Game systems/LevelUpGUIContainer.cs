using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpGUIContainer : MonoBehaviour
{
    public Button levelUpButton;
    public BlessingType godBlessing;

    [SerializeField] Image[] levelIndicators;

    public void SetLevel(int level)
    {
        if (level <= 5)
        {
            // Encender en amarillo un indicador de nivel por nivel que se tenga de la bendición
            for (int i = 0; i < level; i++)
            {
                levelIndicators[i].color = Color.yellow;
            }
        }
        else
        {
            // Poner todo en rojito porque es ultimate 8)
            for (int i = 0; i < 5; i++) 
            {
                levelIndicators[i].color = Color.red;
            }
        }
        
    }
}
