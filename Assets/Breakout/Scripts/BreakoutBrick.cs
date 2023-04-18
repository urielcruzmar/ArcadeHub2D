using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Breakout.Scripts
{
    public class BreakoutBrick : MonoBehaviour
    {
        [SerializeField] private int hits = 3;
        [SerializeField] private Sprite[] sprites;
        private SpriteRenderer _renderer;

        // Start is called before the first frame update
        void Start()
        {
            _renderer.sprite = sprites[hits];
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        // Get hits
        public int GetRemainingHits()
        {
            return hits;
        }

        // Return true if destroyed
        private bool OnHit()
        {
            hits--;
            bool isAlive = hits > 0;
            if (isAlive)
            {
                _renderer.sprite = sprites[hits];
            }
            return isAlive;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            OnHit();
        }
    }
}
