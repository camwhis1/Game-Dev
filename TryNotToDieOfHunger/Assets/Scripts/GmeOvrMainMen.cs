using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GmeOvrMainMen : MonoBehaviour
{
    [SerializeField] GameObject gameOverPrompt;
    [SerializeField] GameObject mainMenuPrompt;

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
            SceneManager.LoadScene(0);
            ScoreText.gmeScore = 0;
            UpdateFood();
        }
        if(n == 2)
        {

        }
        ClosePanelMain();
    }

    public void UserClickGmeOver(int n) //0==MainMenu 1==Retry
    {
        if(n == 1)
        {
            SceneManager.LoadScene(0);
            ScoreText.gmeScore = 0;
            ClosePanelGme();
            UpdateFood();
        }
        if(n == 0)
        {
            ClosePanelGme();
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
        mainMenuPrompt.SetActive(true);
        PauseGame();
    }

    public void ClosePanelMain()
    {
        mainMenuPrompt.SetActive(false);
        ResumeGame();
    }

    public void UpdateFood()
    {
        ScoreText.playerScore = 0;
        ScoreText.toBeCollected = 5;
    }
}
