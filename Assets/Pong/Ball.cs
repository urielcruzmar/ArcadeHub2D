using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
    
    private Rigidbody2D ballRb;
    
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody2D>();
    }
    
    public void Launch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Paddle"))
        {
            ballRb.velocity *= velocityMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Goal1"))
        {
            ballRb.velocity = new Vector2(0, 0);
            GameManager.Instance.Paddle2Scored();
            GameManager.Instance.Restart();
        }

        if (col.gameObject.CompareTag("Goal2"))
        {
            ballRb.velocity = new Vector2(0, 0);
            GameManager.Instance.Paddle1Scored();
            GameManager.Instance.Restart();
        }
    }
}
