using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public bool AwareOfPlayer {  get; private set; }
    public Vector2 DirectionToPlayer {  get; private set; }
    [SerializeField]
    private float _playerAwarenessDistance;

    private Transform _player;
    private bool _playerFound;
    // Start is called before the first frame update

    // Update is called once per frame

    private void Update()
    {
  
        if (!_playerFound)
        {
            FindPlayer();
        }

        if (_player == null)
        {
            AwareOfPlayer = false; 
            return; 
        }

        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;


        AwareOfPlayer = enemyToPlayerVector.magnitude <= _playerAwarenessDistance;
    }
    private void FindPlayer()
    {
        if (_player != null)
            return;

        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null)
            _player = player.transform;
    }
}

