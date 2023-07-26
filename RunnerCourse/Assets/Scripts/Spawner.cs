using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _template;
    [SerializeField] private Transform[] _point;
    [SerializeField] private float _secondsBetweenSpawn;

    private float _elapsedTime;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject gameObject))
            {
                _elapsedTime = 0;
                int spawnPointNumber = Random.Range(0, _point.Length);
                SetObject(gameObject, _point[spawnPointNumber].position);
            }
        }
    }

    public void Initialize()
    {
        Initialize(_template);
    }

    private void SetObject(GameObject gameObject, Vector3 spawnPoint)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = spawnPoint;
    }
}
