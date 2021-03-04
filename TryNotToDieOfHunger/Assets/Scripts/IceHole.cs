using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceHole : MonoBehaviour
{
    public Player player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.TriggerIceFall();
        }
    }
}
