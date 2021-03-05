using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackLarge : MonoBehaviour
{
    public Player player;
    public IceHole iceHolePrefab;

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
            IceHole iceHole = Instantiate(iceHolePrefab, transform.position, Quaternion.identity);
            iceHole.player = player;
            audio.Play();
            renderer.enabled = false;
            collider.enabled = false;
        }
    }
}
