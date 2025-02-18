using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;  // Damage value to be assigned by the player or the projectile itself

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the projectile hits an object with the "Enemy" tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }

        // Destroy the projectile after the collision (whether it's hitting an enemy or not)
        Destroy(gameObject);
    }
}
