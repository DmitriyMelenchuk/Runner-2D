using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamePauseScreen : Screen
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _pauseButton;

    public event UnityAction RestartButtonClick;
    public event UnityAction PlayButtonClick;
    public event UnityAction PauseButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _playButton.interactable = false;
        _restartButton.interactable = false;
        Time.timeScale = 1;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Time.timeScale = 0;
        _playButton.interactable = true;
        _restartButton.interactable = true;
    }
   
    protected override void OnAddListener()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _pauseButton.onClick.AddListener(OnButtonClick);
    }

    protected override void OnRemoveListener()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _pauseButton.onClick.RemoveListener(OnButtonClick);
    }

    protected override void OnButtonClick()
    {           
        PauseButtonClick?.Invoke();
    }

    protected override void OnRestartButtonClick()
    {
        RestartButtonClick?.Invoke();
    }

    private void OnPlayButtonClick()
    {
        PlayButtonClick?.Invoke();
    }
}
