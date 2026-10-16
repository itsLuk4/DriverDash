using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = .5f;
    bool hasPackage;
    TopDownCarController carController;
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Its working!");
            hasPackage = true;
            // get component will help in getting in this situation Particle System
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, destroyDelay);
            carController = GetComponent<TopDownCarController>();
            carController.accelerationFactor = 8f;
            carController.maxSpeed = 5f;
          

        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("This also working!");
            hasPackage = false;
        }
    }

}
