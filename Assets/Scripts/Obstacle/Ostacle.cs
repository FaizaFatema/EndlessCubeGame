using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ostacle : MovingObstacle
{
    private Vector3 startingPosition;

    private bool movingRight = true;

    private void  Start()
    {
        startingPosition = transform.position;
    }
    private void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x > startingPosition.x + movementRange)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
            if (transform.position.x < startingPosition.x - movementRange)
            {
                movingRight = true;
            }
        }


    }
}
