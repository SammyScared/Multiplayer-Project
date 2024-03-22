using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : NetworkBehaviour
{
    public GameObject hitEffect;
    public Shooting parent;
    private NetworkUI networkUI;

    void Start()
    {
        Destroy(gameObject, 1.5f);
        networkUI = FindObjectOfType<NetworkUI>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyMovement enemy = collision.collider.gameObject.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(effect, 1f);
            Destroy(gameObject);
            if (IsServer)
            {

                    networkUI.EnemyDestroyedServerRpc();

            }
        }
    }
}