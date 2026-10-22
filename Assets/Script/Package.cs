using UnityEngine;

public class Package : MonoBehaviour
{
    bool hasPackage;
    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Customer"))
        {
            Debug.Log("This also working!");
            hasPackage = false;
        }
    }

}

