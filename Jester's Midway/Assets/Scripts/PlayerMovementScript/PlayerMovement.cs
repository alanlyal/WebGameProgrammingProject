using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float airControl = 0.5f;

    [Header("Jump")]
    public float jumpForce = 6f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private float x, z;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // prevents tipping over
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // reset vertical velocity so jump feels consistent
            Vector3 v = rb.linearVelocity;
            v.y = 0f;
            rb.linearVelocity = v;

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        Vector3 inputDir = new Vector3(x, 0f, z).normalized;
        Vector3 desired = inputDir * moveSpeed;

        float control = isGrounded ? 1f : airControl;

        // Keep current Y velocity, only steer XZ
        Vector3 velocity = rb.linearVelocity;
        Vector3 targetVel = new Vector3(desired.x, velocity.y, desired.z);

        rb.linearVelocity = Vector3.Lerp(velocity, targetVel, control);
    }
}