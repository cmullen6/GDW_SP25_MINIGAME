using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public int damage = 10; // The amount of damage the projectile deals
    public float speed = 10f;
    public float lifetime = 5f;

    void Start()
    {
        Destroy(gameObject, lifetime); // Destroy the projectile after a set time
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime); // Move the projectile upwards
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the projectile collides with an object tagged "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Get the EnemyController component attached to the enemy
            EnemyController enemy = other.GetComponent<EnemyController>();

            if (enemy != null)
            {
                // Apply damage to the enemy
                enemy.TakeDamage(damage);
            }

            // Destroy the enemy and the projectile
            Destroy(other.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the projectile
        }
    }
}
