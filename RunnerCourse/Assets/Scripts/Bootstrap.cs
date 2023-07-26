using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Score _score;
    [SerializeField] private HighScore _highScore;
    [SerializeField] private Spawner _enemySpawner;
    [SerializeField] private Spawner _coinSpawner;
    [SerializeField] private Spawner _guardSpawner;
    [SerializeField] private GamePauseScreen _pauseScreen;
    [SerializeField] private GameOverScreen _gameOver;
    [SerializeField] private AudioSource _soundGame;
    [SerializeField] private AudioSource _soundGameOver;

    private Enemy[] _enemys;

    private void Awake()
    {
        _soundGame.Play();
        _player.Initialize();
        _playerMover.Initialize();
        _score.Initialize(_player);
        _highScore.Initialize(_score);
        _coinSpawner.Initialize();
        _enemySpawner.Initialize();      
        _guardSpawner.Initialize();
        _gameOver.Initialize();
        _pauseScreen.Initialize();

        InitializeFireBallSpawner();
    }

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
        _pauseScreen.PlayButtonClick += OnPlayButtonClick;
        _pauseScreen.PauseButtonClick += OnPauseButtonClick;
        _pauseScreen.RestartButtonClick += OnRestartButtonClick;
        _gameOver.RestartButtonClick += OnRestartButtonClick;
        _gameOver.ExitButtonClick += OnExitButtonClick;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
        _pauseScreen.PlayButtonClick -= OnPlayButtonClick;
        _pauseScreen.PauseButtonClick -= OnPauseButtonClick;
        _pauseScreen.RestartButtonClick -= OnRestartButtonClick;
        _gameOver.RestartButtonClick -= OnRestartButtonClick;
        _gameOver.ExitButtonClick -= OnExitButtonClick;
    }

    private void InitializeFireBallSpawner()
    {
        _enemys = _enemySpawner.GetComponentsInChildren<Enemy>(true);
        foreach (var item in _enemys)
        {
            item.GetComponent<FireBallSpawner>().Initialize();
        }
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnPlayButtonClick()
    {
        _pauseScreen.Close();
    }

    private void OnPauseButtonClick()
    {
        _pauseScreen.Open();
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }

    private void OnPlayerDied()
    {
        _soundGame.Stop();
        _soundGameOver.Play();
    }
}
