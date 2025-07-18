using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol Settings")]
    public float speed = 2f;           // Patrol speed
    public float patrolDistance = 3f;  // Distance to patrol from start point

    [Header("Components")]
    public SpriteRenderer spriteRenderer; // Assign in Inspector!

    private Vector3 startPoint;
    private bool movingRight = true;

    void Start()
    {
        startPoint = transform.position;

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Patrol();
        FlipSprite();
    }

    void Patrol()
    {
        float move = speed * Time.deltaTime * (movingRight ? 1 : -1);
        transform.Translate(Vector2.right * move);

        if (movingRight && transform.position.x >= startPoint.x + patrolDistance)
            movingRight = false;
        else if (!movingRight && transform.position.x <= startPoint.x - patrolDistance)
            movingRight = true;
    }

    void FlipSprite()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = movingRight;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<GameOverOnCollision>().GameOver();
        }
    }
}
