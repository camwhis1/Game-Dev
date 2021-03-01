using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    GameObject gameObject;
    Rigidbody2D rdb;
  
    // Start is called before the first frame update
    void Start()
    {
        gameObject = GetComponent<GameObject>();
        rdb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
