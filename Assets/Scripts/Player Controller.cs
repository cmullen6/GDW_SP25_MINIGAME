using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveDirection;
    private SpriteRenderer spriteRenderer;

    public GameObject projectilePrefab;  // Reference to the projectile prefab
    public float projectileSpeed = 10f; // Speed of the projectile
    public float maxProjectileDistance = 15f; // Maximum distance before despawning

    public float minX = -10f;  // Minimum x position
    public float maxX = 10f;   // Maximum x position

    void Start()
    {
        // Get the SpriteRenderer component to flip the sprite
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get player input for movement (WASD / Arrow keys)
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        //moveDirection.y = Input.GetAxisRaw("Vertical");

        // Normalize the movement direction
        moveDirection.Normalize();

        // Flip the sprite based on movement direction (reversed)
        if (moveDirection.x > 0)
        {
            spriteRenderer.flipX = true;  // Face left
        }
        else if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = false; // Face right
        }

        // Move the player based on input
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Clamp the player's position within the minX and maxX boundaries
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // Shooting the projectile
        if (Input.GetKeyDown(KeyCode.Space))  // Assuming Space bar to shoot
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        // Create the projectile at the player's position and facing direction
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Check which way the player is facing and shoot accordingly
        if (moveDirection.x > 0) // Player is facing right (moving right)
        {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0); // Shoot right
        }
        else if (moveDirection.x < 0) // Player is facing left (moving left)
        {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0); // Shoot left
        }
        else
        {
            // If the player is not moving horizontally (standing still), shoot based on sprite direction
            if (spriteRenderer.flipX)
            {
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0); // Shoot left
            }
            else
            {
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0); // Shoot right
            }
        }

        // Set up a timer or max distance check for despawning the projectile
        Destroy(projectile, maxProjectileDistance / projectileSpeed); // Destroy after reaching max distance
    }
}
