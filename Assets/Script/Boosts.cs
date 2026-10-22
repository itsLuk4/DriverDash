using System;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class Boosts : MonoBehaviour
{
    [Header("Boost Settings")]
    public float boostMultiplier = 1.5f; // how much faster
    public float boostDuration = 3f; //seconds

    [Header("Components")]
    private TopDownCarController car;

    [Header("Other")]
    private float originalFactor;
    private float originalMaxSpeed;
    private bool hasBoost;

    private void Awake()
    {
        car = GetComponent<TopDownCarController>();
        originalFactor = car.accelerationFactor;
        originalMaxSpeed = car.maxSpeed;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Boost") && !hasBoost)
        {
            Debug.Log("Speed boost collected!");
            hasBoost = true;
            Destroy(collision.gameObject);
            GetComponent<ParticleSystem>().Play();

            // ---------- Apply boost ----------
            car.accelerationFactor *= boostMultiplier;
            car.maxSpeed *= boostMultiplier;

            // ---------- Play sounds ----------
            SoundManager.Instance.PlayCollectibleSounds();

            /* ---------- Calls "ResetBoost" after the given number of 
               seconds without needing a coroutine ----------       */
            Invoke(nameof(ResetBoost), boostDuration); 
        }
    }
    private void ResetBoost()
    {
        if (car != null)
        {
            car.accelerationFactor = originalFactor;
            car.maxSpeed = originalMaxSpeed;
            // ---------- Allow next pickup ----------
            hasBoost = false; 
        }
    }

}
