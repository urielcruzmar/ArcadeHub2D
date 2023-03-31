using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerFlappyBird : MonoBehaviour
{
    private int _score = 0;
    public bool isGamePaused = true;
    public GameObject gameOverScreen;
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

    public void BeginGame()
    {
        bird.Speed = 5;
        bird.transform.position = new Vector3(0, 0, 0);
        isGamePaused = false;
        Time.timeScale = isGamePaused ? 0 : 1;
        _score = 0;
        scoreTxt.SetText(_score.ToString());
    }

    public void Score()
    {
        _score++;
        scoreTxt.SetText(_score.ToString());
    }

    public void Die()
    {
        isGamePaused = true;
        Time.timeScale = isGamePaused ? 0 : 1;
        gameOverScreen.SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = isGamePaused ? 0 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
