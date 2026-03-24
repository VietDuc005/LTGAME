using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public PlayerHealth playerHealth;

    void OnEnable()
    {
        if (playerHealth != null)
            playerHealth.OnHealthChanged += PlayHurtSound;
    }

    void OnDisable()
    {
        if (playerHealth != null)
            playerHealth.OnHealthChanged -= PlayHurtSound;
    }

    void PlayHurtSound(int hp)
    {
        // Chỉ kêu khi mất máu (hp < 100) và chưa chết (hp > 0)
        if (hp < 100 && hp > 0)
        {
            // Ở đây mình dùng Debug thay cho âm thanh thật để bạn dễ test
            Debug.Log("🔊 Âm thanh: Á đù! Đau quá!");
        }
    }
}
