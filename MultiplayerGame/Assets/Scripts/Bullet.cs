using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : NetworkBehaviour
{
    public GameObject hitEffect;
    public Shooting parent;
    void Start()
    {
        Destroy(gameObject, 1.5f);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyMovement enemy = collision.collider.gameObject.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            if (!IsOwner) return;
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(effect, 1f);
            Destroy(gameObject);    

        }
    }

}
