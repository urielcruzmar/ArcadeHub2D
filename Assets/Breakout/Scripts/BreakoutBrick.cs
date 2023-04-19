using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Breakout.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BreakoutBrick : MonoBehaviour
    {
        [SerializeField] public int hits;
        [SerializeField] private Sprite[] sprites;
        [SerializeField] public bool unbreakable;
        [SerializeField] public bool special;
        [SerializeField] private new SpriteRenderer renderer;
        [SerializeField] private GameManagerBreakout managerBreakout;

        // Start is called before the first frame update
        void Start()
        {
            renderer = GetComponent<SpriteRenderer>();
            if (!unbreakable && !special)
            {
                renderer.sprite = sprites[hits];
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        // Return true if destroyed
        private bool OnHit()
        {
            if (special)
            {
                managerBreakout.PowerUp();
                return false;
            }
            
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
