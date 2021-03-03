using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigidbody;
    public float playerSpeed = 0.1f;
    public bool isOnIce = false;

    public float iceFriction = 0.0001f;

    float iceSpeedX = 0;
    float iceSpeedY = 0;

    void Start()
    {
        anim = GetComponent<Animator> ();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        anim.speed = isOnIce ? 3 : 1;

        float x = Input.GetAxis("DiscreteHorizontal");
        float y = Input.GetAxis("DiscreteVertical");
        anim.SetFloat("XSpeed", x);
        anim.SetFloat("YSpeed", y);

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
}
