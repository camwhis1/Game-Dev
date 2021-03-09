using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public GameObject score; 
    public GameObject scoreShadow; 
    public GameObject gameScore;
    public GameObject gameScoreShadow;
    public GameObject dayCounter;
    public GameObject dayCounterShadow;
    public GameObject endScore;
    public GameObject returnHomeMessage;
    public GameObject returnHomeMessageShadow;
    public static int endSc;
    public static int gmeScore;
    public static int playerScore = 25;
    public static int toBeCollected = 25;    

    Text foodText;
    Text foodTextShadow;
    Text scoreText;
    Text scoreTextShadow;
    Text dayText;
    Text dayTextShadow;
    Text endScoreText;
    Text returnHomeText;
    Text returnHomeTextShadow;

    AudioSource audio;

    float timer = -1;
    int sfxCounter = 0;
    float flashTimer = -1;

    bool isComplete = false;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        foodText = score.GetComponent<Text>();
        foodTextShadow = scoreShadow.GetComponent<Text>();
        scoreText = gameScore.GetComponent<Text>();
        scoreTextShadow = gameScoreShadow.GetComponent<Text>();
        dayText = dayCounter.GetComponent<Text>();
        dayTextShadow = dayCounterShadow.GetComponent<Text>();
        endScoreText = endScore.GetComponent<Text>();
        returnHomeText = returnHomeMessage.GetComponent<Text>();
        returnHomeTextShadow = returnHomeMessageShadow.GetComponent<Text>();
    }

    void Update()
    {
        if (playerScore < toBeCollected)
        {
            isComplete = false;
        }
        else if (!isComplete)
        {
            timer = 0;
            flashTimer = 0;
            sfxCounter = 3;
            isComplete = true;
        }

        foodText.text = foodTextShadow.text = "Food: " + playerScore + " / " + toBeCollected;
        scoreText.text = scoreTextShadow.text = "Score: " + gmeScore; 
        dayText.text = dayTextShadow.text = "Day: " + (toBeCollected / 5) + " / 5";
        endScoreText.text = "Score: " + endSc;

        if (isComplete)
        {
            foodText.color = Color.green;
            returnHomeText.enabled = returnHomeTextShadow.enabled = true;
        }
        else
        {
            foodText.color = new Color(0.75f, 0.75f, 0.75f, 1);
            returnHomeText.enabled = returnHomeTextShadow.enabled = false;
            flashTimer = -1;
        }

        if (timer >= 0)
        {
            timer += Time.deltaTime;
            if (timer > 0.175f)
            {
                if (sfxCounter > 0)
                {
                    sfxCounter -= 1;
                    timer = 0;
                    audio.Play();
                }
                else
                {
                    timer = -1;
                }
            }
        }

        if (flashTimer >= 0)
        {
            flashTimer += Time.deltaTime;
            if (flashTimer > 0.25f)
            {
                returnHomeText.color = returnHomeText.color == Color.gray ? Color.yellow : Color.gray;
                flashTimer = 0;
            }
        }
    }
}
