using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Breakout
{
    public class GameManagerBreakout : MonoBehaviour
    {
        private int _health = 3;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private GameObject loseScreen;
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
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            _health = 3;
        }

        public void LoseLife()
        {
            if (_health <= 0)
            {
                Die();
            }
            else
            {
                _health--;
            }
        }

        private void Die()
        {
            Time.timeScale = 0;
            loseScreen.SetActive(true);
        }

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                BeginGame();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name == "Breakout" ? "MainMenu" : "Breakout");
            }
        }
    }
}
