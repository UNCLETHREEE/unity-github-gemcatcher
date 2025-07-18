using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPickup : MonoBehaviour
{
    public float speedMultiplier = 2f; // Multiplier to speed up the game
    public float boostDuration = 5f; // Duration of the speed boost in seconds

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player picked up the speed boost
        if (other.CompareTag("Booster"))
        {
             
            StartCoroutine(ActivateSpeedBoost());
            Destroy(gameObject); // Destroy the pickup object after use
        }
    }

    private IEnumerator ActivateSpeedBoost()
    {
        // Increase the game's speed
        Time.timeScale *= speedMultiplier;
        
         
        // Wait for the boost duration
        yield return new WaitForSecondsRealtime(boostDuration);

        // Reset the game's speed
        Time.timeScale /= speedMultiplier;
    }
}