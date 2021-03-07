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
    public Image blackCover;
    Color blackCoverColor;

    bool dayEnding = false;
    int cutsceneTimer = -1;

    void Start()
    {
        blackCoverColor = blackCover.color;
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
           if(SceneManager.GetActiveScene().buildIndex != 0)
           {
               SceneManager.LoadScene(0);
           }
           else
           {
               if(nextDayPanel)
               {
                   OpenPanel();
               }
            }
        }             

        // Day end "cutscene"
        if (dayEnding)
        {
            Time.timeScale = 0;
            if (cutsceneTimer == -1)
            {
                if (healthBar.GetCuurentHealth() > 1)
                {
                    healthBar.LoseHealth(1);
                    ScoreText.gmeScore += 20;
                }
                else if (blackCover.color.a < 1)
                {
                    blackCover.color = new Color(0, 0, 0, blackCover.color.a + 0.01f);
                }
                else
                {
                    cutsceneTimer = 0;
                    healthBar.FillHealth();
                    ScoreText.toBeCollected += 5;
                    ScoreText.playerScore = 0;
                }
            }
            else if (cutsceneTimer < 240)
            {
                cutsceneTimer++;
            }
            else if (blackCover.color.a > 0)
            {
                    blackCover.color = new Color(0, 0, 0, blackCover.color.a - 0.01f);
            }
            else
            {
                dayEnding = false;
                Time.timeScale = 1;
            }
        }
    }

    public void userClickYesNo(int n) //0==no 1==yes
    {
        if(n == 1)
        {
            if(ScoreText.playerScore == ScoreText.toBeCollected)
            {
                dayEnding = true;
            }
            else
            {
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

    void PauseGame()
    {
        Time.timeScale = 0f;
    }
     
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}