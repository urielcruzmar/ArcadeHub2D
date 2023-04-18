using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Breakout.Scripts
{
    public class BreakoutBrick : MonoBehaviour
    {
        [SerializeField] public int hits = 3;
        [SerializeField] private Sprite[] sprites;
        [SerializeField] public bool unbreakable;
        [SerializeField] private SpriteRenderer renderer;

        // Start is called before the first frame update
        void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = sprites[hits];
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        // Return true if destroyed
        private bool OnHit()
        {
            if (!unbreakable)
            {
                hits--;
                bool isAlive = hits >= 0;
                if (isAlive)
                {
                    renderer.sprite = sprites[hits];
                }
                return isAlive;
            }
            return true;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (!OnHit())
            {
                Destroy(this.gameObject);
            }
        }
    }
}
