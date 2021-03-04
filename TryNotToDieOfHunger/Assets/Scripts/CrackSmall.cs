using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackSmall : MonoBehaviour
{
    public Player player;
    public CrackLarge crackLargePrefab;

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CrackLarge crackLarge = Instantiate(crackLargePrefab, transform.position, Quaternion.identity);
            crackLarge.player = player;
            Destroy(gameObject);
        }
    }
}
