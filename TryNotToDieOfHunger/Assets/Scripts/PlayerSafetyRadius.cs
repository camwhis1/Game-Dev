using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSafetyRadius : MonoBehaviour
{
    public Player player;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ice")
        {
            player.isSafe = true;
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ice")
        {
            player.isSafe = false;
        }
    }
}
