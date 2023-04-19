using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Image = UnityEngine.UI.Image;

namespace Breakout.Scripts
{
    public class GameManagerBreakout : MonoBehaviour
    {
        private bool _pausedOnLose = false;
        private bool _pausedOnDie = false;
        private int _health;
        [SerializeField] private int maxHealth = 3;
        [SerializeField] private Transform health;
        [SerializeField] private Sprite[] hearts;
        [SerializeField] private Transform bricks;
        [SerializeField] private GameObject loseScreen;
        [SerializeField] private GameObject victoryScreen;
        [SerializeField] private GameObject startScreen;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Transform ballTransform;
        [SerializeField] private BreakoutBall ball;
    
        private static GameManagerBreakout _instance;
        

        public static GameManagerBreakout Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameManagerBreakout>();
                }

                return _instance;
            }
        }

        private void BeginGame()
        {
            Time.timeScale = 1;
            if (startScreen)
            {
                startScreen.SetActive(false);
            }

            if (loseScreen)
            {
                loseScreen.SetActive(false);
            }
            ball.Launch();
            _pausedOnLose = false;
        }

        public void LoseLife()
        {
            if (_health <= 1)
            {
                Die();
            }
            else
            {
                _health--;
                _pausedOnLose = true;
                UpdateHealth();
            }
        }

        private void UpdateHealth()
        {
            for (var i = 0; i < maxHealth; i++)
            {
                var imageComponent = health.GetChild(i).GameObject().GetComponent<Image>();
                var newSprite = i < _health ? hearts[1] : hearts[0];
                imageComponent.sprite = newSprite;
            }
        }

        private void Die()
        {
            Time.timeScale = 0;
            _pausedOnDie = true;
            loseScreen.SetActive(true);
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private bool AllBricksDestroyed()
        {
            return bricks.childCount <= 0;
        }
        
        private void Victory()
        {
            Time.timeScale = 0;
            victoryScreen.SetActive(true);
        }

        public void PowerUp()
        {
            
        }

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 0;
            _health = maxHealth;
            _pausedOnLose = true;
            UpdateHealth();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_pausedOnLose)
                {
                    BeginGame();
                }

                if (_pausedOnDie)
                {
                    Restart();
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Breakout");
            }

            if (AllBricksDestroyed())
            {
                Victory();
            }
        }
    }
}
