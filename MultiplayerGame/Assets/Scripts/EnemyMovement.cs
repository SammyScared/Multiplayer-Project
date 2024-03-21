using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class EnemyMovement : NetworkBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody2D _rb;
    private EnemyAwareness _playerAwareness;
    private Vector2 _targetDirection;

    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAwareness = GetComponent<EnemyAwareness>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();

    }
    
    private void UpdateTargetDirection()
    {
        if (_playerAwareness.AwareOfPlayer)
        {
            _targetDirection = _playerAwareness.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rb.SetRotation(rotation);
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rb.velocity = Vector2.zero;
        }
        else
        {
            _rb.velocity = transform.up * _speed;
        }

    }
}
