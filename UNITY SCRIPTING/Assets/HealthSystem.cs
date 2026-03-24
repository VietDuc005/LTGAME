using UnityEngine;
using UnityEngine.Events;
using System; // Cần cái này để dùng Action

public class HealthSystem : MonoBehaviour
{
    public int maxHP = 5;
    public int currentHP;

    // LAB 5: C# Event - Cái "loa" thông báo số máu thay đổi
    public event Action<int> OnHealthChanged;

    // LAB 6: Unity Event - Để kéo thả sự kiện chết trong Inspector
    public UnityEvent OnDead;

    void Start()
    {
        currentHP = maxHP;
        // Báo cáo máu lúc bắt đầu game
        if (OnHealthChanged != null) OnHealthChanged(currentHP);
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;

        // LAB 5: Hét lên "Máu thay đổi rồi!" cho UI nghe thấy
        if (OnHealthChanged != null) OnHealthChanged(currentHP);

        if (currentHP <= 0)
        {
            OnDead.Invoke(); // Kích hoạt sự kiện chết
            Destroy(gameObject); // Biến mất
        }
    }
}