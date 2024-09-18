using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneSwitchSpeed = 5f;
    public float jumpForce = 7f;
    public LayerMask groundLayer;

    private int currentLane = 1;
    private readonly float[] lanePositions = { -7.5f, 0f, 7.5f };
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
        {
            currentLane++;
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        Move();
    }

    void Move()
    {
        float targetX = lanePositions[currentLane];

        Vector3 targetPosition = new(targetX, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime);

        rb.MovePosition(targetPosition);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);
    }
}
