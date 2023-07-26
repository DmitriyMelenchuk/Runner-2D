using UnityEngine;

public class FireBallSpawner : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _secondsBetweenSpawn;

    private Enemy _enemy;
    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject gameObject))
            {
                _elapsedTime = 0;
                var spawnPoint = _enemy.transform.position;
                SetObject(gameObject, spawnPoint);
            }
        }
    }

    public void Initialize()
    {
        Initialize(_template);
        _enemy = GetComponent<Enemy>();
    }

    private void SetObject(GameObject gameObject, Vector3 spawnPoint)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = spawnPoint;
    } 
}
