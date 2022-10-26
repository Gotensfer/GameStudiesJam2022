using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetKillsDisplay : MonoBehaviour
{
    TextMeshProUGUI display;
    [SerializeField] PlayerVitals vitals;

    private void Start()
    {
        display = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        display.text = $"{PlayerController.kills}";
    }
}
