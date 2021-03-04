using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackLarge : MonoBehaviour
{
    public Player player;
    public IceHole iceHolePrefab;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            IceHole iceHole = Instantiate(iceHolePrefab, transform.position, Quaternion.identity);
            iceHole.player = player;
            Destroy(gameObject);
        }
    }
}
