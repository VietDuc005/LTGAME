using UnityEngine;
using UnityEngine.UI; // Cần thư viện này để sửa Text
using TMPro;
public class AngleCalculator : MonoBehaviour
{
    public TextMeshProUGUI angleLabel; // Kéo cái Text UI vào đây

    void Update()
    {
        // 1. Lấy vị trí chuột trong không gian World
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Đảm bảo z bằng 0 vì game 2D

        // 2. Xoay nhân vật nhìn theo chuột (Giống bài trước)
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90); // -90 nếu sprite hướng lên

        // 3. TÍNH SIGNED ANGLE (Góc có dấu) - Yêu cầu bài tập
        // Tính góc giữa hướng trước mặt của Player (transform.up) và hướng đến chuột
        // Kết quả: Góc từ -180 đến 180 độ
        float signedAngle = Vector2.SignedAngle(Vector2.up, direction);

        // 4. Hiển thị lên màn hình
        if (angleLabel != null)
        {
            angleLabel.text = "Angle: " + Mathf.Round(signedAngle) + "°";
        }

        // Vẽ Gizmos để dễ hình dung (Màu xanh lá là hướng mặt, Màu đỏ là hướng chuột)
        Debug.DrawRay(transform.position, transform.up * 3, Color.green);
        Debug.DrawRay(transform.position, direction.normalized * 3, Color.red);
    }
}