using UnityEngine;

public class Package : MonoBehaviour
{
    [Header("Package Settings")]
    internal bool hasPackage;
    [SerializeField] float delay = .5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ---------- Only handles package pickup ----------
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Picked up package");
            hasPackage = true;
            Destroy(collision.gameObject, delay);

        }
    }
}

