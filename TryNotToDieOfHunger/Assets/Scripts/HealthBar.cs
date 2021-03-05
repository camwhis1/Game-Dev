using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GmeOvrMainMen gme;
    
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void LoseHealth(int healthLost)
    {
        if(slider.value != 0)
        {
            slider.value -= healthLost;
        }else{
            gme.GameOver();
        }
        
    }

    public void FillHealth()
    {
        slider.value = slider.maxValue;
    }
}
