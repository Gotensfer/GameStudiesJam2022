using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class LevelUpManager : MonoBehaviour
{
    public GameObject[] levelUpGUIElements;
    public List<GameObject> ownedLevelUpGUIElements;
    public List<GodBlessing> ownedBlessings;

    [SerializeField] RectTransform[] pickOptionsContainer;

    IEnumerable<GameObject> Pick3Random()
    {
        System.Random rnd = new System.Random();
        return levelUpGUIElements.OrderBy(x => rnd.Next()).Take(3);
    }

    public void Spawn3RandomLevelUpChoices()
    {
        IEnumerable<GameObject> picks = Pick3Random();

        for (int i = 0; i < picks.Count(); i++)
        {
            GameObject levelUpGUIElement = Instantiate(picks.ElementAt(i), pickOptionsContainer[i]);
            InitializeButtonFunctionality(levelUpGUIElement.GetComponent<LevelUpGUIContainer>().godBlessing,
                levelUpGUIElement.GetComponent<LevelUpGUIContainer>().levelUpButton,
                levelUpGUIElement);
            
        }
    }

    public void Spawn3OwnedLevelUpChoices()
    {
        for (int i = 0; i < ownedLevelUpGUIElements.Count; i++)
        {
            GameObject levelUpGUIElement = Instantiate(ownedLevelUpGUIElements[i], pickOptionsContainer[i]);
            InitializeButtonFunctionality(levelUpGUIElement.GetComponent<LevelUpGUIContainer>().godBlessing,
                levelUpGUIElement.GetComponent<LevelUpGUIContainer>().levelUpButton,
                levelUpGUIElement);
        }
    }

    public void DeleteGUILevelUpElements()
    {
        Time.timeScale = 1;

        for (int i = 0; i < pickOptionsContainer.Length; i++)
        {
            try
            {
                Destroy(pickOptionsContainer[i].GetChild(0).gameObject);
            }
            catch (Exception)
            {
                Debug.LogWarning("No hab?an elementos de mejora GUI a remover");
            }
        }
    }

    public void DisplayLevelUpOptions()
    {
        Time.timeScale = 0;

        if (ownedBlessings.Count != 3)
        {
            Spawn3RandomLevelUpChoices();
        }
        else
        {
            Spawn3OwnedLevelUpChoices();
        }
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (ownedBlessings.Count != 3)
            {
                Spawn3RandomLevelUpChoices();
            }
            else
            {
                Spawn3OwnedLevelUpChoices();
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            DeleteGUILevelUpElements();
        }
    }
#endif

    void InitializeButtonFunctionality(BlessingType blessing, Button button, GameObject levelUpGUIElement)
    {
        bool alreadyHasIt = false;
        GodBlessing ownedBlessing = null;

        for (int i = 0; i < ownedBlessings.Count; i++)
        {
            if (blessing == ownedBlessings[i].Blessing)
            {
                alreadyHasIt = true;
                ownedBlessing = ownedBlessings[i];
            }
        }

        if (!alreadyHasIt)
        {
            switch (blessing)
            {
                case BlessingType.HerculesGauntlet:
                    button.onClick.AddListener(AddHerculesGauntlet);
                    break;
                case BlessingType.Mjolnir:
                    button.onClick.AddListener(AddMjolnir);
                    break;
                case BlessingType.HalfmoonBlade:
                    button.onClick.AddListener(AddHalfmoonBlade);
                    break;
                case BlessingType.TotsukaSword:
                    button.onClick.AddListener(AddTotsukaSword);
                    break;
                case BlessingType.Muramasa:
                    button.onClick.AddListener(AddMuramasa);
                    break;
                case BlessingType.Ascalon:
                    button.onClick.AddListener(AddAscalon);
                    break;
            }

            levelUpGUIElement.GetComponent<LevelUpGUIContainer>().SetLevel(0);
            button.onClick.AddListener(DeleteGUILevelUpElements);
        }
        else
        {
            if (ownedBlessing.Level < 5)
            {
                button.onClick.AddListener(ownedBlessing.LevelUp);
            }
            else
            {
                if (ownedBlessing.Level == 5)
                {
                    switch (blessing)
                    {
                        case BlessingType.HerculesGauntlet:
                            button.onClick.AddListener(AltarHercules);
                            break;
                        case BlessingType.Mjolnir:
                            button.onClick.AddListener(AltarMjolnir);
                            break;
                        case BlessingType.HalfmoonBlade:
                            button.onClick.AddListener(AltarHalfmooon);
                            break;
                        case BlessingType.TotsukaSword:
                            button.onClick.AddListener(AltarTotsuka);
                            break;
                        case BlessingType.Muramasa:
                            button.onClick.AddListener(AltarMuramasa);
                            break;
                        case BlessingType.Ascalon:
                            button.onClick.AddListener(AltarAscalon);
                            break;
                    }
                }
            }
            
            levelUpGUIElement.GetComponent<LevelUpGUIContainer>().SetLevel(ownedBlessing.Level);
            button.onClick.AddListener(DeleteGUILevelUpElements);
        }      
    }

    #region"M?todos para agregar nuevas bendiciones"
    [SerializeField] GameObject herculesGauntletBlessing, mjolnirBlessing, halfmoonBladeBlessing, totsukaSwordBlessing, muramasaBlessing, ascalonBlessing;
    [SerializeField] Transform godsBlessingsContainer;

    // No me gusta mucho este c?digo :/ - Jf

    void AddHerculesGauntlet()
    {
        GodBlessing blessing = Instantiate(herculesGauntletBlessing, godsBlessingsContainer).GetComponent<GodBlessing>();
        ownedBlessings.Add(blessing);
        blessing.LevelUp();
        ownedLevelUpGUIElements.Add(levelUpGUIElements[0]);
    }

    void AddMjolnir()
    {
        GodBlessing blessing = Instantiate(mjolnirBlessing, godsBlessingsContainer).GetComponent<GodBlessing>();
        ownedBlessings.Add(blessing);
        blessing.LevelUp();
        ownedLevelUpGUIElements.Add(levelUpGUIElements[1]);
    }

    void AddHalfmoonBlade()
    {
        GodBlessing blessing = Instantiate(halfmoonBladeBlessing, godsBlessingsContainer).GetComponent<GodBlessing>();
        ownedBlessings.Add(blessing);
        blessing.LevelUp();
        ownedLevelUpGUIElements.Add(levelUpGUIElements[2]);
    }

    void AddTotsukaSword()
    {
        GodBlessing blessing = Instantiate(totsukaSwordBlessing, godsBlessingsContainer).GetComponent<GodBlessing>();
        ownedBlessings.Add(blessing);
        blessing.LevelUp();
        ownedLevelUpGUIElements.Add(levelUpGUIElements[3]);
    }

    void AddMuramasa()
    {
        GodBlessing blessing = Instantiate(muramasaBlessing, godsBlessingsContainer).GetComponent<GodBlessing>();
        ownedBlessings.Add(blessing);
        blessing.LevelUp();
        ownedLevelUpGUIElements.Add(levelUpGUIElements[4]);
    }

    void AddAscalon()
    {
        GodBlessing blessing = Instantiate(ascalonBlessing, godsBlessingsContainer).GetComponent<GodBlessing>();
        ownedBlessings.Add(blessing);
        blessing.LevelUp();
        ownedLevelUpGUIElements.Add(levelUpGUIElements[5]);
    }
    #endregion

    #region"M?todos pa conseguir altares"

    [SerializeField] GameObject altarHercules, altarMjolnir, altarHalfmoon, altarTotsuka, altarMuramasa, altarAscalon;

    void AltarHercules()
    {
        SpawnAltar(altarHercules);
    }

    void AltarMjolnir()
    {
        SpawnAltar(altarMjolnir);
    }

    void AltarHalfmooon()
    {
        SpawnAltar(altarHalfmoon);
    }

    void AltarTotsuka()
    {
        SpawnAltar(altarTotsuka);
    }

    void AltarMuramasa()
    {
        SpawnAltar(altarMuramasa);
    }

    void AltarAscalon()
    {
        SpawnAltar(altarAscalon);
    }

    [SerializeField] Transform northWest;
    [SerializeField] Transform northEast;
    [SerializeField] Transform southWest;
    [SerializeField] Transform southEast;

    Vector3 ReturnRandomPos()
    {
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(southWest.position.x, northEast.position.x), 1, UnityEngine.Random.Range(northWest.position.z, southEast.position.z));
        print(spawnPosition);
        return spawnPosition;
    }
    
    void SpawnAltar(GameObject altar)
    {
        Instantiate(altar).transform.position = ReturnRandomPos();
    }

    #endregion
}