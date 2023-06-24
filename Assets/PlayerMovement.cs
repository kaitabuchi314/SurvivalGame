using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4.5f;
    public float jumpForce = 3f; // Adjust the jumpForce value for a more realistic jump
    public Rigidbody rb;
    public Animator animator;
    private float idleTimer = 1f; // Make the animation start when the scene starts
    private bool isMoving = false;
    private bool isGrounded = true; // Check if the player is on the ground

    void Update()
    {
        // Rotate the player to match the camera's rotation
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);

        // Move the player in the forward direction based on the input
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = (transform.forward * verticalInput * speed) * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        isMoving = Mathf.Abs(verticalInput) > 0;

        animator.SetFloat("Running", Mathf.Abs(verticalInput * speed));
        animator.SetBool("Idle", !isMoving);

        if (isGrounded && Input.GetButtonDown("Jump")) // Check if player is on the ground and jump button is pressed
        {
            Vector3 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
            isGrounded = false; // Player is no longer on the ground
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Player is on the ground
        }
    }
}