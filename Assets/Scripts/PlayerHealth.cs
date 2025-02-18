using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required for working with UI components

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // Player's health
    public Text healthText; // Reference to the UI Text element displaying health

    private void Start()
    {
        // Make sure the health UI text is initialized
        UpdateHealthUI();
    }

    private void Update()
    {
        // Here we continuously update the health UI
        UpdateHealthUI();
    }

    // Method to handle taking damage (e.g., when colliding with enemies)
    public void TakeDamage(int damage)
    {
        health -= damage;

        // Prevent health from going below 0
        if (health < 0)
        {
            health = 0;
        }

        // Update the health UI after taking damage
        UpdateHealthUI();
    }

    // Method to update the health text UI
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + health.ToString(); // Update the health UI text
        }
    }
}

