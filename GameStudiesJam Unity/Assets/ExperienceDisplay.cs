using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExperienceDisplay : MonoBehaviour
{
    [SerializeField] ExperienceSystem experienceSystem;
    TextMeshProUGUI display;

    private void Start()
    {
        display = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        display.text = $"{experienceSystem.Experience} / {experienceSystem.ExperienceForNextLevel}";
    }
}
