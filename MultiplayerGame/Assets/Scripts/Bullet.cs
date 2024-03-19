using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyMovement enemy = collision.collider.gameObject.GetComponent<EnemyMovement>();
        if (enemy != null)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(effect, 1f);
            Destroy(gameObject);
        }
    }

}
