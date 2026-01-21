using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Thư viện để dùng chữ TextMeshPro

public class UIManager : MonoBehaviour
{
    [Header("Kéo thả các thứ vào đây")]
    public PlayerHealth playerHealth;  // Cần biết ai là Player để đăng ký
    public TextMeshProUGUI hpText;     // Ô chữ hiển thị số máu
    public GameObject gameOverPanel;   // Chữ GAME OVER to đùng

    // --- QUY TRÌNH ĐĂNG KÝ (Quan trọng nhất) ---

    // 1. Khi bật Object -> Đăng ký nghe (Subscribe)
    void OnEnable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += UpdateHealthUI; // Đăng ký cập nhật máu
            playerHealth.OnPlayerDeath += ShowGameOver;     // Đăng ký sự kiện chết
        }
    }

    // 2. Khi tắt Object -> Hủy đăng ký (Unsubscribe)
    // Nếu quên hàm này, game sẽ bị lỗi khi chuyển màn chơi
    void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthUI;
            playerHealth.OnPlayerDeath -= ShowGameOver;
        }
    }

    // --- CÁC HÀM XỬ LÝ ---

    // Hàm này tự chạy khi Player báo đổi máu
    void UpdateHealthUI(int currentHP)
    {
        hpText.text = "HP: " + currentHP;

        // Đổi màu chữ: Máu thấp (<30) thì đỏ, cao thì xanh
        if (currentHP <= 30) hpText.color = Color.red;
        else hpText.color = Color.green;
    }

    // Hàm này tự chạy khi Player báo chết
    void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Hiện bảng Game Over lên
        }
    }
}
