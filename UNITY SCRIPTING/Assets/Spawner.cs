using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    void Start()
    {
        // Cứ 2 giây gọi hàm Spawn 1 lần
        InvokeRepeating("SpawnEnemy", 1f, 2f);
    }

    void SpawnEnemy()
    {
        // Random vị trí
        float x = Random.Range(-8f, 8f);
        float y = Random.Range(-4f, 4f);
        Vector2 pos = new Vector2(x, y);

        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}