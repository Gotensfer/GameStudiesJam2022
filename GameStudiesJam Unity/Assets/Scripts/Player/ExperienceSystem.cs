using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExperienceSystem : MonoBehaviour
{
    [field: SerializeField] public int Experience { get; private set; }
    [field: SerializeField] public int ExperienceForNextLevel { get; private set; }

    public static int PlayerLevel { get; private set; }

    public UnityEvent levelUpEvent;

    private void Start()
    {
        PlayerLevel = 0;

        LevelUp();

        levelUpEvent.AddListener(LevelUp);
    }

    public void AddExperience(int amount)
    {
        Experience = Mathf.Clamp(Experience + amount, 0, ExperienceForNextLevel);

        if (Experience == ExperienceForNextLevel)
        {
            levelUpEvent.Invoke();
        }
    }

    int CalculateExperienceNeededForLevelUp(int currentLevel)
    {
        int neededExperience = (int)(10 + Mathf.Pow(100, (float)currentLevel / 10));
        return neededExperience;
    }

    void LevelUp()
    {
        PlayerLevel++;
        ExperienceForNextLevel = CalculateExperienceNeededForLevelUp(PlayerLevel);

        Experience = 0;
    }
}