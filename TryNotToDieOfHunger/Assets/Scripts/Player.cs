using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigidbody;
    SpriteRenderer renderer;
    public float playerSpeed = 0.1f;
    public bool isOnIce = false;
    public bool isSafe = true;

    public float iceFriction = 0.05f;

    float iceSpeedX = 0;
    float iceSpeedY = 0;

    public HealthBar healthBar;

    Vector2 lastSafePosition = new Vector2(0, 0);

    float respawnTimer = -1;
    float respawnSparkleTimer = -1;
    public float respawnTime = 1;

    public ParticleSystem waterSplash;
    public ParticleSystem respawnSparkles;


    AudioSource[] audio;

    void Start()
    {
        anim = GetComponent<Animator> ();
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        audio = GetComponents<AudioSource>();
    }
    
    void Update()
    {
        if (respawnSparkleTimer > -1)
        {
            if (respawnSparkleTimer > respawnTime * 0.9)
            {
                Instantiate(respawnSparkles, transform.position, Quaternion.identity);
                respawnSparkleTimer = -1;
            }
            else
            {
                respawnSparkleTimer += Time.deltaTime;
            }
        }

        if (respawnTimer > -1)
        {
            if (respawnTimer > respawnTime)
            {
                respawnTimer = -1;
                audio[2].Play();
            }
            else
            {
                respawnTimer += Time.deltaTime;
            }
            return;
        }

        renderer.enabled = true;
        anim.speed = isOnIce ? 3 : 1;

        float x = Input.GetAxis("DiscreteHorizontal");
        float y = Input.GetAxis("DiscreteVertical");
        anim.SetFloat("XSpeed", x);
        anim.SetFloat("YSpeed", y);

        if (isSafe)
        {
            lastSafePosition = rigidbody.position;
        }

        if (!isOnIce)
        {
            iceSpeedX = 0;
            iceSpeedY = 0;   
            rigidbody.MovePosition(rigidbody.position + Vector2.right * x * playerSpeed + Vector2.up * y * playerSpeed);
        }
        else
        {
            if (Mathf.Abs(x) < 0.5)
            {
                if (iceSpeedX > iceFriction * Time.deltaTime)
                {
                    iceSpeedX -= iceFriction * Time.deltaTime;
                }
                else if (iceSpeedX < iceFriction * Time.deltaTime * -1)
                {
                    iceSpeedX += iceFriction * Time.deltaTime;
                }
                else
                {
                    iceSpeedX = 0;
                }
            }
            else if (Mathf.Abs(iceSpeedX) < playerSpeed)
            {
                iceSpeedX += x * iceFriction * Time.deltaTime;
            }

            if (Mathf.Abs(y) < 0.5)
            {
                if (iceSpeedY > iceFriction * Time.deltaTime)
                {
                    iceSpeedY -= iceFriction * Time.deltaTime;
                }
                else if (iceSpeedY < -iceFriction * Time.deltaTime)
                {
                    iceSpeedY += iceFriction * Time.deltaTime;
                }
                else
                {
                    iceSpeedY = 0;
                }
            }
            else if (Mathf.Abs(iceSpeedY) < playerSpeed)
            {
                iceSpeedY += y * iceFriction * Time.deltaTime;
            }

            rigidbody.MovePosition(rigidbody.position + Vector2.right * iceSpeedX + Vector2.up * iceSpeedY);
        }
    }

    public void TriggerIceFall()
    {
        ScoreText.gmeScore -= 10;
        renderer.enabled = false;
        healthBar.LoseHealth(5);
        rigidbody.position = lastSafePosition;
        iceSpeedX = 0;
        iceSpeedY = 0;
        respawnTimer = 0;
        respawnSparkleTimer = 0;
        audio[0].Play();
        audio[1].Play();
        Instantiate(waterSplash, transform.position, Quaternion.identity);
    }
}
