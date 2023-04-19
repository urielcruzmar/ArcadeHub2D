using Pong;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Breakout.Scripts
{
    public class BreakoutBall : MonoBehaviour
    {
        private Rigidbody2D _ballRb;
        [SerializeField] private float initialVelocity = 4f;
        [SerializeField] private float velocityMultiplier = 1.1f;
        [SerializeField] private Transform player;

        [SerializeField] public AudioSource source;
        [SerializeField] public AudioClip paddleHitSound;
        [SerializeField] public AudioClip wallHitSound;
        [SerializeField] public AudioClip brickSound;
        [SerializeField] public AudioClip loseSound;
        [SerializeField] public AudioClip victorySound;

        // Start is called before the first frame update
        void Start()
        {
            _ballRb = GetComponent<Rigidbody2D>();
        }
    
        public void Launch()
        {
            var position = player.position;
            transform.position = new Vector3(position.x, (position.y + 1), position.z);
            float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
            float yVelocity = 1;
            _ballRb.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Paddle"))
            {
                source.PlayOneShot(paddleHitSound);
            }

            if (col.gameObject.CompareTag("Wall"))
            {
                source.PlayOneShot(wallHitSound);
            }

            if (col.gameObject.CompareTag("Brick"))
            {
                source.PlayOneShot(brickSound);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Goal1"))
            {
                _ballRb.velocity = new Vector2(0, 0);
                source.PlayOneShot(loseSound);
                GameManagerBreakout.Instance.LoseLife();
            }
        }
    }
}
