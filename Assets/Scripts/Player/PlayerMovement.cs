using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float horizontalSpeed;

    [SerializeField] float minX;
    [SerializeField] float maxX;


    public void Move(Vector3 inputVector)
    {
        inputVector  = inputVector.normalized;
        inputVector *= Time.deltaTime;
        transform.position += new Vector3(horizontalSpeed * inputVector.x, horizontalSpeed * inputVector.y,
            10*Time.deltaTime) ;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x,minX,maxX),
            transform.position.y,
            transform.position.z);


    }
}
