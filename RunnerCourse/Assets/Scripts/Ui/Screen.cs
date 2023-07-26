using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Screen : MonoBehaviour
{
    protected CanvasGroup CanvasGroup;
    protected Player Player;

    private void OnEnable()
    {
        OnAddListener();
    }

    private void OnDisable()
    {
        OnRemoveListener();
    }

    protected abstract void OnAddListener();
    protected abstract void OnRemoveListener();
    protected abstract void OnButtonClick();
    protected abstract void OnRestartButtonClick();

    public abstract void Open();
    public abstract void Close();

    public void Initialize()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
    }
}
