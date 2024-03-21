using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EnemySpawner _enemySpawner1;
    [SerializeField] private EnemySpawner _enemySpawner2;
    [SerializeField] private EnemySpawner _enemySpawner3;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _enemySpawner.SetReadyToSpawn(true);
            _enemySpawner1.SetReadyToSpawn(true);
            _enemySpawner2.SetReadyToSpawn(true);
            _enemySpawner3.SetReadyToSpawn(true);
        }
    }
}
