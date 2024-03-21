using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GameController : NetworkBehaviour
{
    [SerializeField] private List<EnemySpawner> enemySpawners = new List<EnemySpawner>();
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private EnemySpawner _enemySpawner1;
    [SerializeField] private EnemySpawner _enemySpawner2;
    [SerializeField] private EnemySpawner _enemySpawner3;


    void Update()
    {
        if (IsServer && Input.GetKeyDown(KeyCode.Space))
        {
            StartEnemySpawn();
        }
    }
    void StartEnemySpawn()
    {
        foreach (var spawner in enemySpawners)
        {
            if (spawner != null)
            {
                spawner.StartSpawn();
            }
        }
    }

}