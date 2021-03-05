using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class NextDay : MonoBehaviour
{
    [SerializeField] GameObject nextDayPanel;
    public GmeOvrMainMen gmeOvr;
    public HealthBar healthBar;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
           if(SceneManager.GetActiveScene().buildIndex != 0)
           {
               SceneManager.LoadScene(0);
           }else{
               if(nextDayPanel)
               {
                   OpenPanel();
               }
            }
        }             
    }

    public void userClickYesNo(int n) //0==no 1==yes
    {
        if(n == 1)
        {
            if(ScoreText.playerScore == ScoreText.toBeCollected)
            {
                ScoreText.gmeScore += 100;
                UpdateFood();
                UpdateHealthBar();
            }else{
                gmeOvr.OpenPanelGme();
            }
        }
        ClosePanel();
    }

    public void OpenPanel()
    {
        nextDayPanel.SetActive(true);
        PauseGame();
    }

    public void ClosePanel()
    {
        nextDayPanel.SetActive(false);
        ResumeGame();
    }
    public void UpdateFood()
    {
        ScoreText.playerScore = 0;
        ScoreText.toBeCollected += 5;
    }

    public void UpdateHealthBar()
    {
        healthBar.FillHealth();
    } 

    void PauseGame()
    {
        Time.timeScale = 0f;
    }
     
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}