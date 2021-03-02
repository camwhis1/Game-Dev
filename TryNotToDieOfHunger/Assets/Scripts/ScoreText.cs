using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public GameObject score; 
    public static int playerScore;
    public static int toBeCollected = 5;    

    void Update()
    {
        score.GetComponent<Text>().text = playerScore + "/" + toBeCollected + "Food"; 
    }
}
