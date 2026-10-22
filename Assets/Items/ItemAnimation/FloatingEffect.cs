using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    public float speed = 1.5f;
    public float height = 0.045f;

    private Vector2 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector2(transform.position.x, newY);
    }
}
