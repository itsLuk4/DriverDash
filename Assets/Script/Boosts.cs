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
    private bool hasPackage;

    private void Awake()
    {
        car = GetComponent<TopDownCarController>();
        originalFactor = car.accelerationFactor;
        originalMaxSpeed = car.maxSpeed;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Boost") && !hasPackage)
        {
            Debug.Log("Speed boost collected!");
            hasPackage = true;
            Destroy(collision.gameObject);
            GetComponent<ParticleSystem>().Play();
            // ---------- Apply boost ----------
            car.accelerationFactor *= boostMultiplier;
            car.maxSpeed *= boostMultiplier;
            Invoke(nameof(ResetBoost), boostDuration); // Calls "ResetBoost" after the given number of seconds without needing a coroutine
        }

        //if (collision.CompareTag("Customer") && hasPackage)
        //{
        //    Debug.Log("This also working!");
        //    hasPackage = false;
        //}
    }
    private void ResetBoost()
    {
        if (car != null)
        {
            car.accelerationFactor = originalFactor;
            car.maxSpeed = originalMaxSpeed;
            hasPackage = false; // allow next pickup
        }
    }

}
