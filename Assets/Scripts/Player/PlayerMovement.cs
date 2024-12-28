using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SoundManager soundManager;

    [SerializeField]
    private float horizontalSpeed;

    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float gravityScale = 2f;
    private bool isGrounded;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        soundManager.PlayBackgroundMusic();
    }

    public void Move(Vector3 inputVector, bool isJumping)
    {
        inputVector = inputVector.normalized;
        inputVector *= Time.deltaTime;

        transform.position += new Vector3(horizontalSpeed * inputVector.x, horizontalSpeed * inputVector.y,
            10 * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y,
            transform.position.z);

        if (isJumping && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            soundManager.PlayJumpSound();
        }
        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * gravityScale, ForceMode.Acceleration);
        }

    }
    private void OnCollisionStay(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}