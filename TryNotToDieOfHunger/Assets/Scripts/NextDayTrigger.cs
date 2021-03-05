using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDayTrigger : MonoBehaviour
{
    public NextDay prompt;
    public GmeOvrMainMen winPrompt;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(ScoreText.playerScore == 10 && ScoreText.toBeCollected == 10)
            {
                ScoreText.endSc = ScoreText.gmeScore;
                winPrompt.OpenWin();
            }else{
                prompt.OpenPanel();
            }
        }
    }
}