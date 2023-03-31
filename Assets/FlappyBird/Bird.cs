using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float Speed = 1;
    private Rigidbody2D BirdRigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        BirdRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Bird jump
        if (Input.GetMouseButtonDown(0))
        {
            BirdRigidbody2D.velocity = Vector2.up * Speed;
        }
    }
}
