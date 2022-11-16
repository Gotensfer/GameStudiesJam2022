using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    TextMeshProUGUI display;

    private void Start()
    {
        display = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        display.text = $"{ExperienceSystem.PlayerLevel}";
    }
}