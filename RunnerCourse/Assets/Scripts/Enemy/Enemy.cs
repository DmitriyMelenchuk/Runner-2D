using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delayAttack;

    private FireBallSpawner _fireBallSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.ApplyDamage(_damage);

        Die();
    }
    
    public void Die()
    {       
        gameObject.SetActive(false);
    }
}
