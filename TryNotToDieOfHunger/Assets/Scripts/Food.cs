using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    AudioSource audio;
    SpriteRenderer renderer;
    BoxCollider2D collider;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(ScoreText.playerScore < ScoreText.toBeCollected)
            {
                ScoreText.gmeScore += 100;
                ScoreText.playerScore++;
                audio.Play();
                // Destroy object without destroying it so audio doesn't stop
                renderer.enabled = false;
                collider.enabled = false;
            }
        }
    }
}
