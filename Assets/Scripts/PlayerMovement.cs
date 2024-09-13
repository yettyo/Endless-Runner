using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float strafeSpeed = 4f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    private Rigidbody rb;
    
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        Move(horizontalInput);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    void Move(float horizontalInput)
    {
        Vector3 forwardMovement = forwardSpeed * Time.deltaTime * Vector3.forward;

        Vector3 strafeMovement = horizontalInput * strafeSpeed * Time.deltaTime * Vector3.right;

        Vector3 totalMovement = forwardMovement + strafeMovement;

        rb.MovePosition(transform.position + totalMovement);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }    
}
