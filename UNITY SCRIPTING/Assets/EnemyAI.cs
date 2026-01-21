using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 2f;
    Transform player;
    UIManagers uiManagers; // MỚI: Biến để giữ liên lạc với UIManager

    void Start()
    {
        GameObject p = GameObject.Find("Player");
        if (p != null) player = p.transform;

        // MỚI: Tự động tìm UIManager trong màn chơi
        // Vì Enemy sinh ra liên tục nên không kéo thả bằng tay được, phải dùng code tìm
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas != null)
        {
            uiManagers = canvas.GetComponent<UIManagers>();
        }
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 1. Xử lý khi trúng đạn
        if (other.CompareTag("Bullet"))
        {
            // Lấy máu hiện tại
            HealthSystem myHealth = GetComponent<HealthSystem>();

            if (myHealth != null)
            {
                myHealth.TakeDamage(1); // Trừ máu
                Destroy(other.gameObject); // Hủy viên đạn

                // MỚI: Kiểm tra nếu hết máu thì cộng điểm
                if (myHealth.currentHP <= 0)
                {
                    if (uiManagers != null)
                    {
                        uiManagers.AddScore(1); // Cộng 1 điểm
                    }
                }
            }
        }

        // 2. Xử lý khi đâm vào Player (Không cộng điểm)
        if (other.CompareTag("Player")) // Lưu ý: Bạn nhớ gán Tag "Player" cho nhân vật nhé
        {
            HealthSystem playerHealth = other.GetComponent<HealthSystem>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
            Destroy(gameObject); // Enemy tự sát
        }
    }
}