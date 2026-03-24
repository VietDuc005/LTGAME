using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lab6UI : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public GameObject gameOverPanel;

    // Hàm này phải là PUBLIC để UnityEvent nhìn thấy
    public void UpdateHealth(int hp)
    {
        hpText.text = "HP: " + hp;

        if (hp <= 30) hpText.color = Color.red;
        else hpText.color = Color.green;
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }
}
