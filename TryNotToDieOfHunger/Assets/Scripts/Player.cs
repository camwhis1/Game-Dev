using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 0.015f;
    
    void Update()
    {
        transform.Translate(Input.GetAxis("DiscreteHorizontal") * playerSpeed, 0f, 0f);
        transform.Translate(0f, Input.GetAxis("DiscreteVertical") * playerSpeed, 0f);
    }
}
