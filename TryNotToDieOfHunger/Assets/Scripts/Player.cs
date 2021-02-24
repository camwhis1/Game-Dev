using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    public float playerSpeed = 2;

    void Start()
    {
        anim = GetComponent<Animator> ();
    }
    
    void Update()
    {
        float x = Input.GetAxis("DiscreteHorizontal");
        float y = Input.GetAxis("DiscreteVertical");
        transform.Translate(x * playerSpeed * Time.deltaTime, 0f, 0f);
        anim.SetFloat("XSpeed", x);
        transform.Translate(0f, y * playerSpeed * Time.deltaTime, 0f);
        anim.SetFloat("YSpeed", y);
    }
}
