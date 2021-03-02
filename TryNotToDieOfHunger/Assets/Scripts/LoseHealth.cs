using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseHealth : MonoBehaviour
{
    public HealthBar healthBar;
    public Player player;
    public int maxHealth = 20;
    public int currHealth;

    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(player.name == other.name)
        {
            TakeDamage(2);
        }
    }

    void TakeDamage(int damage)
    {
        currHealth -= damage;
        healthBar.SetHealth(currHealth);
    }
       
}
