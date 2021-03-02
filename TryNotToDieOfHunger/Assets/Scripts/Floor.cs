using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public Player player;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.isOnIce = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.isOnIce = false;
        }
    }
}
