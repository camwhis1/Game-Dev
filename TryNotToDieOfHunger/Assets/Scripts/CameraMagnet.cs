using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMagnet : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    float transitionTimer = -1;
    float xDist = 0;
    float yDist = 0;
    float lastFrameTime = 0;
    
    void Update()
    {
        if (transitionTimer > 0 && cam.transform.position != transform.position)
        {
            float deltaTime = Time.realtimeSinceStartup - lastFrameTime;
            Time.timeScale = 0;
            transitionTimer -= deltaTime;
            cam.transform.Translate(xDist * deltaTime, yDist * deltaTime, 0);
        }
        else if (transitionTimer != -1)
        {
            Time.timeScale = 1;
            transitionTimer = -1;
            cam.transform.position = transform.position;
        }
        lastFrameTime = Time.realtimeSinceStartup;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == player.name)
        {
            transitionTimer = 1;
            xDist = transform.position.x - cam.transform.position.x;
            yDist = transform.position.y - cam.transform.position.y;
        }
    }
}
