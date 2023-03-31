using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FlappyBird
{
    public class PipeSpawn : MonoBehaviour
    {
        public float maxTime = 1;
        private float _timer = 0;
        public GameObject pipe;
        public float height;

        // Start is called before the first frame update
        void Start()
        {
            GameObject newPipe = Instantiate(pipe) ?? throw new ArgumentNullException("Instantiate(pipe)");
            newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        }

        // Update is called once per frame
        void Update()
        {
            if (_timer > maxTime)
            {
                GameObject newPipe = Instantiate(pipe);
                newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
                Destroy(newPipe, 15);
                _timer = 0;
            }
            _timer += Time.deltaTime;
        }
    }
}
