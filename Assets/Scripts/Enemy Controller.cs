using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f; // Movement speed of the enemy
    public int health = 50; // Health of the enemy
    public Transform player;  // Reference to the player's transform
    public float followRange = 30f; // Maximum distance at which the enemy starts moving towards the player
    public int damage = 10; // Damage dealt to the player when they collide

    private void Start()
    {
        // Find the player in the scene (or you could manually assign the player)
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the distance from the enemy to the player
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Only move if the player is within the follow range
            if (distanceToPlayer <= followRange)
            {
                MoveTowardsPlayer();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction to the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Move the enemy towards the player at the specified speed
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    // Method to handle damage to the enemy
    public void TakeDamage(int damage)
    {
        health -= damage; // Subtract the damage from the enemy's health

        // Check if the enemy's health reaches 0 and destroy it
        if (health <= 0)
        {
            Die();
        }
    }

    // Method to handle enemy death
    void Die()
    {
        // Destroy the enemy gameObject when health is zero or less
        Destroy(gameObject);
    }

    // Method to handle collisions with the player (deals damage)
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Deal damage to the player
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}





