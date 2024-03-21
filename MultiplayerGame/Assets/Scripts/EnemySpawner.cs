using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefabs;

    [SerializeField]
    private float _minimumSpawnTime;

    [SerializeField]
    private float _maximumSpawnTime;

    private float _timeUntilSpawn;
    private bool _isReadyToSpawn;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (!_isReadyToSpawn)
        {
            return;
        }

        _timeUntilSpawn -= Time.deltaTime;
        
        if(_timeUntilSpawn <= 0)
        {
            Instantiate(_enemyPrefabs, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }

    public void SetReadyToSpawn(bool ready)
    {
        _isReadyToSpawn = ready;
    }
}
