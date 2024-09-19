using System;
using UnityEngine;
using DG.Tweening;  // Include DOTween namespace

public class CharacterMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneSwitchSpeed = 0.5f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;

    private int currentLane = 1;
    private readonly float[] lanePositions = { -7.5f, 0f, 7.5f };
    private Rigidbody rb;
    private bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        if (!canMove) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
            SwitchLane();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
        {
            currentLane++;
            SwitchLane();
        }

    
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        MoveForward();
    }

    void SwitchLane()
    {
        float targetX = lanePositions[currentLane];

        transform.DOMoveX(targetX, laneSwitchSpeed).SetEase(Ease.OutExpo);
    }

    void MoveForward()
    {
        Vector3 forwardMove = new(transform.position.x, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime);
        transform.position = forwardMove;
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }

    public void StopMovement()
    {
        canMove = false;
        rb.velocity = Vector3.zero;
    }
}
