using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class TopDownCarController : MonoBehaviour
{
    
    
    [Header("Speed")]
    float accelerationInput = 0;
    public float accelerationFactor = 30f;
    public float maxSpeed = 20;

    [Header("Audio")]
    [SerializeField] SoundManager soundManager;

    [Header("Steering")]
    // Local variables
    [SerializeField] float driftFactor = 0.95f;
    float steeringInput = 0;
    [SerializeField] float turnFactor = 3.5f;
    float rotationAngle = 0;
    float velocityVsUp = 0;

    // Components
    [Header("Components")]
    Rigidbody2D carRigidbody2D;

    // ---- Awake is called when the script instance is being loaded ---- 
    private void Awake()
    {
        carRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // ---- Start is called once before the first execution of Update after the MonoBehaviour is created ---- 
    void Start()
    {
        
    }

    void FixedUpdate()
    {

        ApplyEngineForce();

        KillOrthogonalVelocity();

        ApplySteering();

    }



    void ApplyEngineForce()
    {

        // ---- Engine sounds logic ----
        if (soundManager != null)
        {
            if (accelerationInput != 0 && !soundManager.IsEnginePlaying())
            {
                soundManager.StartEngineSound();
            }
            else if (accelerationInput == 0 && soundManager.IsEnginePlaying())
            {
                soundManager.StopEngineSound();
            }
        }

        // ---- Calculate how much "forward" we are going in terms of the direction of our velocity ---- 
        velocityVsUp = Vector2.Dot(transform.up, carRigidbody2D.linearVelocity);

        // ---- Limit so we cannot go faster than the max speed in the "forward" direction ---- 
        if (velocityVsUp > maxSpeed && accelerationInput > 0)
        {
            return;
        }

        // ---- Limit so we cannot go faster than the 30% of max speed in the "reverse" direction ---- 
        if (velocityVsUp < -maxSpeed * 0.3f && accelerationInput < 0)
        {
            return;
        }

        // ---- Limit so we cannot go faster in any direction while accelerating ---- 
        if (carRigidbody2D.linearVelocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
        {
            return;
        }

        // ---- Apply drag if there is no accelerationInput so the car stops when the player lets go of the accelerator ---- 
        if (accelerationInput == 0)
        {
            carRigidbody2D.linearDamping = Mathf.Lerp(carRigidbody2D.linearDamping, 3.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            carRigidbody2D.linearDamping = 0;
        }


        // ---- Create a force for the engine ----
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        // Applay force and pushe the car forward
        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);

        
    }

    void ApplySteering()
    {
        // ---- Limit the cars ability to turn when moving slowly ---- 
        float minSpeedBeforeAllowTurningFactor = (carRigidbody2D.linearVelocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        // ---- Update the rotation angle based on input ---- 
        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;

        // ---- Apply steering by rotating the car object ---- 
        carRigidbody2D.MoveRotation(rotationAngle);
    }

    void KillOrthogonalVelocity()
    {
        // ---- calculates how much forward velocity the car has; by taking the transform up with te Vetor.Dot  ---- 
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2D.linearVelocity, transform.up);
        // ---- calculates how much right velocity the car has; by taking the transform up with te Vetor.Dot ---- 
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.linearVelocity, transform.right);

        // the result formula
        carRigidbody2D.linearVelocity = forwardVelocity + rightVelocity * driftFactor;
    }

    float GetLateralVelocity()
    {
        // ---- Returns how fast the car is moving sideways  ----
        return Vector2.Dot(transform.right, carRigidbody2D.linearVelocity);
    }

    public bool IsTireScreeching(out float lateralVelocity, out bool isBraking)
    {
        lateralVelocity = GetLateralVelocity();
        isBraking = false;

        // ---- Checking if player is moving forward and if the player is hittings the brakes. In that case the tires should screech ----
        if (accelerationInput < 0 && velocityVsUp > 0)
        {
            isBraking = true;
            return true;
        }
        
        // ---- if player has a lot of side movement then the tires should be screeching ----
        if (Mathf.Abs(GetLateralVelocity()) > .2f)
        {
            return true;
        }

        return false;

    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }


}
