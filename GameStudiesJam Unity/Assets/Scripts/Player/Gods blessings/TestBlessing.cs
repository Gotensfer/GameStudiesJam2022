using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBlessing : MonoBehaviour
{
    [Tooltip("The attack cooldown time between each attack")]
    [SerializeField] float attackCD;
    [Header("Remaining cooldown")]
    [SerializeField] float CD;

    private void Start()
    {
        transform.parent.GetComponent<BlessingsTick>().blessingTick.AddListener(Attempt_TestBlessing);
        CD = attackCD;
    }

    void Attempt_TestBlessing()
    {
        CD -= Time.deltaTime;

        if (CD < 0)
        {
            PerformTestBlessing();
        }
    }

    void PerformTestBlessing()
    {
        print($"Performed test blessing of {gameObject.name}");
        CD = attackCD;
    }
}
