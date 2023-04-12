using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyBird
{
    public class GameManagerFlappyBird : MonoBehaviour
    {
        private int _score = 0;
        public bool isGameEnded = false;
        public bool isGamePaused = true;
        public GameObject gameOverScreen;
        public GameObject pauseGameScreen;
        public TMP_Text finalScoreTxt;
        public PipeSpawn pipeSpawner;
        [SerializeField] private TMP_Text scoreTxt;
        [SerializeField] private Bird bird;

        private static GameManagerFlappyBird _instance;
        public static GameManagerFlappyBird Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<GameManagerFlappyBird>();
                }

                return _instance;
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void BeginGame()
        {
            bird.speed = 5;
            bird.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            bird.transform.position = new Vector3(0, 0, 0);
            isGameEnded = false;
            gameOverScreen.SetActive(isGameEnded);
            pipeSpawner.Restart();
            Time.timeScale = isGameEnded ? 0 : 1;
            _score = 0;
            scoreTxt.SetText(_score.ToString());
        }

        private void TogglePauseGame()
        {
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
            isGamePaused = Time.timeScale == 0;
            pauseGameScreen.SetActive(isGamePaused);
        }

        public void Score()
        {
            _score++;
            scoreTxt.SetText(_score.ToString());
        }

        public void Die()
        {
            isGameEnded = true;
            Time.timeScale = isGameEnded ? 0 : 1;
            finalScoreTxt.SetText(_score.ToString());
            gameOverScreen.SetActive(true);
        }

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 0;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !isGameEnded)
            {
                TogglePauseGame();
            }

            if (Input.GetKeyDown(KeyCode.Backspace) && isGameEnded)
            {
                BeginGame();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
