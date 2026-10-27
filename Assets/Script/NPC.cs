using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Animator animator;

    [Header("Settings")]
    private bool hasReceivedPackage = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ---------- Check if player (with Package component) collides with this NPC ----------
        Package playerPackage = collision.GetComponent<Package>();

        if (playerPackage != null && playerPackage.hasPackage && !hasReceivedPackage)
        {
            DeliverPackage(playerPackage);
        }
    }

    private void DeliverPackage(Package playerPackage)
    {
        Debug.Log("Package delivered to NPC");

        // ---------- Mark NPC as having received package ----------
        hasReceivedPackage = true;
        animator.SetBool("hasPackage", true);

        // ---------- Remove package from player ----------
        playerPackage.hasPackage = false;
    }
}
