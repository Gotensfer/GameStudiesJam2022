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
            GameObject LevelUpGUIElement = Instantiate(picks.ElementAt(i), pickOptionsContainer[i]);
        }
    }

    void Spawn3OwnedLevelUpChoices()
    {

    }

    void DeleteGUILevelUpElements()
    {
        for (int i = 0; i < pickOptionsContainer.Length; i++)
        {
            Destroy(pickOptionsContainer[i].GetChild(0).gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Spawn3RandomLevelUpChoices();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DeleteGUILevelUpElements();
        }
    }

    // To do: Asignar funcionalidades correspondientes a si se tiene o no el poder
    // 1 -> Añadir el nuevo powerup
    // 2 -> Subir de nivel el powerup

    void AssignButton(BlessingType blessing, Button button)
    {
        switch (blessing)
        {
            case BlessingType.HerculesGauntlet:
                button.onClick.AddListener(AddHerculesGauntlet);
                break;
            case BlessingType.Mjolnir:
                break;
            case BlessingType.HalfmoonBlade:
                break;
            case BlessingType.TotsukaSword:
                break;
            case BlessingType.Muramasa:
                break;
            case BlessingType.Ascalon:
                break;
        }
    }

    #region"Métodos para agregar nuevas bendiciones"
    [SerializeField] GameObject herculesGauntletBlessing, mjolnirBlessing, halfmoonBladeBlessing, totsukaSwordBlessing, muramasaBlessing, ascalonBlessing;
    [SerializeField] Transform godsBlessingsContainer;

    void AddHerculesGauntlet()
    {
        Instantiate(herculesGauntletBlessing, godsBlessingsContainer);
    }

    void AddMjolnir()
    {
        Instantiate(muramasaBlessing, godsBlessingsContainer);
    }

    void AddHalfmoonBlade()
    {
        Instantiate(halfmoonBladeBlessing, godsBlessingsContainer);
    }

    void AddTotsukaSword()
    {
        Instantiate(totsukaSwordBlessing, godsBlessingsContainer);
    }

    void AddMuramasa()
    {
        Instantiate(muramasaBlessing, godsBlessingsContainer);
    }

    void AddAscalon()
    {
        Instantiate(ascalonBlessing, godsBlessingsContainer);
    }
    #endregion
}