using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float flySpeed = 12f;
    public int damage = 1;

    private void Update()
    {
        transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Đúng theo slide: tìm EnemyHealth
        var enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // đạn biến mất sau khi trúng
        }
    }
}

