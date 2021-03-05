using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDayTrigger : MonoBehaviour
{
    public NextDay prompt;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            prompt.OpenPanel();
        }
    }
}