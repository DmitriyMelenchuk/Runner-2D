using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Heart _heart;
    [SerializeField] private Player _player;

    private List<Heart> _hearts = new List<Heart>();
    
    public void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_hearts.Count < value)
        {
            int createHealth = value - _hearts.Count;
            for (int i = 0; i < createHealth; i++)
                CreateHearts();
        }
        else if(_hearts.Count > value && _hearts.Count != 0)
        {
            int deletedHealth = _hearts.Count - value;
            for (int i = 0; i < deletedHealth; i++)
                DestroyHeart(_hearts[_hearts.Count - 1]);
        }
    }

    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }

    private void CreateHearts()
    {
        Heart newHeart = Instantiate(_heart, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }
}
