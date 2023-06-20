using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4.5f;
    public float jumpForce = 5f; // Set an appropriate value for jumpForce
    public Rigidbody rb;
    public Animator animator;
    private float idleTimer = 1f; // Make the animation start when scene starts
    private bool isMoving = false;

    void Update()
    {
        // Rotate the player to match the camera's rotation
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);

        // Move the player in the forward direction based on the input
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = (transform.forward * verticalInput * speed) * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        isMoving = Mathf.Abs(verticalInput) > 0;
        Debug.Log(Mathf.Abs(verticalInput) > 0);

        animator.SetFloat("Running", Mathf.Abs(verticalInput * speed));
        animator.SetBool("Idle", !isMoving);
        Debug.Log(animator.GetFloat("Running"));

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }
}
