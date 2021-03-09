using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Sprite buttonDown;
    public GameObject rock;
    public GameObject explosion;

    SpriteRenderer renderer;
    BoxCollider2D collider;
    AudioSource audio;

    float destroyTimer = -1;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (destroyTimer >= 0)
        {
            if (destroyTimer < 0.1)
            {
                destroyTimer += Time.deltaTime;
            }
            else
            {
                destroyTimer = -1;
                Destroy(rock);
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            renderer.sprite = buttonDown;
            collider.enabled = false;
            Instantiate(explosion, rock.transform.position, Quaternion.identity);
            audio.Play();
            destroyTimer = 0;
        }
    }
}
