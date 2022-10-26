using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetHealthtext : MonoBehaviour
{
    TextMeshProUGUI display;
    [SerializeField] PlayerVitals vitals;

    private void Start()
    {
        display = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        display.text = $"{vitals.health}";
    }
}
