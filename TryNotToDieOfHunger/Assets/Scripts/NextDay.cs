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

    AudioSource bgm;
    AudioSource sleep;
    AudioSource scoreCount;

    bool dayEnding = false;
    bool sleepStarted = false;

    void Start()
    {
        blackCoverColor = blackCover.color;
        AudioSource[] audio = GetComponents<AudioSource>();
        bgm = audio[0];
        sleep = audio[1];
        scoreCount = audio[2];
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
            if (!sleepStarted)
            {
                if (healthBar.GetCurrentHealth() > 1)
                {
                    healthBar.LoseHealth(1);
                    ScoreText.gmeScore += 20;
                    scoreCount.Play();
                }
                else if (blackCover.color.a < 1)
                {
                    blackCover.color = new Color(0, 0, 0, blackCover.color.a + 0.01f);
                }
                else
                {
                    sleep.Play();
                    sleepStarted = true;
                    healthBar.FillHealth();
                    ScoreText.toBeCollected += 5;
                    ScoreText.playerScore = 0;
                }
            }
            else if (!sleep.isPlaying)
            {
                if (blackCover.color.a > 0)
                {
                    blackCover.color = new Color(0, 0, 0, blackCover.color.a - 0.01f);
                }
                else
                {
                    dayEnding = false;
                    sleepStarted = false;
                    Time.timeScale = 1;
                    bgm.Play();
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
                dayEnding = true;
                bgm.Pause();
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