using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Scotty! We have been hit!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("We hit something, Scotty!");
    }
}
