using Player;
using UI;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    private void Awake()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _endGameScreen.Close();
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _bird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _bird.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }
    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.Reset();
    }
}
