using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileInput : MonoBehaviour
{
    private Vector2 touchStartPosition;
    private Vector2 touchEndPosition;
    private float minSwipeDistance = 5f;
    private bool isJumping = false;

    float horizontalValue = 0;

    public float HorizontalValue => horizontalValue;
    public bool IsJumping => isJumping;


    private float screenWidth; 
    private float touchDuration;
    private const float maxTouchDuration = 2f;  
 
    private bool jumpSoundPlayed = false;

    public Button jumpButton;

    void Start()
    {
        screenWidth = Screen.width;
        if (jumpButton != null)
        {
            jumpButton.onClick.AddListener(OnJumpButtonPressed);
        }
    }

    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            //switch (touch.phase)
            //{
            //    case TouchPhase.Began:

            //        touchStartPosition = touchPosition;
            //        touchDuration = 0;
            //        isJumping = false;
            //        jumpSoundPlayed = false;
            //        break;
            //    case TouchPhase.Moved:
            //    case TouchPhase.Stationary:
            //        touchDuration += Time.deltaTime;
            //        if (touchPosition.x < screenWidth / 2)
            //        {
            //            horizontalValue = Mathf.Clamp(-touchDuration / maxTouchDuration, -1, 0); // Left side
            //        }
            //        else
            //        {
            //            horizontalValue = Mathf.Clamp(touchDuration / maxTouchDuration, 0, 1); // Right side
            //        }
            //        break;
            //    case TouchPhase.Ended:
            //        touchEndPosition = touchPosition;
            //        DetectSwipe(touchStartPosition, touchEndPosition);
            //        horizontalValue = 0;
            //        touchDuration = 0;
            //        break;

            //    case TouchPhase.Canceled:

            //        horizontalValue = 0;
            //        touchDuration = 0;
            //        isJumping = false;
            //        break;
            //}
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchDuration = 0;
                    break;
                case TouchPhase.Moved:
                case TouchPhase.Stationary:
                    touchDuration += Time.deltaTime;
                    if (touchPosition.x < screenWidth / 2)
                    {
                        horizontalValue = Mathf.Clamp(-touchDuration / maxTouchDuration, -1, 0); // Left side
                    }
                    else
                    {
                        horizontalValue = Mathf.Clamp(touchDuration / maxTouchDuration, 0, 1); // Right side
                    }
                    break;
                case TouchPhase.Ended:
                    horizontalValue = 0;
                    touchDuration = 0;
                    break;

                case TouchPhase.Canceled:
                    horizontalValue = 0;
                    touchDuration = 0;
                    break;
            }
        }
       
    }
    //private void DetectSwipe(Vector2 start, Vector2 end)
    //{
    //    Vector2 swipeVector = end - start;

    //    // Calculate the swipe distance
    //    if (swipeVector.magnitude >= minSwipeDistance)
    //    {

    //        if (swipeVector.y > Mathf.Abs(swipeVector.x)) 
    //        {
    //            //canMoveHorizontally = false;
    //            isJumping = true;
    //            if (!jumpSoundPlayed)
    //            {

    //                jumpSoundPlayed = true; // Set the flag to true to prevent the sound from playing again
    //            }
    //            StartCoroutine(EndJumpAfterDelay());
    //        }
    //    }
    //}
    private void OnJumpButtonPressed()
    {
        if (!isJumping)
        {
            isJumping = true; // Trigger jump
            if (!jumpSoundPlayed)
            {
                jumpSoundPlayed = true; // Prevent jump sound from being played multiple times
                // Play the jump sound here if you want to
            }
            StartCoroutine(EndJumpAfterDelay()); // End the jump after a delay
        }
    }
    private IEnumerator EndJumpAfterDelay()
    {
        yield return new WaitForSeconds(1f); 
        isJumping = false;
       
      
    }
  
}
