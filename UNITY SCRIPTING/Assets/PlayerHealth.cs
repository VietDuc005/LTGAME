using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // Bắt buộc phải có dòng này để dùng Action

public class PlayerHealth : MonoBehaviour
{
    // --- 1. KHAI BÁO SỰ KIỆN (Event) ---
    // Action<int>: Sự kiện gửi kèm số nguyên (máu hiện tại)
    public event Action<int> OnHealthChanged;

    // Action: Sự kiện chỉ báo tin (không gửi số liệu), dùng cho lúc chết
    public event Action OnPlayerDeath;

    // --- 2. CÁC BIẾN CƠ BẢN ---
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        // Báo cáo máu đầy ngay khi game bắt đầu
        // Dấu "?" nghĩa là: Nếu có ai đang nghe thì mới báo (tránh lỗi)
        OnHealthChanged?.Invoke(currentHealth);
    }

    void Update()
    {
        // Nhấn phím H để tự trừ máu mình (để test)
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Không cho máu xuống dưới 0
        if (currentHealth < 0) currentHealth = 0;

        // --- 3. PHÁT TIN (Invoke) ---
        // Hét lên: "Tôi bị đổi máu rồi, máu mới là..."
        OnHealthChanged?.Invoke(currentHealth);

        // Kiểm tra nếu hết máu thì báo chết
        if (currentHealth <= 0)
        {
            OnPlayerDeath?.Invoke();
            Debug.Log("Player đã ngỏm!");
        }
    }
}