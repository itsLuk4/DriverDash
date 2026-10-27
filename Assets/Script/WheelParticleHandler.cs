using UnityEngine;

public class WheelParticleHandler : MonoBehaviour
{
    [SerializeField] float particleEmissionRate = 0;

    TopDownCarController topDownCarController;
    ParticleSystem particleSystemSmoke;
    ParticleSystem.EmissionModule particleSystemEmissionModule;

    void Awake()
    {
        
        topDownCarController = GetComponentInParent<TopDownCarController>();

        particleSystemSmoke = GetComponentInParent<ParticleSystem>();

        // ---- get emission component ----
        particleSystemEmissionModule = particleSystemSmoke.emission;

        // ---- set it to zero emission ----
        particleSystemEmissionModule.rateOverTime = 0;
    }

    private void Update()
    {
        // ---- reduces the particles over time ----
        particleEmissionRate = Mathf.Lerp(particleEmissionRate, 0, Time.deltaTime * 5);
        particleSystemEmissionModule.rateOverTime = particleEmissionRate;

        if (topDownCarController.IsTireScreeching(out float lateralVelocity, out bool isBraking))
        {
            // ---- if the car tires are screeching then we'll emitt smoke. If the player is braking then emitt a lot of smoke ----
            if (isBraking)
            {
                particleEmissionRate = 30;
            }
            // ---- if the player is drifting emitt smoke based on how much the player is drifting
            else
            {
                particleEmissionRate = Mathf.Abs(lateralVelocity) * 20;
            }
        }
    }
}
