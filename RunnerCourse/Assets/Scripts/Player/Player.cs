using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _armor;

    private Guard _guard;
    private Coroutine _currentCoroutine;
    private int _currentArmor;
    private float _durationShield = 3;

    public int Score { get; private set; }

    public event UnityAction<int> ChangedScore;
    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    public void Initialize()
    {
        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage - _currentArmor;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    public void Init(Guard guard)
    {
        _guard = guard;
    }

    public void AddScore()
    {
        Score++;
        ChangedScore?.Invoke(Score);
    }

    public void ActivateShield()
    {
        StartState(ActivateTemproryShield());
    }   
   
    private IEnumerator ActivateTemproryShield()
    {
        _currentArmor = _guard.Armor;
        yield return new WaitForSeconds(_durationShield);
        _currentArmor = _armor;
    }

    private void Die()
    {
        Score = 0;
        Died?.Invoke();
    } 

    private void StartState(IEnumerator coroutine)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(coroutine);
    }  
}
