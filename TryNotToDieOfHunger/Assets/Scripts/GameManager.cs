using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Text scoreText;
    Text gameOverText;
    public static int playerScore = 0;

    public void AddScore()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = playerScore + "/5 Food";
    }

    public void PlayerDied()
    {
        gameOverText.enabled = true;
        Time.timeScale = 0;
    }
}
