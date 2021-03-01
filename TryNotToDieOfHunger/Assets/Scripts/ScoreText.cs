using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public GameObject score; 
    public int playerScore;
    public AudioSource sound;
    public int toBeCollected = 5;

    void OnTriggerExit2D(Collider2D other)
    {
       playerScore += 1;
       score.GetComponent<Text>().text = playerScore + "/" + toBeCollected + "Food"; 
       Destroy(gameObject);
    }
}
