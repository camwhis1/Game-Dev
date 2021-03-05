using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFood : MonoBehaviour
{   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(ScoreText.playerScore != ScoreText.toBeCollected)
            {
                ScoreText.playerScore++;
                Destroy(gameObject);
            }else{
                
            }
        }
    }

}
