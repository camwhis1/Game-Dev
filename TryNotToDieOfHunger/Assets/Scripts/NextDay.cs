using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class NextDay : MonoBehaviour
{
    [SerializeField] GameObject nextDayPanel;
    public GmeOvrMainMen gmeOvr;
    public GmeOvrMainMen winPrompt;
    public GameObject win;
    public HealthBar healthBar;
    public Image blackCover;
    Color blackCoverColor;

    AudioSource bgm;
    AudioSource sleep;
    AudioSource scoreCount;

    bool dayEnding = false;
    bool sleepStarted = false;
    float healthDrainTimer = 0;
    float lastFrameTime;

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
        // Day end "cutscene"
        if (dayEnding)
        {
            
            float deltaTime = Time.realtimeSinceStartup - lastFrameTime;
            Time.timeScale = 0;
            if (!sleepStarted)
            {
                if (healthBar.GetCurrentHealth() > 1)
                {
                    healthDrainTimer += deltaTime;
                    if (healthDrainTimer > 0.02f)
                    {
                        healthDrainTimer -= 0.02f;
                        healthBar.LoseHealth(1);
                        ScoreText.gmeScore += 20;
                        scoreCount.Play();
                    }
                }
                else if (blackCover.color.a < 1)
                {   
                    if (ScoreText.toBeCollected == 25)
                    {
                        ScoreText.endSc = ScoreText.gmeScore;
                        winPrompt.OpenWin();
                    }
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
                if (!win.activeInHierarchy)
                {
                    if (blackCover.color.a > 0)
                    {
                        blackCover.color = new Color(0, 0, 0, blackCover.color.a - 0.01f);
                    }
                    else
                    {
                        dayEnding = false;
                        sleepStarted = false;
                        healthDrainTimer = 0;
                        Time.timeScale = 1;
                        bgm.Play();
                    }
                }
                else
                {
                    dayEnding = false;
                    Time.timeScale = 1;
                }
            }
        }
        lastFrameTime = Time.realtimeSinceStartup;
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