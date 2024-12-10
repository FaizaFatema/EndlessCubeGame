
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    private float minSwipeDistance = 5f;


    float horizontalValue = 0;

    public float HorizontalValue => horizontalValue;


    private float screenWidth;  // Screen width
    private float touchDuration;
    private const float maxTouchDuration = 2f;  // Max time for full value (-1 or 1)


    void Start()
    {
        screenWidth = Screen.width;
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                touchDuration = 0;
            }
            else if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // Increment touch duration
                touchDuration += Time.deltaTime;

                // Determine whether the touch is on the left or right side of the screen
                if (touchPosition.x < screenWidth / 2)
                {
                    horizontalValue = Mathf.Clamp(-touchDuration / maxTouchDuration, -1, 0); // Left side
                }
                else
                {
                    horizontalValue = Mathf.Clamp(touchDuration / maxTouchDuration, 0, 1); // Right side
                }
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                touchDuration = 0;
                horizontalValue = 0; // Reset
            }
        }
        // Use horizontalAxis value (for debugging or gameplay mechanics)
        Debug.Log("Horizontal Value: " + horizontalValue);
    }
}



//public float HorizontalInput()
//{
//    return swipeDirection.x;
//}

