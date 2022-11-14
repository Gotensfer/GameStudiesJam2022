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

    System.Random rnd = new System.Random();

    IEnumerable<GameObject> Pick3Random()
    {
        return levelUpGUIElements.OrderBy(x => rnd.Next()).Take(3);
    }

    void Spawn3RandomLevelUpChoices()
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

    void Spawn3OwnedLevelUpChoices()
    {
        for (int i = 0; i < ownedLevelUpGUIElements.Count; i++)
        {
            GameObject levelUpGUIElement = Instantiate(ownedLevelUpGUIElements[i], pickOptionsContainer[i]);
            InitializeButtonFunctionality(levelUpGUIElement.GetComponent<LevelUpGUIContainer>().godBlessing,
                levelUpGUIElement.GetComponent<LevelUpGUIContainer>().levelUpButton,
                levelUpGUIElement);
        }
    }

    void DeleteGUILevelUpElements()
    {
        for (int i = 0; i < pickOptionsContainer.Length; i++)
        {
            try
            {
                Destroy(pickOptionsContainer[i].GetChild(0).gameObject);
            }
            catch (Exception e)
            {
                Debug.LogWarning("No habían elementos de mejora GUI a remover");
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
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

        if (Input.GetKeyDown(KeyCode.D))
        {
            DeleteGUILevelUpElements();
        }
    }

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
                // To do: Cositas extra que deben pasar cuando ya se tiene el nivel máximo mejorable
            }
            
            levelUpGUIElement.GetComponent<LevelUpGUIContainer>().SetLevel(ownedBlessing.Level);
            button.onClick.AddListener(DeleteGUILevelUpElements);
        }      
    }

    #region"Métodos para agregar nuevas bendiciones"
    [SerializeField] GameObject herculesGauntletBlessing, mjolnirBlessing, halfmoonBladeBlessing, totsukaSwordBlessing, muramasaBlessing, ascalonBlessing;
    [SerializeField] Transform godsBlessingsContainer;

    // No me gusta mucho este código :/ - Jf

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
}