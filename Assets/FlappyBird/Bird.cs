using UnityEngine;

namespace FlappyBird
{
    public class Bird : MonoBehaviour
    {
        public float speed = 1;
        private Rigidbody2D _birdRigidbody2D;
    
        // Start is called before the first frame update
        void Start()
        {
            _birdRigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            // Bird jump
            if (Input.GetMouseButtonDown(0))
            {
                _birdRigidbody2D.velocity = Vector2.up * speed;
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Ground") || col.CompareTag("Pipe"))
            {
                GameManagerFlappyBird.Instance.Die();
            }

            if (col.CompareTag("Goal1"))
            {
                GameManagerFlappyBird.Instance.Score();
            }
        }
    }
}
