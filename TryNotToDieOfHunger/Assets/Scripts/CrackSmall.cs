using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackSmall : MonoBehaviour
{
    public Player player;
    public CrackLarge crackLargePrefab;
    
    AudioSource audio;
    SpriteRenderer renderer;
    BoxCollider2D collider;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CrackLarge crackLarge = Instantiate(crackLargePrefab, transform.position, Quaternion.identity);
            crackLarge.player = player;
            audio.Play();
            renderer.enabled = false;
            collider.enabled = false;
        }
    }
}
