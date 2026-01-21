using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagers : MonoBehaviour
{
    [Header("UI Components")]
    public Text hpText;
    public Text scoreText;        // MỚI: Text hiển thị điểm khi chơi
    public Text finalScoreText;   // MỚI: Text hiển thị điểm khi thua
    public GameObject gameOverPanel;

    [Header("Connect")]
    public HealthSystem playerHealth;

    private int _score = 0;       // MỚI: Biến lưu điểm số

    void OnEnable()
    {
        if (playerHealth != null)
            playerHealth.OnHealthChanged += UpdateHPUI;
    }

    void OnDisable()
    {
        if (playerHealth != null)
            playerHealth.OnHealthChanged -= UpdateHPUI;
    }

    void Start()
    {
        // Reset điểm về 0 khi bắt đầu
        UpdateScoreUI();
    }

    void UpdateHPUI(int currentHP)
    {
        hpText.text = "HP: " + currentHP;
    }

    // MỚI: Hàm để cộng điểm
    public void AddScore(int amount)
    {
        _score += amount;
        UpdateScoreUI();
    }

    // MỚI: Cập nhật text điểm
    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + _score;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);

        // MỚI: Hiển thị điểm cuối cùng vào bảng Game Over
        if (finalScoreText != null)
            finalScoreText.text = "Final Score: " + _score;

        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}