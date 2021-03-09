using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GmeOvrMainMen : MonoBehaviour
{
    [SerializeField] GameObject gameOverPrompt;
    [SerializeField] GameObject mainMenuPrompt;
    [SerializeField] GameObject winPrompt;
    [SerializeField] GameObject helpPrompt;

    public void GameOver()
    {
        OpenPanelGme();
    }

    public void MainMenu()
    {
        OpenPanelMain();
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }
     
    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void UserClickMainMen(int n) //0==Close 1==Start 2==Help
    {
        if(n == 1)
        {
            SceneManager.LoadScene(1);
            ScoreText.gmeScore = 0;
            UpdateFood();
        }
        if(n == 2)
        {
            ClosePanelMain();
            OpenHelp();
        }
        if(n == 0)
        {
            Application.Quit();
        }
        ResumeGame();
    }

    public void UserClickGmeOver(int n) //0==MainMenu 1==Retry
    {
        if(n == 1)
        {
            SceneManager.LoadScene(1);
            ScoreText.gmeScore = 0;
            ClosePanelGme();
            UpdateFood();
            ResumeGame();
        }
        if(n == 0)
        {
            ClosePanelGme();
            OpenPanelMain();
        }
    }

    public void UserClickWin(int n) //0==MainMenu 1==Retry 
    {
        if(n == 1)
        {
            SceneManager.LoadScene(1);
            CloseWin();
            UpdateFood();
            ResumeGame();
        }
        if(n == 0)
        {
            CloseWin();
            OpenPanelMain();
        }
    }

    public void UserClickHelp(int n) //0==Main Menu 
    {
        if(n == 0)
        {
            CloseHelp();
            OpenPanelMain();
        }
    }

    public void OpenPanelGme()
    {
        gameOverPrompt.SetActive(true);
        PauseGame();
    }

    public void ClosePanelGme()
    {
        gameOverPrompt.SetActive(false);
        ResumeGame();
    }

    public void OpenPanelMain()
    {
        SceneManager.LoadScene(0);
        PauseGame();
    }

    public void ClosePanelMain()
    {
        mainMenuPrompt.SetActive(false);
        ResumeGame();
    }

    public void OpenWin()
    {
        winPrompt.SetActive(true);
        PauseGame();
    }

    public void CloseWin()
    {
        winPrompt.SetActive(false);
        ResumeGame();
    }

    public void OpenHelp()
    {
        helpPrompt.SetActive(true);
    }

    public void CloseHelp()
    {
        helpPrompt.SetActive(false);
    }   

    public void UpdateFood()
    {
        ScoreText.playerScore = 0;
        ScoreText.toBeCollected = 5;
    }
}
