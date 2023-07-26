using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameOverScreen : Screen
{
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Player _player;

    public event UnityAction RestartButtonClick;
    public event UnityAction ExitButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _exitButton.interactable = false;
        _restartButton.interactable = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        _exitButton.interactable = true;
        _restartButton.interactable = true;
    }

    protected override void OnAddListener()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnButtonClick);
        _player.Died += OnDied;
    }

    protected override void OnButtonClick()
    {
        ExitButtonClick?.Invoke();
    }

    protected override void OnRemoveListener()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnButtonClick);
        _player.Died -= OnDied;
    }

    protected override void OnRestartButtonClick()
    {
        RestartButtonClick?.Invoke();
    }

    private void OnDied()
    {
        CanvasGroup.alpha = 1;
        Time.timeScale = 0;
    }
}
