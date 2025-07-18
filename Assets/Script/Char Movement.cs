using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] public SpriteRenderer spriteRenderer;
    public float speed = 5.0f; // Movement speed
    public float jumpForce = 5.0f; // Force applied for jumping
    private Animator animator;
    private Rigidbody2D rb;

    private int jumpCount = 0; // Tracks the number of jumps made
    private bool isGrounded = false; // Checks if the player is on the ground

    public Transform groundCheck; // Reference to a point near the player's feet
    public LayerMask groundLayer; // Layer mask for the ground
    //Awake -> Start -> Update -> LateUpdate
    void Start()
    {
        animator = GetComponent<Animator>(); // Initialize animator
        rb = GetComponent<Rigidbody2D>(); // Initialize Rigidbody2D
    }

    void Update()
    {
        //Vertical , horizontal
        float moveHorizontal = Input.GetAxis("Horizontal"); // (-1,1)
        Vector2 movement = new Vector2(moveHorizontal * speed, rb.velocity.y);
        rb.velocity = movement;
        bool isMoving = moveHorizontal != 0;
        animator.SetBool("isMoving", isMoving);

        if (moveHorizontal > 0) spriteRenderer.flipX = true;
        else if (moveHorizontal < 0) spriteRenderer.flipX = false;

        if (isMoving)
        {
            transform.position += new Vector3(moveHorizontal * speed * Time.deltaTime, 0f, 0f);
        }

        // Check for jump input
        if (Input.GetButtonDown("Jump") && jumpCount < 2)
        {
            Jump();
        }

        // Update grounded state
        CheckIfGrounded();
    }
    //Collider 2
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.CompareTag("Ground"))
        {
          jumpCount = 0;
        }

    }


    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Apply vertical velocity
        jumpCount++; // Increment jump count
        animator.SetTrigger("Jump"); // Trigger jump animation
    }

    void CheckIfGrounded()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0; // Reset jump count when on the ground
        }

        
    }

}