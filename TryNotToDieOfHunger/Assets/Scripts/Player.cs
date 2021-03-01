using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameObject gameObject;
    GameManager gm;
    Animator anim;
    Rigidbody2D rigidbody;
    public float playerSpeed = 0.1f;

    void Start()
    {
        //gameObject = GetComponent<GameObject>();
        gm = GetComponent<GameManager>();
        anim = GetComponent<Animator> ();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float x = Input.GetAxis("DiscreteHorizontal");
        float y = Input.GetAxis("DiscreteVertical");
        
        rigidbody.MovePosition(rigidbody.position + Vector2.right * x * playerSpeed + Vector2.up * y * playerSpeed);
        anim.SetFloat("XSpeed", x);
        anim.SetFloat("YSpeed", y);
    }

    void OnTriggerEnter2D(Collider2D item)
    {
         if(item.CompareTag("Food"))
         {
            Destroy(item.gameObject);
            var objectSetTriger = item.gameObject;
            gm.AddScore();
         }
    }

}
