using System;
using UnityEngine;

namespace FlappyBird
{
    public class Ground : MonoBehaviour
    {
        public float maxTime = 1;
        private float _timer = 0;
        public GameObject ground;
        public float height;

        // Start is called before the first frame update
        void Start()
        {
            GameObject newGround = Instantiate(ground) ?? throw new ArgumentNullException("Instantiate(ground)");
            newGround.transform.position = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (_timer > maxTime)
            {
                GameObject newGround = Instantiate(ground);
                newGround.transform.position = transform.position;
                Destroy(ground, 15);
                _timer = 0;
            }
            _timer += Time.deltaTime;
        }
    }
}
