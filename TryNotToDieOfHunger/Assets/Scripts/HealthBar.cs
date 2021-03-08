using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GmeOvrMainMen gme;
    int maxHealth;
    int currentHealth;

    float healthTimer = 0;
    public float secondsPerDamage = 1;
    
    Image image;

    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        currentHealth = health;
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
    }

    public void LoseHealth(int healthLost)
    {
        if(currentHealth > healthLost)
        {
            currentHealth -= healthLost;
        }
        else
        {
            gme.GameOver();
        }
        
    }

    public void LoseHealthNoGameOver(int healthLost)
    {
        currentHealth -= healthLost;
    }

    public void FillHealth()
    {
        currentHealth = maxHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    void Start()
    {
        image = GetComponent<Image>();
        SetMaxHealth(64);
    }

    void Update()
    {
        image.fillAmount = (float)currentHealth / maxHealth;

        healthTimer += Time.deltaTime;
        if (healthTimer >= secondsPerDamage)
        {
            LoseHealth(1);
            healthTimer -= secondsPerDamage;
        }
    }
}
