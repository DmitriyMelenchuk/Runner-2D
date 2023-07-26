using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _textScore;
    [SerializeField] private Player _player;

    public int Value { get; private set; }

    private void OnEnable()
    {      
        _player.ChangedScore += OnScoreChanged;
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.ChangedScore -= OnScoreChanged;
        _player.Died -= OnDied;
    }

    public void Initialize(Player player)
    {    
        _player = player;
    }

    private void OnScoreChanged(int value)
    {
        _textScore.text = value.ToString();
        Value = value;
    }

    private void OnDied()
    {
        gameObject.SetActive(false);
    }
}
