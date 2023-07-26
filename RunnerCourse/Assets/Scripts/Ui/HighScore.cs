using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentScore;
    [SerializeField] private TMP_Text _highScore;
    [SerializeField] private Player _player;

    private Score _score;
    private int _valueHighScore;

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    public void Initialize(Score score)
    {
        _score = score;
    }

    private void OnDied()
    {
        _currentScore.text += _score.Value;
        _highScore.text += PlayerPrefs.GetInt("HighScoreText");
        _valueHighScore = _score.Value;

        if (PlayerPrefs.GetInt("HighScoreText") <= _valueHighScore)
            PlayerPrefs.SetInt("HighScoreText", _valueHighScore);
    }
}
