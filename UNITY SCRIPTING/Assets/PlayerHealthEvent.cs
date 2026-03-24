using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Bắt buộc để dùng UnityEvent

public class PlayerHealthEvent : MonoBehaviour
{
    // --- 1. KHAI BÁO EVENT ---
    // Định nghĩa một kiểu Event đặc biệt có thể gửi kèm số nguyên (int)
    [System.Serializable]
    public class MyIntEvent : UnityEvent<int> { }

    [Header("Cài đặt Event trong Inspector")]
    // Event 1: Gửi số máu ra ngoài (Dynamic)
    public MyIntEvent OnHealthChanged;

    // Event 2: Chỉ báo tin chết (không cần tham số)
    public UnityEvent OnDeath;

    // --- 2. LOGIC MÁU (Giống hệt bài trước) ---
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        // Báo cáo ngay khi vào game
        OnHealthChanged?.Invoke(currentHealth);
    }

    void Update()
    {
        // Nhấn H test thử
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        // --- 3. PHÁT TIN ---
        // Thay vì dùng Action, ta dùng Invoke của UnityEvent
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
            // Tắt Player đi để nhìn cho rõ là đã chết
            // gameObject.SetActive(false); 
        }
    }
}
