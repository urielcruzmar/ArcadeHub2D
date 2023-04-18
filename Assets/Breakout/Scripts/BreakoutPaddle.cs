using UnityEngine;

namespace Breakout.Scripts
{
    public class BreakoutPaddle : MonoBehaviour
    {
        [SerializeField] private float speed = 7f;

        private float _movementHorizontal;
        private const int XBound = 8;

        // Update is called once per frame
        void Update()
        {
            _movementHorizontal = Input.GetAxisRaw("Horizontal");
            transform.position += Vector3.right * (_movementHorizontal * speed * Time.deltaTime);
            
            Vector2 paddlePosition = transform.position;
            paddlePosition.x = Mathf.Clamp(paddlePosition.x + _movementHorizontal * speed * Time.deltaTime, -XBound, XBound);
            transform.position = paddlePosition;
        }

    }
}
