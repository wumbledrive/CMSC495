using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour
{
    public Rigidbody2D rb;
    public float scrollSpeed;

    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(scrollSpeed,0f);
    }

    void Update()
    {
        rb.velocity = new Vector2(scrollSpeed, 0f);
    }
}