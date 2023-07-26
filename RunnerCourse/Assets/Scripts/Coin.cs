using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.AddScore();

        SetActive();
    }

    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
