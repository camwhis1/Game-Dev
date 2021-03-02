using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectFood : MonoBehaviour
{
    public AudioSource collectSound;
    public Player player;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(player.name == other.name)
        {
            ScoreText.playerScore++;
            Destroy(gameObject);
        }
    }

}
