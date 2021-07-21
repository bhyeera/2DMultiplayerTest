using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public int currentLevel;
    public int currentHealth;
    public int currentMaxHealth;
    public string playerName;


    public void SetPlayerHealth()
    {
        currentMaxHealth = maxHealth * currentLevel;
    }

}
