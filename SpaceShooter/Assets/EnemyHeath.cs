using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet")) return;

        var ex = Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(ex, 1f);
        Destroy(gameObject);
    }
}
