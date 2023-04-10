using System.Collections;
using System.Collections.Generic;
using FlappyBird;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManagerBreakout : MonoBehaviour
{
    private int _score = 0;
    public bool isGameEnded = false;
    public bool isGamePaused = true;
    public GameObject gameOverScreen;
    public GameObject pauseGameScreen;
    public TMP_Text finalScoreTxt;

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

    public void BeginGame()
    {
        isGameEnded = false;
        gameOverScreen.SetActive(isGameEnded);
        Time.timeScale = isGameEnded ? 0 : 1;
        _score = 0;
    }

    public void TogglePauseGame()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        isGamePaused = Time.timeScale == 0;
        pauseGameScreen.SetActive(isGamePaused);
    }

    public void Score()
    {
        _score++;
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
