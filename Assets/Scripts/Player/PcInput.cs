using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PcInput:MonoBehaviour
{
    private bool isJumping = false;
    
    float horizontalValue = 0;

    public float HorizontalValue => horizontalValue;
    public bool IsJumping => isJumping;

    public SoundManager soundManager;

    public void Update()
    {
        horizontalValue = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {

            isJumping = true;
        }
        else
        {

            isJumping = false;
        }
    }
   
}