
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    private float minSwipeDistance = 5f;


    Vector2 swipeDirection;

    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                touchEndPosition = touch.position;
                DetectSwipeDirection();
            }

        }
    }
    public void DetectSwipeDirection()
    {
        float swipeDistance = (touchEndPosition - touchStartPosition).magnitude;
        if (swipeDistance >= minSwipeDistance)
        {
             swipeDirection = touchEndPosition - touchStartPosition;

            // Determine swipe direction (up, down, left, right)
            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y)) // Horizontal swipe
            {
                //if (swipeDirection.x > 0)
                //{
                //    // Swipe right
                //    MovePlayerRight();

                //}
                //else
                //{
                //    MovePlayerLeft();
                //}
            }
            else // Vertical swipe
            {
                if (swipeDirection.y > 0)
                {
                    // Swipe up
                    Debug.Log("Swipe Up");
                }
                else
                {
                    // Swipe down
                    Debug.Log("Swipe Down");
                }
            }

        }
        swipeDirection = Vector2.zero;
    }


    public float HorizontalInput()
    {
        return swipeDirection.x;
    }
}
