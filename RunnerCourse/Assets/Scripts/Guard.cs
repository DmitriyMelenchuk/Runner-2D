using UnityEngine;

public class Guard : MonoBehaviour
{
    [SerializeField] private int _armor;
    [SerializeField] private ParticleSystem _particleShield;

    public int Armor => _armor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Instantiate(_particleShield, player.transform);
            player.Init(this);
            player.ActivateShield();
        }

        SetActive();
    }

    public void SetActive()
    {
        gameObject.SetActive(false);
    }
}
