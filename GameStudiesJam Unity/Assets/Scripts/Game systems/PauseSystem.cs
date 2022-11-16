using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] LevelUpManager levelUpManager;

    bool paused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
        paused = true;

        if (levelUpManager.ownedBlessings.Count != 3)
        {
            levelUpManager.Spawn3RandomLevelUpChoices();
        }
        else
        {
            levelUpManager.Spawn3OwnedLevelUpChoices();
        }
    }

    void UnPause()
    {
        Time.timeScale = 1f;
        paused = false;

        levelUpManager.DeleteGUILevelUpElements();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
