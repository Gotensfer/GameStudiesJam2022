using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVitals : MonoBehaviour
{
    [SerializeField] PlayerConfig playerConfig;

    public int maxHealth { get; private set; }
    public int health { get; private set; }
    public int damage { get; private set; }

    private void Start()
    {
        if (playerConfig == null)
        {
            Debug.LogError("�Debes asignar un PlayerConfig a las vitales!");
            return;
        }

        maxHealth = playerConfig.baseMaxHealth;
        health = maxHealth;
        damage = playerConfig.baseDamage;
    }

    public void Damage(int amount)
    {
        int receivedDamage = amount;
        health = Mathf.Clamp(health - receivedDamage, 0, maxHealth);
    }

    public void Heal(int amount)
    {
        int receivedHeal = amount;
        health = Mathf.Clamp(health + receivedHeal, 0, maxHealth);
    }

    public void AddMaxHealth(int amount)
    {
        int receivedMaxHealth = amount;
        maxHealth += receivedMaxHealth;
    }
}