using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int _amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyHealth(_amount);
            SetActive();           
        }           
    }

    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
