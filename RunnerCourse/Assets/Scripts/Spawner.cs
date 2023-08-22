using System.Collections;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _template;
    [SerializeField] private Transform[] _point;
    [SerializeField] private float _secondsBetweenSpawn;

    public void Initialize()
    {
        Initialize(_template); 
        StartCoroutine(DelaySpawn());
    }

    private IEnumerator DelaySpawn()
    {
        var waitForSeconds = new WaitForSeconds(_secondsBetweenSpawn);

        while (true)
        {
            if (TryGetObject(out GameObject gameObject))
            {
                int spawnPointNumber = Random.Range(0, _point.Length);
                yield return waitForSeconds;
                SetObject(gameObject, _point[spawnPointNumber].position);
            }

            yield return null;
        }      
    }

    private void SetObject(GameObject gameObject, Vector3 spawnPoint)
    {
        gameObject.SetActive(true);
        gameObject.transform.position = spawnPoint;
    }
}
