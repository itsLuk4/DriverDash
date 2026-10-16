using UnityEngine;

public class TopDownCarController : MonoBehaviour
{
    [Header("Car Settings")]

    // this will be use for drifting
    [SerializeField] float driftFactor = 0.95f;
    public float accelerationFactor = 30f;
    [SerializeField] float turnFactor = 3.5f;
    public float maxSpeed = 20;

    // Local variables
    float accelerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;
    float velocityVsUp = 0;
    // Components
    Rigidbody2D carRigidbody2D;

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        carRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
        // Calculate how much "forward" we are going in terms of the direction of our velocity (
        velocityVsUp = Vector2.Dot(transform.up, carRigidbody2D.linearVelocity);

        // Limit so we cannot go faster than the max speed in the "forward" direction
        if (velocityVsUp > maxSpeed && accelerationInput > 0)
        {
            return;
        }

        // Limit so we cannot go faster than the 30% of max speed in the "reverse" direction
        if (velocityVsUp < -maxSpeed * 0.3f && accelerationInput < 0)
        {
            return;
        }

        // Limit so we cannot go faster in any direction while accelerating
        if (carRigidbody2D.linearVelocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
        {
            return;
        }

        // Apply drag if there is no accelerationInput so the car stops when the player lets go of the accelerator
        if (accelerationInput == 0)
        {
            carRigidbody2D.linearDamping = Mathf.Lerp(carRigidbody2D.linearDamping, 3.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            carRigidbody2D.linearDamping = 0;
        }


        // Create a force for the engine
        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;

        // Applay force and pushe the car forward
        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        // Limit the cars ability to turn when moving slowly
        float minSpeedBeforeAllowTurningFactor = (carRigidbody2D.linearVelocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        // Update the rotation angle based on input
        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;

        // Apply steering by rotating the car object
        carRigidbody2D.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    void KillOrthogonalVelocity()
    {
        // calculates how much forward velocity the car has; by taking the transform up with te Vetor.Dot
        Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2D.linearVelocity, transform.up);
        // calculates how much right velocity the car has; by taking the transform up with te Vetor.Dot
        Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.linearVelocity, transform.right);

        // the result formula
        carRigidbody2D.linearVelocity = forwardVelocity + rightVelocity * driftFactor;
    }
}
